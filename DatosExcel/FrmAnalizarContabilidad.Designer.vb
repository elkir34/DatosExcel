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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        MiDataGrid = New DataGridView()
        BtnProcesar = New Button()
        TxtCargos = New TextBox()
        TxtAbonos = New TextBox()
        CType(MiDataGrid, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MiDataGrid
        ' 
        MiDataGrid.AllowUserToAddRows = False
        MiDataGrid.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = Color.Silver
        DataGridViewCellStyle4.ForeColor = Color.Black
        DataGridViewCellStyle4.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle4.SelectionForeColor = Color.White
        MiDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        MiDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        MiDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MiDataGrid.Location = New Point(8, 78)
        MiDataGrid.Name = "MiDataGrid"
        MiDataGrid.ReadOnly = True
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = SystemColors.Control
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle6.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        MiDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        MiDataGrid.RowHeadersWidth = 25
        MiDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        MiDataGrid.Size = New Size(780, 406)
        MiDataGrid.TabIndex = 2
        ' 
        ' BtnProcesar
        ' 
        BtnProcesar.Location = New Point(12, 12)
        BtnProcesar.Name = "BtnProcesar"
        BtnProcesar.Size = New Size(139, 60)
        BtnProcesar.TabIndex = 3
        BtnProcesar.Text = "Procesar"
        BtnProcesar.UseVisualStyleBackColor = True
        ' 
        ' TxtCargos
        ' 
        TxtCargos.Enabled = False
        TxtCargos.Location = New Point(582, 490)
        TxtCargos.Name = "TxtCargos"
        TxtCargos.Size = New Size(100, 23)
        TxtCargos.TabIndex = 6
        TxtCargos.TextAlign = HorizontalAlignment.Right
        ' 
        ' TxtAbonos
        ' 
        TxtAbonos.Enabled = False
        TxtAbonos.Location = New Point(688, 490)
        TxtAbonos.Name = "TxtAbonos"
        TxtAbonos.Size = New Size(100, 23)
        TxtAbonos.TabIndex = 5
        TxtAbonos.TextAlign = HorizontalAlignment.Right
        ' 
        ' FrmAnalizarNomina
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 539)
        Controls.Add(TxtCargos)
        Controls.Add(TxtAbonos)
        Controls.Add(BtnProcesar)
        Controls.Add(MiDataGrid)
        Name = "FrmAnalizarNomina"
        Text = "FrmAnalizarNomina"
        CType(MiDataGrid, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MiDataGrid As DataGridView
    Friend WithEvents BtnProcesar As Button
    Friend WithEvents TxtCargos As TextBox
    Friend WithEvents TxtAbonos As TextBox
End Class
