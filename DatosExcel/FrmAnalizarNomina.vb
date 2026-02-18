Imports MySql.Data.MySqlClient

Public Class FrmAnalizarNomina
    Private MiDatosCONTPAQiBS As BindingSource
    Private WithEvents MiDatosCONTPAQiAgrupadosBS As BindingSource
    Private MiDatosSistemaTrabajadoresDT As DataTable
    Private cellFormatInfo As New Dictionary(Of String, HashSet(Of String)) ' Clave: "Numero-TipoPoliza-Fecha", Valor: Campos que coinciden

    Public Sub New(bindingSource As BindingSource)
        InitializeComponent()
        'Recibir los datos sacados del archivo de Excel generado por CONTPAQi Nóminas
        MiDatosCONTPAQiBS = bindingSource
    End Sub

    Private Sub FrmAnalizarNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtAbonos.Text = "0.00"
        TxtCargos.Text = "0.00"

        MyCargarDatosSistemaTrabajadores()
        MyCargarDatosSistemaCONTPAQiAgrupados()
        MyAnalizarTablas()

    End Sub

    Private Sub MyCargarDatosSistemaTrabajadores()
        Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=localhost; User Id=buzosbyp_erp; password=Mientras12$; database=buzosbyp_erp")
        Dim segundaTablaDA As MySqlDataAdapter
        Dim FechaInicio, FechaFin As String

        If MiDatosCONTPAQiBS.Count > 0 Then
            MiDatosCONTPAQiBS.Sort = "Fecha ASC, Numero ASC, TipoPoliza ASC, TipoTrabajador ASC, Nombre ASC"

            'Se saca el periódo de pólizas, después de ordenar los datos que se sacaron de Excel desde CONTPAQi
            FechaInicio = CDate(CType(MiDatosCONTPAQiBS.List(0), DataRowView)("Fecha")).ToString("yyyy-MM-dd")
            FechaFin = CDate(CType(MiDatosCONTPAQiBS.List(MiDatosCONTPAQiBS.Count - 1), DataRowView)("Fecha")).ToString("yyyy-MM-dd")

            'Se sacan los datos de la BD de trabajadores para el periodo de polizas, de forma agrupada para analizar.
            Dim strSQL As String = "SELECT DATE_FORMAT(Fecha,'%d/%m/%Y') AS Fecha, Poliza AS Numero, TipoPoliza, count(idCargo) AS Registros, ROUND(SUM(Cargo),2) AS SumaCargos, ROUND(SUM(Abono),2) AS SumaAbonos 
                                FROM tbl_cargos 
                                    INNER JOIN ctg_tipopoliza ON ctg_tipopoliza.idTipoPoliza=tbl_cargos.idTipoPoliza 
                                WHERE Fecha BETWEEN '" & FechaInicio & "' AND '" & FechaFin & "' 
                                GROUP BY TipoPoliza, Poliza, Fecha;"
            Try
                sqlConexion.Open()
                segundaTablaDA = New MySqlDataAdapter(strSQL, sqlConexion)
                MiDatosSistemaTrabajadoresDT = New DataTable()
                segundaTablaDA.Fill(MiDatosSistemaTrabajadoresDT)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                sqlConexion.Close()
            End Try
        Else
            MessageBox.Show("No hay datos para analizar...")
        End If
    End Sub

    Private Sub MyCargarDatosSistemaCONTPAQiAgrupados()
        Dim agrupacionDict As New Dictionary(Of String, List(Of DataRow))
        Dim resultTable As New DataTable()

        ' Recorrer los datos del BindingSource
        For Each rowView As DataRowView In MiDatosCONTPAQiBS
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
        resultTable.Columns.Add("Importada", GetType(String))

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
            newRow("Importada") = "CONTPAQi"

            resultTable.Rows.Add(newRow)
        Next

        ' Mostrar los datos en el DataGridView
        MiDatosCONTPAQiAgrupadosBS = New BindingSource With {.DataSource = resultTable}
        MiDataGrid.DataSource = MiDatosCONTPAQiAgrupadosBS

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

        SumarCargosYAbonos()
    End Sub

    Private Sub MyAnalizarTablas()
        If MiDatosCONTPAQiAgrupadosBS Is Nothing OrElse MiDatosSistemaTrabajadoresDT Is Nothing Then
            Return
        End If

        Dim resultTable As DataTable = CType(MiDatosCONTPAQiAgrupadosBS.DataSource, DataTable)

        ' Primero procesar las pólizas de CONTPAQi
        For Each row As DataRow In resultTable.Rows
            Dim clave As String = $"{row("Fecha").ToString()}-{row("Numero")}-{row("TipoPoliza")}"

            ' Buscar la póliza correspondiente en el sistema de trabajadores
            Dim filtro As String = $"Fecha = '{row("Fecha").ToString()}' AND Numero = '{row("Numero")}' AND TipoPoliza = '{row("TipoPoliza")}'"
            Dim rowsEncontradas() As DataRow = MiDatosSistemaTrabajadoresDT.Select(filtro)

            If rowsEncontradas.Length > 0 Then
                ' La póliza existe en ambos sistemas, verificar si coinciden los valores
                Dim rowSistema As DataRow = rowsEncontradas(0)

                Dim registrosIguales As Boolean = CInt(row("Registros")) = CInt(rowSistema("Registros"))
                Dim cargosIguales As Boolean = Math.Abs(CDbl(row("SumaCargos")) - CDbl(rowSistema("SumaCargos"))) < 0.01
                Dim abonosIguales As Boolean = Math.Abs(CDbl(row("SumaAbonos")) - CDbl(rowSistema("SumaAbonos"))) < 0.01

                If registrosIguales AndAlso cargosIguales AndAlso abonosIguales Then
                    row("Importada") = "CONCILIADA"
                Else
                    row("Importada") = "REVISAR"
                End If
            Else
                ' La póliza no existe en el sistema de trabajadores
                row("Importada") = "CONTPAQi"
            End If
        Next

        ' Ahora agregar las pólizas que están en el sistema de trabajadores pero no en CONTPAQi
        For Each rowSistema As DataRow In MiDatosSistemaTrabajadoresDT.Rows
            Dim filtro As String = $"Fecha = '{rowSistema("Fecha").ToString()}' AND Numero = '{rowSistema("Numero")}' AND TipoPoliza = '{rowSistema("TipoPoliza")}'"
            Dim rowsEncontradas() As DataRow = resultTable.Select(filtro)

            If rowsEncontradas.Length = 0 Then
                ' Esta póliza está en el sistema de trabajadores pero no en CONTPAQi
                Dim newRow As DataRow = resultTable.NewRow()
                newRow("Fecha") = rowSistema("Fecha")
                newRow("Numero") = rowSistema("Numero")
                newRow("TipoPoliza") = rowSistema("TipoPoliza")
                newRow("Registros") = rowSistema("Registros")
                newRow("SumaCargos") = rowSistema("SumaCargos")
                newRow("SumaAbonos") = rowSistema("SumaAbonos")
                newRow("Importada") = "EMPLEADOS"
                resultTable.Rows.Add(newRow)
            End If
        Next

        ' Actualizar colores según el estado
        ActualizarColoresGrid()
        SumarCargosYAbonos()
    End Sub

    Private Sub ActualizarColoresGrid()
        For Each row As DataGridViewRow In MiDataGrid.Rows
            If Not row.IsNewRow Then
                Dim estado As String = row.Cells(6).Value?.ToString()
                Select Case estado
                    Case "CONCILIADA"
                        row.DefaultCellStyle.BackColor = Color.LightGreen
                    Case "REVISAR"
                        row.DefaultCellStyle.BackColor = Color.LightYellow
                    Case "EMPLEADOS"
                        row.DefaultCellStyle.BackColor = Color.LightCoral
                    Case "CONTPAQi"
                        row.DefaultCellStyle.BackColor = Color.LightBlue
                End Select
            End If
        Next
    End Sub

    Private Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        If MiDataGrid.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione una fila para procesar.")
            Return
        End If

        Dim filaSeleccionada As DataGridViewRow = MiDataGrid.CurrentRow
        Dim estado As String = filaSeleccionada.Cells(6).Value?.ToString()
        Dim fecha As String = filaSeleccionada.Cells(0).Value?.ToString()
        Dim numero As String = filaSeleccionada.Cells(1).Value?.ToString()
        Dim tipoPoliza As String = filaSeleccionada.Cells(2).Value?.ToString()

        Select Case estado
            Case "CONTPAQi"
                ImportarPolizaDeCONTPAQi(fecha, numero, tipoPoliza)

            Case "CONCILIADA"
                MessageBox.Show($"La póliza {tipoPoliza} #{numero} del {fecha} ya existe en ambos sistemas y está conciliada.")

            Case "REVISAR"
                MostrarInconsistencias(fecha, numero, tipoPoliza)

            Case "EMPLEADOS"
                MessageBox.Show($"La póliza {tipoPoliza} #{numero} del {fecha} existe solo en el sistema de empleados." & vbCrLf &
                              "Esta póliza debe ser revisada y posiblemente eliminada del sistema de empleados.")
        End Select
    End Sub

    Private Sub ImportarPolizaDeCONTPAQi(fecha As String, numero As String, tipoPoliza As String)
        Try
            ' Obtener los registros desagrupados de CONTPAQi para esta póliza específica
            Dim registrosParaImportar As New List(Of DataRow)

            For Each rowView As DataRowView In MiDatosCONTPAQiBS
                Dim row As DataRow = rowView.Row
                If row("Fecha").ToString() = fecha AndAlso
                   row("Numero").ToString() = numero AndAlso
                   row("TipoPoliza").ToString() = tipoPoliza Then
                    registrosParaImportar.Add(row)
                End If
            Next

            If registrosParaImportar.Count = 0 Then
                MessageBox.Show("No se encontraron registros para importar.")
                Return
            End If

            ' Confirmar importación
            Dim resultado As DialogResult = MessageBox.Show(
                $"¿Desea importar {registrosParaImportar.Count} registros de la póliza {tipoPoliza} #{numero} del {fecha}?",
                "Confirmar Importación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                ' Aquí implementarías la lógica de importación a la base de datos
                ' Por ahora solo mostramos un mensaje
                MessageBox.Show($"Se importaron {registrosParaImportar.Count} registros exitosamente.")

                ' Actualizar el estado de la fila
                MiDataGrid.CurrentRow.Cells(6).Value = "CONCILIADA"
                ActualizarColoresGrid()
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al importar: {ex.Message}")
        End Try
    End Sub

    Private Sub MostrarInconsistencias(fecha As String, numero As String, tipoPoliza As String)
        ' Obtener datos de CONTPAQi
        Dim filaCONTPAQi As DataGridViewRow = MiDataGrid.CurrentRow
        Dim registrosCONTPAQi As Integer = CInt(filaCONTPAQi.Cells(3).Value)
        Dim cargosCONTPAQi As Double = CDbl(filaCONTPAQi.Cells(4).Value)
        Dim abonosCONTPAQi As Double = CDbl(filaCONTPAQi.Cells(5).Value)

        ' Obtener datos del sistema de empleados
        Dim filtro As String = $"Fecha = '{fecha}' AND Numero = '{numero}' AND TipoPoliza = '{tipoPoliza}'"
        Dim rowsEmpleados() As DataRow = MiDatosSistemaTrabajadoresDT.Select(filtro)

        If rowsEmpleados.Length > 0 Then
            Dim rowEmpleados As DataRow = rowsEmpleados(0)

            Dim mensaje As String = $"Póliza: {tipoPoliza}, Número: {numero}, Fecha: {fecha}" & vbCrLf & vbCrLf &
                                  $"CONTPAQi: Registros: {registrosCONTPAQi}, Cargos: {cargosCONTPAQi:N2}, Abonos: {abonosCONTPAQi:N2}" & vbCrLf &
                                  $"EMPLEADOS: Registros: {rowEmpleados("Registros")}, Cargos: {CDbl(rowEmpleados("SumaCargos")):N2}, Abonos: {CDbl(rowEmpleados("SumaAbonos")):N2}" & vbCrLf & vbCrLf &
                                  "¿Desea revisar los detalles de esta póliza?"

            Dim resultado As DialogResult = MessageBox.Show(mensaje, "Inconsistencias Detectadas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If resultado = DialogResult.Yes Then
                MessageBox.Show("Aquí se abriría el formulario de revisión detallada (pendiente de implementar).")
            End If
        End If
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
End Class