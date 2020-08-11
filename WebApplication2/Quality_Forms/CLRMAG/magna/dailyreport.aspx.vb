Public Class dailyreport
    Inherits System.Web.UI.Page
    Protected WithEvents txtHeatNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlMPO As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlReg As System.Web.UI.WebControls.Panel
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox9 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox10 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button5 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox11 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button6 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox13 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox14 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button7 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox15 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox16 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button8 As System.Web.UI.WebControls.Button
    Protected WithEvents Textbox17 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox18 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button9 As System.Web.UI.WebControls.Button
    Protected WithEvents Button10 As System.Web.UI.WebControls.Button
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button
    Protected WithEvents btHFMC As System.Web.UI.WebControls.Button
    Protected WithEvents btVTL As System.Web.UI.WebControls.Button
    Protected WithEvents btGM As System.Web.UI.WebControls.Button
    Protected WithEvents btHBMC As System.Web.UI.WebControls.Button
    Protected WithEvents btHP As System.Web.UI.WebControls.Button
    Protected WithEvents btHRMC As System.Web.UI.WebControls.Button
    Protected WithEvents btHT As System.Web.UI.WebControls.Button
    Protected WithEvents btMM As System.Web.UI.WebControls.Button
    Protected WithEvents btRHT As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents dd As System.Web.UI.WebControls.Button








    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Shared themeValue As String
    Public Function DateTime(x As Date) As String
        DateTime = "Date(" & Year(x) & "," & Month(x) & "," & Day(x) & " 0,0,0)"
    End Function

    Public Sub New()

        AddHandler PreInit, New EventHandler(AddressOf Page_PreInit)
    End Sub

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)

        Page.Theme = themeValue
    End Sub


    Protected Sub Dd1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        themeValue = Dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Private Sub btnRLCRL_Click(sender As Object, e As EventArgs) Handles btnRLCRL.Click
        Dim strPathName As String


        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31551&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)
        'End If

    End Sub

    Protected Sub btnHFMC_Click(sender As Object, e As EventArgs) Handles btnHFMC.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39278&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)
        'End If



    End Sub
    Protected Sub btnHP_Click(sender As Object, e As EventArgs) Handles btnHP.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=41617&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHRMC_Click(sender As Object, e As EventArgs) Handles btnHRMC.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39308&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnVTL_Click(sender As Object, e As EventArgs) Handles btnVTL.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31272&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHBMC_Click(sender As Object, e As EventArgs) Handles btnHBMC.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31285&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnGM_Click(sender As Object, e As EventArgs) Handles btnGM.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=40118&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHT_Click(sender As Object, e As EventArgs) Handles btnHT.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31304&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnMM_Click(sender As Object, e As EventArgs) Handles btnMM.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39295&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnRHT_Click(sender As Object, e As EventArgs) Handles btnRHT.Click
        Dim strPathName As String

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39285&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)"

        Response.Redirect(strPathName)

    End Sub




End Class