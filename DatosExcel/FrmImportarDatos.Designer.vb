<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImportarDatos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImportarDatos))
        MiDataGrid = New DataGridView()
        Cuenta = New DataGridViewTextBoxColumn()
        TipoTrabajador = New DataGridViewTextBoxColumn()
        Nombre = New DataGridViewTextBoxColumn()
        Fecha = New DataGridViewTextBoxColumn()
        TipoPoliza = New DataGridViewTextBoxColumn()
        Numero = New DataGridViewTextBoxColumn()
        Concepto = New DataGridViewTextBoxColumn()
        Referencia = New DataGridViewTextBoxColumn()
        Cargos = New DataGridViewTextBoxColumn()
        Abonos = New DataGridViewTextBoxColumn()
        idEmpleado = New DataGridViewTextBoxColumn()
        idTipoPoliza = New DataGridViewTextBoxColumn()
        ClaveRubro = New DataGridViewTextBoxColumn()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        BtnCopiar = New ToolStripMenuItem()
        ToolStrip1 = New ToolStrip()
        BtnAbrirArchivo = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        BtnAnalizar = New ToolStripButton()
        BtnAyuda = New ToolStripButton()
        ToolStripSeparator6 = New ToolStripSeparator()
        BtnConciliar = New ToolStripButton()
        OpenFileDialog1 = New OpenFileDialog()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        TxtNombreArchivo = New TextBox()
        LblArchivoCargado = New Label()
        ToolStrip2 = New ToolStrip()
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
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
        ToolStrip2.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
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
        MiDataGrid.Columns.AddRange(New DataGridViewColumn() {Cuenta, TipoTrabajador, Nombre, Fecha, TipoPoliza, Numero, Concepto, Referencia, Cargos, Abonos, idEmpleado, idTipoPoliza, ClaveRubro})
        MiDataGrid.ContextMenuStrip = ContextMenuStrip1
        MiDataGrid.Dock = DockStyle.Fill
        MiDataGrid.EditMode = DataGridViewEditMode.EditOnEnter
        MiDataGrid.Location = New Point(3, 99)
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(1200, 408)
        MiDataGrid.TabIndex = 1
        ' 
        ' Cuenta
        ' 
        Cuenta.DataPropertyName = "Cuenta"
        Cuenta.HeaderText = "Cuenta"
        Cuenta.Name = "Cuenta"
        Cuenta.ReadOnly = True
        Cuenta.Width = 50
        ' 
        ' TipoTrabajador
        ' 
        TipoTrabajador.DataPropertyName = "TipoTrabajador"
        TipoTrabajador.HeaderText = "Tipo de trabajador"
        TipoTrabajador.Name = "TipoTrabajador"
        TipoTrabajador.ReadOnly = True
        TipoTrabajador.Width = 80
        ' 
        ' Nombre
        ' 
        Nombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Nombre.DataPropertyName = "Nombre"
        Nombre.HeaderText = "Nombre"
        Nombre.Name = "Nombre"
        Nombre.ReadOnly = True
        ' 
        ' Fecha
        ' 
        Fecha.DataPropertyName = "Fecha"
        Fecha.HeaderText = "Fecha"
        Fecha.Name = "Fecha"
        Fecha.ReadOnly = True
        Fecha.Width = 80
        ' 
        ' TipoPoliza
        ' 
        TipoPoliza.DataPropertyName = "TipoPoliza"
        TipoPoliza.HeaderText = "Tipo de póliza"
        TipoPoliza.Name = "TipoPoliza"
        TipoPoliza.ReadOnly = True
        ' 
        ' Numero
        ' 
        Numero.DataPropertyName = "Numero"
        Numero.HeaderText = "Número de póliza"
        Numero.Name = "Numero"
        Numero.ReadOnly = True
        Numero.Width = 60
        ' 
        ' Concepto
        ' 
        Concepto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Concepto.DataPropertyName = "Concepto"
        Concepto.HeaderText = "Concepto"
        Concepto.Name = "Concepto"
        Concepto.ReadOnly = True
        ' 
        ' Referencia
        ' 
        Referencia.DataPropertyName = "Referencia"
        Referencia.HeaderText = "Referencia"
        Referencia.Name = "Referencia"
        Referencia.ReadOnly = True
        ' 
        ' Cargos
        ' 
        Cargos.DataPropertyName = "Cargos"
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Cargos.DefaultCellStyle = DataGridViewCellStyle2
        Cargos.HeaderText = "Cargos"
        Cargos.Name = "Cargos"
        Cargos.ReadOnly = True
        ' 
        ' Abonos
        ' 
        Abonos.DataPropertyName = "Abonos"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Abonos.DefaultCellStyle = DataGridViewCellStyle3
        Abonos.HeaderText = "Abonos"
        Abonos.Name = "Abonos"
        Abonos.ReadOnly = True
        ' 
        ' idEmpleado
        ' 
        idEmpleado.DataPropertyName = "idEmpleado"
        idEmpleado.HeaderText = "idEmpleado"
        idEmpleado.Name = "idEmpleado"
        idEmpleado.ReadOnly = True
        idEmpleado.Visible = False
        ' 
        ' idTipoPoliza
        ' 
        idTipoPoliza.DataPropertyName = "idTipoPoliza"
        idTipoPoliza.HeaderText = "idTipoPoliza"
        idTipoPoliza.Name = "idTipoPoliza"
        idTipoPoliza.ReadOnly = True
        idTipoPoliza.Visible = False
        ' 
        ' ClaveRubro
        ' 
        ClaveRubro.DataPropertyName = "ClaveRubro"
        ClaveRubro.HeaderText = "ClaveRubro"
        ClaveRubro.Name = "ClaveRubro"
        ClaveRubro.ReadOnly = True
        ClaveRubro.Visible = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {BtnCopiar})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(110, 26)
        ' 
        ' BtnCopiar
        ' 
        BtnCopiar.Name = "BtnCopiar"
        BtnCopiar.Size = New Size(109, 22)
        BtnCopiar.Text = "Copiar"
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Dock = DockStyle.Fill
        ToolStrip1.Items.AddRange(New ToolStripItem() {BtnAbrirArchivo, ToolStripSeparator2, BtnAnalizar, BtnAyuda, ToolStripSeparator6, BtnConciliar})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1206, 55)
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
        BtnAnalizar.Text = "Analizar datos"
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
        BtnConciliar.Enabled = False
        BtnConciliar.Image = CType(resources.GetObject("BtnConciliar.Image"), Image)
        BtnConciliar.ImageScaling = ToolStripItemImageScaling.None
        BtnConciliar.ImageTransparentColor = Color.Magenta
        BtnConciliar.Name = "BtnConciliar"
        BtnConciliar.Size = New Size(58, 52)
        BtnConciliar.Text = "Conciliar"
        BtnConciliar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        OpenFileDialog1.Filter = "Archivos de Excel (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
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
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 41F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 36F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 67F))
        TableLayoutPanel1.Size = New Size(1206, 613)
        TableLayoutPanel1.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TxtNombreArchivo)
        Panel1.Controls.Add(LblArchivoCargado)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(3, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1200, 35)
        Panel1.TabIndex = 4
        ' 
        ' TxtNombreArchivo
        ' 
        TxtNombreArchivo.Enabled = False
        TxtNombreArchivo.Location = New Point(60, 5)
        TxtNombreArchivo.Name = "TxtNombreArchivo"
        TxtNombreArchivo.Size = New Size(651, 23)
        TxtNombreArchivo.TabIndex = 3
        ' 
        ' LblArchivoCargado
        ' 
        LblArchivoCargado.AutoSize = True
        LblArchivoCargado.Location = New Point(3, 8)
        LblArchivoCargado.Name = "LblArchivoCargado"
        LblArchivoCargado.Size = New Size(51, 15)
        LblArchivoCargado.TabIndex = 0
        LblArchivoCargado.Text = "Archivo:"
        ' 
        ' ToolStrip2
        ' 
        ToolStrip2.Dock = DockStyle.Fill
        ToolStrip2.Items.AddRange(New ToolStripItem() {MyProgressBar1, LblProgreso, BtnAceptar, LblAbonos, LblCargos, ToolStripLabel2, LblSeleccion, ToolStripLabel1})
        ToolStrip2.Location = New Point(0, 546)
        ToolStrip2.Name = "ToolStrip2"
        ToolStrip2.Size = New Size(1206, 67)
        ToolStrip2.TabIndex = 3
        ToolStrip2.Text = "ToolStrip2"
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
        Panel2.Location = New Point(940, 513)
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
        ' BackgroundWorker1
        ' 
        BackgroundWorker1.WorkerReportsProgress = True
        ' 
        ' FrmImportarDatos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1206, 613)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmImportarDatos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Cargar datos de Compaqi..."
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ToolStrip2.ResumeLayout(False)
        ToolStrip2.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnAbrirArchivo As ToolStripButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents MyProgressBar1 As ToolStripProgressBar
    Friend WithEvents LblProgreso As ToolStripLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnAnalizar As ToolStripButton
    Friend WithEvents BtnAyuda As ToolStripButton
    Friend WithEvents BtnAceptar As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblArchivoCargado As Label
    Friend WithEvents TxtNombreArchivo As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtCargos As TextBox
    Friend WithEvents TxtAbonos As TextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents LblSeleccion As ToolStripTextBox
    Friend WithEvents LblCargos As ToolStripTextBox
    Friend WithEvents LblAbonos As ToolStripTextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BtnCopiar As ToolStripMenuItem
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents BtnConciliar As ToolStripButton
    Friend WithEvents Cuenta As DataGridViewTextBoxColumn
    Friend WithEvents TipoTrabajador As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents TipoPoliza As DataGridViewTextBoxColumn
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents Concepto As DataGridViewTextBoxColumn
    Friend WithEvents Referencia As DataGridViewTextBoxColumn
    Friend WithEvents Cargos As DataGridViewTextBoxColumn
    Friend WithEvents Abonos As DataGridViewTextBoxColumn
    Friend WithEvents idEmpleado As DataGridViewTextBoxColumn
    Friend WithEvents idTipoPoliza As DataGridViewTextBoxColumn
    Friend WithEvents ClaveRubro As DataGridViewTextBoxColumn

End Class
