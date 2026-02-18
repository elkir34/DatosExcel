Imports MySql.Data.MySqlClient

Public Class FrmAnalizar
    Private MiDatosContPaqBS As BindingSource
    Private segundaTablaDT As DataTable
    Private WithEvents PrimeraTablaBS As BindingSource
    Private cellFormatInfo As New Dictionary(Of String, HashSet(Of String))

    Public Sub New(bindingSource As BindingSource)
        InitializeComponent()
        MiDatosContPaqBS = bindingSource
    End Sub

    Private Sub FrmAnalizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblSeleccion.Text = "0"
        LblCargos.Text = "0.00"
        LblAbonos.Text = "0.00"
        TxtTotalRegistros.Text = "0"
        TxtAbonos.Text = "0.00"
        TxtCargos.Text = "0.00"
        BtnPrimero.Enabled = False
        BtnAnterior.Enabled = False
        BtnSiguiente.Enabled = False
        BtnUltimo.Enabled = False
        BtnActualizar.Enabled = False

        MyCargarSegundaTabla()
        MyAgruparDatos()
        MyAnalizarTablas()
    End Sub

    Private Sub MyAnalizarTablas()
        ' Recorrer los datos de MiDataGrid y comparar con secondTable
        For Each row As DataGridViewRow In MiDataGrid.Rows
            Dim fecha As Date = CDate(row.Cells("Fecha").Value.ToString.Trim())
            Dim numero As Integer = CInt(row.Cells("Numero").Value.ToString.Trim())
            Dim tipoPoliza As String = row.Cells("TipoPoliza").Value.ToString().Trim()
            Dim registros As Integer = CInt(row.Cells("Registros").Value.ToString().Trim())
            Dim sumaCargos As Double = CDbl(row.Cells("SumaCargos").Value.ToString().Trim())
            Dim sumaAbonos As Double = CDbl(row.Cells("SumaAbonos").Value.ToString().Trim())

            ' Comparar con la segunda tabla
            Dim importadaCount As Integer = 0
            Dim camposIguales As Integer = 0
            Dim campoNumero As Boolean = False
            Dim campoTipoPoliza As Boolean = False
            Dim campoFecha As Boolean = False
            Dim campoRegistros As Boolean = False
            Dim campoSumaCargos As Boolean = False
            Dim campoSumaAbonos As Boolean = False

            For Each secondRow As DataRow In segundaTablaDT.Rows
                Dim secondFecha As Date = CDate(secondRow("Fecha").ToString().Trim())
                Dim secondNumero As Integer = CInt(secondRow("Numero").ToString().Trim())
                Dim secondTipoPoliza As String = secondRow("TipoPoliza").ToString().Trim()
                Dim secondRegistros As Integer = CInt(secondRow("Registros").ToString().Trim())
                Dim secondSumaCargos As Double = CDbl(secondRow("SumaCargos").ToString().Trim())
                Dim secondSumaAbonos As Double = CDbl(secondRow("SumaAbonos").ToString().Trim())

                If secondNumero = numero Then
                    If secondTipoPoliza.ToUpper = tipoPoliza.ToUpper Then
                        camposIguales += 2
                        campoNumero = True
                        campoTipoPoliza = True

                        If secondFecha = fecha Then
                            camposIguales += 1
                            campoFecha = True
                        End If
                        If secondRegistros = registros Then
                            camposIguales += 1
                            campoRegistros = True
                        End If
                        If Math.Abs(secondSumaCargos - sumaCargos) < 0.01 Then
                            camposIguales += 1
                            campoSumaCargos = True
                        End If
                        If Math.Abs(secondSumaAbonos - sumaAbonos) < 0.01 Then
                            camposIguales += 1
                            campoSumaAbonos = True
                        End If

                        If camposIguales >= 6 Then
                            importadaCount = 6
                        End If
                    End If
                End If
            Next

            If importadaCount = 6 Then
                row.Cells("Importada").Value = importadaCount
            Else
                row.Cells("Importada").Value = camposIguales
            End If

            Dim rowKey As String = $"{numero}-{tipoPoliza}-{fecha:yyyy-MM-dd}"
            cellFormatInfo(rowKey) = New HashSet(Of String)

            If campoNumero Then cellFormatInfo(rowKey).Add("Numero")
            If campoTipoPoliza Then cellFormatInfo(rowKey).Add("TipoPoliza")
            If campoFecha Then cellFormatInfo(rowKey).Add("Fecha")
            If campoRegistros Then cellFormatInfo(rowKey).Add("Registros")
            If campoSumaCargos Then cellFormatInfo(rowKey).Add("SumaCargos")
            If campoSumaAbonos Then cellFormatInfo(rowKey).Add("SumaAbonos")

        Next
    End Sub

    Private Sub MiDataGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles MiDataGrid.CellFormatting
        Dim row As DataGridViewRow = MiDataGrid.Rows(e.RowIndex)
        Dim numero As Integer = CInt(row.Cells("Numero").Value)
        Dim tipoPoliza As String = row.Cells("TipoPoliza").Value.ToString()
        Dim fecha As Date = CDate(row.Cells("Fecha").Value)
        Dim rowKey As String = $"{numero}-{tipoPoliza}-{fecha:yyyy-MM-dd}"
        Dim columnName As String = MiDataGrid.Columns(e.ColumnIndex).Name

        If cellFormatInfo.ContainsKey(rowKey) AndAlso cellFormatInfo(rowKey).Contains(columnName) Then
            e.CellStyle.BackColor = Color.Blue
            e.CellStyle.ForeColor = Color.LightCoral
        End If
    End Sub

    Private Sub MyCargarSegundaTabla()
        Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=localhost; User Id=buzosbyp_erp; password=Mientras12$; database=buzosbyp_erp")
        Dim segundaTablaDA As MySqlDataAdapter
        Dim FechaInicio, FechaFin As String

        If MiDatosContPaqBS.Count > 0 Then
            MiDatosContPaqBS.Sort = "Fecha ASC, Numero ASC, TipoPoliza ASC, TipoTrabajador ASC, Nombre ASC"

            'Se saca el periódo de pólizas, después de ordenar los datos que se sacaron de Excel desde CONTPAQi
            FechaInicio = CDate(CType(MiDatosContPaqBS.List(0), DataRowView)("Fecha")).ToString("yyyy-MM-dd")
            FechaFin = CDate(CType(MiDatosContPaqBS.List(MiDatosContPaqBS.Count - 1), DataRowView)("Fecha")).ToString("yyyy-MM-dd")

            'Se sacan los datos de la BD de trabajadores para el periodo de polizas, de forma agrupada para analizar.
            Dim strSQL As String = "SELECT DATE_FORMAT(Fecha,'%d/%m/%Y') AS Fecha, Poliza AS Numero, TipoPoliza, count(idCargo) AS Registros, ROUND(SUM(Cargo),2) AS SumaCargos, ROUND(SUM(Abono),2) AS SumaAbonos 
                                FROM tbl_cargos 
                                    INNER JOIN ctg_tipopoliza ON ctg_tipopoliza.idTipoPoliza=tbl_cargos.idTipoPoliza 
                                WHERE Fecha BETWEEN '" & FechaInicio & "' AND '" & FechaFin & "' 
                                GROUP BY TipoPoliza, Poliza, Fecha;"
            Try
                sqlConexion.Open()
                segundaTablaDA = New MySqlDataAdapter(strSQL, sqlConexion)
                segundaTablaDT = New DataTable()
                segundaTablaDA.Fill(segundaTablaDT)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                sqlConexion.Close()
            End Try
        Else
            MessageBox.Show("No hay datos para analizar...")
        End If
    End Sub

    Private Sub MyAgruparDatos()
        Dim agrupacionDict As New Dictionary(Of String, List(Of DataRow))
        Dim resultTable As New DataTable()

        ' Recorrer los datos del BindingSource
        For Each rowView As DataRowView In MiDatosContPaqBS
            Dim row As DataRow = rowView.Row
            Dim clave As String = $"{row("Numero")}-{row("TipoPoliza")}-{row("Fecha")}"

            ' Agrupar los datos por Numero, Tipo y Fecha
            If Not agrupacionDict.ContainsKey(clave) Then
                agrupacionDict(clave) = New List(Of DataRow)()
            End If
            agrupacionDict(clave).Add(row)
        Next

        ' Crear una tabla para mostrar los datos agrupados y contados
        resultTable.Columns.Add("Fecha", GetType(DateTime))
        resultTable.Columns.Add("Numero")
        resultTable.Columns.Add("TipoPoliza")
        resultTable.Columns.Add("Registros", GetType(Integer))
        resultTable.Columns.Add("SumaCargos", GetType(Double))
        resultTable.Columns.Add("SumaAbonos", GetType(Double))
        resultTable.Columns.Add("Importada", GetType(Integer))

        ' Llenar la tabla con los datos agrupados y contados
        For Each kvp As KeyValuePair(Of String, List(Of DataRow)) In agrupacionDict
            Dim newRow As DataRow = resultTable.NewRow()
            Dim partes As String() = kvp.Key.Split("-"c)
            newRow("Fecha") = partes(2)
            newRow("Numero") = partes(0)
            newRow("TipoPoliza") = partes(1)
            newRow("Registros") = kvp.Value.Count
            newRow("SumaCargos") = kvp.Value.Sum(Function(r) Convert.ToDouble(r("Cargos")))
            newRow("SumaAbonos") = kvp.Value.Sum(Function(r) Convert.ToDouble(r("Abonos")))

            resultTable.Rows.Add(newRow)
        Next

        ' Mostrar los datos en el DataGridView
        PrimeraTablaBS = New BindingSource With {.DataSource = resultTable}
        MiDataGrid.DataSource = PrimeraTablaBS

        MiDataGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        MiDataGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        MiDataGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns(4).DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns(5).DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        MiDataGrid.Columns(0).Width = 100   'Fecha
        MiDataGrid.Columns(1).Width = 80   'Numero
        MiDataGrid.Columns(2).Width = 140  'TipoPoliza
        MiDataGrid.Columns(2).HeaderText = "Tipo de póliza"
        MiDataGrid.Columns(3).Width = 100   'Registros
        MiDataGrid.Columns(4).Width = 120  'Cargos
        MiDataGrid.Columns(5).Width = 120   'Abonos
        MiDataGrid.Columns(6).Width = 100  'Importada
        MiDataGrid.Columns(4).HeaderText = "Cargos"
        MiDataGrid.Columns(5).HeaderText = "Abonos"
        MiDataGrid.Columns(6).Visible = False ' Importada

        AddHandler PrimeraTablaBS.PositionChanged, AddressOf primeraTablaBS_PositionChanged
        TxtTotalRegistros.Text = PrimeraTablaBS.Count.ToString()
        BtnActualizar.Enabled = MiDatosContPaqBS.Count > 0
        primeraTablaBS_PositionChanged(Nothing, Nothing)
        SumarCargosYAbonos()
    End Sub

    Private Sub SumarCargosYAbonos()
        Dim totalCargos As Double = 0
        Dim totalAbonos As Double = 0

        For Each row As DataGridViewRow In MiDataGrid.Rows
            If Not row.IsNewRow Then
                totalCargos += CDbl(row.Cells(4).Value)
                totalAbonos += CDbl(row.Cells(5).Value)
            End If
        Next

        TxtCargos.Text = totalCargos.ToString("N2")
        TxtAbonos.Text = totalAbonos.ToString("N2")
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        PrimeraTablaBS.MoveFirst()
    End Sub

    Private Sub BtnUltimo_Click(sender As Object, e As EventArgs) Handles BtnUltimo.Click
        PrimeraTablaBS.MoveLast()
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        PrimeraTablaBS.MovePrevious()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        PrimeraTablaBS.MoveNext()
    End Sub

    Private Sub primeraTablaBS_PositionChanged(sender As Object, e As EventArgs) Handles PrimeraTablaBS.PositionChanged
        TxtRegistro.Text = (PrimeraTablaBS.Position + 1).ToString
        TxtTotalRegistros.Text = PrimeraTablaBS.Count.ToString()
        BtnPrimero.Enabled = PrimeraTablaBS.Position > 0
        BtnAnterior.Enabled = PrimeraTablaBS.Position > 0
        BtnSiguiente.Enabled = PrimeraTablaBS.Position < PrimeraTablaBS.Count - 1
        BtnUltimo.Enabled = PrimeraTablaBS.Position < PrimeraTablaBS.Count - 1
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
            Cargos = MiDataGrid.SelectedRows.Cast(Of DataGridViewRow)().Sum(Function(row) CDbl(row.Cells(4).Value))
            Abonos = MiDataGrid.SelectedRows.Cast(Of DataGridViewRow)().Sum(Function(row) CDbl(row.Cells(5).Value))

            LblSeleccion.Text = RenglonesSeleccionados
            LblCargos.Text = Format(Cargos, "N2")
            LblAbonos.Text = Format(Abonos, "N2")
        Else
            LblSeleccion.Text = "0"
            LblCargos.Text = "0.00"
            LblAbonos.Text = "0.00"
        End If
    End Sub

    Private Sub BtnImportar_Click(sender As Object, e As EventArgs) Handles BtnImportar.Click
        Dim RenglonesSeleccionados As Integer = MiDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If RenglonesSeleccionados > 0 Then
            For i As Integer = 0 To RenglonesSeleccionados - 1
                If MiDataGrid.SelectedRows(i).Cells("Importada").Value > 3 Then
                    MsgBox("La poliza: " & MiDataGrid.SelectedRows(i).Cells(1).Value & " ya fue importada", MsgBoxStyle.Information)
                Else
                    Dim fecha As Date = CDate(MiDataGrid.SelectedRows(i).Cells("Fecha").Value.ToString.Trim())
                    Dim numero As Integer = CInt(MiDataGrid.SelectedRows(i).Cells("Numero").Value.ToString.Trim())
                    Dim tipoPoliza As String = MiDataGrid.SelectedRows(i).Cells("TipoPoliza").Value.ToString().Trim()

                    If MsgBox("¿Desea importar la poliza: " & numero & "-" & tipoPoliza & ", del: " & fecha & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If MyTraspasarDatos(numero, tipoPoliza, fecha) Then
                            MiDataGrid.SelectedRows(i).Cells(6).Value = 6
                            Dim rowKey As String = $"{numero}-{tipoPoliza}-{fecha:yyyy-MM-dd}"
                            cellFormatInfo(rowKey) = New HashSet(Of String) From {"Numero", "TipoPoliza", "Fecha", "Registros", "SumaCargos", "SumaAbonos"}
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Function MyTraspasarDatos(ByVal numero As Integer, ByVal tipoPoliza As String, ByVal fecha As Date) As Boolean
        Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=localhost; User Id=buzosbyp_erp; password=Mientras12$; database=buzosbyp_erp")
        Dim sqlComando As MySqlCommand
        Dim empleadosDA As MySqlDataAdapter
        Dim empleadosDT As DataTable
        'Dim miNominacion, miClaveRubro,
        Dim strSQL As String
        Dim miRegresar As Boolean = False

        Try
            sqlConexion.Open()

            ' Filtrar los registros en MiDatosCompaqBS que cumplen con los criterios
            Dim registrosFiltrados = From rowView As DataRowView In MiDatosContPaqBS
                                     Where CInt(rowView("Numero")) = numero AndAlso rowView("TipoPoliza").ToString() = tipoPoliza AndAlso CDate(rowView("Fecha")) = fecha
                                     Select rowView

            ' una vez con los registros filtrados, se procede a validarlos
            Dim ErrorNoCuenta As Integer = 0
            Dim ErrorTipoPoliza As Integer = 0
            Dim ErrorNombre As Integer = 0
            Dim SiImportar As Boolean = False

            ' ver si todos los idEmpleado son > a cero
            For Each rowView As DataRowView In registrosFiltrados
                Dim row As DataRow = rowView.Row
                If CInt(row("idEmpleado")) <= 0 Then
                    MsgBox("El Número de cuenta del Empleado no es correcto: " & row("idEmpleado").ToString() & "-" & row("Nombre").ToString())
                    ErrorNoCuenta += 1
                End If
            Next

            ' ver si todos los idTipoPoliza son > a cero
            For Each rowView As DataRowView In registrosFiltrados
                Dim row As DataRow = rowView.Row
                If CInt(row("idTipoPoliza")) <= 0 Then
                    MsgBox("El Tipo de Póliza no está definido en el programa de Empleados: " & row("idTipoPoliza").ToString() & "-" & row("Nombre").ToString())
                    ErrorTipoPoliza += 1
                End If
            Next

            ' ver si todos los nombres de MiDatosCompaqBS son identicos a los de la base de datos del programa de socios
            '--CARGAR TRABAJADORES-------------------------
            empleadosDA = New MySqlDataAdapter("SELECT idEmpleado, noCuenta, Alias, CONCAT(ApPaterno, ' ', ApMaterno, ' ', Nombre) AS Empleado FROM empleados WHERE Status=1", sqlConexion)
            empleadosDT = New DataTable
            empleadosDA.Fill(empleadosDT)

            For Each rowCompaqView As DataRowView In registrosFiltrados
                Dim rowCompaq As DataRow = rowCompaqView.Row
                Dim NombreCompaq As String = rowCompaq("Nombre").ToString()
                Dim noCuentaCompaq As String = rowCompaq("Cuenta").ToString()
                Dim NombreEmpleados As String = empleadosDT.AsEnumerable().Where(Function(r) r.Field(Of Integer)("noCuenta") = noCuentaCompaq).Select(Function(r) r.Field(Of String)("Empleado")).FirstOrDefault()

                If NombreCompaq <> NombreEmpleados Then ErrorNombre += 1
            Next
            '**************************************************************
            '**************************************************************
            If ErrorNoCuenta > 0 Or ErrorTipoPoliza > 0 Or ErrorNombre > 0 Then
                Dim strMsg As String = "La poliza: " & numero & ", Tipo: " & tipoPoliza & ", Fecha: " & fecha & vbCrLf &
                                       "Contiene los siguente errors: " & vbCrLf &
                                        "1.- " & ErrorNoCuenta & " Empleados sin número de cuenta" & vbCrLf &
                                        "2.- " & ErrorTipoPoliza & " Tipos de póliza no definidos" & vbCrLf &
                                        "3.- " & ErrorNombre & " Nombres de empleados no coinciden" & vbCrLf &
                                        "¿Desea continuar con la importación?"

                If MsgBox(strMsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    SiImportar = True
                End If
            Else
                SiImportar = True
            End If

            If SiImportar Then
                Dim horaCaptura As String = Format(TimeOfDay, "HH:mm:ss")

                ' Insertar los registros en la base de datos
                For Each rowView As DataRowView In registrosFiltrados
                    Dim row As DataRow = rowView.Row

                    strSQL = "INSERT INTO tbl_cargos (idEmpleado, idUsuario, FechaCaptura, Fecha, Hora, Poliza, idTipoPoliza, Rubro, Nominacion, Concepto, Cargo, Abono) 
                            VALUES (@idEmpleado, @idUsuario, @FechaCaptura, @Fecha, @Hora, @Poliza, @idTipoPoliza, @Rubro, @Nominacion, @Concepto, @Cargo, @Abono);"
                    sqlComando = New MySqlCommand(strSQL, sqlConexion)

                    sqlComando.Parameters.AddWithValue("@idEmpleado", row("idEmpleado"))
                    sqlComando.Parameters.AddWithValue("@idUsuario", "17")
                    sqlComando.Parameters.AddWithValue("@FechaCaptura", Today.ToString("yyyy-MM-dd"))
                    sqlComando.Parameters.AddWithValue("@Fecha", CDate(row("Fecha")).ToString("yyyy-MM-dd"))
                    sqlComando.Parameters.AddWithValue("@Hora", horaCaptura)
                    sqlComando.Parameters.AddWithValue("@Poliza", CInt(row("Numero")))
                    sqlComando.Parameters.AddWithValue("@idTipoPoliza", row("idTipoPoliza").ToString())
                    sqlComando.Parameters.AddWithValue("@Rubro", If(row("ClaveRubro") = "", "Z", row("ClaveRubro").ToString()))
                    sqlComando.Parameters.AddWithValue("@Nominacion", If(CDbl(row("Abonos")) > 0, "13", "05"))
                    sqlComando.Parameters.AddWithValue("@Concepto", row("Concepto").ToString())
                    sqlComando.Parameters.AddWithValue("@Cargo", CDbl(row("Cargos")))
                    sqlComando.Parameters.AddWithValue("@Abono", CDbl(row("Abonos")))
                    sqlComando.ExecuteNonQuery()
                Next
                miRegresar = True
            Else
                MsgBox("No se importó la póliza: " & numero & ", Tipo: " & tipoPoliza & ", Fecha: " & fecha & vbCrLf)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConexion.Close()
        End Try

        Return miRegresar
    End Function
End Class