Public Class FrmMenuInicio

    Private Sub FrmMenuInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnCompaqi_Click(sender As Object, e As EventArgs) Handles BtnCompaqi.Click
        FrmImportarDatos.Show()
    End Sub

    Private Sub BtnNomiPaq_Click(sender As Object, e As EventArgs) Handles BtnNomiPaq.Click
        'FrmNomipaqDatos.Show()
    End Sub
End Class