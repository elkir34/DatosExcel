<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuInicio
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
        BtnCompaqi = New Button()
        BtnNomiPaq = New Button()
        SuspendLayout()
        ' 
        ' BtnCompaqi
        ' 
        BtnCompaqi.Location = New Point(12, 12)
        BtnCompaqi.Name = "BtnCompaqi"
        BtnCompaqi.Size = New Size(193, 35)
        BtnCompaqi.TabIndex = 0
        BtnCompaqi.Text = "Importar datos de Compaqi"
        BtnCompaqi.UseVisualStyleBackColor = True
        ' 
        ' BtnNomiPaq
        ' 
        BtnNomiPaq.Enabled = False
        BtnNomiPaq.Location = New Point(12, 53)
        BtnNomiPaq.Name = "BtnNomiPaq"
        BtnNomiPaq.Size = New Size(193, 35)
        BtnNomiPaq.TabIndex = 1
        BtnNomiPaq.Text = "Importar datos de NomiPaq"
        BtnNomiPaq.UseVisualStyleBackColor = True
        ' 
        ' FrmMenuInicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(219, 247)
        Controls.Add(BtnNomiPaq)
        Controls.Add(BtnCompaqi)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "FrmMenuInicio"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inicio"
        ResumeLayout(False)
    End Sub

    Friend WithEvents BtnCompaqi As Button
    Friend WithEvents BtnNomiPaq As Button
End Class
