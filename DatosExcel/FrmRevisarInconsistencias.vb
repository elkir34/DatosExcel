Public Class FrmRevisarInconsistencias
    Private polizaFecha As Date
    Private polizaNumero As String
    Private polizaTipo As String

    ' Datos de CONTPAQi
    Private contpaqiRegistros As Integer
    Private contpaqiCargos As Double
    Private contpaqiAbonos As Double
    Private contpaqiDetalles As List(Of DataRow)

    ' Datos del Sistema de Empleados
    Private empleadosRegistros As Integer
    Private empleadosCargos As Double
    Private empleadosAbonos As Double
    'Private empleadosDetalles As DataTable

    Public Sub New(fecha As Date, numero As String, tipo As String,
                   regCONTPAQi As Integer, cargosCONTPAQi As Double, abonosCONTPAQi As Double,
                   regEmpleados As Integer, cargosEmpleados As Double, abonosEmpleados As Double)
        InitializeComponent()

        polizaFecha = fecha
        polizaNumero = numero
        polizaTipo = tipo

        contpaqiRegistros = regCONTPAQi
        contpaqiCargos = cargosCONTPAQi
        contpaqiAbonos = abonosCONTPAQi

        empleadosRegistros = regEmpleados
        empleadosCargos = cargosEmpleados
        empleadosAbonos = abonosEmpleados
    End Sub

    Private Sub FrmRevisarInconsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar título
        Me.Text = $"Revisar Inconsistencias - Póliza {polizaTipo} #{polizaNumero}"

        ' Mostrar información de la póliza
        LblFecha.Text = polizaFecha.ToLongDateString
        LblNumero.Text = polizaNumero
        LblTipoPoliza.Text = polizaTipo

        ' Panel CONTPAQi
        LblCONTPAQiRegistros.Text = contpaqiRegistros.ToString()
        LblCONTPAQiCargos.Text = contpaqiCargos.ToString("N2")
        LblCONTPAQiAbonos.Text = contpaqiAbonos.ToString("N2")

        ' Panel Empleados
        LblEmpleadosRegistros.Text = empleadosRegistros.ToString()
        LblEmpleadosCargos.Text = empleadosCargos.ToString("N2")
        LblEmpleadosAbonos.Text = empleadosAbonos.ToString("N2")

        ' Resaltar diferencias
        ResaltarDiferencias()
    End Sub


    Private Sub ResaltarDiferencias()
        Dim diferenciaRegistros As Integer = Math.Abs(contpaqiRegistros - empleadosRegistros)
        If diferenciaRegistros <> 0 Then
            LblDiferenciaRegistros.Text = $"⚠ {diferenciaRegistros} registros"
            LblDiferenciaRegistros.ForeColor = Color.DarkRed
        Else
            LblDiferenciaRegistros.Text = "✓ Coincide"
            'LblDiferenciaRegistros.ForeColor = Color.DarkGreen
        End If

        Dim diferenciaCargos As Double = Math.Abs(contpaqiCargos - empleadosCargos)
        If diferenciaCargos >= 0.01 Then
            LblDiferenciaCargos.Text = $"⚠ ${diferenciaCargos:N2}"
            LblDiferenciaCargos.ForeColor = Color.DarkRed
        Else
            LblDiferenciaCargos.Text = "✓ Coincide"
            'LblDiferenciaCargos.ForeColor = Color.DarkGreen
        End If

        Dim diferenciaAbonos As Double = Math.Abs(contpaqiAbonos - empleadosAbonos)
        If diferenciaAbonos >= 0.01 Then
            LblDiferenciaAbonos.Text = $"⚠ ${diferenciaAbonos:N2}"
            LblDiferenciaAbonos.ForeColor = Color.DarkRed
        Else
            LblDiferenciaAbonos.Text = "✓ Coincide"
            'LblDiferenciaAbonos.ForeColor = Color.DarkGreen
        End If

        Dim diferenciaTrabajadores As Integer = Math.Abs(CInt(LblCONTPAQiTrabajadores.Text) - CInt(LblEmpleadosTrabajadores.Text))
        If diferenciaTrabajadores <> 0 Then
            LblDiferenciaTrabajadores.Text = $"⚠ {diferenciaTrabajadores} trabajadores"
            LblDiferenciaTrabajadores.ForeColor = Color.DarkRed
        Else
            LblDiferenciaTrabajadores.Text = "✓ Coincide"
            'LblDiferenciaTrabajadores.ForeColor = Color.DarkGreen
        End If
    End Sub

    Public Sub CargarDetallesCONTPAQi(detalles As List(Of DataRow))
        contpaqiDetalles = detalles

        ' Crear DataTable para el grid
        Dim dt As New DataTable()
        dt.Columns.Add("Cuenta")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Concepto")
        dt.Columns.Add("Referencia")
        dt.Columns.Add("Cargos", GetType(Double))
        dt.Columns.Add("Abonos", GetType(Double))

        For Each row In detalles
            Dim newRow = dt.NewRow()
            newRow("Cuenta") = row("Cuenta")
            newRow("Nombre") = row("Nombre")
            newRow("Concepto") = row("Concepto")
            newRow("Referencia") = row("Referencia")
            newRow("Cargos") = CDbl(row("Cargos"))
            newRow("Abonos") = CDbl(row("Abonos"))
            dt.Rows.Add(newRow)
        Next
        'COntar el numero de empleados diferentes en la póliza, por su columna "Cuenta"
        'LblCONTPAQiTrabajadores.Text = detalles.AsEnumerable().Select(Function(r) r("Cuenta").ToString()).Distinct().Count().ToString()
        LblCONTPAQiTrabajadores.Text = detalles.AsEnumerable().Select(Function(r) r.Field(Of String)("Cuenta")).Distinct().Count().ToString()

        DataGridCONTPAQi.AutoGenerateColumns = False
        DataGridCONTPAQi.DataSource = dt
        'ConfigurarGridCONTPAQi()
    End Sub

    Public Sub CargarDetallesEmpleados(detalles As DataTable)
        'empleadosDetalles = detalles
        DataGridEmpleados.AutoGenerateColumns = False
        DataGridEmpleados.DataSource = detalles

        'Contar cuantos trabajadores diferentes están en la póliza, de la tabla de detalles por su columna "Cuenta"
        LblEmpleadosTrabajadores.Text = detalles.AsEnumerable().Select(Function(row) row.Field(Of String)("Cuenta")).Distinct().Count().ToString()

        'Dim trabajadoresUnicos As Integer = detalles.AsEnumerable().Select(Function(row) row.Field(Of String)("Nombre")).Distinct().Count()

        'ConfigurarGridEmpleados()
    End Sub

    'Private Sub ConfigurarGridCONTPAQi()
    'With DataGridCONTPAQi
    ' Configuración de columnas
    'If .Columns.Count > 0 Then
    '.Columns("Cuenta").Width = 70
    '.Columns("Cuenta").HeaderText = "Cta"
    '.Columns("Cuenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '
    '.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '.Columns("Nombre").HeaderText = "Empleado"
    '
    '.Columns("Concepto").Width = 150
    '.Columns("Concepto").HeaderText = "Concepto"
    '
    '.Columns("Referencia").Width = 100
    '.Columns("Referencia").HeaderText = "Referencia"

    '.Columns("Cargos").Width = 100
    '.Columns("Cargos").HeaderText = "Cargos"
    '.Columns("Cargos").DefaultCellStyle.Format = "N2"
    '.Columns("Cargos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '
    '.Columns("Abonos").Width = 100
    '.Columns("Abonos").HeaderText = "Abonos"
    '.Columns("Abonos").DefaultCellStyle.Format = "N2"
    '.Columns("Abonos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    'End If
    '
    ' Configuración general del grid
    '.AllowUserToAddRows = False
    '.AllowUserToDeleteRows = False
    '.ReadOnly = True
    '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '.MultiSelect = False
    '.RowHeadersVisible = False
    '.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
    '.DefaultCellStyle.Font = New Font("Segoe UI", 9)
    '.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    '.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy
    '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '.EnableHeadersVisualStyles = False
    '.Dock = DockStyle.Fill
    'End With
    'End Sub

    'Private Sub ConfigurarGridEmpleados()
    'With DataGridEmpleados
    '' Configuración de columnas
    'If .Columns.Count > 0 Then
    '.Columns("Cuenta").Width = 70
    '.Columns("Cuenta").HeaderText = "Cta"
    '.Columns("Cuenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    '.Columns("Nombre").HeaderText = "Empleado"
    '.Columns("Concepto").Width = 150
    '.Columns("Concepto").HeaderText = "Concepto"
    '.Columns("Rubro").Width = 100
    ''.Columns("Rubro").HeaderText = "Rubro"
    '.Columns("Cargo").Width = 100
    '.Columns("Cargo").HeaderText = "Cargos"
    '.Columns("Cargo").DefaultCellStyle.Format = "N2"
    '.Columns("Cargo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '.Columns("Abono").Width = 100
    '.Columns("Abono").HeaderText = "Abonos"
    '.Columns("Abono").DefaultCellStyle.Format = "N2"
    '.Columns("Abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    'End If
    ' Configuración general del grid
    '.AllowUserToAddRows = False
    '.AllowUserToDeleteRows = False
    '.ReadOnly = True
    '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '.MultiSelect = False
    '.RowHeadersVisible = False
    '.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew
    '.DefaultCellStyle.Font = New Font("Segoe UI", 9)
    '.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
    '.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen
    '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
    '.EnableHeadersVisualStyles = False
    ''.Dock = DockStyle.Fill
    'End With
    'End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs)
        Close
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs)
        ' Exportar a Excel o generar reporte
        MessageBox.Show("Función de exportación pendiente de implementar")
    End Sub
End Class