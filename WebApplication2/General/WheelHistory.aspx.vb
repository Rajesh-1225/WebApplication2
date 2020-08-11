Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data

Public Class WheelHistory1
    Inherits System.Web.UI.Page
    Protected WithEvents cmdReport As System.Web.UI.WebControls.Button
    ' Protected WithEvents cmdExit As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmployee_name As System.Web.UI.WebControls.Label
    Protected WithEvents txtFrmdt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTodt As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid3 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid4 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid5 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid6 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid7 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid8 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid9 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DataGrid10 As System.Web.UI.WebControls.DataGrid


    Dim sqlString As String
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Dim rdr As SqlDataReader
    Private con As New SqlConnection(ConfigurationManager.AppSettings("DBcon"))
    Dim strServer, strPathName As String
    Protected WithEvents cmdClear As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Dim datefr As String
    Dim dateto As String
    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Dd1.SelectedIndexChanged
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Put user code to initialize the page here
        'txtEmployee_code.Text = Session("Ecode")
        'Dim available As Boolean = False
        'lblMessage.Text = ""
        'lblEmployee_name.Text = ""
        'sqlString = "select empname from employee_master where empno='" & Trim(txtEmployee_code.Text) & "'"
        'rdr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings("con"), CommandType.Text, sqlString)
        'While rdr.Read
        '    If IsDBNull(rdr.Item("empname")) = True Then

        '    Else
        '        available = True
        '        lblEmployee_name.Text = rdr.Item("empname")
        '    End If
        'End While
        'If available = False Then
        '    lblMessage.Text = " "
        '    Dim i As Integer
        '    ' Response.Write("<script language=""javascript"">alert('Congratulations!');</script>")
        '    i = MsgBox("Record is not available...", 0, "Information")
        'End If
        'con.Open()
    End Sub



    Private Sub txtFrmdt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFrmdt.TextChanged


    End Sub
    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        datefr = txtFrmdt.Text
        dateto = txtTodt.Text

        DataGrid1.Visible = True

        bind_grid1()
        bind_grid2()
        bind_grid3()
        bind_grid4()
        bind_grid5()
        bind_grid6()
        bind_grid7()
        bind_grid8()
        bind_grid9()
        bind_grid10()


    End Sub
    Private Sub bind_grid1()

        Dim ds As New DataSet()
        Dim da As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da.SelectCommand.CommandText = "mm_sp_WheelHistoryMasterData"
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da.SelectCommand.CommandTimeout = 3600
            da.Fill(ds)
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da.Dispose()
            ds.Dispose()
            da = Nothing
            ds = Nothing
        End Try



    End Sub

    Private Sub bind_grid2()
        'Dim sqlstring2 As String = "select distinct application_number,application_type, leavecode, convert(varchar,from_date,103) [from_date],convert(varchar,to_date,103) [to_date],l_convert,number_of_days,reason,l_confirm,outstation_or_hq from hr_leave_application_details where empno='" & Trim(txtEmployee_code.Text) & "'"

        'Dim myCommand As New SqlDataAdapter(sqlstring2, con)
        'Dim ds As New DataSet()
        'myCommand.Fill(ds)

        'DataGrid1.DataSource = ds
        'DataGrid1.DataBind()
        Dim ds1 As New DataSet()
        Dim da1 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter

        Try
            da1.SelectCommand.CommandText = "mm_sp_WheelHistoryMasterData"
            da1.SelectCommand.CommandType = CommandType.StoredProcedure
            da1.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da1.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da1.SelectCommand.CommandTimeout = 3600
            da1.Fill(ds1)
            DataGrid2.DataSource = ds1
            DataGrid2.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da1.Dispose()
            ds1.Dispose()
            da1 = Nothing
            ds1 = Nothing
        End Try



    End Sub

    Private Sub bind_grid3()
        Dim ds2 As New DataSet()
        Dim da2 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da2.SelectCommand.CommandText = "mm_sp_WheelHistoryMasterData"
            da2.SelectCommand.CommandType = CommandType.StoredProcedure
            da2.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da2.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da2.SelectCommand.CommandTimeout = 3600
            da2.Fill(ds2)
            DataGrid3.DataSource = ds2
            DataGrid3.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da2.Dispose()
            ds2.Dispose()
            da2 = Nothing
            ds2 = Nothing
        End Try
    End Sub


    Private Sub bind_grid4()
        Dim ds3 As New DataSet()
        Dim da3 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da3.SelectCommand.CommandText = "mm_sp_WheelHistoryFinalInspData"
            da3.SelectCommand.CommandType = CommandType.StoredProcedure
            da3.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da3.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da3.SelectCommand.CommandTimeout = 3600
            da3.Fill(ds3)
            DataGrid4.DataSource = ds3
            DataGrid4.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da3.Dispose()
            ds3.Dispose()
            da3 = Nothing
            ds3 = Nothing
        End Try
    End Sub


    Private Sub bind_grid5()
        Dim ds4 As New DataSet()
        Dim da4 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da4.SelectCommand.CommandText = "mm_sp_WheelHistoryMachiningData"
            da4.SelectCommand.CommandType = CommandType.StoredProcedure
            da4.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da4.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da4.SelectCommand.CommandTimeout = 3600
            da4.Fill(ds4)
            DataGrid5.DataSource = ds4
            DataGrid5.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da4.Dispose()
            ds4.Dispose()
            da4 = Nothing
            ds4 = Nothing
        End Try
    End Sub

    Private Sub bind_grid6()
        Dim ds5 As New DataSet()
        Dim da5 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da5.SelectCommand.CommandText = "mm_sp_WheelHistoryMagnaData"
            da5.SelectCommand.CommandType = CommandType.StoredProcedure
            da5.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da5.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da5.SelectCommand.CommandTimeout = 3600
            da5.Fill(ds5)
            DataGrid6.DataSource = ds5
            DataGrid6.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da5.Dispose()
            ds5.Dispose()
            da5 = Nothing
            ds5 = Nothing
        End Try
    End Sub
    Private Sub bind_grid7()
        Dim ds6 As New DataSet()
        Dim da6 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da6.SelectCommand.CommandText = "mm_sp_WheelHistoryQCIInspData"
            da6.SelectCommand.CommandType = CommandType.StoredProcedure
            da6.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da6.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da6.SelectCommand.CommandTimeout = 3600
            da6.Fill(ds6)
            DataGrid7.DataSource = ds6
            DataGrid7.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da6.Dispose()
            ds6.Dispose()
            da6 = Nothing
            ds6 = Nothing
        End Try
    End Sub

    Private Sub bind_grid8()
        Dim ds7 As New DataSet()
        Dim da7 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da7.SelectCommand.CommandText = "mm_WheelHistoryLooseWheelDespData"
            da7.SelectCommand.CommandType = CommandType.StoredProcedure
            da7.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da7.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da7.SelectCommand.CommandTimeout = 3600
            da7.Fill(ds7)
            DataGrid8.DataSource = ds7
            DataGrid8.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da7.Dispose()
            ds7.Dispose()
            da7 = Nothing
            ds7 = Nothing
        End Try
    End Sub

    Private Sub bind_grid9()
        Dim ds8 As New DataSet()
        Dim da8 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da8.SelectCommand.CommandText = "mm_sp_WheelHistoryMasterData"
            da8.SelectCommand.CommandType = CommandType.StoredProcedure
            da8.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da8.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da8.SelectCommand.CommandTimeout = 3600
            da8.Fill(ds8)
            DataGrid9.DataSource = ds8
            DataGrid9.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da8.Dispose()
            ds8.Dispose()
            da8 = Nothing
            ds8 = Nothing
        End Try
    End Sub
    Private Sub bind_grid10()
        Dim ds9 As New DataSet()
        Dim da9 As SqlClient.SqlDataAdapter = rwfGen.Connection.Adapter
        Try
            da9.SelectCommand.CommandText = "mm_sp_WheelHistoryMasterData"
            da9.SelectCommand.CommandType = CommandType.StoredProcedure
            da9.SelectCommand.Parameters.Add("@WheelNumber", SqlDbType.BigInt, 20).Value = datefr
            da9.SelectCommand.Parameters.Add("@HeatNumber", SqlDbType.BigInt, 20).Value = dateto
            da9.SelectCommand.CommandTimeout = 3600
            da9.Fill(ds9)
            DataGrid10.DataSource = ds9
            DataGrid10.DataBind()

        Catch exp As Exception
            'Throw New Exception(exp.Message)
        Finally
            da9.Dispose()
            ds9.Dispose()
            da9 = Nothing
            ds9 = Nothing
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        txtFrmdt.Text = ""
        txtTodt.Text = ""
        DataGrid1.Visible = False
    End Sub
End Class
