Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class FrmImportarDatos
    Private x, y As Integer
    Private MiDatosContPaqDT As Data.DataTable
    Private WithEvents MiDatosContPaqBS As BindingSource
    Dim MyIndex As Integer

    Private Sub FrmImportarDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtNombreArchivo.Text = "ninguno"
        LblSeleccion.Text = "0"
        LblCargos.Text = "0.00"
        LblAbonos.Text = "0.00"
        TxtTotalRegistros.Text = "0"
        TxtAbonos.Text = "0.00"
        TxtCargos.Text = "0.00"
        BtnAnalizar.Enabled = False
        BtnPrimero.Enabled = False
        BtnAnterior.Enabled = False
        BtnSiguiente.Enabled = False
        BtnUltimo.Enabled = False
        BtnActualizar.Enabled = False

        ' Configurar BackgroundWorker
        If BackgroundWorker1 Is Nothing Then
            BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
            BackgroundWorker1.WorkerReportsProgress = True
        End If
    End Sub

    Private Sub BtnAbrirArchivo_Click(sender As Object, e As EventArgs) Handles BtnAbrirArchivo.Click
        OpenFileDialog1.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Todos los archivos (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.Title = "Seleccionar archivo de Excel generado en CONTPAQi"

        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            TxtNombreArchivo.Text = OpenFileDialog1.FileName
            MiDataGrid.Columns.Clear()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub MiNuevosMovimientos()
        If MiDatosContPaqDT Is Nothing OrElse MiDatosContPaqDT.Columns.Count = 0 Then
            MessageBox.Show("Error: No hay datos válidos para mostrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MiDatosContPaqBS = New BindingSource With {.DataSource = MiDatosContPaqDT}
        MiDataGrid.DataSource = MiDatosContPaqBS

        ' Solo configurar columnas si existen
        If MiDataGrid.Columns.Count >= 13 Then
            MiDataGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'Cuenta
            MiDataGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter 'TipoTrabajador
            MiDataGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Numero de póliza
            MiDataGrid.Columns(8).DefaultCellStyle.Format = "N2" 'Cargos
            MiDataGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Cargos
            MiDataGrid.Columns(9).DefaultCellStyle.Format = "N2" 'Abonos
            MiDataGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight 'Abonos
            MiDataGrid.Columns(0).Width = 50   'Cuenta
            MiDataGrid.Columns(1).Width = 80   'Tipo de Trabajador
            MiDataGrid.Columns(2).Width = 250  'Nombre
            MiDataGrid.Columns(3).Width = 80   'Fecha
            MiDataGrid.Columns(4).Width = 100  'Tipo de póliza
            MiDataGrid.Columns(5).Width = 60   'Número
            MiDataGrid.Columns(6).Width = 250  'Concepto
            MiDataGrid.Columns(7).Width = 100  'Referencia
            MiDataGrid.Columns(8).Width = 100  'Cargos
            MiDataGrid.Columns(9).Width = 100  'Abonos
            MiDataGrid.Columns(1).HeaderText = "Tipo de trabajador"
            MiDataGrid.Columns(4).HeaderText = "Tipo de póliza"
            MiDataGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill  'Nombre
            MiDataGrid.Columns(10).Visible = False  'idEmpleado
            MiDataGrid.Columns(11).Visible = False 'idTipoPoliza
            MiDataGrid.Columns(12).Visible = False 'ClaveRubro
        End If

        AddHandler MiDatosContPaqBS.PositionChanged, AddressOf MiDatosContPaqBS_PositionChanged
        TxtTotalRegistros.Text = MiDatosContPaqBS.Count.ToString()
        BtnActualizar.Enabled = MiDatosContPaqBS.Count > 0
        MiDatosContPaqBS_PositionChanged(Nothing, Nothing)
        SumarCargosYAbonos()
        MiBuscarIndices()
        MiDatosContPaqBS.Sort = "Fecha ASC, Numero ASC, TipoPoliza ASC, Nombre ASC"
    End Sub

    Private Sub MiDatosContPaqBS_PositionChanged(sender As Object, e As EventArgs) Handles MiDatosContPaqBS.PositionChanged
        TxtRegistro.Text = (MiDatosContPaqBS.Position + 1).ToString
        TxtTotalRegistros.Text = MiDatosContPaqBS.Count.ToString
        BtnPrimero.Enabled = MiDatosContPaqBS.Position > 0
        BtnAnterior.Enabled = MiDatosContPaqBS.Position > 0
        BtnSiguiente.Enabled = MiDatosContPaqBS.Position < MiDatosContPaqBS.Count - 1
        BtnUltimo.Enabled = MiDatosContPaqBS.Position < MiDatosContPaqBS.Count - 1
    End Sub

    Private Sub MiBuscarIndices()
        Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=localhost; User Id=buzosbyp_erp; password=Mientras12$; database=buzosbyp_erp")
        Dim noCuentaCompaq As Integer = 0
        Dim idEmpleado As Integer = 0
        Dim TipoPoliza As String = ""
        Dim idTipoPoliza As Integer = 0
        Dim empleadosDA, tipoPolizaDA, rubrosDA As MySqlDataAdapter
        Dim empleadosDT, tipoPolizaDT, rubrosDT As New System.Data.DataTable
        Dim empleadosBS, tipoPolizaBS, rubrosBS As BindingSource
        Dim rowSocios, rowTipoPoliza, rowRubros As DataRowView

        Try
            sqlConexion.Open()

            empleadosDA = New MySqlDataAdapter("SELECT idEmpleado, TipoEmpleado, noCuenta, CONCAT(ApPaterno, ' ', ApMaterno, ' ', Nombre) AS Nombre FROM empleados", sqlConexion)
            empleadosDA.Fill(empleadosDT)
            empleadosBS = New BindingSource With {.DataSource = empleadosDT}
            If empleadosBS.Count > 0 Then
                MiDatosContPaqBS.Sort = "Nombre ASC"
                For Each rowCompaq As DataRowView In MiDatosContPaqBS
                    If noCuentaCompaq <> rowCompaq.Row.Item("Cuenta") Then
                        noCuentaCompaq = rowCompaq.Row.Item("Cuenta")
                        MyIndex = empleadosBS.Find("noCuenta", noCuentaCompaq)
                        If MyIndex >= 0 Then
                            empleadosBS.Position = MyIndex
                            rowSocios = empleadosBS.Current
                            idEmpleado = rowSocios("idEmpleado")
                        Else
                            idEmpleado = 0
                        End If
                    End If
                    rowCompaq.Row.Item("idEmpleado") = idEmpleado
                Next
            Else
                MsgBox("Error, no se pudo cargar la tabla de empleados, del programa de socios...")
            End If

            tipoPolizaDA = New MySqlDataAdapter("SELECT * FROM ctg_tipopoliza", sqlConexion)
            tipoPolizaDA.Fill(tipoPolizaDT)
            tipoPolizaBS = New BindingSource With {.DataSource = tipoPolizaDT}
            If tipoPolizaBS.Count > 0 Then
                MiDatosContPaqBS.Sort = "TipoPoliza ASC"
                For Each rowCompaq As DataRowView In MiDatosContPaqBS
                    If TipoPoliza <> rowCompaq.Row.Item("TipoPoliza") Then
                        TipoPoliza = rowCompaq.Row.Item("TipoPoliza")
                        MyIndex = tipoPolizaBS.Find("TipoPoliza", TipoPoliza)
                        If MyIndex >= 0 Then
                            tipoPolizaBS.Position = MyIndex
                            rowTipoPoliza = tipoPolizaBS.Current
                            idTipoPoliza = rowTipoPoliza("idTipoPoliza")
                        Else
                            idTipoPoliza = 0
                        End If
                    End If
                    rowCompaq.Row.Item("idTipoPoliza") = idTipoPoliza
                Next
            Else
                MsgBox("Error, no se pudo cargar la tabla del catálogo de pólizas, del programa de socios...")
            End If

            rubrosDA = New MySqlDataAdapter("SELECT * FROM ctg_rubros", sqlConexion)
            rubrosDA.Fill(rubrosDT)
            rubrosBS = New BindingSource With {.DataSource = rubrosDT}
            If rubrosBS.Count > 0 Then
                MiDatosContPaqBS.Sort = "Referencia ASC"
                For Each rowCompaq As DataRowView In MiDatosContPaqBS
                    MyIndex = rubrosBS.Find("Clave", rowCompaq.Row.Item("Referencia"))
                    If MyIndex >= 0 Then
                        rubrosBS.Position = MyIndex
                        rowRubros = rubrosBS.Current
                        rowCompaq.Row.Item("ClaveRubro") = rowRubros("Clave")
                    Else
                        MyIndex = rubrosBS.Find("Rubro", rowCompaq.Row.Item("Referencia"))
                        If MyIndex >= 0 Then
                            rubrosBS.Position = MyIndex
                            rowRubros = rubrosBS.Current
                            rowCompaq.Row.Item("ClaveRubro") = rowRubros("Clave")
                        Else
                            rowCompaq.Row.Item("ClaveRubro") = ""
                        End If
                    End If
                Next
            Else
                MsgBox("Error, no se pudo cargar la tabla del catálogo de rubros, del programa de socios...")
            End If

        Catch ex As MySqlException
            MsgBox("Error al intentar buscar los índices de los empleados: " & ex.Message)
        Finally
            sqlConexion.Close()
        End Try
    End Sub

    Private Sub SumarCargosYAbonos()
        Dim totalCargos As Double = 0
        Dim totalAbonos As Double = 0

        For Each row As DataGridViewRow In MiDataGrid.Rows
            If Not row.IsNewRow Then
                If row.Cells(8).Value IsNot Nothing Then
                    totalCargos += CDbl(row.Cells(8).Value)
                End If
                If row.Cells(9).Value IsNot Nothing Then
                    totalAbonos += CDbl(row.Cells(9).Value)
                End If
            End If
        Next

        TxtCargos.Text = totalCargos.ToString("N2")
        TxtAbonos.Text = totalAbonos.ToString("N2")
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim excelApp As Application = Nothing
        Dim excelWorkBook As Workbook = Nothing
        Dim excelWorkSheet As Worksheet = Nothing
        'Dim diagnostico As New System.Text.StringBuilder()

        Try
            'diagnostico.AppendLine("=== INICIO DEL PROCESO (CON ARRAY OPTIMIZADO) ===")
            ' Obtener la ruta del archivo de forma segura
            Dim miruta As String = ""
            Me.Invoke(Sub() miruta = OpenFileDialog1.FileName)
            'diagnostico.AppendLine($"Archivo seleccionado: {miruta}")

            ' Verificar que el archivo existe
            If String.IsNullOrEmpty(miruta) OrElse Not System.IO.File.Exists(miruta) Then
                'diagnostico.AppendLine("ERROR: El archivo no existe o la ruta está vacía")
                Throw New System.IO.FileNotFoundException("El archivo no existe: " & miruta)
            End If

            'diagnostico.AppendLine("Archivo existe - OK")

            ' Inicializar Excel - SOLO configuraciones básicas
            'diagnostico.AppendLine("Inicializando aplicación Excel...")
            excelApp = New Application
            excelApp.ScreenUpdating = False
            excelApp.DisplayAlerts = False
            excelApp.EnableEvents = False
            'diagnostico.AppendLine("Aplicación Excel inicializada - OK")

            ' Abrir el libro PRIMERO
            'diagnostico.AppendLine("Abriendo libro de Excel...")
            excelWorkBook = excelApp.Workbooks.Open(miruta)
            'diagnostico.AppendLine("Libro abierto - OK")

            ' AHORA sí configurar Calculation después de abrir el libro
            'diagnostico.AppendLine("Configurando cálculo manual...")
            Try
                excelApp.Calculation = XlCalculation.xlCalculationManual
                'diagnostico.AppendLine("Cálculo manual configurado - OK")
            Catch calcEx As Exception
                'diagnostico.AppendLine($"Advertencia: No se pudo configurar cálculo manual: {calcEx.Message}")
            End Try

            ' Obtener la hoja de trabajo
            'diagnostico.AppendLine("Obteniendo primera hoja de trabajo...")
            excelWorkSheet = excelWorkBook.Worksheets(1)
            'diagnostico.AppendLine($"Hoja obtenida: {excelWorkSheet.Name}")

            ' Obtener el rango usado y cargarlo en array - AQUÍ ESTÁ LA OPTIMIZACIÓN
            'diagnostico.AppendLine("Cargando datos en array...")
            Dim usedRange = excelWorkSheet.UsedRange
            If usedRange Is Nothing Then
                'diagnostico.AppendLine("ERROR: UsedRange es Nothing")
                Throw New Exception("No hay datos en la hoja de Excel")
            End If

            Dim totalRows As Integer = usedRange.Rows.Count
            Dim totalCols As Integer = usedRange.Columns.Count
            'diagnostico.AppendLine($"Rango usado - Filas: {totalRows}, Columnas: {totalCols}")

            If totalRows = 0 Then
                'diagnostico.AppendLine("ERROR: No hay filas con datos")
                Throw New Exception("No hay datos en la hoja de Excel")
            End If

            ' CARGAR TODO EL RANGO EN UN ARRAY DE UNA SOLA VEZ
            Dim dataArray As Object(,) = usedRange.Value
            'diagnostico.AppendLine($"Array cargado con éxito: {dataArray.GetUpperBound(0)} x {dataArray.GetUpperBound(1)}")

            ' Liberar el rango usado inmediatamente
            Marshal.ReleaseComObject(usedRange)

            ' Crear el DataTable
            'diagnostico.AppendLine("Creando DataTable...")
            MiDatosContPaqDT = New Data.DataTable
            MiDatosContPaqDT.Columns.Add("Cuenta")
            MiDatosContPaqDT.Columns.Add("TipoTrabajador")
            MiDatosContPaqDT.Columns.Add("Nombre")
            MiDatosContPaqDT.Columns.Add("Fecha", GetType(Date))
            MiDatosContPaqDT.Columns.Add("TipoPoliza")
            MiDatosContPaqDT.Columns.Add("Numero", GetType(Integer))
            MiDatosContPaqDT.Columns.Add("Concepto")
            MiDatosContPaqDT.Columns.Add("Referencia")
            MiDatosContPaqDT.Columns.Add("Cargos", GetType(Double))
            MiDatosContPaqDT.Columns.Add("Abonos", GetType(Double))
            MiDatosContPaqDT.Columns.Add("idEmpleado", GetType(Integer))
            MiDatosContPaqDT.Columns.Add("idTipoPoliza", GetType(Integer))
            MiDatosContPaqDT.Columns.Add("ClaveRubro")
            'diagnostico.AppendLine("DataTable creado - OK")

            ' Variables para el procesamiento
            Dim miCuenta, miNombre, miTipoTrabajador As String
            Dim miBanderaCuenta As Boolean = False
            'Dim MyCargo, MyAbono As Double
            Dim miCelda As String
            Dim registrosProcesados As Integer = 0

            x = 0
            y = totalRows
            miCuenta = ""
            miNombre = ""
            miTipoTrabajador = ""

            'diagnostico.AppendLine($"Iniciando procesamiento del array de {totalRows} filas...")

            ' PROCESAR EL ARRAY EN MEMORIA - MUCHO MÁS RÁPIDO
            For i = 1 To totalRows
                'Try
                If i Mod 1000 = 0 Then
                    BackgroundWorker1.ReportProgress(CInt((i * 100) / totalRows))
                End If

                ' Leer la primera celda del array
                'miCelda = ""
                'If i <= dataArray.GetUpperBound(0) AndAlso 1 <= dataArray.GetUpperBound(1) Then
                'If dataArray(i, 1) IsNot Nothing Then
                'miCelda = dataArray(i, 1).ToString().Trim()
                'End If
                'End If
                miCelda = If(dataArray(i, 1) IsNot Nothing, dataArray(i, 1).ToString().Trim(), "")

                If String.IsNullOrEmpty(miCelda) Then
                    miBanderaCuenta = False
                    Continue For
                End If

                ' Identificar línea de cuenta
                If miCelda.Length = 17 Then
                    'Try
                    miCuenta = miCelda.Substring(10, 3)
                    miTipoTrabajador = If(miCelda.Substring(4, 1).Trim() = "1", "SOCIO", "EXTRA")
                    'miNombre = ""
                    'If i <= dataArray.GetUpperBound(0) AndAlso 2 <= dataArray.GetUpperBound(1) Then
                    'If dataArray(i, 2) IsNot Nothing Then
                    'miNombre = dataArray(i, 2).ToString().Trim()
                    'End If
                    'End If
                    miNombre = If(dataArray(i, 2) IsNot Nothing, dataArray(i, 2).ToString().Trim(), "")
                    miBanderaCuenta = True
                    'If i <= 5 Then ' Solo log para las primeras filas
                    'diagnostico.AppendLine($"Cuenta encontrada en fila {i}: {miCuenta} - {miNombre}")
                    'End If
                    'Catch
                    'miBanderaCuenta = False
                    'End Try
                ElseIf miBanderaCuenta AndAlso IsDate(miCelda) Then
                    ' Procesar línea de datos
                    'MyCargo = 0
                    'MyAbono = 0
                    'MyCargo = If(dataArray(i, 6) IsNot Nothing AndAlso IsNumeric(dataArray(i, 6)), CDbl(dataArray(i, 6)), 0)
                    'MyAbono = If(dataArray(i, 7) IsNot Nothing AndAlso IsNumeric(dataArray(i, 7)), CDbl(dataArray(i, 7)), 0)
                    ' Crear fila
                    Dim nuevaFila As DataRow = MiDatosContPaqDT.NewRow()
                    nuevaFila("Cuenta") = miCuenta
                    nuevaFila("Nombre") = miNombre
                    nuevaFila("TipoTrabajador") = miTipoTrabajador
                    ' Fecha - CONTPAQi siempre genera fechas válidas
                    nuevaFila("Fecha") = If(dataArray(i, 1) IsNot Nothing, CDate(dataArray(i, 1)), DateTime.Now)
                    ' Campos de texto - solo verificar Nothing
                    nuevaFila("TipoPoliza") = If(dataArray(i, 2)?.ToString(), "")
                    nuevaFila("Concepto") = If(dataArray(i, 4)?.ToString(), "")
                    nuevaFila("Referencia") = If(dataArray(i, 5)?.ToString(), "")
                    ' Numero - validar si es numérico
                    nuevaFila("Numero") = If(dataArray(i, 3) IsNot Nothing AndAlso IsNumeric(dataArray(i, 3)), CInt(dataArray(i, 3)), 0)
                    nuevaFila("Cargos") = If(dataArray(i, 6) IsNot Nothing AndAlso IsNumeric(dataArray(i, 6)), CDbl(dataArray(i, 6)), 0)
                    nuevaFila("Abonos") = If(dataArray(i, 7) IsNot Nothing AndAlso IsNumeric(dataArray(i, 7)), CDbl(dataArray(i, 7)), 0)
                    nuevaFila("idEmpleado") = 0
                    nuevaFila("idTipoPoliza") = 0
                    nuevaFila("ClaveRubro") = ""

                    MiDatosContPaqDT.Rows.Add(nuevaFila)
                    registrosProcesados += 1
                End If

                'Catch rowEx As Exception
                'diagnostico.AppendLine($"Error en fila {i}: {rowEx.Message}")
                'Continue For
                'End Try

                x += 1
            Next

            'diagnostico.AppendLine($"Procesamiento completado. Registros agregados: {registrosProcesados}")

            ' Verificar resultados
            'If MiDatosContPaqDT.Rows.Count = 0 Then
            'diagnostico.AppendLine("ERROR: No se procesaron datos")
            'Throw New Exception("No se encontraron datos válidos en el archivo Excel")
            'End If

            'diagnostico.AppendLine($"=== PROCESO EXITOSO === Filas en DataTable: {MiDatosContPaqDT.Rows.Count}")

        Catch ex As Exception
            'diagnostico.AppendLine($"EXCEPCIÓN CAPTURADA: {ex.Message}")
            'diagnostico.AppendLine($"StackTrace: {ex.StackTrace}")

            ' Remover MessageBox para producción
            ' MessageBox.Show(diagnostico.ToString(), "Diagnóstico del Error", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'e.Result = ex
            'Console.WriteLine(diagnostico.ToString())

            If MiDatosContPaqDT IsNot Nothing Then
                MiDatosContPaqDT.Dispose()
                MiDatosContPaqDT = Nothing
            End If

        Finally
            ' Escribir todo el diagnóstico
            'Console.WriteLine(diagnostico.ToString())

            ' Liberar recursos COM
            Try
                If excelApp IsNot Nothing Then
                    excelApp.ScreenUpdating = True
                    excelApp.DisplayAlerts = True
                    Try
                        excelApp.Calculation = XlCalculation.xlCalculationAutomatic
                    Catch
                        ' Ignorar errores al restaurar cálculo
                    End Try
                    excelApp.EnableEvents = True
                End If

                If excelWorkSheet IsNot Nothing Then
                    Marshal.ReleaseComObject(excelWorkSheet)
                    excelWorkSheet = Nothing
                End If

                If excelWorkBook IsNot Nothing Then
                    excelWorkBook.Close(False)
                    Marshal.ReleaseComObject(excelWorkBook)
                    excelWorkBook = Nothing
                End If

                If excelApp IsNot Nothing Then
                    excelApp.Quit()
                    Marshal.ReleaseComObject(excelApp)
                    excelApp = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()

            Catch comEx As Exception
                Debug.WriteLine($"Error liberando recursos COM: {comEx.Message}")
            End Try
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        MyProgressBar1.Value = e.ProgressPercentage
        LblProgreso.Text = x & "/" & y
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MyProgressBar1.Value = 0
        LblProgreso.Text = ""

        ' CORRECCIÓN: Verificar si hubo errores
        If e.Result IsNot Nothing AndAlso TypeOf e.Result Is Exception Then
            Dim ex As Exception = CType(e.Result, Exception)
            MessageBox.Show("Error al importar el archivo de CONTPAQi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BtnAnalizar.Enabled = False
            Return
        End If

        ' CORRECCIÓN: Verificar que los datos se cargaron correctamente antes de continuar
        If MiDatosContPaqDT Is Nothing OrElse MiDatosContPaqDT.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos válidos en el archivo seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BtnAnalizar.Enabled = False
            Return
        End If

        'MessageBox.Show($"El archivo de CONTPAQi fue importado con éxito. Se procesaron {MiDatosContPaqDT.Rows.Count} registros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MiNuevosMovimientos()
        BtnAnalizar.Enabled = True
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        MiDatosContPaqBS.MoveFirst()
    End Sub

    Private Sub BtnUltimo_Click(sender As Object, e As EventArgs) Handles BtnUltimo.Click
        MiDatosContPaqBS.MoveLast()
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        MiDatosContPaqBS.MovePrevious()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        MiDatosContPaqBS.MoveNext()
    End Sub

    Private Sub AbrirFrmAnalizar()
        Dim FrmAbierto As Boolean = False

        For Each frm As Form In My.Application.OpenForms
            If frm.Name = "FrmAnalizar" Then
                FrmAbierto = True
            End If
        Next
        If FrmAbierto Then
            MsgBox("Ya existe una ventana de análisis abierta...")
        Else
            Dim FrmAnalizar As New FrmAnalizar(MiDatosContPaqBS)
            FrmAnalizar.Show()
        End If
    End Sub

    Private Sub BtnAnalizar_Click(sender As Object, e As EventArgs) Handles BtnAnalizar.Click
        If TxtBuscar.TextLength > 0 Then
            If MsgBox("¿Desea quitar el filtro de búsqueda?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MiDatosContPaqBS.RemoveFilter()
                TxtBuscar.Text = ""
            End If
        End If
        AbrirFrmAnalizar()
    End Sub

    Private Sub BtnCopiar_Click(sender As Object, e As EventArgs) Handles BtnCopiar.Click
        If MiDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Try
                Clipboard.SetDataObject(MiDataGrid.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("Error, no se puede copiar la información en este momento: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub MiDataGrid_SelectionChanged(sender As Object, e As EventArgs) Handles MiDataGrid.SelectionChanged
        Dim RenglonesSeleccionados As Integer = MiDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim Cargos As Double = 0
        Dim Abonos As Double = 0

        If RenglonesSeleccionados > 0 Then
            For Each row As DataGridViewRow In MiDataGrid.SelectedRows
                If row.Cells(8).Value IsNot Nothing Then
                    Cargos += CDbl(row.Cells(8).Value)
                End If
                If row.Cells(9).Value IsNot Nothing Then
                    Abonos += CDbl(row.Cells(9).Value)
                End If
            Next

            LblSeleccion.Text = RenglonesSeleccionados.ToString()
            LblCargos.Text = Format(Cargos, "N2")
            LblAbonos.Text = Format(Abonos, "N2")
        Else
            LblSeleccion.Text = "0"
            LblCargos.Text = "0.00"
            LblAbonos.Text = "0.00"
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        If String.IsNullOrWhiteSpace(TxtBuscar.Text) Then
            MiDatosContPaqBS.RemoveFilter()
        Else
            MiDatosContPaqBS.Filter = ConstruirFiltroBusqueda(TxtBuscar.Text.Trim())
        End If
        MiDatosContPaqBS_PositionChanged(Nothing, Nothing)
        SumarCargosYAbonos()
    End Sub

    Private Function ConstruirFiltroBusqueda(texto As String) As String
        Dim criterio = texto.Replace("'", "''")

        ' CORRECCIÓN: Columnas que realmente existen en el DataTable
        Dim columnasTexto = New String() {
            "Cuenta", "TipoTrabajador", "Nombre", "TipoPoliza", "Concepto", "Referencia"
        }

        Dim columnasNumericas = New String() {
            "Numero", "Cargos", "Abonos"
        }

        Dim filtroPartes As New List(Of String)

        For Each col In columnasTexto
            filtroPartes.Add($"{col} LIKE '%{criterio}%'")
        Next

        For Each col In columnasNumericas
            filtroPartes.Add($"CONVERT({col}, 'System.String') LIKE '%{criterio}%'")
        Next

        filtroPartes.Add($"CONVERT(Fecha, 'System.String') LIKE '%{criterio}%'")

        Return String.Join(" OR ", filtroPartes)
    End Function

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBuscar.KeyDown
        If MiDatosContPaqBS IsNot Nothing AndAlso MiDatosContPaqBS.Count > 0 Then
            Select Case e.KeyCode
                Case Keys.Up
                    MiDatosContPaqBS.MovePrevious()
                Case Keys.Down
                    MiDatosContPaqBS.MoveNext()
                Case Keys.Home
                    MiDatosContPaqBS.MoveFirst()
                Case Keys.End
                    MiDatosContPaqBS.MoveLast()
                Case Keys.Left
                    MoverCeldaIzquierda()
                Case Keys.Right
                    MoverCeldaDerecha()
            End Select
        End If
        e.Handled = True
    End Sub

    Private Sub MoverCeldaIzquierda()
        If MiDataGrid.CurrentCell IsNot Nothing AndAlso MiDataGrid.CurrentCell.ColumnIndex > 0 Then
            Dim nuevaColumna As Integer = MiDataGrid.CurrentCell.ColumnIndex - 1
            MiDataGrid.CurrentCell = MiDataGrid.Rows(MiDataGrid.CurrentCell.RowIndex).Cells(nuevaColumna)
        End If
    End Sub

    Private Sub MoverCeldaDerecha()
        If MiDataGrid.CurrentCell IsNot Nothing AndAlso MiDataGrid.CurrentCell.ColumnIndex < MiDataGrid.ColumnCount - 1 Then
            Dim nuevaColumna As Integer = MiDataGrid.CurrentCell.ColumnIndex + 1
            MiDataGrid.CurrentCell = MiDataGrid.Rows(MiDataGrid.CurrentCell.RowIndex).Cells(nuevaColumna)
        End If
    End Sub

    Private Sub BtnConciliar_Click(sender As Object, e As EventArgs) Handles BtnConciliar.Click

    End Sub
End Class
