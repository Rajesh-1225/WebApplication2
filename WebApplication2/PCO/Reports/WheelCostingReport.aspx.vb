Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class WheelCostingReport
    Inherits System.Web.UI.Page

    Protected WithEvents START_FIN_YR As Global.System.Web.UI.WebControls.DropDownList
    Protected WithEvents FIN_YR As System.Web.UI.WebControls.DropDownList
    Protected WithEvents FROM_MONTH As System.Web.UI.WebControls.DropDownList
    Protected WithEvents TO_MONTH As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim rdr As SqlDataReader
        If Not IsPostBack Then
            con.Open()
            Dim sql As String = "SELECT DISTINCT year AS YEAR FROM wap.dbo.WHEEL_CAST  ORDER BY YEAR DESC"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql)
            FIN_YR.DataValueField = "YEAR"
            FIN_YR.DataTextField = "YEAR"
            FIN_YR.DataSource = rdr
            FIN_YR.DataBind()



            rdr.Close()

            con.Close()
        End If

        If Not IsPostBack Then
            con.Open()
            Dim sql As String = "SELECT DISTINCT year AS YEAR FROM wap.dbo.WHEEL_CAST  ORDER BY YEAR DESC"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql)

            START_FIN_YR.DataValueField = "YEAR"
            START_FIN_YR.DataTextField = "YEAR"
            START_FIN_YR.DataSource = rdr
            START_FIN_YR.DataBind()





            rdr.Close()

            con.Close()
        End If

        'Dim currentDate As DateTime = DateTime.Now

        'TO_MONTH.Items.FindByValue(currentDate.Month).Selected = True



        con.Open()
        Dim sql1 As String = "SELECT TOP 1 year AS YEAR FROM wap.dbo.WHEEL_CAST  ORDER BY YEAR DESC"
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql1)

        While rdr.Read

            initial_yr = rdr.Item("YEAR")


        End While

        rdr.Close()

        con.Close()

        'con.Open()
        'Dim sql_month As String = " SELECT MONTH(GETDATE()) AS FINAL_MONTH"
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql_month)

        'While rdr.Read

        '    final_month = rdr.Item("FINAL_MONTH")


        'End While

        'rdr.Close()

        'con.Close()

        'TO_MONTH.Items.FindByValue(final_month).Selected = True

        'wheel_costing_report(initial_yr, initial_yr, "1", final_month)

        wheel_costing_report(initial_yr, initial_yr, "1", "12")




    End Sub


    Public year_value As New ArrayList
    Public month As New ArrayList
    Public total_wheel_cast As New ArrayList
    Public total_good_wheel As New ArrayList
    Public total_wheel_xc As New ArrayList
    Public total_debit As New ArrayList
    Public wheel_cost As New ArrayList

    Public initial_yr As String

    Public final_month As String

    Public start_fin_yr_str As String
    Public fin_yr_str As String
    Public from_month_str As String
    Public to_month_str As String


    Dim con As SqlConnection = New SqlConnection("Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=WAP;Persist Security Info=True;User ID=crissqlserver;Password=Cris@BelaQwertPoiuy")


    Sub wheel_costing_report(ByVal From_year As String, ByVal to_year As String, ByVal from_month As String, ByVal to_month As String)

        Dim str1 = "CREATE OR ALTER VIEW PLAN_HEAD_DETAILS_VW AS
                    select year,month, CONCAT(SUBSTRING(DateName( month , DateAdd( month , MONTH , 0 ) - 1 ), 1, 3),'-',SUBSTRING(CAST(YEAR as varchar), 3, 4)) AS MONTH_YEAR ,ISNULL(sum(debit),0) as totaldebit
                    from wap.dbo.PLAN_HEAD_DETAILS
                    group by year,month"

        Dim str2 = "CREATE OR ALTER VIEW WHEEL_CAST_NEW_VW AS 
                    select year,month, CONCAT(SUBSTRING(DateName( month , DateAdd( month , MONTH , 0 ) - 1 ), 1, 3),'-',SUBSTRING(CAST(YEAR as varchar), 3, 4)) AS MONTH_YEAR,ISNULL(sum(wheel_cast),0) as totalwheelcast,ISNULL(sum(good_wheel),0) as totalgoodwheel, ISNULL(sum(wheel_cast),0)-ISNULL(sum(good_wheel),0) as totalwheelxc
                    from wap.dbo.WHEEL_CAST
                    group by year,month"

        Dim str3 = "CREATE OR ALTER VIEW ALLWHEELDATA AS 
                    SELECT WHEEL_CAST_NEW_VW.YEAR, WHEEL_CAST_NEW_VW.MONTH_YEAR , WHEEL_CAST_NEW_VW.MONTH as MONTH , WHEEL_CAST_NEW_VW.totalwheelcast , WHEEL_CAST_NEW_VW.totalgoodwheel , WHEEL_CAST_NEW_VW.totalwheelxc , PLAN_HEAD_DETAILS_VW.totaldebit , CAST( ROUND(ISNULL((PLAN_HEAD_DETAILS_VW.totaldebit / NULLIF(WHEEL_CAST_NEW_VW.totalgoodwheel , 0)), 0) , 2) as decimal(20,2)) AS wheelcost
                    FROM WHEEL_CAST_NEW_VW
                    LEFT JOIN PLAN_HEAD_DETAILS_VW ON PLAN_HEAD_DETAILS_VW.MONTH_YEAR=WHEEL_CAST_NEW_VW.MONTH_YEAR AND WHEEL_CAST_NEW_VW.YEAR = PLAN_HEAD_DETAILS_VW.YEAR AND WHEEL_CAST_NEW_VW.MONTH = PLAN_HEAD_DETAILS_VW.MONTH"

        Dim str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_WHEEL AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, year(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS YEAR , DATEPART(m, CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS MONTH , -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, year(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS YEAR, DATEPART(m, CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS MONTH , number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date,YEAR,MONTH
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR,YEAR,MONTH"

        Dim str5 = "CREATE OR ALTER VIEW ALLWHEELDATA_FINAL AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,B.YEAR,B.MONTH ,ISNULL(A.totaldebit,0) AS totaldebit, ISNULL(A.totalgoodwheel,0) AS totalgoodwheel , ISNULL(A.totalwheelcast,0) AS totalwheelcast , ISNULL(A.totalwheelxc,0) AS totalwheelxc , ISNULL(A.wheelcost,0) AS  wheelcost
                    FROM ALLWHEELDATA AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER_WHEEL AS B ON B.MONTH_YEAR=A.Month_Year AND B.MONTH=A.MONTH AND B.YEAR=A.YEAR
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,B.YEAR,B.MONTH,A.totaldebit,A.totalgoodwheel,A.totalwheelcast,A.totalwheelxc,A.wheelcost"

        Dim str6_value = "SELECT ALLWHEELDATA_FINAL.YEAR, ALLWHEELDATA_FINAL.MONTH_YEAR , ALLWHEELDATA_FINAL.MONTH as MONTH , ALLWHEELDATA_FINAL.totalwheelcast , ALLWHEELDATA_FINAL.totalgoodwheel , ALLWHEELDATA_FINAL.totalwheelxc , ALLWHEELDATA_FINAL.totaldebit , ALLWHEELDATA_FINAL.wheelcost
                        FROM ALLWHEELDATA_FINAL
                        WHERE ALLWHEELDATA_FINAL.YEAR BETWEEN '" & From_year & "' AND '" & to_year & "' 
                        AND ALLWHEELDATA_FINAL.MONTH BETWEEN '" & from_month & "' AND '" & to_month & "' "



        Dim rdr As SqlDataReader

        year_value = New ArrayList
        month = New ArrayList
        total_wheel_cast = New ArrayList
        total_good_wheel = New ArrayList
        total_wheel_xc = New ArrayList
        total_debit = New ArrayList
        wheel_cost = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6_value)

        While rdr.Read

            year_value.Add(rdr.Item("YEAR"))
            month.Add(rdr.Item("MONTH_YEAR"))
            total_wheel_cast.Add(rdr.Item("totalwheelcast"))
            total_good_wheel.Add(rdr.Item("totalgoodwheel"))
            total_wheel_xc.Add(rdr.Item("totalwheelxc"))
            total_debit.Add(rdr.Item("totaldebit"))
            wheel_cost.Add(rdr.Item("wheelcost"))

            'Dim time As DateTime = DateTime.Now
            'Dim format As String = "MMM-yy"
            'Dim currentmonyr As String = time.ToString(format)
            'Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            'If String.Compare(currentmonyr, datamonyr) = 0 Then
            '    Exit While
            'End If

        End While
        rdr.Close()

        con.Close()
    End Sub


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        start_fin_yr_str = START_FIN_YR.SelectedValue

        fin_yr_str = FIN_YR.SelectedValue

        from_month_str = FROM_MONTH.SelectedValue

        Dim from_month_int As Integer



        from_month_int = Integer.Parse(from_month_str)

        to_month_str = TO_MONTH.SelectedValue

        Dim to_month_int As Integer

        to_month_int = Integer.Parse(to_month_str)

        Dim from_year_int As Integer

        Dim to_year_int As Integer

        from_year_int = Integer.Parse(start_fin_yr_str)

        to_year_int = Integer.Parse(fin_yr_str)


        If from_month_int <= to_month_int And from_year_int <= to_year_int Then



            wheel_costing_report(start_fin_yr_str, fin_yr_str, from_month_str, to_month_str)

        End If

    End Sub



End Class