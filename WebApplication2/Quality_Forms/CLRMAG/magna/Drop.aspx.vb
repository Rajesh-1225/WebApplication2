Public Class Drop
    Inherits System.Web.UI.Page
    Protected WithEvents dd As System.Web.UI.WebControls.Button

    Protected WithEvents dd1 As System.Web.UI.WebControls.DropDownList




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
        themeValue = dd1.SelectedItem.Value
        Response.Redirect(Request.Url.ToString())
    End Sub
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected Sub dd_Click(sender As Object, e As EventArgs) Handles dd.Click

        If DropDownList1.SelectedValue = "Daily" Then
            Response.Redirect("dailyreport.aspx")

        ElseIf DropDownList1.SelectedValue = "Shift" Then
            Response.Redirect("Shift.aspx")

        Else
            Response.Redirect("Monthly.aspx")



        End If


    End Sub
End Class