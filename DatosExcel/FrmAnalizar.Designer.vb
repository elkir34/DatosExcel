<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnalizar
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnalizar))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        LblProgreso = New ToolStripLabel()
        MyProgressBar1 = New ToolStripProgressBar()
        ToolStripSeparator1 = New ToolStripSeparator()
        BtnUltimo = New ToolStripButton()
        BtnSiguiente = New ToolStripButton()
        TxtRegistro = New ToolStripTextBox()
        BtnAnterior = New ToolStripButton()
        BtnAceptar = New ToolStripButton()
        BtnPrimero = New ToolStripButton()
        TableLayoutPanel1 = New TableLayoutPanel()
        ToolStrip1 = New ToolStrip()
        BtnImportar = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        BtnAyuda = New ToolStripButton()
        MiDataGrid = New DataGridView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        BtnCopiar = New ToolStripMenuItem()
        ToolStrip2 = New ToolStrip()
        ToolStripSeparator5 = New ToolStripSeparator()
        TxtTotalRegistros = New ToolStripLabel()
        ToolStripSeparator4 = New ToolStripSeparator()
        BtnActualizar = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        LblAbonos = New ToolStripTextBox()
        LblCargos = New ToolStripTextBox()
        ToolStripLabel2 = New ToolStripLabel()
        LblSeleccion = New ToolStripTextBox()
        ToolStripLabel1 = New ToolStripLabel()
        Panel1 = New Panel()
        TxtCargos = New TextBox()
        TxtAbonos = New TextBox()
        OpenFileDialog1 = New OpenFileDialog()
        Fecha = New DataGridViewTextBoxColumn()
        Numeor = New DataGridViewTextBoxColumn()
        TipoPoliza = New DataGridViewTextBoxColumn()
        Registros = New DataGridViewTextBoxColumn()
        Cargos = New DataGridViewTextBoxColumn()
        Abonos = New DataGridViewTextBoxColumn()
        TableLayoutPanel1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        ToolStrip2.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' BackgroundWorker1
        ' 
        BackgroundWorker1.WorkerReportsProgress = True
        ' 
        ' LblProgreso
        ' 
        LblProgreso.Name = "LblProgreso"
        LblProgreso.Size = New Size(24, 59)
        LblProgreso.Text = "0/0"
        ' 
        ' MyProgressBar1
        ' 
        MyProgressBar1.Name = "MyProgressBar1"
        MyProgressBar1.Size = New Size(100, 59)
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 62)
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
        ' BtnSiguiente
        ' 
        BtnSiguiente.Image = CType(resources.GetObject("BtnSiguiente.Image"), Image)
        BtnSiguiente.ImageScaling = ToolStripItemImageScaling.None
        BtnSiguiente.ImageTransparentColor = Color.Magenta
        BtnSiguiente.Name = "BtnSiguiente"
        BtnSiguiente.Size = New Size(60, 59)
        BtnSiguiente.Text = "Siguiente"
        BtnSiguiente.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' TxtRegistro
        ' 
        TxtRegistro.Enabled = False
        TxtRegistro.Name = "TxtRegistro"
        TxtRegistro.Size = New Size(50, 62)
        TxtRegistro.TextBoxTextAlign = HorizontalAlignment.Center
        ' 
        ' BtnAnterior
        ' 
        BtnAnterior.Image = CType(resources.GetObject("BtnAnterior.Image"), Image)
        BtnAnterior.ImageScaling = ToolStripItemImageScaling.None
        BtnAnterior.ImageTransparentColor = Color.Magenta
        BtnAnterior.Name = "BtnAnterior"
        BtnAnterior.Size = New Size(54, 59)
        BtnAnterior.Text = "Anterior"
        BtnAnterior.TextImageRelation = TextImageRelation.ImageAboveText
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
        ' BtnPrimero
        ' 
        BtnPrimero.Image = CType(resources.GetObject("BtnPrimero.Image"), Image)
        BtnPrimero.ImageScaling = ToolStripItemImageScaling.None
        BtnPrimero.ImageTransparentColor = Color.Magenta
        BtnPrimero.Name = "BtnPrimero"
        BtnPrimero.Size = New Size(53, 59)
        BtnPrimero.Text = "Primero"
        BtnPrimero.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(ToolStrip1, 0, 0)
        TableLayoutPanel1.Controls.Add(MiDataGrid, 0, 1)
        TableLayoutPanel1.Controls.Add(ToolStrip2, 0, 3)
        TableLayoutPanel1.Controls.Add(Panel1, 0, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 4
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 55F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 62F))
        TableLayoutPanel1.Size = New Size(945, 617)
        TableLayoutPanel1.TabIndex = 4
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Dock = DockStyle.Fill
        ToolStrip1.Items.AddRange(New ToolStripItem() {BtnImportar, ToolStripSeparator2, BtnAyuda})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(945, 55)
        ToolStrip1.TabIndex = 2
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' BtnImportar
        ' 
        BtnImportar.Image = CType(resources.GetObject("BtnImportar.Image"), Image)
        BtnImportar.ImageScaling = ToolStripItemImageScaling.None
        BtnImportar.ImageTransparentColor = Color.Magenta
        BtnImportar.Name = "BtnImportar"
        BtnImportar.Size = New Size(91, 52)
        BtnImportar.Text = "Importar póliza"
        BtnImportar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 55)
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
        ' MiDataGrid
        ' 
        MiDataGrid.AllowUserToAddRows = False
        MiDataGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.Silver
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        MiDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        MiDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        MiDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MiDataGrid.Columns.AddRange(New DataGridViewColumn() {Fecha, Numeor, TipoPoliza, Registros, Cargos, Abonos})
        MiDataGrid.ContextMenuStrip = ContextMenuStrip1
        MiDataGrid.Dock = DockStyle.Fill
        MiDataGrid.Location = New Point(3, 58)
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        MiDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(939, 459)
        MiDataGrid.TabIndex = 1
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
        ' ToolStrip2
        ' 
        ToolStrip2.Dock = DockStyle.Fill
        ToolStrip2.Items.AddRange(New ToolStripItem() {BtnPrimero, BtnAnterior, ToolStripSeparator5, TxtRegistro, TxtTotalRegistros, ToolStripSeparator4, BtnSiguiente, BtnUltimo, ToolStripSeparator1, BtnActualizar, ToolStripSeparator3, MyProgressBar1, LblProgreso, BtnAceptar, LblAbonos, LblCargos, ToolStripLabel2, LblSeleccion, ToolStripLabel1})
        ToolStrip2.Location = New Point(0, 555)
        ToolStrip2.Name = "ToolStrip2"
        ToolStrip2.Size = New Size(945, 62)
        ToolStrip2.TabIndex = 3
        ToolStrip2.Text = "ToolStrip2"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 62)
        ' 
        ' TxtTotalRegistros
        ' 
        TxtTotalRegistros.Name = "TxtTotalRegistros"
        TxtTotalRegistros.Size = New Size(29, 59)
        TxtTotalRegistros.Text = "de 0"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 62)
        ' 
        ' BtnActualizar
        ' 
        BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), Image)
        BtnActualizar.ImageScaling = ToolStripItemImageScaling.None
        BtnActualizar.ImageTransparentColor = Color.Magenta
        BtnActualizar.Name = "BtnActualizar"
        BtnActualizar.Size = New Size(63, 59)
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 62)
        ' 
        ' LblAbonos
        ' 
        LblAbonos.Alignment = ToolStripItemAlignment.Right
        LblAbonos.Name = "LblAbonos"
        LblAbonos.Size = New Size(100, 62)
        LblAbonos.TextBoxTextAlign = HorizontalAlignment.Right
        ' 
        ' LblCargos
        ' 
        LblCargos.Alignment = ToolStripItemAlignment.Right
        LblCargos.Name = "LblCargos"
        LblCargos.Size = New Size(100, 62)
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
        ToolStripLabel1.Size = New Size(60, 59)
        ToolStripLabel1.Text = "Selección:"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TxtCargos)
        Panel1.Controls.Add(TxtAbonos)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(560, 523)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(382, 29)
        Panel1.TabIndex = 4
        ' 
        ' TxtCargos
        ' 
        TxtCargos.Enabled = False
        TxtCargos.Location = New Point(50, 3)
        TxtCargos.Name = "TxtCargos"
        TxtCargos.Size = New Size(100, 23)
        TxtCargos.TabIndex = 3
        TxtCargos.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtAbonos
        ' 
        TxtAbonos.Enabled = False
        TxtAbonos.Location = New Point(156, 3)
        TxtAbonos.Name = "TxtAbonos"
        TxtAbonos.Size = New Size(100, 23)
        TxtAbonos.TabIndex = 2
        TxtAbonos.TextAlign = HorizontalAlignment.Right
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        OpenFileDialog1.Filter = "Archivos de Excel (*.xls)|*.xlsx|Todos los archivos (*.*)|*.*"
        ' 
        ' Fecha
        ' 
        Fecha.HeaderText = "Fecha"
        Fecha.Name = "Fecha"
        Fecha.ReadOnly = True
        ' 
        ' Numeor
        ' 
        Numeor.HeaderText = "Número"
        Numeor.Name = "Numeor"
        Numeor.ReadOnly = True
        ' 
        ' TipoPoliza
        ' 
        TipoPoliza.HeaderText = "Tipo de póliza"
        TipoPoliza.Name = "TipoPoliza"
        TipoPoliza.ReadOnly = True
        TipoPoliza.Width = 200
        ' 
        ' Registros
        ' 
        Registros.HeaderText = "Registros"
        Registros.Name = "Registros"
        Registros.ReadOnly = True
        ' 
        ' Cargos
        ' 
        Cargos.HeaderText = "Cargos"
        Cargos.Name = "Cargos"
        Cargos.ReadOnly = True
        ' 
        ' Abonos
        ' 
        Abonos.HeaderText = "Abonos"
        Abonos.Name = "Abonos"
        Abonos.ReadOnly = True
        ' 
        ' FrmAnalizar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(945, 617)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmAnalizar"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Analizar datos para importar..."
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        ToolStrip2.ResumeLayout(False)
        ToolStrip2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents LblProgreso As ToolStripLabel
    Friend WithEvents MyProgressBar1 As ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BtnUltimo As ToolStripButton
    Friend WithEvents BtnSiguiente As ToolStripButton
    Friend WithEvents TxtRegistro As ToolStripTextBox
    Friend WithEvents BtnAnterior As ToolStripButton
    Friend WithEvents BtnAceptar As ToolStripButton
    Friend WithEvents BtnPrimero As ToolStripButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnImportar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BtnAyuda As ToolStripButton
    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents BtnActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents TxtTotalRegistros As ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BtnCopiar As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtCargos As TextBox
    Friend WithEvents TxtAbonos As TextBox
    Friend WithEvents LblAbonos As ToolStripTextBox
    Friend WithEvents LblCargos As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents LblSeleccion As ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Numeor As DataGridViewTextBoxColumn
    Friend WithEvents TipoPoliza As DataGridViewTextBoxColumn
    Friend WithEvents Registros As DataGridViewTextBoxColumn
    Friend WithEvents Cargos As DataGridViewTextBoxColumn
    Friend WithEvents Abonos As DataGridViewTextBoxColumn
End Class
