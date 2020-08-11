Public Class MetlabReports
    Inherits System.Web.UI.Page
    Protected WithEvents txtLabNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnFEMNCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnFESICHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnSIMNCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnGP2CHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnLIMECHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnSANDPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnSANDCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnFRCLAYPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnFRCLAYCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnMagBRkPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnMagBRkCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnMCBPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnMCBCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnHABPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnHABCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnISBPHY As System.Web.UI.WebControls.Button
    Protected WithEvents btnISBCHEM As System.Web.UI.WebControls.Button
    Protected WithEvents btnReport As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnDetails As System.Web.UI.WebControls.Button
    'Protected WithEvents btnVEEGUM As System.Web.UI.WebControls.Button
    'Protected WithEvents btnSTEELSHOTS As System.Web.UI.WebControls.Button
    'Protected WithEvents btnSLAG As System.Web.UI.WebControls.Button
    Protected WithEvents Dd1 As System.Web.UI.WebControls.DropDownList


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


    '#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If IsPostBack = False Then

        End If
    End Sub

    Protected Sub btnFEMNCHEM_Click(sender As Object, e As EventArgs) Handles btnFEMNCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34232&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFESICHEM_Click(sender As Object, e As EventArgs) Handles btnFESICHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34248&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnSIMNCHEM_Click(sender As Object, e As EventArgs) Handles btnSIMNCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34240&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGP2CHEM_Click(sender As Object, e As EventArgs) Handles btnGP2CHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34255&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnLIMECHEM_Click(sender As Object, e As EventArgs) Handles btnLIMECHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=35827&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnSANDPHY_Click(sender As Object, e As EventArgs) Handles btnSANDPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34328&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnSANDCHEM_Click(sender As Object, e As EventArgs) Handles btnSANDCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34336&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
        "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFRCLAYPHY_Click(sender As Object, e As EventArgs) Handles btnFRCLAYPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34272&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFRCLAYCHEM_Click(sender As Object, e As EventArgs) Handles btnFRCLAYCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34265&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnMagBRkPHY_Click(sender As Object, e As EventArgs) Handles btnMagBRkPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34319&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
         "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnMagBRKCHEM_Click(sender As Object, e As EventArgs) Handles btnMagBRKCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34312&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnMCBPHY_Click(sender As Object, e As EventArgs) Handles btnMCBPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27207&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnMCBCHEM_Click(sender As Object, e As EventArgs) Handles btnMCBCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=27214&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnHABPHY_Click(sender As Object, e As EventArgs) Handles btnHABPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34281&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
         "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnHABCHEM_Click(sender As Object, e As EventArgs) Handles btnHABCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34287&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnISBPHY_Click(sender As Object, e As EventArgs) Handles btnISBPHY.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34297&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnVEEGUM_Click(sender As Object, e As EventArgs) Handles btnVEEGUM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37206&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnSTEELSHOTS_Click(sender As Object, e As EventArgs) Handles btnSTEELSHOTS.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37199&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnSLAG_Click(sender As Object, e As EventArgs) Handles btnSLAG.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37191&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGAZEBINDER_Click(sender As Object, e As EventArgs) Handles btnGAZEBINDER.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37185&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGAZETUBE_Click(sender As Object, e As EventArgs) Handles btnGAZETUBE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37178&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnDOMEDISC_Click(sender As Object, e As EventArgs) Handles btnDOMEDISC.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37172&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub


    Protected Sub btnCOATEDSAND_Click(sender As Object, e As EventArgs) Handles btnCOATEDSAND.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37166&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnALMSTAR_Click(sender As Object, e As EventArgs) Handles btnALMSTAR.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37152&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnAIRSETMORTOR_click(sender As Object, e As EventArgs) Handles btnAIRSETMORTOR.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37152&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnABSGASKET_Click(sender As Object, e As EventArgs) Handles btnABSGASKET.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37145&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnCERNONABSGASKET_Click(sender As Object, e As EventArgs) Handles btnCERNONABSGASKET.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37138&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnCLAYGRAPSTOPPER_Click(sender As Object, e As EventArgs) Handles btnCLAYGRAPSTOPPER.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37131&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnCMC_Click(sender As Object, e As EventArgs) Handles btnCMC.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37112&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnCRUSRAWDOLOMITE_Click(sender As Object, e As EventArgs) Handles btnCRUSRAWDOLOMITE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37104&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnDELTACASTABLE_Click(sender As Object, e As EventArgs) Handles btnDELTACASTABLE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37095&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnDRINKWATER_Click(sender As Object, e As EventArgs) Handles btnDRINKWATER.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37074&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnDryRAMMASS_Click(sender As Object, e As EventArgs) Handles btnDryRAMMASS.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37060&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFLOURANCHALK_Click(sender As Object, e As EventArgs) Handles btnFLOURANCHALK.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37053&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFLOUSPHAR_Click(sender As Object, e As EventArgs) Handles btnFLOUSPHAR.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37047&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnFUSEDSILICASAND_Click(sender As Object, e As EventArgs) Handles btnFUSEDSILICASAND.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37040&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGARLOCKPOURTUBEGASKET_Click(sender As Object, e As EventArgs) Handles btnGARLOCKPOURTUBEGASKET.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37034&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGRAPHMOULDBLANKET_Click(sender As Object, e As EventArgs) Handles btnGRAPHMOULDBLANKET.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37024&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnGUNNINGMASS_Click(sender As Object, e As EventArgs) Handles btnGUNNINGMASS.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37015&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnHDDRM_Click(sender As Object, e As EventArgs) Handles btnHDDRM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=38381&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnHEXAMINE_Click(sender As Object, e As EventArgs) Handles btnHEXAMINE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=36998&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnINGATESLEEVE_Click(sender As Object, e As EventArgs) Handles btnINGATESLEEVE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=36987&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnLADLEINSULATMATERIAL_Click(sender As Object, e As EventArgs) Handles btnLADLEINSULATMATERIAL.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=38374&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnMSPLATE_Click(sender As Object, e As EventArgs) Handles btnMSPLATE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=36958&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnPOURINGTUBE_Click(sender As Object, e As EventArgs) Handles btnPOURINGTUBE.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=37806&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnWETRAMMINGMASS_Click(sender As Object, e As EventArgs) Handles btnWETRAMMINGMASS.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=38367&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub

    Protected Sub btnISBCHEM_Click(sender As Object, e As EventArgs) Handles btnISBCHEM.Click
        Dim strPathName As String
        strPathName = "http://rwpbela3.southindia.cloudapp.azure.com:8080/BOE/CMC/1903072256/CrystalReports/viewrpt.cwr?apsuser=Administrator&apspassword=Cris@123&1225&apsauthtype=secEnterprise&id=34304&user0=crissqlserver&password0=Cris@BelaQwertPoiuy" &
     "&prompt0=" & (txtLabNumber.Text.Trim) & ""
        Response.Redirect(strPathName)
    End Sub
End Class
