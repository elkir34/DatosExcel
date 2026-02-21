<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnalizarContabilidad
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
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        MiDataGrid = New DataGridView()
        TxtCargos = New TextBox()
        TxtAbonos = New TextBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        BtnRevisar = New Button()
        Label2 = New Label()
        TxtFechaFin = New TextBox()
        TxtFechaInicio = New TextBox()
        Label1 = New Label()
        BtnProcesar = New Button()
        Fecha = New DataGridViewTextBoxColumn()
        Numero = New DataGridViewTextBoxColumn()
        TipoPoliza = New DataGridViewTextBoxColumn()
        Registros = New DataGridViewTextBoxColumn()
        Cargos = New DataGridViewTextBoxColumn()
        Abonos = New DataGridViewTextBoxColumn()
        Importada = New DataGridViewTextBoxColumn()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        Panel1.SuspendLayout()
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
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        MiDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        MiDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MiDataGrid.Columns.AddRange(New DataGridViewColumn() {Fecha, Numero, TipoPoliza, Registros, Cargos, Abonos, Importada})
        MiDataGrid.Dock = DockStyle.Fill
        MiDataGrid.Location = New Point(3, 48)
        MiDataGrid.MultiSelect = False
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = SystemColors.Control
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle8.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        MiDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(814, 452)
        MiDataGrid.TabIndex = 2
        ' 
        ' TxtCargos
        ' 
        TxtCargos.Enabled = False
        TxtCargos.Location = New Point(164, 3)
        TxtCargos.Name = "TxtCargos"
        TxtCargos.Size = New Size(100, 23)
        TxtCargos.TabIndex = 6
        TxtCargos.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtAbonos
        ' 
        TxtAbonos.Enabled = False
        TxtAbonos.Location = New Point(58, 3)
        TxtAbonos.Name = "TxtAbonos"
        TxtAbonos.Size = New Size(100, 23)
        TxtAbonos.TabIndex = 5
        TxtAbonos.TextAlign = HorizontalAlignment.Right
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(MiDataGrid, 0, 1)
        TableLayoutPanel1.Controls.Add(Panel1, 0, 2)
        TableLayoutPanel1.Controls.Add(Panel2, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 9.052631F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 90.9473648F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 35F))
        TableLayoutPanel1.Size = New Size(820, 539)
        TableLayoutPanel1.TabIndex = 7
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TxtCargos)
        Panel1.Controls.Add(TxtAbonos)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(541, 506)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(276, 30)
        Panel1.TabIndex = 4
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(BtnRevisar)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(TxtFechaFin)
        Panel2.Controls.Add(TxtFechaInicio)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(BtnProcesar)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 3)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(814, 39)
        Panel2.TabIndex = 5
        ' 
        ' BtnRevisar
        ' 
        BtnRevisar.Location = New Point(106, 2)
        BtnRevisar.Name = "BtnRevisar"
        BtnRevisar.Size = New Size(97, 33)
        BtnRevisar.TabIndex = 9
        BtnRevisar.Text = "Revisar"
        BtnRevisar.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(687, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(12, 15)
        Label2.TabIndex = 8
        Label2.Text = "-"
        ' 
        ' TxtFechaFin
        ' 
        TxtFechaFin.Enabled = False
        TxtFechaFin.Location = New Point(705, 8)
        TxtFechaFin.Name = "TxtFechaFin"
        TxtFechaFin.Size = New Size(100, 23)
        TxtFechaFin.TabIndex = 7
        ' 
        ' TxtFechaInicio
        ' 
        TxtFechaInicio.Enabled = False
        TxtFechaInicio.Location = New Point(581, 8)
        TxtFechaInicio.Name = "TxtFechaInicio"
        TxtFechaInicio.Size = New Size(100, 23)
        TxtFechaInicio.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(524, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 15)
        Label1.TabIndex = 5
        Label1.Text = "Periodo:"
        ' 
        ' BtnProcesar
        ' 
        BtnProcesar.Location = New Point(3, 3)
        BtnProcesar.Name = "BtnProcesar"
        BtnProcesar.Size = New Size(97, 33)
        BtnProcesar.TabIndex = 4
        BtnProcesar.Text = "Procesar"
        BtnProcesar.UseVisualStyleBackColor = True
        ' 
        ' Fecha
        ' 
        Fecha.DataPropertyName = "Fecha"
        Fecha.HeaderText = "Fecha"
        Fecha.Name = "Fecha"
        Fecha.ReadOnly = True
        ' 
        ' Numero
        ' 
        Numero.DataPropertyName = "Numero"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        Numero.DefaultCellStyle = DataGridViewCellStyle3
        Numero.HeaderText = "Número"
        Numero.Name = "Numero"
        Numero.ReadOnly = True
        Numero.Width = 80
        ' 
        ' TipoPoliza
        ' 
        TipoPoliza.DataPropertyName = "TipoPoliza"
        TipoPoliza.HeaderText = "Tipo de póliza"
        TipoPoliza.Name = "TipoPoliza"
        TipoPoliza.ReadOnly = True
        TipoPoliza.Width = 150
        ' 
        ' Registros
        ' 
        Registros.DataPropertyName = "Registros"
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        Registros.DefaultCellStyle = DataGridViewCellStyle4
        Registros.HeaderText = "Registros"
        Registros.Name = "Registros"
        Registros.ReadOnly = True
        ' 
        ' Cargos
        ' 
        Cargos.DataPropertyName = "SumaCargos"
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Cargos.DefaultCellStyle = DataGridViewCellStyle5
        Cargos.HeaderText = "Cargos"
        Cargos.Name = "Cargos"
        Cargos.ReadOnly = True
        Cargos.Width = 120
        ' 
        ' Abonos
        ' 
        Abonos.DataPropertyName = "SumaAbonos"
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Abonos.DefaultCellStyle = DataGridViewCellStyle6
        Abonos.HeaderText = "Abonos"
        Abonos.Name = "Abonos"
        Abonos.ReadOnly = True
        Abonos.Width = 120
        ' 
        ' Importada
        ' 
        Importada.DataPropertyName = "Importada"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        Importada.DefaultCellStyle = DataGridViewCellStyle7
        Importada.HeaderText = "Importada"
        Importada.Name = "Importada"
        Importada.ReadOnly = True
        ' 
        ' FrmAnalizarContabilidad
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(820, 539)
        Controls.Add(TableLayoutPanel1)
        Name = "FrmAnalizarContabilidad"
        Text = "Analizar Contabilidad"
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents TxtCargos As TextBox
    Friend WithEvents TxtAbonos As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TxtFechaInicio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnProcesar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtFechaFin As TextBox
    Friend WithEvents BtnRevisar As Button
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Numero As DataGridViewTextBoxColumn
    Friend WithEvents TipoPoliza As DataGridViewTextBoxColumn
    Friend WithEvents Registros As DataGridViewTextBoxColumn
    Friend WithEvents Cargos As DataGridViewTextBoxColumn
    Friend WithEvents Abonos As DataGridViewTextBoxColumn
    Friend WithEvents Importada As DataGridViewTextBoxColumn
End Class
