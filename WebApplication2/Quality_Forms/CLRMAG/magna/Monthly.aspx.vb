Public Class Monthly
    Inherits System.Web.UI.Page
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DropDownList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnRLCRL As System.Web.UI.WebControls.Button
    Protected WithEvents btnHFMC As System.Web.UI.WebControls.Button
    Protected WithEvents btnVTL As System.Web.UI.WebControls.Button
    Protected WithEvents btnGM As System.Web.UI.WebControls.Button
    Protected WithEvents btnHBMC As System.Web.UI.WebControls.Button
    Protected WithEvents btnHP As System.Web.UI.WebControls.Button
    Protected WithEvents btnHRMC As System.Web.UI.WebControls.Button









    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Shared themeValue As String
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

    Protected Sub btnRLCRL_Click(sender As Object, e As EventArgs) Handles btnRLCRL.Click
        Dim strPathName As String



        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39400&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)



    End Sub

    Protected Sub btnHFMC_Click(sender As Object, e As EventArgs) Handles btnHFMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31430&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)


    End Sub

    Protected Sub btnHP_Click(sender As Object, e As EventArgs) Handles btnHP.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=40133&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)


    End Sub

    Protected Sub btnHRMC_Click(sender As Object, e As EventArgs) Handles btnHRMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=39406&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)


    End Sub

    Protected Sub btnVTL_Click(sender As Object, e As EventArgs) Handles btnVTL.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31422&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)


    End Sub

    Protected Sub btnHBMC_Click(sender As Object, e As EventArgs) Handles btnHBMC.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31416&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)


    End Sub

    Protected Sub btnGM_Click(sender As Object, e As EventArgs) Handles btnGM.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&i=39400&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnHT_Click(sender As Object, e As EventArgs) Handles btnHT.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31450&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnMM_Click(sender As Object, e As EventArgs) Handles btnMM.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31460&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)

    End Sub

    Protected Sub btnRHT_Click(sender As Object, e As EventArgs) Handles btnRHT.Click
        Dim strPathName As String
        Dim str = DropDownList1.SelectedItem.Value
        Dim Str1 = DropDownList2.SelectedItem.Value
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=31466&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
             "&promptex0= " & DropDownList1.SelectedItem.Value &
              "&promptex1= " & DropDownList2.SelectedItem.Value
        Response.Redirect(strPathName)

    End Sub
End Class