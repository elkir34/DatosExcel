<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNomiPaqAnaliza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNomiPaqAnaliza))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TableLayoutPanel1 = New TableLayoutPanel()
        ToolStrip1 = New ToolStrip()
        BtnAbrirArchivo = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        BtnAnalizar = New ToolStripButton()
        BtnAyuda = New ToolStripButton()
        ToolStripSeparator6 = New ToolStripSeparator()
        BtnConciliar = New ToolStripButton()
        MiDataGrid = New DataGridView()
        idCuenta = New DataGridViewTextBoxColumn()
        Cuenta = New DataGridViewTextBoxColumn()
        Trabajador = New DataGridViewTextBoxColumn()
        Tipo = New DataGridViewTextBoxColumn()
        Poliza = New DataGridViewTextBoxColumn()
        TipoPoliza = New DataGridViewTextBoxColumn()
        Rubro = New DataGridViewTextBoxColumn()
        Nominacion = New DataGridViewTextBoxColumn()
        Concepto = New DataGridViewTextBoxColumn()
        Cargo = New DataGridViewTextBoxColumn()
        Abono = New DataGridViewTextBoxColumn()
        Panel1 = New Panel()
        TxtUsuario = New TextBox()
        Label6 = New Label()
        TxtHora = New TextBox()
        Label5 = New Label()
        DtpFechaCaptura = New DateTimePicker()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        CbxTipoPoliza = New ComboBox()
        DtpFecha = New DateTimePicker()
        TxtNombreArchivo = New TextBox()
        TxtBuscar = New TextBox()
        Label1 = New Label()
        LblArchivoCargado = New Label()
        ToolStrip2 = New ToolStrip()
        BtnPrimero = New ToolStripButton()
        BtnAnterior = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        TxtRegistro = New ToolStripTextBox()
        TxtTotalRegistros = New ToolStripLabel()
        ToolStripSeparator4 = New ToolStripSeparator()
        BtnSiguiente = New ToolStripButton()
        BtnUltimo = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        BtnActualizar = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        MyProgressBar1 = New ToolStripProgressBar()
        LblProgreso = New ToolStripLabel()
        BtnAceptar = New ToolStripButton()
        LblAbonos = New ToolStripTextBox()
        LblCargos = New ToolStripTextBox()
        ToolStripLabel2 = New ToolStripLabel()
        LblSeleccion = New ToolStripTextBox()
        ToolStripLabel1 = New ToolStripLabel()
        Panel2 = New Panel()
        TxtCargos = New TextBox()
        TxtAbonos = New TextBox()
        TableLayoutPanel1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        ToolStrip2.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(ToolStrip1, 0, 0)
        TableLayoutPanel1.Controls.Add(MiDataGrid, 0, 2)
        TableLayoutPanel1.Controls.Add(Panel1, 0, 1)
        TableLayoutPanel1.Controls.Add(ToolStrip2, 0, 4)
        TableLayoutPanel1.Controls.Add(Panel2, 0, 3)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 5
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 55F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 66F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 67F))
        TableLayoutPanel1.Size = New Size(1145, 604)
        TableLayoutPanel1.TabIndex = 5
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Dock = DockStyle.Fill
        ToolStrip1.Items.AddRange(New ToolStripItem() {BtnAbrirArchivo, ToolStripSeparator2, BtnAnalizar, BtnAyuda, ToolStripSeparator6, BtnConciliar})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1145, 55)
        ToolStrip1.TabIndex = 2
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' BtnAbrirArchivo
        ' 
        BtnAbrirArchivo.Image = CType(resources.GetObject("BtnAbrirArchivo.Image"), Image)
        BtnAbrirArchivo.ImageScaling = ToolStripItemImageScaling.None
        BtnAbrirArchivo.ImageTransparentColor = Color.Magenta
        BtnAbrirArchivo.Name = "BtnAbrirArchivo"
        BtnAbrirArchivo.Size = New Size(79, 52)
        BtnAbrirArchivo.Text = "Abrir archivo"
        BtnAbrirArchivo.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 55)
        ' 
        ' BtnAnalizar
        ' 
        BtnAnalizar.AutoSize = False
        BtnAnalizar.Image = CType(resources.GetObject("BtnAnalizar.Image"), Image)
        BtnAnalizar.ImageScaling = ToolStripItemImageScaling.None
        BtnAnalizar.ImageTransparentColor = Color.Magenta
        BtnAnalizar.Name = "BtnAnalizar"
        BtnAnalizar.Size = New Size(79, 52)
        BtnAnalizar.Text = "Generar póliza"
        BtnAnalizar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' BtnAyuda
        ' 
        BtnAyuda.Alignment = ToolStripItemAlignment.Right
        BtnAyuda.AutoSize = False
        BtnAyuda.Image = CType(resources.GetObject("BtnAyuda.Image"), Image)
        BtnAyuda.ImageScaling = ToolStripItemImageScaling.None
        BtnAyuda.ImageTransparentColor = Color.Magenta
        BtnAyuda.Name = "BtnAyuda"
        BtnAyuda.Size = New Size(60, 52)
        BtnAyuda.Text = "Ayuda"
        BtnAyuda.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 55)
        ' 
        ' BtnConciliar
        ' 
        BtnConciliar.Image = CType(resources.GetObject("BtnConciliar.Image"), Image)
        BtnConciliar.ImageScaling = ToolStripItemImageScaling.None
        BtnConciliar.ImageTransparentColor = Color.Magenta
        BtnConciliar.Name = "BtnConciliar"
        BtnConciliar.Size = New Size(58, 52)
        BtnConciliar.Text = "Conciliar"
        BtnConciliar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' MiDataGrid
        ' 
        MiDataGrid.AllowUserToAddRows = False
        MiDataGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.Silver
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        MiDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        MiDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MiDataGrid.Columns.AddRange(New DataGridViewColumn() {idCuenta, Cuenta, Trabajador, Tipo, Poliza, TipoPoliza, Rubro, Nominacion, Concepto, Cargo, Abono})
        MiDataGrid.Dock = DockStyle.Fill
        MiDataGrid.EditMode = DataGridViewEditMode.EditOnEnter
        MiDataGrid.Location = New Point(3, 124)
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(1139, 374)
        MiDataGrid.TabIndex = 1
        ' 
        ' idCuenta
        ' 
        idCuenta.HeaderText = "idCuenta"
        idCuenta.Name = "idCuenta"
        idCuenta.ReadOnly = True
        idCuenta.Visible = False
        ' 
        ' Cuenta
        ' 
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        Cuenta.DefaultCellStyle = DataGridViewCellStyle2
        Cuenta.HeaderText = "Cuenta"
        Cuenta.Name = "Cuenta"
        Cuenta.ReadOnly = True
        Cuenta.Width = 50
        ' 
        ' Trabajador
        ' 
        Trabajador.HeaderText = "Trabajador"
        Trabajador.Name = "Trabajador"
        Trabajador.ReadOnly = True
        Trabajador.Width = 200
        ' 
        ' Tipo
        ' 
        Tipo.HeaderText = "Tipo"
        Tipo.Name = "Tipo"
        Tipo.ReadOnly = True
        Tipo.Width = 60
        ' 
        ' Poliza
        ' 
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        Poliza.DefaultCellStyle = DataGridViewCellStyle3
        Poliza.HeaderText = "Poliza"
        Poliza.Name = "Poliza"
        Poliza.ReadOnly = True
        Poliza.Width = 50
        ' 
        ' TipoPoliza
        ' 
        TipoPoliza.HeaderText = "TipoPoliza"
        TipoPoliza.Name = "TipoPoliza"
        TipoPoliza.ReadOnly = True
        ' 
        ' Rubro
        ' 
        Rubro.HeaderText = "Rubro"
        Rubro.Name = "Rubro"
        Rubro.ReadOnly = True
        ' 
        ' Nominacion
        ' 
        Nominacion.HeaderText = "Nominacion"
        Nominacion.Name = "Nominacion"
        Nominacion.ReadOnly = True
        ' 
        ' Concepto
        ' 
        Concepto.HeaderText = "Concepto"
        Concepto.Name = "Concepto"
        Concepto.ReadOnly = True
        Concepto.Width = 200
        ' 
        ' Cargo
        ' 
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Cargo.DefaultCellStyle = DataGridViewCellStyle4
        Cargo.HeaderText = "Cargo"
        Cargo.Name = "Cargo"
        Cargo.ReadOnly = True
        ' 
        ' Abono
        ' 
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Abono.DefaultCellStyle = DataGridViewCellStyle5
        Abono.HeaderText = "Abono"
        Abono.Name = "Abono"
        Abono.ReadOnly = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TxtUsuario)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(TxtHora)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(DtpFechaCaptura)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(CbxTipoPoliza)
        Panel1.Controls.Add(DtpFecha)
        Panel1.Controls.Add(TxtNombreArchivo)
        Panel1.Controls.Add(TxtBuscar)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(LblArchivoCargado)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1139, 60)
        Panel1.TabIndex = 4
        ' 
        ' TxtUsuario
        ' 
        TxtUsuario.Enabled = False
        TxtUsuario.Location = New Point(1053, 26)
        TxtUsuario.Name = "TxtUsuario"
        TxtUsuario.Size = New Size(77, 23)
        TxtUsuario.TabIndex = 13
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(1054, 8)
        Label6.Name = "Label6"
        Label6.Size = New Size(47, 15)
        Label6.TabIndex = 12
        Label6.Text = "Usuario"
        ' 
        ' TxtHora
        ' 
        TxtHora.Enabled = False
        TxtHora.Location = New Point(978, 26)
        TxtHora.Name = "TxtHora"
        TxtHora.Size = New Size(69, 23)
        TxtHora.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(979, 8)
        Label5.Name = "Label5"
        Label5.Size = New Size(33, 15)
        Label5.TabIndex = 10
        Label5.Text = "Hora"
        ' 
        ' DtpFechaCaptura
        ' 
        DtpFechaCaptura.Enabled = False
        DtpFechaCaptura.Location = New Point(752, 26)
        DtpFechaCaptura.Name = "DtpFechaCaptura"
        DtpFechaCaptura.Size = New Size(220, 23)
        DtpFechaCaptura.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(752, 8)
        Label4.Name = "Label4"
        Label4.Size = New Size(97, 15)
        Label4.TabIndex = 8
        Label4.Text = "Fecha de captura"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(376, 8)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 15)
        Label3.TabIndex = 7
        Label3.Text = "Tipo de póliza"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(150, 8)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 15)
        Label2.TabIndex = 6
        Label2.Text = "Fecha de movimiento"
        ' 
        ' CbxTipoPoliza
        ' 
        CbxTipoPoliza.FormattingEnabled = True
        CbxTipoPoliza.Location = New Point(376, 26)
        CbxTipoPoliza.Name = "CbxTipoPoliza"
        CbxTipoPoliza.Size = New Size(121, 23)
        CbxTipoPoliza.TabIndex = 5
        ' 
        ' DtpFecha
        ' 
        DtpFecha.Location = New Point(150, 26)
        DtpFecha.Name = "DtpFecha"
        DtpFecha.Size = New Size(220, 23)
        DtpFecha.TabIndex = 4
        ' 
        ' TxtNombreArchivo
        ' 
        TxtNombreArchivo.Enabled = False
        TxtNombreArchivo.Location = New Point(9, 26)
        TxtNombreArchivo.Name = "TxtNombreArchivo"
        TxtNombreArchivo.Size = New Size(135, 23)
        TxtNombreArchivo.TabIndex = 3
        ' 
        ' TxtBuscar
        ' 
        TxtBuscar.Location = New Point(503, 26)
        TxtBuscar.Name = "TxtBuscar"
        TxtBuscar.Size = New Size(243, 23)
        TxtBuscar.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(503, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 15)
        Label1.TabIndex = 1
        Label1.Text = "Concepto +"
        ' 
        ' LblArchivoCargado
        ' 
        LblArchivoCargado.AutoSize = True
        LblArchivoCargado.Location = New Point(9, 8)
        LblArchivoCargado.Name = "LblArchivoCargado"
        LblArchivoCargado.Size = New Size(101, 15)
        LblArchivoCargado.TabIndex = 0
        LblArchivoCargado.Text = "Número de póliza"
        ' 
        ' ToolStrip2
        ' 
        ToolStrip2.Dock = DockStyle.Fill
        ToolStrip2.Items.AddRange(New ToolStripItem() {BtnPrimero, BtnAnterior, ToolStripSeparator5, TxtRegistro, TxtTotalRegistros, ToolStripSeparator4, BtnSiguiente, BtnUltimo, ToolStripSeparator1, BtnActualizar, ToolStripSeparator3, MyProgressBar1, LblProgreso, BtnAceptar, LblAbonos, LblCargos, ToolStripLabel2, LblSeleccion, ToolStripLabel1})
        ToolStrip2.Location = New Point(0, 537)
        ToolStrip2.Name = "ToolStrip2"
        ToolStrip2.Size = New Size(1145, 67)
        ToolStrip2.TabIndex = 3
        ToolStrip2.Text = "ToolStrip2"
        ' 
        ' BtnPrimero
        ' 
        BtnPrimero.Image = CType(resources.GetObject("BtnPrimero.Image"), Image)
        BtnPrimero.ImageScaling = ToolStripItemImageScaling.None
        BtnPrimero.ImageTransparentColor = Color.Magenta
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(53, 64)
        BtnPrimero.Text = "Primero"
        BtnPrimero.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Image = CType(resources.GetObject("BtnAnterior.Image"), Image)
        BtnAnterior.ImageScaling = ToolStripItemImageScaling.None
        BtnAnterior.ImageTransparentColor = Color.Magenta
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(54, 64)
        BtnAnterior.Text = "Anterior"
        BtnAnterior.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 67)
        ' 
        ' TxtRegistro
        ' 
        TxtRegistro.Enabled = False
        TxtRegistro.Name = "TxtRegistro"
        TxtRegistro.Size = New Size(50, 67)
        TxtRegistro.TextBoxTextAlign = HorizontalAlignment.Center
        ' 
        ' TxtTotalRegistros
        ' 
        TxtTotalRegistros.Name = "TxtTotalRegistros"
        TxtTotalRegistros.Size = New Size(29, 64)
        TxtTotalRegistros.Text = "de 0"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 67)
        ' 
        ' BtnSiguiente
        ' 
        BtnSiguiente.Image = CType(resources.GetObject("BtnSiguiente.Image"), Image)
        BtnSiguiente.ImageScaling = ToolStripItemImageScaling.None
        BtnSiguiente.ImageTransparentColor = Color.Magenta
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(60, 64)
        BtnSiguiente.Text = "Siguiente"
        BtnSiguiente.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' BtnUltimo
        ' 
        BtnUltimo.AutoSize = False
        BtnUltimo.Image = CType(resources.GetObject("BtnUltimo.Image"), Image)
        BtnUltimo.ImageScaling = ToolStripItemImageScaling.None
        BtnUltimo.ImageTransparentColor = Color.Magenta
        BtnUltimo.Name = "BtnUltimo"
        BtnUltimo.Size = New Size(60, 51)
        BtnUltimo.Text = "Ultimo"
        BtnUltimo.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 67)
        ' 
        ' BtnActualizar
        ' 
        BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), Image)
        BtnActualizar.ImageScaling = ToolStripItemImageScaling.None
        BtnActualizar.ImageTransparentColor = Color.Magenta
        BtnActualizar.Name = "BtnActualizar"
        BtnActualizar.Size = New Size(63, 64)
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 67)
        ' 
        ' MyProgressBar1
        ' 
        MyProgressBar1.Name = "MyProgressBar1"
        MyProgressBar1.Size = New Size(100, 64)
        ' 
        ' LblProgreso
        ' 
        LblProgreso.Name = "LblProgreso"
        LblProgreso.Size = New Size(24, 64)
        LblProgreso.Text = "0/0"
        ' 
        ' BtnAceptar
        ' 
        BtnAceptar.Alignment = ToolStripItemAlignment.Right
        BtnAceptar.AutoSize = False
        BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), Image)
        BtnAceptar.ImageScaling = ToolStripItemImageScaling.None
        BtnAceptar.ImageTransparentColor = Color.Magenta
        BtnAceptar.Name = "BtnAceptar"
        BtnAceptar.Size = New Size(60, 51)
        BtnAceptar.Text = "Aceptar"
        BtnAceptar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' LblAbonos
        ' 
        LblAbonos.Alignment = ToolStripItemAlignment.Right
        LblAbonos.Name = "LblAbonos"
        LblAbonos.Size = New Size(100, 67)
        LblAbonos.TextBoxTextAlign = HorizontalAlignment.Right
        ' 
        ' LblCargos
        ' 
        LblCargos.Alignment = ToolStripItemAlignment.Right
        LblCargos.Name = "LblCargos"
        LblCargos.Size = New Size(100, 67)
        LblCargos.TextBoxTextAlign = HorizontalAlignment.Right
        ' 
        ' ToolStripLabel2
        ' 
        ToolStripLabel2.Alignment = ToolStripItemAlignment.Right
        ToolStripLabel2.AutoSize = False
        ToolStripLabel2.Name = "ToolStripLabel2"
        ToolStripLabel2.Size = New Size(20, 64)
        ToolStripLabel2.Text = "-"
        ' 
        ' LblSeleccion
        ' 
        LblSeleccion.Alignment = ToolStripItemAlignment.Right
        LblSeleccion.AutoSize = False
        LblSeleccion.Name = "LblSeleccion"
        LblSeleccion.Size = New Size(50, 67)
        LblSeleccion.TextBoxTextAlign = HorizontalAlignment.Center
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Alignment = ToolStripItemAlignment.Right
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(60, 64)
        ToolStripLabel1.Text = "Selección:"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(TxtCargos)
        Panel2.Controls.Add(TxtAbonos)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(879, 504)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(263, 30)
        Panel2.TabIndex = 5
        ' 
        ' TxtCargos
        ' 
        TxtCargos.Enabled = False
        TxtCargos.Location = New Point(54, 3)
        TxtCargos.Name = "TxtCargos"
        TxtCargos.Size = New Size(100, 23)
        TxtCargos.TabIndex = 1
        TxtCargos.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtAbonos
        ' 
        TxtAbonos.Enabled = False
        TxtAbonos.Location = New Point(160, 3)
        TxtAbonos.Name = "TxtAbonos"
        TxtAbonos.Size = New Size(100, 23)
        TxtAbonos.TabIndex = 0
        TxtAbonos.TextAlign = HorizontalAlignment.Right
        ' 
        ' FrmNomiPaqAnaliza
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1145, 604)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmNomiPaqAnaliza"
        Text = "Poliza generada desde NomiPaqi"
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ToolStrip2.ResumeLayout(False)
        ToolStrip2.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnAbrirArchivo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnAnalizar As ToolStripButton
    Friend WithEvents BtnAyuda As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents BtnConciliar As ToolStripButton
    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtNombreArchivo As TextBox
    Friend WithEvents TxtBuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblArchivoCargado As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents BtnPrimero As ToolStripButton
    Friend WithEvents BtnAnterior As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents TxtRegistro As ToolStripTextBox
    Friend WithEvents TxtTotalRegistros As ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BtnSiguiente As ToolStripButton
    Friend WithEvents BtnUltimo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MyProgressBar1 As ToolStripProgressBar
    Friend WithEvents LblProgreso As ToolStripLabel
    Friend WithEvents BtnAceptar As ToolStripButton
    Friend WithEvents LblAbonos As ToolStripTextBox
    Friend WithEvents LblCargos As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents LblSeleccion As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtCargos As TextBox
    Friend WithEvents TxtAbonos As TextBox
    Friend WithEvents CbxTipoPoliza As ComboBox
    Friend WithEvents DtpFecha As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DtpFechaCaptura As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtHora As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents idCuenta As DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents Trabajador As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents Poliza As DataGridViewTextBoxColumn
    Friend WithEvents TipoPoliza As DataGridViewTextBoxColumn
    Friend WithEvents Rubro As DataGridViewTextBoxColumn
    Friend WithEvents Nominacion As DataGridViewTextBoxColumn
    Friend WithEvents Concepto As DataGridViewTextBoxColumn
    Friend WithEvents Cargo As DataGridViewTextBoxColumn
    Friend WithEvents Abono As DataGridViewTextBoxColumn
End Class
