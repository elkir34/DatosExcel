Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient
Imports System.Runtime.InteropServices

Public Class FrmImportarDatos
    Private x, y As Integer
    Private MiDatosContPaqDT As Data.DataTable
    Private WithEvents MiDatosContPaqBS As BindingSource
    Dim MyIndex As Integer

    Private empleadosDict As Dictionary(Of Integer, Integer)
    Private tipoPolizaDict As Dictionary(Of String, Integer)
    Private rubrosDict As Dictionary(Of String, String)

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
            BackgroundWorker1 = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True
            }
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
            'MiDataGrid.Columns(10).Visible = False  'idEmpleado
            'MiDataGrid.Columns(11).Visible = False 'idTipoPoliza
            'MiDataGrid.Columns(12).Visible = False 'ClaveRubro
        End If

        AddHandler MiDatosContPaqBS.PositionChanged, AddressOf MiDatosContPaqBS_PositionChanged
        TxtTotalRegistros.Text = MiDatosContPaqBS.Count.ToString()
        BtnActualizar.Enabled = MiDatosContPaqBS.Count > 0
        MiDatosContPaqBS_PositionChanged(Nothing, Nothing)
        SumarCargosYAbonos()
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

    Private Sub MiCargarDiccionarios()
        Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=localhost; User Id=buzosbyp_erp; password=Mientras12$; database=buzosbyp_erp")

        'Dim noCuentaCompaq As Integer = 0
        'Dim idEmpleado As Integer = 0
        'Dim TipoPoliza As String = ""
        'Dim idTipoPoliza As Integer = 0
        Dim empleadosDA, tipoPolizaDA, rubrosDA As MySqlDataAdapter
        Dim empleadosDT, tipoPolizaDT, rubrosDT As New System.Data.DataTable
        'Dim empleadosBS, tipoPolizaBS, rubrosBS As BindingSource
        'Dim rowSocios, rowTipoPoliza, rowRubros As DataRowView

        empleadosDict = New Dictionary(Of Integer, Integer)
        tipoPolizaDict = New Dictionary(Of String, Integer)
        rubrosDict = New Dictionary(Of String, String)


        Try
            sqlConexion.Open()

            empleadosDA = New MySqlDataAdapter("SELECT idEmpleado, noCuenta FROM empleados", sqlConexion)
            'empleadosDA = New MySqlDataAdapter("SELECT idEmpleado, TipoEmpleado, noCuenta, CONCAT(ApPaterno, ' ', ApMaterno, ' ', Nombre) AS Nombre FROM empleados", sqlConexion)
            empleadosDA.Fill(empleadosDT)
            'empleadosBS = New BindingSource With {.DataSource = empleadosDT}
            'If empleadosBS.Count > 0 Then
            'MiDatosContPaqBS.Sort = "Nombre ASC"
            'For Each rowCompaq As DataRowView In MiDatosContPaqBS
            'If noCuentaCompaq <> rowCompaq.Row.Item("Cuenta") Then
            'noCuentaCompaq = rowCompaq.Row.Item("Cuenta")
            'MyIndex = empleadosBS.Find("noCuenta", noCuentaCompaq)
            'If MyIndex >= 0 Then
            'empleadosBS.Position = MyIndex
            'rowSocios = empleadosBS.Current
            'idEmpleado = rowSocios("idEmpleado")
            'Else
            'idEmpleado = 0
            'End If
            'End If
            'rowCompaq.Row.Item("idEmpleado") = idEmpleado
            'Next
            'Else
            'MsgBox("Error, no se pudo cargar la tabla de empleados, del programa de socios...")
            'End If
            For Each row As DataRow In empleadosDT.Rows
                empleadosDict(Convert.ToInt32(row("noCuenta"))) = Convert.ToInt32(row("idEmpleado"))
            Next

            tipoPolizaDA = New MySqlDataAdapter("SELECT idTipoPoliza, TipoPoliza FROM ctg_tipopoliza", sqlConexion)
            tipoPolizaDA.Fill(tipoPolizaDT)
            'tipoPolizaBS = New BindingSource With {.DataSource = tipoPolizaDT}
            'If tipoPolizaBS.Count > 0 Then
            'MiDatosContPaqBS.Sort = "TipoPoliza ASC"
            'For Each rowCompaq As DataRowView In MiDatosContPaqBS
            'If TipoPoliza <> rowCompaq.Row.Item("TipoPoliza") Then
            'TipoPoliza = rowCompaq.Row.Item("TipoPoliza")
            'MyIndex = tipoPolizaBS.Find("TipoPoliza", TipoPoliza)
            'If MyIndex >= 0 Then
            'tipoPolizaBS.Position = MyIndex
            'rowTipoPoliza = tipoPolizaBS.Current
            'idTipoPoliza = rowTipoPoliza("idTipoPoliza")
            'Else
            'idTipoPoliza = 0
            'End If
            'End If
            'rowCompaq.Row.Item("idTipoPoliza") = idTipoPoliza
            'Next
            'Else
            'MsgBox("Error, no se pudo cargar la tabla del catálogo de pólizas, del programa de socios...")
            'End If
            For Each row As DataRow In tipoPolizaDT.Rows
                tipoPolizaDict(row("TipoPoliza").ToString()) = Convert.ToInt32(row("idTipoPoliza"))
            Next

            rubrosDA = New MySqlDataAdapter("SELECT Clave, Rubro FROM ctg_rubros", sqlConexion)
            rubrosDA.Fill(rubrosDT)
            'rubrosBS = New BindingSource With {.DataSource = rubrosDT}
            'If rubrosBS.Count > 0 Then
            'MiDatosContPaqBS.Sort = "Referencia ASC"
            'For Each rowCompaq As DataRowView In MiDatosContPaqBS
            'MyIndex = rubrosBS.Find("Clave", rowCompaq.Row.Item("Referencia"))
            'If MyIndex >= 0 Then
            'rubrosBS.Position = MyIndex
            'rowRubros = rubrosBS.Current
            'rowCompaq.Row.Item("ClaveRubro") = rowRubros("Clave")
            'Else
            'MyIndex = rubrosBS.Find("Rubro", rowCompaq.Row.Item("Referencia"))
            'If MyIndex >= 0 Then
            'rubrosBS.Position = MyIndex
            'rowRubros = rubrosBS.Current
            'rowCompaq.Row.Item("ClaveRubro") = rowRubros("Clave")
            'Else
            'rowCompaq.Row.Item("ClaveRubro") = ""
            'End If
            'End If
            'Next
            'Else
            'MsgBox("Error, no se pudo cargar la tabla del catálogo de rubros, del programa de socios...")
            'End If
            For Each row As DataRow In rubrosDT.Rows
                Dim clave As String = row("Clave").ToString()
                Dim rubro As String = row("Rubro").ToString()
                If Not rubrosDict.ContainsKey(clave) Then
                    rubrosDict(clave) = clave
                End If
                If Not rubrosDict.ContainsKey(rubro) Then
                    rubrosDict(rubro) = clave
                End If
            Next

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

        MiCargarDiccionarios() ' Cargar los diccionarios antes de procesar el archivo de Excel para mejorar el rendimiento

        Try
            Dim miruta As String = ""
            Me.Invoke(Sub() miruta = OpenFileDialog1.FileName)
            ' Verificar que el archivo existe
            If String.IsNullOrEmpty(miruta) OrElse Not System.IO.File.Exists(miruta) Then
                Throw New System.IO.FileNotFoundException("El archivo no existe: " & miruta)
            End If

            excelApp = New Application With {.ScreenUpdating = False, .DisplayAlerts = False, .EnableEvents = False}
            excelWorkBook = excelApp.Workbooks.Open(miruta)
            excelApp.Calculation = XlCalculation.xlCalculationManual

            ' Obtener la hoja de trabajo
            excelWorkSheet = excelWorkBook.Worksheets(1)

            ' Obtener el rango usado y cargarlo en array - AQUÍ ESTÁ LA OPTIMIZACIÓN
            Dim usedRange = excelWorkSheet.UsedRange
            If usedRange Is Nothing Then
                Throw New Exception("No hay datos en la hoja de Excel")
            End If

            Dim totalRows As Integer = usedRange.Rows.Count
            Dim totalCols As Integer = usedRange.Columns.Count

            If totalCols <> 8 Then
                Throw New Exception("El número de columnas en la hoja de Excel no es el esperado: " & totalCols)
            End If

            If totalRows = 0 Then
                Throw New Exception("No hay datos en la hoja de Excel")
            End If

            ' CARGAR TODO EL RANGO EN UN ARRAY DE UNA SOLA VEZ
            Dim dataArray As Object(,) = usedRange.Value

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

            Dim miCuenta, miNombre, miTipoTrabajador As String
            Dim miBanderaCuenta As Boolean = False
            Dim miCelda As String

            x = 0
            y = totalRows
            miCuenta = ""
            miNombre = ""
            miTipoTrabajador = ""

            For i = 1 To totalRows
                If i Mod 1000 = 0 Then
                    BackgroundWorker1.ReportProgress(CInt((i * 100) / totalRows))
                End If
                miCelda = If(dataArray(i, 1) IsNot Nothing, dataArray(i, 1).ToString().Trim(), "")

                If String.IsNullOrEmpty(miCelda) Then
                    miBanderaCuenta = False
                    Continue For
                End If

                If miCelda.Length = 17 Then
                    miCuenta = miCelda.Substring(10, 3)
                    miTipoTrabajador = If(miCelda.Substring(4, 1).Trim() = "1", "SOCIO", "EXTRA")
                    miNombre = If(dataArray(i, 2) IsNot Nothing, dataArray(i, 2).ToString().Trim(), "")
                    miBanderaCuenta = True
                ElseIf miBanderaCuenta AndAlso IsDate(miCelda) Then
                    Dim tipoPoliza As String = If(dataArray(i, 2)?.ToString(), "")
                    Dim referencia As String = If(dataArray(i, 5)?.ToString(), "")
                    Dim cuentaInt As Integer = If(IsNumeric(miCuenta), Convert.ToInt32(miCuenta), 0)

                    Dim nuevaFila As DataRow = MiDatosContPaqDT.NewRow()

                    nuevaFila("Cuenta") = miCuenta
                    nuevaFila("Nombre") = miNombre
                    nuevaFila("TipoTrabajador") = miTipoTrabajador
                    nuevaFila("Fecha") = If(dataArray(i, 1) IsNot Nothing, CDate(dataArray(i, 1)), DateTime.Now)
                    nuevaFila("TipoPoliza") = tipoPoliza
                    nuevaFila("Concepto") = If(dataArray(i, 4)?.ToString(), "")
                    nuevaFila("Referencia") = referencia
                    nuevaFila("Numero") = If(dataArray(i, 3) IsNot Nothing AndAlso IsNumeric(dataArray(i, 3)), CInt(dataArray(i, 3)), 0)
                    nuevaFila("Cargos") = If(dataArray(i, 6) IsNot Nothing AndAlso IsNumeric(dataArray(i, 6)), CDbl(dataArray(i, 6)), 0)
                    nuevaFila("Abonos") = If(dataArray(i, 7) IsNot Nothing AndAlso IsNumeric(dataArray(i, 7)), CDbl(dataArray(i, 7)), 0)
                    'nuevaFila("idEmpleado") = If(empleadosDict.ContainsKey(Convert.ToInt32(miCuenta)), empleadosDict(Convert.ToInt32(miCuenta)), 0)
                    nuevaFila("idEmpleado") = If(empleadosDict.ContainsKey(cuentaInt), empleadosDict(cuentaInt), 0)
                    nuevaFila("idTipoPoliza") = If(tipoPolizaDict.ContainsKey(tipoPoliza), tipoPolizaDict(tipoPoliza), 0)
                    'nuevaFila("ClaveRubro") = If(rubrosDict.ContainsKey(nuevaFila("Referencia").ToString()), rubrosDict(nuevaFila("Referencia").ToString()), "")
                    nuevaFila("ClaveRubro") = If(rubrosDict.ContainsKey(referencia), rubrosDict(referencia), "")

                    MiDatosContPaqDT.Rows.Add(nuevaFila)
                    'registrosProcesados += 1
                End If

                x += 1
            Next
        Catch ex As Exception
            If MiDatosContPaqDT IsNot Nothing Then
                MiDatosContPaqDT.Dispose()
                MiDatosContPaqDT = Nothing
            End If
        Finally
            If excelApp IsNot Nothing Then
                excelApp.ScreenUpdating = True
                excelApp.DisplayAlerts = True
                excelApp.Calculation = XlCalculation.xlCalculationAutomatic
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
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        MyProgressBar1.Value = e.ProgressPercentage
        LblProgreso.Text = x & "/" & y
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MyProgressBar1.Value = 0
        LblProgreso.Text = ""

        If e.Result IsNot Nothing AndAlso TypeOf e.Result Is Exception Then
            Dim ex As Exception = CType(e.Result, Exception)
            MessageBox.Show("Error al importar el archivo de CONTPAQi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BtnAnalizar.Enabled = False
            Return
        End If

        If MiDatosContPaqDT Is Nothing OrElse MiDatosContPaqDT.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos válidos en el archivo seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BtnAnalizar.Enabled = False
            Return
        End If

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
