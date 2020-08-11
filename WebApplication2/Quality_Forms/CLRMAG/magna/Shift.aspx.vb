Public Class Shift
    Inherits System.Web.UI.Page

    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList

    Protected WithEvents CustomValidator1 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents btnRLCRL As System.Web.UI.WebControls.Button
    Protected WithEvents btnHFMC As System.Web.UI.WebControls.Button
    Protected WithEvents btnVTL As System.Web.UI.WebControls.Button
    Protected WithEvents btnGM As System.Web.UI.WebControls.Button
    Protected WithEvents btnHBMC As System.Web.UI.WebControls.Button
    Protected WithEvents btnHP As System.Web.UI.WebControls.Button
    Protected WithEvents btnHRMC As System.Web.UI.WebControls.Button
    Protected WithEvents btnHT As System.Web.UI.WebControls.Button
    Protected WithEvents btnMM As System.Web.UI.WebControls.Button
    Protected WithEvents btnRHT As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList



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
        Dim str = DropDownList1.SelectedItem.Value

        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39394&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
              "&promptex2= " & DropDownList1.SelectedItem.Value




        Response.Redirect(strPathName)
        'End If

    End Sub

    Protected Sub btnHFMC_Click(sender As Object, e As EventArgs) Handles btnHFMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39355&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
              "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)
        'End If



    End Sub
    Protected Sub btnHP_Click(sender As Object, e As EventArgs) Handles btnHP.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39388&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
            "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHRMC_Click(sender As Object, e As EventArgs) Handles btnHRMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31346&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
              "&promptex2= " & DropDownList1.SelectedItem.Value



    End Sub

    Protected Sub btnVTL_Click(sender As Object, e As EventArgs) Handles btnVTL.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39381&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
              "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHBMC_Click(sender As Object, e As EventArgs) Handles btnHBMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39372&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
             "&promptex2= " & DropDownList1.SelectedItem.Value

        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnGM_Click(sender As Object, e As EventArgs) Handles btnGM.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39349&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
       "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHT_Click(sender As Object, e As EventArgs) Handles btnHT.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39323&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
             "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnMM_Click(sender As Object, e As EventArgs) Handles btnMM.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39343&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
              "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnRHT_Click(sender As Object, e As EventArgs) Handles btnRHT.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39362&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&promptex0=DateTime(" & CDate(txtFromDate.Text).Year & "," & CDate(txtFromDate.Text).Month & ", " & CDate(txtFromDate.Text).Day & ", 0,0,0)" &
            "&promptex1=DateTime(" & CDate(TextToDate.Text).Year & "," & CDate(TextToDate.Text).Month & ", " & CDate(TextToDate.Text).Day & ", 0,0,0)" &
             "&promptex2= " & DropDownList1.SelectedItem.Value


        Response.Redirect(strPathName)

    End Sub


End Class
