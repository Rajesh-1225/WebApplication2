Public Class DailyEnergyConsumptionShopsQryReport
    Inherits System.Web.UI.Page
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList

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

    Shared themeValue As String

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then
            'txtDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lblMessage.Text = ""
        txtDate.Text = Maintenance.ElecTables.CheckReportDate("ms_electrical_econs", "c_date", CDate(txtDate.Text))
        If CDate(txtDate.Text) = #1/1/1900# Then
            lblMessage.Text = "No Data for the given Date !"
        Else
            Dim strPathName, strRptName, strRptFormula, strRptNameWithPath As String
            strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?id=39514&apsuser=Administrator&apspassword=Cris@123&apsauthtype=secEnterprise&user0=crissqlserver&password0=Cris@BelaQwertPoiuy&promptonrefresh=0&prompt0=DateTime(" & Format(CDate(txtDate.Text), "yyyy, MM, dd, 00, 00, 00") & ")"
            Response.Redirect(strPathName)
        End If
    End Sub
End Class
