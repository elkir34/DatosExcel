Imports System.Numerics
Imports Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient

Public Class FrmNomipaqDatos
    Private x, y As Integer
    Private MisDatosNomipaqDT As Data.DataTable
    Private WithEvents MisDatosNomipaqBS As BindingSource
    Dim MyIndex As Integer

    Private Sub FrmNomipaqDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtNombreArchivo.Text = "ninguno"
        LblSeleccion.Text = "0"
        LblCargos.Text = "0.00"
        LblAbonos.Text = "0.00"
        TxtTotalRegistros.Text = "0"
        TxtAbonos.Text = "0.00"
        TxtCargos.Text = "0.00"
        BtnAnalizar.Enabled = False
        BtnPrimero.Enabled = False
        BtnAnterior.Enabled = False
        BtnSiguiente.Enabled = False
        BtnUltimo.Enabled = False
        BtnActualizar.Enabled = False
    End Sub

    Private Sub BtnAbrirArchivo_Click(sender As Object, e As EventArgs) Handles BtnAbrirArchivo.Click
        ' Configurar el filtro para mostrar solo archivos de Excel
        OpenFileDialog1.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Todos los archivos (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1 ' Por defecto mostrar archivos de Excel
        OpenFileDialog1.Title = "Seleccionar archivo de Excel generado en NomiPaqi"

        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            TxtNombreArchivo.Text = OpenFileDialog1.FileName
            MiDataGrid.Columns.Clear()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub MiNuevosMovimientos()
        MisDatosNomipaqBS = New BindingSource With {.DataSource = MisDatosNomipaqDT}
        MiDataGrid.DataSource = MisDatosNomipaqBS

        MiDataGrid.Columns("CargoAnticipoNomina").HeaderText = "Anticipo Nómina"
        MiDataGrid.Columns("CuentaCorriente").HeaderText = "Cuenta Corriente"
        MiDataGrid.Columns("CargoAnticipoNomina").DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns("CuentaCorriente").DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns("Semanarios").DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns("Total").DefaultCellStyle.Format = "N2"
        MiDataGrid.Columns("CargoAnticipoNomina").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns("CuentaCorriente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns("Semanarios").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        MiDataGrid.Columns("Cuenta").Width = 80
        MiDataGrid.Columns("Nombre").Width = 250


        AddHandler MisDatosNomipaqBS.PositionChanged, AddressOf MisDatosNomipaqBS_PositionChanged
        TxtTotalRegistros.Text = MisDatosNomipaqBS.Count.ToString()
        BtnActualizar.Enabled = MisDatosNomipaqBS.Count > 0
        MisDatosNomipaqBS_PositionChanged(Nothing, Nothing)
        'SumarCargosYAbonos()
        'MiBuscarIndices()
        'MisDatosNomipaqBS.Sort = "Fecha ASC, Numero ASC, TipoPoliza ASC, TipoTrabajador ASC, Nombre ASC"
    End Sub

    Private Sub MisDatosNomipaqBS_PositionChanged(sender As Object, e As EventArgs) Handles MisDatosNomipaqBS.PositionChanged
        TxtRegistro.Text = (MisDatosNomipaqBS.Position + 1).ToString
        TxtTotalRegistros.Text = MisDatosNomipaqBS.Count.ToString
        BtnPrimero.Enabled = MisDatosNomipaqBS.Position > 0
        BtnAnterior.Enabled = MisDatosNomipaqBS.Position > 0
        BtnSiguiente.Enabled = MisDatosNomipaqBS.Position < MisDatosNomipaqBS.Count - 1
        BtnUltimo.Enabled = MisDatosNomipaqBS.Position < MisDatosNomipaqBS.Count - 1
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim excelApp As New Application
            Dim workbook As Workbook = excelApp.Workbooks.Open(TxtNombreArchivo.Text)
            Dim worksheet As Worksheet = workbook.Sheets(1)
            Dim miCelda, miEncabezado As String
            Dim miRenglon As Data.DataRow
            Dim indexColAnticipo As Integer = -1
            Dim indexColCtaCorriente As Integer = -1
            Dim indexColSemanrios As Integer = -1
            Dim BuscarEncabezado As Boolean = True

            ' Leer los datos de la hoja de Excel
            x = 0
            y = worksheet.UsedRange.Rows.Count

            MisDatosNomipaqDT = New Data.DataTable()
            MisDatosNomipaqDT.Columns.Add("Cuenta", GetType(String))
            MisDatosNomipaqDT.Columns.Add("Nombre", GetType(String))
            MisDatosNomipaqDT.Columns.Add("CargoAnticipoNomina", GetType(Double))
            MisDatosNomipaqDT.Columns.Add("CuentaCorriente", GetType(Double))
            MisDatosNomipaqDT.Columns.Add("Semanarios", GetType(Double))
            MisDatosNomipaqDT.Columns.Add("Total", GetType(Double), "CargoAnticipoNomina + CuentaCorriente + Semanarios")

            For indexRenglon = 1 To worksheet.UsedRange.Rows.Count
                BackgroundWorker1.ReportProgress(x * 100 / y)
                miRenglon = MisDatosNomipaqDT.NewRow()
                miCelda = worksheet.Cells(indexRenglon, 1).Value

                If BuscarEncabezado Then
                    If Not IsNothing(miCelda) AndAlso miCelda.ToString = "Código" Then
                        For col = 1 To worksheet.UsedRange.Columns.Count
                            miEncabezado = worksheet.Cells(indexRenglon, col).Value
                            If Not IsNothing(miEncabezado) Then
                                If miEncabezado.ToString.Trim().Equals("ANTICIPO NOMINA", StringComparison.CurrentCultureIgnoreCase) Then
                                    indexColAnticipo = col
                                End If
                                If miEncabezado.ToString.Trim().Equals("CUENTA CORRIENTE", StringComparison.CurrentCultureIgnoreCase) Then
                                    indexColCtaCorriente = col
                                End If
                                If miEncabezado.ToString.Trim().Equals("SEMANARIOS", StringComparison.CurrentCultureIgnoreCase) Then
                                    indexColSemanrios = col
                                End If
                            End If
                        Next
                        BuscarEncabezado = False
                    End If
                Else
                    If Not IsNothing(miCelda) AndAlso miCelda.Length = 3 Then
                        miRenglon("Cuenta") = miCelda.ToString.Trim()
                        miCelda = worksheet.Cells(indexRenglon, 2).Value
                        If Not IsNothing(miCelda) Then
                            miRenglon("Nombre") = miCelda.ToString.Trim()
                        End If
                        ' Leer el anticipo de nómina si la columna existe
                        If indexColAnticipo > 0 Then
                            miCelda = worksheet.Cells(indexRenglon, indexColAnticipo).Value
                            If Not IsNothing(miCelda) Then
                                miRenglon("CargoAnticipoNomina") = Convert.ToDouble(miCelda)
                            Else
                                miRenglon("CargoAnticipoNomina") = 0.0
                            End If
                        End If
                        ' Leer la cuenta corriente si la columna existe
                        If indexColCtaCorriente > 0 Then
                            miCelda = worksheet.Cells(indexRenglon, indexColCtaCorriente).Value
                            If Not IsNothing(miCelda) Then
                                miRenglon("CuentaCorriente") = Convert.ToDouble(miCelda)
                            Else
                                miRenglon("CuentaCorriente") = 0.0
                            End If
                        End If
                        ' Leer los semanarios si la columna existe
                        If indexColSemanrios > 0 Then
                            miCelda = worksheet.Cells(indexRenglon, indexColSemanrios).Value
                            If Not IsNothing(miCelda) Then
                                miRenglon("Semanarios") = Convert.ToDouble(miCelda)
                            Else
                                miRenglon("Semanarios") = 0.0
                            End If
                        End If
                        If miRenglon("CargoAnticipoNomina") = 0.0 AndAlso miRenglon("CuentaCorriente") = 0.0 AndAlso miRenglon("Semanarios") = 0.0 Then
                            Continue For
                        End If

                        MisDatosNomipaqDT.Rows.Add(miRenglon)
                    End If
                End If
                x += 1
            Next
        Catch ex As Exception
            MessageBox.Show("Error al importar el archivo de excel con los datos de NomiPaq: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        MyProgressBar1.Value = e.ProgressPercentage
        LblProgreso.Text = x & "/" & y
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MessageBox.Show("El archivo de NomiPaq, fue importado con éxito...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MyProgressBar1.Value = 0
        LblProgreso.Text = ""
        MiNuevosMovimientos()
        BtnAnalizar.Enabled = True
    End Sub

    Private Sub BtnPrimero_Click(sender As Object, e As EventArgs) Handles BtnPrimero.Click
        MisDatosNomipaqBS.MoveFirst()
    End Sub

    Private Sub BtnUltimo_Click(sender As Object, e As EventArgs) Handles BtnUltimo.Click
        MisDatosNomipaqBS.MoveLast()
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        MisDatosNomipaqBS.MovePrevious()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        MisDatosNomipaqBS.MoveNext()
    End Sub

    Private Sub BtnAnalizar_Click(sender As Object, e As EventArgs) Handles BtnAnalizar.Click
        FrmNomiPaqAnaliza.ShowDialog()
    End Sub
End Class