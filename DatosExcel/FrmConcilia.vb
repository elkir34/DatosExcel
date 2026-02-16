'Imports System.IO
Imports MySql.Data.MySqlClient

Public Class FrmConcilia
    Dim sqlConexion As New MySqlConnection("allowuservariables=True; server=MARY; User Id=elkir; password=Mientras12$; database=buzosbyp_erp")
    Dim conciliaBS As BindingSource
    Dim conciliaComparaBS As BindingSource

    Dim x As Integer
    Dim y As Integer

    Private Sub FrmConcilia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyCargarConcilia()

    End Sub

    Private Sub MyCargarConcilia()
        Dim conciliaDA As MySqlDataAdapter
        Dim conciliaDT As DataTable

        Try
            sqlConexion.Open()

            conciliaDA = New MySqlDataAdapter("SELECT * FROM tbl_concilia", sqlConexion)
            conciliaDT = New DataTable
            conciliaDA.Fill(conciliaDT)
            conciliaBS = New BindingSource With {.DataSource = conciliaDT}

            MiDataGrid.AutoGenerateColumns = False
            MiDataGrid.DataSource = conciliaBS
            'NavContabilidad.BindingSource = conciliaBS

            ' btnActualizar.Enabled = True

            If conciliaDT.Rows.Count > 0 Then
                Dim row As DataRow
                row = conciliaDT.Rows(0)
                'DtpFechaInicio.Value = row("Fecha")

                row = conciliaDT.Rows(conciliaDT.Rows.Count - 1)
                'DtpFechaFinal.Value = row("Fecha")
            End If
        Catch ex As MySqlException
            'FrmMensaje.Show("No se ha podido establecer la conexión con la base de datos... " & ex.Message, 1)
            Close()
        Finally
            Select Case sqlConexion.State
                Case ConnectionState.Open
                    sqlConexion.Close()
            End Select
        End Try
    End Sub

    Private Sub BtnAnalizarDatos_Click(sender As Object, e As EventArgs)
        'Dim ConciliaComparaDA As MySqlDataAdapter
        Dim ConciliaComparaDT As DataTable
        'Dim strSQL As String

        Try
            sqlConexion.Open()

            'strSQL = "SELECT Fecha0, IFNULL(CargoContabilidad,0) AS CargoContabilidad, IFNULL(AbonoContabilidad,0) AS AbonoContabilidad, 
            'IFNULL(CargoDeudores,0) AS CargoDeudores, IFNULL(AbonoDeudores,0) AS AbonoDeudores,
            'If ( IFNULL( ROUND(CargoContabilidad,2),0) = IFNULL( ROUND(CargoDeudores,2),0),
            '                     'Concilidado', 
            '                     'revisar'
            '                   ) AS Cargos,
            'If ( IFNULL( ROUND(AbonoContabilidad,2),0) = IFNULL( ROUND(AbonoDeudores,2),0), 'Concilidado', 'revisar') AS Abonos
            ' FROM (SELECT Fecha AS Fecha0 FROM fechas WHERE Fecha BETWEEN '" & FechaInicio & "' AND '" & FechaFinal & "' GROUP BY Fecha) T0
            'Left JOIN (SELECT Fecha AS Fecha1, SUM(Cargo) AS CargoContabilidad, SUM(Abono) AS AbonoContabilidad 
            'From tbl_concilia WHERE Fecha BETWEEN '" & FechaInicio & "' AND '" & FechaFinal & "' GROUP BY Fecha)T1 ON T0.Fecha0 = T1.Fecha1
            'Left JOIN (SELECT Fecha AS Fecha2, SUM(Cargo) AS CargoDeudores,     SUM(Abono) AS AbonoDeudores
            'From tbl_cargos   WHERE Fecha BETWEEN '" & FechaInicio & "' AND '" & FechaFinal & "' GROUP BY Fecha)T2 ON T0.Fecha0 = T2.Fecha2;"

            'ConciliaComparaDA = New MySqlDataAdapter(strSQL, sqlConexion)
            ConciliaComparaDT = New DataTable
                    'ConciliaComparaDA.Fill(ConciliaComparaDT)
                    conciliaComparaBS = New BindingSource With {.DataSource = ConciliaComparaDT}

            MiDataGrid.AutoGenerateColumns = False
            MiDataGrid.DataSource = conciliaComparaBS
                    'NavConcilia.BindingSource = conciliaComparaBS

                    'btnActualizar.Enabled = True
                    MyCalcularTotal()
        Catch ex As MySqlException
            'FrmMensaje.Show("No se ha podido establecer la conexión con la base de datos... " & ex.Message, 1)
            Close()
        Finally
            Select Case sqlConexion.State
                Case ConnectionState.Open
                    sqlConexion.Close()
            End Select
        End Try
    End Sub

    Function MyFecha(ByVal Fecha As String) As String
        Dim MesLetra As String = Fecha.Substring(3, 3)
        Dim MesNumero As Integer
        Dim MiFecha As Date

        Select Case MesLetra
            Case "ENE"
                MesNumero = 1
            Case "FEB"
                MesNumero = 2
            Case "MAR"
                MesNumero = 3
            Case "ABR"
                MesNumero = 4
            Case "MAY"
                MesNumero = 5
            Case "JUN"
                MesNumero = 6
            Case "JUL"
                MesNumero = 7
            Case "AGO"
                MesNumero = 8
            Case "SEP"
                MesNumero = 9
            Case "OCT"
                MesNumero = 10
            Case "NOV"
                MesNumero = 11
            Case "DIC"
                MesNumero = 12
        End Select

        If IsDate(Fecha.Substring(0, 3) & MesNumero & Fecha.Substring(6, 3)) Then
            MiFecha = CDate(Fecha.Substring(0, 3) & MesNumero & Fecha.Substring(6, 3)).ToShortDateString
            Return MiFecha.ToString("yyyy-MM-dd")
        Else
            Return False
        End If
    End Function
    Function MyIsDate(ByVal Fecha As String) As String
        Dim MesLetra As String = Fecha.Substring(3, 3)
        Dim MesNumero As Integer
        Select Case MesLetra
            Case "ENE"
                MesNumero = 1
            Case "FEB"
                MesNumero = 2
            Case "MAR"
                MesNumero = 3
            Case "ABR"
                MesNumero = 4
            Case "MAY"
                MesNumero = 5
            Case "JUN"
                MesNumero = 6
            Case "JUL"
                MesNumero = 7
            Case "AGO"
                MesNumero = 8
            Case "SEP"
                MesNumero = 9
            Case "OCT"
                MesNumero = 10
            Case "NOV"
                MesNumero = 11
            Case "DIC"
                MesNumero = 12
        End Select

        If IsDate(Fecha.Substring(0, 3) & MesNumero & Fecha.Substring(6, 3)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCopiarConciliacion_Click(sender As Object, e As EventArgs) Handles BtnCopiarConciliacion.Click
        If MiDataGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
            Clipboard.SetDataObject(MiDataGrid.GetClipboardContent())
        End If
    End Sub

    Private Sub MyCalcularTotal()
        Dim dblCargoContabilidad As Double
        Dim dblAbonoContabilidad As Double
        Dim dblCargoDeudores As Double
        Dim dblAbonoDeudores As Double

        If conciliaComparaBS.Count > 0 Then
            TxtCargoContabilidad.Text = "0.00"
            TxtAbonoContabilidad.Text = "0.00"
            TxtCargoDeudores.Text = "0.00"
            TxtAbonoDeudores.Text = "0.00"

            For Each r As DataRowView In conciliaComparaBS
                dblCargoContabilidad += r("CargoContabilidad")
                dblAbonoContabilidad += r("AbonoContabilidad")
                dblCargoDeudores += r("CargoDeudores")
                dblAbonoDeudores += r("AbonoDeudores")
            Next

            TxtCargoContabilidad.Text = Format(dblCargoContabilidad, "N2")
            TxtAbonoContabilidad.Text = Format(dblAbonoContabilidad, "N2")
            TxtCargoDeudores.Text = Format(dblCargoDeudores, "N2")
            TxtAbonoDeudores.Text = Format(dblAbonoDeudores, "N2")
        End If
    End Sub

    Private Sub MiDataGridCompara_SelectionChanged(sender As Object, e As EventArgs) Handles MiDataGrid.SelectionChanged
        Dim RenglonesSeleccionados As Integer = MiDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim dblCargoContabilidad As Double
        Dim dblAbonoContabilidad As Double
        Dim dblCargoDeudores As Double
        Dim dblAbonoDeudores As Double

        'TxtFechaInicio.Text = ""
        'TxtFechaFinal.Text = ""

        If RenglonesSeleccionados > 0 Then
            'TxtFechaInicio.Text = CDate(MiDataGrid.SelectedRows(0).Cells("FechaAnaliza").Value).ToString("yyyy-MM-dd")

            For i As Integer = 0 To RenglonesSeleccionados - 1
                dblCargoContabilidad += MiDataGrid.SelectedRows(i).Cells("CargoContabilidad").Value
                dblAbonoContabilidad += MiDataGrid.SelectedRows(i).Cells("AbonoContabilidad").Value
                dblCargoDeudores += MiDataGrid.SelectedRows(i).Cells("CargoDeudores").Value
                dblAbonoDeudores += MiDataGrid.SelectedRows(i).Cells("AbonoDeudores").Value

                '   TxtFechaFinal.Text = CDate(MiDataGrid.SelectedRows(i).Cells("FechaAnaliza").Value).ToString("yyyy-MM-dd")
            Next

            TxtSeleccionados.Text = RenglonesSeleccionados
            SelCargoContabilidad.Text = Format(dblCargoContabilidad, "N2")
            SelAbonoContabilidad.Text = Format(dblAbonoContabilidad, "N2")
            SelCargoDeudores.Text = Format(dblCargoDeudores, "N2")
            SelAbonoDeudores.Text = Format(dblAbonoDeudores, "N2")
        Else
            SelCargoContabilidad.Text = "0.00"
            SelAbonoContabilidad.Text = "0.00"
            SelCargoDeudores.Text = "0.00"
            SelAbonoDeudores.Text = "0.00"
        End If
    End Sub

    Private Sub BtnDesglosar_Click(sender As Object, e As EventArgs)
        ' FrmConciliaAnaliza.Show
    End Sub

    Private Sub BtnActualizarCompara_Click(sender As Object, e As EventArgs)
        BtnAnalizarDatos_Click(Nothing, Nothing)
    End Sub
End Class