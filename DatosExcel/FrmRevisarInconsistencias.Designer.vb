<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRevisarInconsistencias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridEmpleados = New DataGridView()
        EmpCuenta = New DataGridViewTextBoxColumn()
        EmpNombre = New DataGridViewTextBoxColumn()
        EmpConcepto = New DataGridViewTextBoxColumn()
        EmpRubro = New DataGridViewTextBoxColumn()
        EmpCargos = New DataGridViewTextBoxColumn()
        EmpAbonos = New DataGridViewTextBoxColumn()
        DataGridCONTPAQi = New DataGridView()
        ConCuenta = New DataGridViewTextBoxColumn()
        ConNombre = New DataGridViewTextBoxColumn()
        ConConcepto = New DataGridViewTextBoxColumn()
        ConReferencia = New DataGridViewTextBoxColumn()
        ConCargos = New DataGridViewTextBoxColumn()
        ConAbonos = New DataGridViewTextBoxColumn()
        LblFecha = New Label()
        LblNumero = New Label()
        LblTipoPoliza = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        BtnExportar = New Button()
        BtnCerrar = New Button()
        Label14 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        Panel2 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel3 = New Panel()
        Label10 = New Label()
        LblDiferenciaTrabajadores = New Label()
        LblCONTPAQiTrabajadores = New Label()
        Label13 = New Label()
        LblEmpleadosTrabajadores = New Label()
        Label8 = New Label()
        Label1 = New Label()
        Label5 = New Label()
        LblCONTPAQiAbonos = New Label()
        LblDiferenciaAbonos = New Label()
        LblDiferenciaRegistros = New Label()
        LblCONTPAQiRegistros = New Label()
        Label7 = New Label()
        LblDiferenciaCargos = New Label()
        LblCONTPAQiCargos = New Label()
        LblEmpleadosAbonos = New Label()
        Label9 = New Label()
        LblEmpleadosRegistros = New Label()
        Label6 = New Label()
        LblEmpleadosCargos = New Label()
        Label2 = New Label()
        Panel4 = New Panel()
        CType(DataGridEmpleados, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridCONTPAQi, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridEmpleados
        ' 
        DataGridEmpleados.AllowUserToAddRows = False
        DataGridEmpleados.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.Silver
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridEmpleados.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridEmpleados.Columns.AddRange(New DataGridViewColumn() {EmpCuenta, EmpNombre, EmpConcepto, EmpRubro, EmpCargos, EmpAbonos})
        DataGridEmpleados.Dock = DockStyle.Fill
        DataGridEmpleados.Location = New Point(3, 64)
        DataGridEmpleados.Name = "DataGridEmpleados"
        DataGridEmpleados.ReadOnly = True
        DataGridEmpleados.RowHeadersWidth = 25
        DataGridEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridEmpleados.Size = New Size(649, 568)
        DataGridEmpleados.TabIndex = 0
        ' 
        ' EmpCuenta
        ' 
        EmpCuenta.DataPropertyName = "Cuenta"
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        EmpCuenta.DefaultCellStyle = DataGridViewCellStyle2
        EmpCuenta.HeaderText = "Cuenta"
        EmpCuenta.Name = "EmpCuenta"
        EmpCuenta.ReadOnly = True
        EmpCuenta.Width = 50
        ' 
        ' EmpNombre
        ' 
        EmpNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        EmpNombre.DataPropertyName = "Nombre"
        EmpNombre.HeaderText = "Nombre"
        EmpNombre.Name = "EmpNombre"
        EmpNombre.ReadOnly = True
        ' 
        ' EmpConcepto
        ' 
        EmpConcepto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        EmpConcepto.DataPropertyName = "Concepto"
        EmpConcepto.HeaderText = "Concepto"
        EmpConcepto.Name = "EmpConcepto"
        EmpConcepto.ReadOnly = True
        ' 
        ' EmpRubro
        ' 
        EmpRubro.DataPropertyName = "Rubro"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        EmpRubro.DefaultCellStyle = DataGridViewCellStyle3
        EmpRubro.HeaderText = "Rubro"
        EmpRubro.Name = "EmpRubro"
        EmpRubro.ReadOnly = True
        ' 
        ' EmpCargos
        ' 
        EmpCargos.DataPropertyName = "Cargo"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        EmpCargos.DefaultCellStyle = DataGridViewCellStyle4
        EmpCargos.HeaderText = "Cargos"
        EmpCargos.Name = "EmpCargos"
        EmpCargos.ReadOnly = True
        EmpCargos.Width = 80
        ' 
        ' EmpAbonos
        ' 
        EmpAbonos.DataPropertyName = "Abono"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        EmpAbonos.DefaultCellStyle = DataGridViewCellStyle5
        EmpAbonos.HeaderText = "Abonos"
        EmpAbonos.Name = "EmpAbonos"
        EmpAbonos.ReadOnly = True
        EmpAbonos.Width = 80
        ' 
        ' DataGridCONTPAQi
        ' 
        DataGridCONTPAQi.AllowUserToAddRows = False
        DataGridCONTPAQi.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = Color.Silver
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle6.SelectionForeColor = Color.White
        DataGridCONTPAQi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        DataGridCONTPAQi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridCONTPAQi.Columns.AddRange(New DataGridViewColumn() {ConCuenta, ConNombre, ConConcepto, ConReferencia, ConCargos, ConAbonos})
        DataGridCONTPAQi.Dock = DockStyle.Fill
        DataGridCONTPAQi.Location = New Point(658, 64)
        DataGridCONTPAQi.Name = "DataGridCONTPAQi"
        DataGridCONTPAQi.ReadOnly = True
        DataGridCONTPAQi.RowHeadersWidth = 25
        DataGridCONTPAQi.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridCONTPAQi.Size = New Size(650, 568)
        DataGridCONTPAQi.TabIndex = 1
        ' 
        ' ConCuenta
        ' 
        ConCuenta.DataPropertyName = "Cuenta"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        ConCuenta.DefaultCellStyle = DataGridViewCellStyle7
        ConCuenta.HeaderText = "Cuenta"
        ConCuenta.Name = "ConCuenta"
        ConCuenta.ReadOnly = True
        ConCuenta.Width = 50
        ' 
        ' ConNombre
        ' 
        ConNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ConNombre.DataPropertyName = "Nombre"
        ConNombre.HeaderText = "Nombre"
        ConNombre.Name = "ConNombre"
        ConNombre.ReadOnly = True
        ' 
        ' ConConcepto
        ' 
        ConConcepto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ConConcepto.DataPropertyName = "Concepto"
        ConConcepto.HeaderText = "Concepto"
        ConConcepto.Name = "ConConcepto"
        ConConcepto.ReadOnly = True
        ' 
        ' ConReferencia
        ' 
        ConReferencia.DataPropertyName = "Referencia"
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        ConReferencia.DefaultCellStyle = DataGridViewCellStyle8
        ConReferencia.HeaderText = "Referencia"
        ConReferencia.Name = "ConReferencia"
        ConReferencia.ReadOnly = True
        ' 
        ' ConCargos
        ' 
        ConCargos.DataPropertyName = "Cargos"
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        ConCargos.DefaultCellStyle = DataGridViewCellStyle9
        ConCargos.HeaderText = "Cargos"
        ConCargos.Name = "ConCargos"
        ConCargos.ReadOnly = True
        ConCargos.Width = 80
        ' 
        ' ConAbonos
        ' 
        ConAbonos.DataPropertyName = "Abonos"
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        ConAbonos.DefaultCellStyle = DataGridViewCellStyle10
        ConAbonos.HeaderText = "Abonos"
        ConAbonos.Name = "ConAbonos"
        ConAbonos.ReadOnly = True
        ConAbonos.Width = 80
        ' 
        ' LblFecha
        ' 
        LblFecha.AutoSize = True
        LblFecha.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblFecha.Location = New Point(55, 7)
        LblFecha.Name = "LblFecha"
        LblFecha.Size = New Size(43, 15)
        LblFecha.TabIndex = 11
        LblFecha.Text = "Label1"
        ' 
        ' LblNumero
        ' 
        LblNumero.AutoSize = True
        LblNumero.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblNumero.Location = New Point(498, 7)
        LblNumero.Name = "LblNumero"
        LblNumero.Size = New Size(43, 15)
        LblNumero.TabIndex = 12
        LblNumero.Text = "Label2"
        ' 
        ' LblTipoPoliza
        ' 
        LblTipoPoliza.AutoSize = True
        LblTipoPoliza.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblTipoPoliza.Location = New Point(661, 7)
        LblTipoPoliza.Name = "LblTipoPoliza"
        LblTipoPoliza.Size = New Size(43, 15)
        LblTipoPoliza.TabIndex = 13
        LblTipoPoliza.Text = "Label3"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Top
        Label3.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label3.Location = New Point(3, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(649, 19)
        Label3.TabIndex = 19
        Label3.Text = "Sistema de empleados"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label4.Location = New Point(658, 40)
        Label4.Name = "Label4"
        Label4.Size = New Size(650, 19)
        Label4.TabIndex = 20
        Label4.Text = "Sistema de CONTPAQi Contabilidad"
        Label4.TextAlign = ContentAlignment.TopCenter
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel1, 0, 0)
        TableLayoutPanel1.Controls.Add(DataGridEmpleados, 0, 2)
        TableLayoutPanel1.Controls.Add(Label4, 1, 1)
        TableLayoutPanel1.Controls.Add(DataGridCONTPAQi, 1, 2)
        TableLayoutPanel1.Controls.Add(Label3, 0, 1)
        TableLayoutPanel1.Controls.Add(Panel2, 0, 3)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 21F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 106F))
        TableLayoutPanel1.Size = New Size(1311, 741)
        TableLayoutPanel1.TabIndex = 26
        ' 
        ' Panel1
        ' 
        TableLayoutPanel1.SetColumnSpan(Panel1, 2)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(LblFecha)
        Panel1.Controls.Add(LblNumero)
        Panel1.Controls.Add(LblTipoPoliza)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1305, 34)
        Panel1.TabIndex = 0
        ' 
        ' BtnExportar
        ' 
        BtnExportar.Location = New Point(119, 7)
        BtnExportar.Name = "BtnExportar"
        BtnExportar.Size = New Size(75, 37)
        BtnExportar.TabIndex = 35
        BtnExportar.Text = "Exportar"
        BtnExportar.UseVisualStyleBackColor = True
        ' 
        ' BtnCerrar
        ' 
        BtnCerrar.Location = New Point(119, 50)
        BtnCerrar.Name = "BtnCerrar"
        BtnCerrar.Size = New Size(75, 35)
        BtnCerrar.TabIndex = 34
        BtnCerrar.Text = "Cerrar"
        BtnCerrar.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(571, 7)
        Label14.Name = "Label14"
        Label14.Size = New Size(84, 15)
        Label14.TabIndex = 16
        Label14.Text = "Tipo de póliza:"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(388, 7)
        Label12.Name = "Label12"
        Label12.Size = New Size(104, 15)
        Label12.TabIndex = 15
        Label12.Text = "Número de póliza:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(8, 7)
        Label11.Name = "Label11"
        Label11.Size = New Size(41, 15)
        Label11.TabIndex = 14
        Label11.Text = "Fecha:"
        ' 
        ' Panel2
        ' 
        TableLayoutPanel1.SetColumnSpan(Panel2, 2)
        Panel2.Controls.Add(TableLayoutPanel2)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 638)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1305, 100)
        Panel2.TabIndex = 21
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 3
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 650F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Controls.Add(Panel3, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel4, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1305, 100)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(LblDiferenciaTrabajadores)
        Panel3.Controls.Add(LblCONTPAQiTrabajadores)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(LblEmpleadosTrabajadores)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(LblCONTPAQiAbonos)
        Panel3.Controls.Add(LblDiferenciaAbonos)
        Panel3.Controls.Add(LblDiferenciaRegistros)
        Panel3.Controls.Add(LblCONTPAQiRegistros)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(LblDiferenciaCargos)
        Panel3.Controls.Add(LblCONTPAQiCargos)
        Panel3.Controls.Add(LblEmpleadosAbonos)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(LblEmpleadosRegistros)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(LblEmpleadosCargos)
        Panel3.Controls.Add(Label2)
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(330, 3)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(644, 94)
        Panel3.TabIndex = 0
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(522, 77)
        Label10.Name = "Label10"
        Label10.Size = New Size(77, 15)
        Label10.TabIndex = 68
        Label10.Text = ":Trabajadores"
        ' 
        ' LblDiferenciaTrabajadores
        ' 
        LblDiferenciaTrabajadores.BorderStyle = BorderStyle.FixedSingle
        LblDiferenciaTrabajadores.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblDiferenciaTrabajadores.ForeColor = Color.DarkGreen
        LblDiferenciaTrabajadores.Location = New Point(249, 74)
        LblDiferenciaTrabajadores.Name = "LblDiferenciaTrabajadores"
        LblDiferenciaTrabajadores.Size = New Size(138, 20)
        LblDiferenciaTrabajadores.TabIndex = 67
        LblDiferenciaTrabajadores.Text = "Label1"
        LblDiferenciaTrabajadores.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblCONTPAQiTrabajadores
        ' 
        LblCONTPAQiTrabajadores.BorderStyle = BorderStyle.FixedSingle
        LblCONTPAQiTrabajadores.Location = New Point(393, 74)
        LblCONTPAQiTrabajadores.Name = "LblCONTPAQiTrabajadores"
        LblCONTPAQiTrabajadores.Size = New Size(120, 20)
        LblCONTPAQiTrabajadores.TabIndex = 65
        LblCONTPAQiTrabajadores.Text = "Label1"
        LblCONTPAQiTrabajadores.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(40, 77)
        Label13.Name = "Label13"
        Label13.Size = New Size(77, 15)
        Label13.TabIndex = 69
        Label13.Text = "Trabajadores:"
        ' 
        ' LblEmpleadosTrabajadores
        ' 
        LblEmpleadosTrabajadores.BorderStyle = BorderStyle.FixedSingle
        LblEmpleadosTrabajadores.Location = New Point(123, 74)
        LblEmpleadosTrabajadores.Name = "LblEmpleadosTrabajadores"
        LblEmpleadosTrabajadores.Size = New Size(120, 20)
        LblEmpleadosTrabajadores.TabIndex = 66
        LblEmpleadosTrabajadores.Text = "Label2"
        LblEmpleadosTrabajadores.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(522, 58)
        Label8.Name = "Label8"
        Label8.Size = New Size(58, 15)
        Label8.TabIndex = 63
        Label8.Text = ":Registros"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(522, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 57
        Label1.Text = ":Abonos"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(522, 38)
        Label5.Name = "Label5"
        Label5.Size = New Size(47, 15)
        Label5.TabIndex = 60
        Label5.Text = ":Cargos"
        ' 
        ' LblCONTPAQiAbonos
        ' 
        LblCONTPAQiAbonos.BorderStyle = BorderStyle.FixedSingle
        LblCONTPAQiAbonos.Location = New Point(393, 17)
        LblCONTPAQiAbonos.Name = "LblCONTPAQiAbonos"
        LblCONTPAQiAbonos.Size = New Size(120, 20)
        LblCONTPAQiAbonos.TabIndex = 55
        LblCONTPAQiAbonos.Text = "Label1"
        LblCONTPAQiAbonos.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LblDiferenciaAbonos
        ' 
        LblDiferenciaAbonos.BorderStyle = BorderStyle.FixedSingle
        LblDiferenciaAbonos.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblDiferenciaAbonos.ForeColor = Color.DarkGreen
        LblDiferenciaAbonos.Location = New Point(249, 17)
        LblDiferenciaAbonos.Name = "LblDiferenciaAbonos"
        LblDiferenciaAbonos.Size = New Size(138, 20)
        LblDiferenciaAbonos.TabIndex = 59
        LblDiferenciaAbonos.Text = "Label3"
        LblDiferenciaAbonos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblDiferenciaRegistros
        ' 
        LblDiferenciaRegistros.BorderStyle = BorderStyle.FixedSingle
        LblDiferenciaRegistros.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblDiferenciaRegistros.ForeColor = Color.DarkGreen
        LblDiferenciaRegistros.Location = New Point(249, 55)
        LblDiferenciaRegistros.Name = "LblDiferenciaRegistros"
        LblDiferenciaRegistros.Size = New Size(138, 20)
        LblDiferenciaRegistros.TabIndex = 51
        LblDiferenciaRegistros.Text = "Label1"
        LblDiferenciaRegistros.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblCONTPAQiRegistros
        ' 
        LblCONTPAQiRegistros.BorderStyle = BorderStyle.FixedSingle
        LblCONTPAQiRegistros.Location = New Point(393, 55)
        LblCONTPAQiRegistros.Name = "LblCONTPAQiRegistros"
        LblCONTPAQiRegistros.Size = New Size(120, 20)
        LblCONTPAQiRegistros.TabIndex = 49
        LblCONTPAQiRegistros.Text = "Label1"
        LblCONTPAQiRegistros.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(295, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(65, 15)
        Label7.TabIndex = 62
        Label7.Text = "Diferencias"
        ' 
        ' LblDiferenciaCargos
        ' 
        LblDiferenciaCargos.BorderStyle = BorderStyle.FixedSingle
        LblDiferenciaCargos.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        LblDiferenciaCargos.ForeColor = Color.DarkGreen
        LblDiferenciaCargos.Location = New Point(249, 36)
        LblDiferenciaCargos.Name = "LblDiferenciaCargos"
        LblDiferenciaCargos.Size = New Size(138, 20)
        LblDiferenciaCargos.TabIndex = 54
        LblDiferenciaCargos.Text = "Label3"
        LblDiferenciaCargos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblCONTPAQiCargos
        ' 
        LblCONTPAQiCargos.BorderStyle = BorderStyle.FixedSingle
        LblCONTPAQiCargos.Location = New Point(393, 36)
        LblCONTPAQiCargos.Name = "LblCONTPAQiCargos"
        LblCONTPAQiCargos.Size = New Size(120, 20)
        LblCONTPAQiCargos.TabIndex = 52
        LblCONTPAQiCargos.Text = "Label1"
        LblCONTPAQiCargos.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LblEmpleadosAbonos
        ' 
        LblEmpleadosAbonos.BorderStyle = BorderStyle.FixedSingle
        LblEmpleadosAbonos.Location = New Point(123, 17)
        LblEmpleadosAbonos.Name = "LblEmpleadosAbonos"
        LblEmpleadosAbonos.Size = New Size(120, 20)
        LblEmpleadosAbonos.TabIndex = 56
        LblEmpleadosAbonos.Text = "Label2"
        LblEmpleadosAbonos.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(59, 56)
        Label9.Name = "Label9"
        Label9.Size = New Size(58, 15)
        Label9.TabIndex = 64
        Label9.Text = "Registros:"
        ' 
        ' LblEmpleadosRegistros
        ' 
        LblEmpleadosRegistros.BorderStyle = BorderStyle.FixedSingle
        LblEmpleadosRegistros.Location = New Point(123, 55)
        LblEmpleadosRegistros.Name = "LblEmpleadosRegistros"
        LblEmpleadosRegistros.Size = New Size(120, 20)
        LblEmpleadosRegistros.TabIndex = 50
        LblEmpleadosRegistros.Text = "Label2"
        LblEmpleadosRegistros.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(70, 38)
        Label6.Name = "Label6"
        Label6.Size = New Size(47, 15)
        Label6.TabIndex = 61
        Label6.Text = "Cargos:"
        ' 
        ' LblEmpleadosCargos
        ' 
        LblEmpleadosCargos.BorderStyle = BorderStyle.FixedSingle
        LblEmpleadosCargos.Location = New Point(123, 36)
        LblEmpleadosCargos.Name = "LblEmpleadosCargos"
        LblEmpleadosCargos.Size = New Size(120, 20)
        LblEmpleadosCargos.TabIndex = 53
        LblEmpleadosCargos.Text = "Label2"
        LblEmpleadosCargos.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(66, 20)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 15)
        Label2.TabIndex = 58
        Label2.Text = "Abonos:"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(BtnCerrar)
        Panel4.Controls.Add(BtnExportar)
        Panel4.Dock = DockStyle.Right
        Panel4.Location = New Point(1102, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(200, 94)
        Panel4.TabIndex = 1
        ' 
        ' FrmRevisarInconsistencias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1311, 741)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmRevisarInconsistencias"
        Text = "FrmRevisarInconsistencias"
        CType(DataGridEmpleados, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridCONTPAQi, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridEmpleados As DataGridView
    Friend WithEvents DataGridCONTPAQi As DataGridView
    Friend WithEvents LblFecha As Label
    Friend WithEvents LblNumero As Label
    Friend WithEvents LblTipoPoliza As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ConCuenta As DataGridViewTextBoxColumn
    Friend WithEvents ConNombre As DataGridViewTextBoxColumn
    Friend WithEvents ConConcepto As DataGridViewTextBoxColumn
    Friend WithEvents ConReferencia As DataGridViewTextBoxColumn
    Friend WithEvents ConCargos As DataGridViewTextBoxColumn
    Friend WithEvents ConAbonos As DataGridViewTextBoxColumn
    Friend WithEvents EmpCuenta As DataGridViewTextBoxColumn
    Friend WithEvents EmpNombre As DataGridViewTextBoxColumn
    Friend WithEvents EmpConcepto As DataGridViewTextBoxColumn
    Friend WithEvents EmpRubro As DataGridViewTextBoxColumn
    Friend WithEvents EmpCargos As DataGridViewTextBoxColumn
    Friend WithEvents EmpAbonos As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents LblDiferenciaTrabajadores As Label
    Friend WithEvents LblCONTPAQiTrabajadores As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblEmpleadosTrabajadores As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblCONTPAQiAbonos As Label
    Friend WithEvents LblDiferenciaAbonos As Label
    Friend WithEvents LblDiferenciaRegistros As Label
    Friend WithEvents LblCONTPAQiRegistros As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblDiferenciaCargos As Label
    Friend WithEvents LblCONTPAQiCargos As Label
    Friend WithEvents LblEmpleadosAbonos As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblEmpleadosRegistros As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblEmpleadosCargos As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
End Class
