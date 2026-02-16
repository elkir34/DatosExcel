<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConcilia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TxtSeleccionados = New TextBox()
        SelAbonoDeudores = New TextBox()
        SelCargoDeudores = New TextBox()
        SelAbonoContabilidad = New TextBox()
        SelCargoContabilidad = New TextBox()
        Label6 = New Label()
        TxtAbonoDeudores = New TextBox()
        TxtCargoDeudores = New TextBox()
        TxtAbonoContabilidad = New TextBox()
        TxtCargoContabilidad = New TextBox()
        MiDataGrid = New DataGridView()
        FechaAnaliza = New DataGridViewTextBoxColumn()
        Cargos = New DataGridViewTextBoxColumn()
        Abonos = New DataGridViewTextBoxColumn()
        CargoContabilidad = New DataGridViewTextBoxColumn()
        AbonoContabilidad = New DataGridViewTextBoxColumn()
        CargoDeudores = New DataGridViewTextBoxColumn()
        AbonoDeudores = New DataGridViewTextBoxColumn()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        BtnCopiarConciliacion = New ToolStripMenuItem()
        OpenFileDialog1 = New OpenFileDialog()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel2 = New Panel()
        Panel4 = New Panel()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' TxtSeleccionados
        ' 
        TxtSeleccionados.Enabled = False
        TxtSeleccionados.Location = New Point(88, 35)
        TxtSeleccionados.Margin = New Padding(4, 3, 4, 3)
        TxtSeleccionados.Name = "TxtSeleccionados"
        TxtSeleccionados.Size = New Size(50, 23)
        TxtSeleccionados.TabIndex = 54
        TxtSeleccionados.TextAlign = HorizontalAlignment.Center
        ' 
        ' SelAbonoDeudores
        ' 
        SelAbonoDeudores.Enabled = False
        SelAbonoDeudores.Location = New Point(522, 33)
        SelAbonoDeudores.Margin = New Padding(4, 3, 4, 3)
        SelAbonoDeudores.Name = "SelAbonoDeudores"
        SelAbonoDeudores.Size = New Size(116, 23)
        SelAbonoDeudores.TabIndex = 53
        SelAbonoDeudores.TextAlign = HorizontalAlignment.Right
        ' 
        ' SelCargoDeudores
        ' 
        SelCargoDeudores.Enabled = False
        SelCargoDeudores.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SelCargoDeudores.ForeColor = SystemColors.WindowText
        SelCargoDeudores.Location = New Point(400, 35)
        SelCargoDeudores.Margin = New Padding(4, 3, 4, 3)
        SelCargoDeudores.Name = "SelCargoDeudores"
        SelCargoDeudores.Size = New Size(116, 20)
        SelCargoDeudores.TabIndex = 52
        SelCargoDeudores.TextAlign = HorizontalAlignment.Right
        ' 
        ' SelAbonoContabilidad
        ' 
        SelAbonoContabilidad.Enabled = False
        SelAbonoContabilidad.Location = New Point(276, 35)
        SelAbonoContabilidad.Margin = New Padding(4, 3, 4, 3)
        SelAbonoContabilidad.Name = "SelAbonoContabilidad"
        SelAbonoContabilidad.Size = New Size(116, 23)
        SelAbonoContabilidad.TabIndex = 51
        SelAbonoContabilidad.TextAlign = HorizontalAlignment.Right
        ' 
        ' SelCargoContabilidad
        ' 
        SelCargoContabilidad.Enabled = False
        SelCargoContabilidad.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SelCargoContabilidad.ForeColor = SystemColors.WindowText
        SelCargoContabilidad.Location = New Point(155, 35)
        SelCargoContabilidad.Margin = New Padding(4, 3, 4, 3)
        SelCargoContabilidad.Name = "SelCargoContabilidad"
        SelCargoContabilidad.Size = New Size(116, 20)
        SelCargoContabilidad.TabIndex = 50
        SelCargoContabilidad.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(22, 38)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(60, 15)
        Label6.TabIndex = 49
        Label6.Text = "Seleccion:"
        ' 
        ' TxtAbonoDeudores
        ' 
        TxtAbonoDeudores.Enabled = False
        TxtAbonoDeudores.Location = New Point(522, 5)
        TxtAbonoDeudores.Margin = New Padding(4, 3, 4, 3)
        TxtAbonoDeudores.Name = "TxtAbonoDeudores"
        TxtAbonoDeudores.Size = New Size(116, 23)
        TxtAbonoDeudores.TabIndex = 48
        TxtAbonoDeudores.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtCargoDeudores
        ' 
        TxtCargoDeudores.Enabled = False
        TxtCargoDeudores.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TxtCargoDeudores.ForeColor = Color.Blue
        TxtCargoDeudores.Location = New Point(400, 6)
        TxtCargoDeudores.Margin = New Padding(4, 3, 4, 3)
        TxtCargoDeudores.Name = "TxtCargoDeudores"
        TxtCargoDeudores.Size = New Size(116, 20)
        TxtCargoDeudores.TabIndex = 47
        TxtCargoDeudores.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtAbonoContabilidad
        ' 
        TxtAbonoContabilidad.Enabled = False
        TxtAbonoContabilidad.Location = New Point(276, 6)
        TxtAbonoContabilidad.Margin = New Padding(4, 3, 4, 3)
        TxtAbonoContabilidad.Name = "TxtAbonoContabilidad"
        TxtAbonoContabilidad.Size = New Size(116, 23)
        TxtAbonoContabilidad.TabIndex = 46
        TxtAbonoContabilidad.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtCargoContabilidad
        ' 
        TxtCargoContabilidad.Enabled = False
        TxtCargoContabilidad.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TxtCargoContabilidad.ForeColor = Color.Blue
        TxtCargoContabilidad.Location = New Point(155, 6)
        TxtCargoContabilidad.Margin = New Padding(4, 3, 4, 3)
        TxtCargoContabilidad.Name = "TxtCargoContabilidad"
        TxtCargoContabilidad.Size = New Size(116, 20)
        TxtCargoContabilidad.TabIndex = 45
        TxtCargoContabilidad.TextAlign = HorizontalAlignment.Right
        ' 
        ' MiDataGrid
        ' 
        MiDataGrid.AllowUserToAddRows = False
        MiDataGrid.AllowUserToDeleteRows = False
        MiDataGrid.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.BackColor = Color.Silver
        DataGridViewCellStyle7.ForeColor = Color.Black
        DataGridViewCellStyle7.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle7.SelectionForeColor = Color.White
        MiDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        MiDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MiDataGrid.Columns.AddRange(New DataGridViewColumn() {FechaAnaliza, Cargos, Abonos, CargoContabilidad, AbonoContabilidad, CargoDeudores, AbonoDeudores})
        MiDataGrid.ContextMenuStrip = ContextMenuStrip1
        MiDataGrid.Dock = DockStyle.Fill
        MiDataGrid.Location = New Point(4, 3)
        MiDataGrid.Margin = New Padding(4, 3, 4, 3)
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(1168, 475)
        MiDataGrid.TabIndex = 44
        ' 
        ' FechaAnaliza
        ' 
        FechaAnaliza.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        FechaAnaliza.DataPropertyName = "Fecha0"
        DataGridViewCellStyle8.Format = "D"
        DataGridViewCellStyle8.NullValue = Nothing
        FechaAnaliza.DefaultCellStyle = DataGridViewCellStyle8
        FechaAnaliza.HeaderText = "Fecha"
        FechaAnaliza.Name = "FechaAnaliza"
        FechaAnaliza.ReadOnly = True
        ' 
        ' Cargos
        ' 
        Cargos.DataPropertyName = "Cargos"
        Cargos.HeaderText = "Cargos"
        Cargos.Name = "Cargos"
        Cargos.ReadOnly = True
        Cargos.Width = 80
        ' 
        ' Abonos
        ' 
        Abonos.DataPropertyName = "Abonos"
        Abonos.HeaderText = "Abonos"
        Abonos.Name = "Abonos"
        Abonos.ReadOnly = True
        Abonos.Width = 80
        ' 
        ' CargoContabilidad
        ' 
        CargoContabilidad.DataPropertyName = "CargoContabilidad"
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        CargoContabilidad.DefaultCellStyle = DataGridViewCellStyle9
        CargoContabilidad.HeaderText = "Cargo CONTABILIDAD"
        CargoContabilidad.Name = "CargoContabilidad"
        CargoContabilidad.ReadOnly = True
        CargoContabilidad.Width = 105
        ' 
        ' AbonoContabilidad
        ' 
        AbonoContabilidad.DataPropertyName = "AbonoContabilidad"
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        AbonoContabilidad.DefaultCellStyle = DataGridViewCellStyle10
        AbonoContabilidad.HeaderText = "Abono CONTABILIDAD"
        AbonoContabilidad.Name = "AbonoContabilidad"
        AbonoContabilidad.ReadOnly = True
        AbonoContabilidad.Width = 105
        ' 
        ' CargoDeudores
        ' 
        CargoDeudores.DataPropertyName = "CargoDeudores"
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        CargoDeudores.DefaultCellStyle = DataGridViewCellStyle11
        CargoDeudores.HeaderText = "Cargo DEUDORES"
        CargoDeudores.Name = "CargoDeudores"
        CargoDeudores.ReadOnly = True
        CargoDeudores.Width = 105
        ' 
        ' AbonoDeudores
        ' 
        AbonoDeudores.DataPropertyName = "AbonoDeudores"
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        AbonoDeudores.DefaultCellStyle = DataGridViewCellStyle12
        AbonoDeudores.HeaderText = "Abono DEUDORES"
        AbonoDeudores.Name = "AbonoDeudores"
        AbonoDeudores.ReadOnly = True
        AbonoDeudores.Width = 105
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {BtnCopiarConciliacion})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(110, 26)
        ' 
        ' BtnCopiarConciliacion
        ' 
        BtnCopiarConciliacion.Name = "BtnCopiarConciliacion"
        BtnCopiarConciliacion.Size = New Size(109, 22)
        BtnCopiarConciliacion.Text = "Copiar"
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(Panel2, 0, 1)
        TableLayoutPanel1.Controls.Add(MiDataGrid, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 67F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TableLayoutPanel1.Size = New Size(1176, 548)
        TableLayoutPanel1.TabIndex = 63
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel4)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(4, 484)
        Panel2.Margin = New Padding(4, 3, 4, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1168, 61)
        Panel2.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(SelAbonoDeudores)
        Panel4.Controls.Add(TxtAbonoDeudores)
        Panel4.Controls.Add(TxtCargoContabilidad)
        Panel4.Controls.Add(SelAbonoContabilidad)
        Panel4.Controls.Add(TxtSeleccionados)
        Panel4.Controls.Add(TxtAbonoContabilidad)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(SelCargoDeudores)
        Panel4.Controls.Add(SelCargoContabilidad)
        Panel4.Controls.Add(TxtCargoDeudores)
        Panel4.Dock = DockStyle.Right
        Panel4.Location = New Point(519, 0)
        Panel4.Margin = New Padding(4, 3, 4, 3)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(649, 61)
        Panel4.TabIndex = 57
        ' 
        ' BackgroundWorker1
        ' 
        BackgroundWorker1.WorkerReportsProgress = True
        ' 
        ' FrmConcilia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1176, 548)
        Controls.Add(TableLayoutPanel1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "FrmConcilia"
        Text = "Conciliación entre contabilidad y estados de cuenta"
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents TxtSeleccionados As TextBox
    Friend WithEvents SelAbonoDeudores As TextBox
    Friend WithEvents SelCargoDeudores As TextBox
    Friend WithEvents SelAbonoContabilidad As TextBox
    Friend WithEvents SelCargoContabilidad As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtAbonoDeudores As TextBox
    Friend WithEvents TxtCargoDeudores As TextBox
    Friend WithEvents TxtAbonoContabilidad As TextBox
    Friend WithEvents TxtCargoContabilidad As TextBox
    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FechaAnaliza As DataGridViewTextBoxColumn
    Friend WithEvents Cargos As DataGridViewTextBoxColumn
    Friend WithEvents Abonos As DataGridViewTextBoxColumn
    Friend WithEvents CargoContabilidad As DataGridViewTextBoxColumn
    Friend WithEvents AbonoContabilidad As DataGridViewTextBoxColumn
    Friend WithEvents CargoDeudores As DataGridViewTextBoxColumn
    Friend WithEvents AbonoDeudores As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BtnCopiarConciliacion As ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
