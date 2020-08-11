Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class Magna_Dashboard
    Inherits System.Web.UI.Page


    Protected WithEvents Fin_Year As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Prod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Report_Type As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSubmit As Global.System.Web.UI.WebControls.Button

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If mon >= 4 And mon <= 12 Then
            c1 = cyear
            c2 = cyear + 1
        End If
        If mon >= 1 And mon <= 3 Then
            c1 = cyear - 1
            c2 = cyear
        End If
        initial_strtyr = CStr(c1) & CStr("-04-01")
        initial_endtyr = CStr(c2) & CStr("-03-31")
        analysis_all(initial_strtyr, initial_endtyr)



        Dim rdr As SqlDataReader
        If Not IsPostBack Then
            con.Open()

            Dim newsql1 As String = "CREATE OR ALTER VIEW FIN_YEAR_CALC AS
		                            SELECT DISTINCT dbo.GetFinancialYear(TestDate) AS FIN_YEAR FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		                            UNION
		                            SELECT DISTINCT dbo.GetFinancialYear(melt_date) AS FIN_YEAR FROM wap.dbo.mm_offheat_heatsheet_header
		                            UNION
		                            SELECT DISTINCT dbo.GetFinancialYear(melt_date) AS FIN_YEAR FROM wap.dbo.mm_heatsheet_header"

            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, newsql1)
            rdr.Close()
            Dim newsql2 As String = "SELECT FIN_YEAR FROM FIN_YEAR_CALC ORDER BY FIN_YEAR DESC"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, newsql2)

            Fin_Year.DataValueField = "FIN_YEAR"
            Fin_Year.DataTextField = "FIN_YEAR"
            Fin_Year.DataSource = rdr
            Fin_Year.DataBind()
            rdr.Close()


            Dim sql1 As String = "SELECT DISTINCT ProdType AS PROD_TYPE FROM wap.dbo.mm_magnaglow_new_shiftwiserecords ORDER BY ProdType"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql1)
            Prod.DataValueField = "PROD_TYPE"
            Prod.DataTextField = "PROD_TYPE"
            Prod.DataSource = rdr
            Prod.DataBind()
            rdr.Close()
            Prod.Items.Insert(0, "COMBINED")

            Dim sql2 As String = "SELECT DISTINCT Report_Type AS REPORT_TYPE,Report_Id FROM wap.dbo.report_master ORDER BY Report_Id"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql2)
            Report_Type.DataValueField = "REPORT_TYPE"
            Report_Type.DataTextField = "REPORT_TYPE"
            Report_Type.DataSource = rdr
            Report_Type.DataBind()
            rdr.Close()

            con.Close()
        End If



    End Sub

    Public mon As Integer = (DateTime.Now.ToString("MM"))
    Public c1 As Integer
    Public c2 As Integer
    Public cyear As Integer = (DateTime.Now.ToString("yyyy"))
    Public initial_strtyr As String
    Public initial_endtyr As String

    Public initial_finyr As New ArrayList
    Public initial_prodtype As New ArrayList
    Public initial_reports As New ArrayList

    Public month_year As New ArrayList
    Public stock_month_per As New ArrayList
    Public machine_month_per As New ArrayList
    Public rejection_month_per As New ArrayList

    Public pie_smr_all_quality As New ArrayList

    Public rejection_analysis_defect_desc As New ArrayList
    Public rejection_analysis_defect_per As New ArrayList

    Public percent_label As New ArrayList
    Public percent_value As New ArrayList

    Public badchem_month As New ArrayList
    Public badchem_percent As New ArrayList

    Public pr_mw_rejection_label As New ArrayList
    Public pr_mw_rejection_badchem As New ArrayList
    Public pr_mw_rejection_mrxc As New ArrayList
    Public pr_mw_rejection_defect As New ArrayList
    Public pr_mw_rejection_machining As New ArrayList


    Public fnYrStr As String
    Public prodTypeStr As String
    Public reportTypeStr As String
    Public startFY As String
    Public endFY As String
    Public strArr() As String


    Dim con As SqlConnection = New SqlConnection("Data Source=cris-sql.public.a226b58b96ec.database.windows.net,3342;Initial Catalog=WAP;Persist Security Info=True;User ID=crissqlserver;Password=Cris@BelaQwertPoiuy")



    Sub analysis_all(ByVal startYear As String, ByVal endYear As String)


        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM')"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='STOCK'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='XC'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
		            SELECT TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
		            FROM TOTAL_COUNT_NEW
		            LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = STOCK_NEW.MONTH_YEAR
		            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR
		            LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTION_NEW.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW TSMR_FINAL  AS
                    SELECT TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.First_Date,TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.STOCK_MONTH , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.REJECTION_MONTH, TSMR_ALL.TOTAL_MONTH "



        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str8 = "CREATE OR ALTER VIEW TSMR_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM TSMR_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT TSMR_FINAL_ALLDATA.MONTH_YEAR , TSMR_FINAL_ALLDATA.First_Date , CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_FINAL_ALLDATA.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.MACHINE_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_FINAL_ALLDATA.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.REJECTION_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_FINAL_ALLDATA.TOTAL_MONTH 
                        From TSMR_FINAL_ALLDATA
                        Where TSMR_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY TSMR_FINAL_ALLDATA.First_Date"



        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList

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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)

        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))

            stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))

            'String.Compare(prodTypeStr, "COMBINED") = 0

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While
        rdr.Close()

        con.Close()
    End Sub
    Sub analysis_bgc(ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)

        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM')"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%') and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='XC' and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
		            SELECT TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
		            FROM TOTAL_COUNT_NEW
		            LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = STOCK_NEW.MONTH_YEAR
		            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR
		            LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTION_NEW.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW TSMR_FINAL  AS
                    SELECT TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.First_Date,TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.STOCK_MONTH , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.REJECTION_MONTH, TSMR_ALL.TOTAL_MONTH "


        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str8 = "CREATE OR ALTER VIEW TSMR_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM TSMR_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT TSMR_FINAL_ALLDATA.MONTH_YEAR , TSMR_FINAL_ALLDATA.First_Date , CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_FINAL_ALLDATA.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.MACHINE_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_FINAL_ALLDATA.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.REJECTION_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_FINAL_ALLDATA.TOTAL_MONTH 
                        From TSMR_FINAL_ALLDATA
                        Where TSMR_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY TSMR_FINAL_ALLDATA.First_Date"

        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList
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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)

        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While
        rdr.Close()
        con.Close()
    End Sub
    Sub analysis_all_rejection(ByVal startYear As String, ByVal endYear As String)

        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM')"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='STOCK'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='XC'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
		            SELECT TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
		            FROM TOTAL_COUNT_NEW
		            LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = STOCK_NEW.MONTH_YEAR
		            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR
		            LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTION_NEW.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW TSMR_FINAL  AS
                    SELECT TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.First_Date,TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.STOCK_MONTH , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.REJECTION_MONTH, TSMR_ALL.TOTAL_MONTH "


        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str8 = "CREATE OR ALTER VIEW TSMR_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM TSMR_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT TSMR_FINAL_ALLDATA.MONTH_YEAR , TSMR_FINAL_ALLDATA.First_Date , CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_FINAL_ALLDATA.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.MACHINE_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_FINAL_ALLDATA.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.REJECTION_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_FINAL_ALLDATA.TOTAL_MONTH 
                        From TSMR_FINAL_ALLDATA
                        Where TSMR_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY TSMR_FINAL_ALLDATA.First_Date"



        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList

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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)

        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add("")
            machine_month_per.Add("")
            'stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            ' machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))


            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If


        End While

        rdr.Close()

        con.Close()
    End Sub
    Sub analysis_bgc_rejection(ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)

        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM')"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%') and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
		            SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
		            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
		            WHERE WheelType='F' AND FinalStatus='XC' and prodtype='" & prodType & "'
		            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
		            SELECT TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
		            FROM TOTAL_COUNT_NEW
		            LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = STOCK_NEW.MONTH_YEAR
		            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR
		            LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTION_NEW.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW TSMR_FINAL  AS
                    SELECT TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.First_Date,TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.STOCK_MONTH , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.REJECTION_MONTH, TSMR_ALL.TOTAL_MONTH "


        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str8 = "CREATE OR ALTER VIEW TSMR_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM TSMR_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT TSMR_FINAL_ALLDATA.MONTH_YEAR , TSMR_FINAL_ALLDATA.First_Date , CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_FINAL_ALLDATA.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_FINAL_ALLDATA.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.MACHINE_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_FINAL_ALLDATA.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_FINAL_ALLDATA.REJECTION_MONTH * 100.0 / NULLIF(TSMR_FINAL_ALLDATA.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_FINAL_ALLDATA.TOTAL_MONTH 
                        From TSMR_FINAL_ALLDATA
                        Where TSMR_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY TSMR_FINAL_ALLDATA.First_Date"

        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList
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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)

        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add("")
            machine_month_per.Add("")
            'stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            'machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))


            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While
        rdr.Close()
        con.Close()
    End Sub
    Sub pie_quality_analysis(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)


        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS TOTAL
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR,  count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND FinalStatus='STOCK'
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%')
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND FinalStatus='XC'
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
                    SELECT TOTAL_COUNT_NEW.FIN_YR,  ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
                    FROM TOTAL_COUNT_NEW
                    LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.FIN_YR = STOCK_NEW.FIN_YR
                    LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.FIN_YR = MACHINE_NEW.FIN_YR
                    LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.FIN_YR = REJECTION_NEW.FIN_YR"

        Dim str6 = "CREATE OR ALTER VIEW PIE_FINAL AS
                    SELECT TSMR_ALL.FIN_YR , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.FIN_YR,TSMR_ALL.STOCK_MONTH,TSMR_ALL.MACHINE_MONTH,TSMR_ALL.REJECTION_MONTH,TSMR_ALL.TOTAL_MONTH"


        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR , -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR , number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR
                    from MONTH_YEAR_TABLE 
                    GROUP by FIN_YR"

        Dim str8 = "CREATE OR ALTER VIEW PIE_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM PIE_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER_PIE AS B ON B.FIN_YR=A.FIN_YR
                    GROUP BY B.FIN_YR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT PIE_FINAL_ALLDATA.FIN_YR, PIE_FINAL_ALLDATA.STOCK_MONTH_PER,PIE_FINAL_ALLDATA.MACHINE_MONTH_PER,PIE_FINAL_ALLDATA.REJECTION_MONTH_PER
                        From PIE_FINAL_ALLDATA
                        Where PIE_FINAL_ALLDATA.FIN_YR IN ('" & finYear & "')
                        ORDER BY PIE_FINAL_ALLDATA.FIN_YR"





        Dim rdr As SqlDataReader


        pie_smr_all_quality = New ArrayList

        Dim stock_str As String
        Dim machine_str As String
        Dim rejection_str As String
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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)

        While rdr.Read

            stock_str = rdr.Item("STOCK_MONTH_PER")
            pie_smr_all_quality.Add(stock_str)
            machine_str = rdr.Item("MACHINE_MONTH_PER")
            pie_smr_all_quality.Add(machine_str)
            rejection_str = rdr.Item("REJECTION_MONTH_PER")
            pie_smr_all_quality.Add(rejection_str)
        End While




        rdr.Close()

        con.Close()
    End Sub
    Sub pie_rejection_analysis(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)

        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear(A.TestDate) AS FIN_YR, A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES like concat (b.defect_code , '%')
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim str2 = "CREATE Or ALTER VIEW REJECTIONPIEDEFECT AS
                    Select REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_DESC, COUNT(*) As DEFECT_COUNT
                    From REJECTIONPIE
                    Group BY REJECTIONPIE.FIN_YR, REJECTIONPIE.DEFECT_DESC"


        Dim str3 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE_REJECTION AS
                    SELECT REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_DESC ,  REJECTIONPIEDEFECT.DEFECT_COUNT ,  CAST(ROUND(ISNULL((CAST(ROUND((REJECTIONPIEDEFECT.DEFECT_COUNT),0) As int) * 100.0 / NULLIF((SELECT SUM(REJECTIONPIEDEFECT.DEFECT_COUNT) FROM REJECTIONPIEDEFECT), 0)), 0) , 2) As Decimal(5,2)) As DEFECT_PER
                    FROM REJECTIONPIEDEFECT
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_DESC , REJECTIONPIEDEFECT.DEFECT_COUNT"

        Dim str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR , -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR , number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR
                    from MONTH_YEAR_TABLE 
                    GROUP by FIN_YR"

        Dim str5_value = "SELECT B.FIN_YR , ISNULL(A.DEFECT_DESC,0) AS DEFECT_DESC , ISNULL(A.DEFECT_PER,0) AS DEFECT_PER
                        FROM FIN_MONTH_FIRSTDATE_MASTER_PIE_REJECTION AS A 
                        RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER_PIE AS B ON B.FIN_YR=A.FIN_YR
                        WHERE B.FIN_YR IN ('" & finYear & "')
                        GROUP BY B.FIN_YR,A.DEFECT_DESC,A.DEFECT_PER"

        Dim rdr As SqlDataReader


        rejection_analysis_defect_desc = New ArrayList
        rejection_analysis_defect_per = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5_value)

        While rdr.Read

            rejection_analysis_defect_desc.Add(rdr.Item("DEFECT_DESC"))
            rejection_analysis_defect_per.Add(rdr.Item("DEFECT_PER"))

        End While




        rdr.Close()

        con.Close()
    End Sub
    Sub pie_quality_analysis_bgc(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)

        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS TOTAL
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str2 = "CREATE OR ALTER VIEW STOCK_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR,  count(distinct concat(heatno, wheelno)) AS STOCK_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='" & prodType & "'
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str3 = "CREATE OR ALTER VIEW MACHINE_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%') and prodtype='" & prodType & "'
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str4 = "CREATE OR ALTER VIEW REJECTION_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, count(distinct concat(heatno, wheelno)) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND FinalStatus='XC' and prodtype='" & prodType & "'
                    GROUP BY year(TestDate),dbo.GetFinancialYear(TestDate)"

        Dim str5 = "CREATE OR ALTER VIEW TSMR_ALL  AS
                    SELECT TOTAL_COUNT_NEW.FIN_YR,  ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(STOCK_NEW.STOCK_COUNT , 0) AS STOCK_MONTH , ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH , ISNULL(REJECTION_NEW.REJECTION_COUNT , 0)  AS REJECTION_MONTH
                    FROM TOTAL_COUNT_NEW
                    LEFT JOIN STOCK_NEW ON TOTAL_COUNT_NEW.FIN_YR = STOCK_NEW.FIN_YR
                    LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.FIN_YR = MACHINE_NEW.FIN_YR
                    LEFT JOIN REJECTION_NEW ON TOTAL_COUNT_NEW.FIN_YR = REJECTION_NEW.FIN_YR"

        Dim str6 = "CREATE OR ALTER VIEW PIE_FINAL AS
                    SELECT TSMR_ALL.FIN_YR , CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) As STOCK_MONTH, CAST(ROUND(ISNULL((CAST(ROUND((TSMR_ALL.STOCK_MONTH),0) As int) * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As STOCK_MONTH_PER , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.REJECTION_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.REJECTION_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As REJECTION_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                    From TSMR_ALL
                    GROUP BY TSMR_ALL.FIN_YR,TSMR_ALL.STOCK_MONTH,TSMR_ALL.MACHINE_MONTH,TSMR_ALL.REJECTION_MONTH,TSMR_ALL.TOTAL_MONTH"


        Dim str7 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR , -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR , number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR
                    from MONTH_YEAR_TABLE 
                    GROUP by FIN_YR"

        Dim str8 = "CREATE OR ALTER VIEW PIE_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , ISNULL(A.STOCK_MONTH,0) AS STOCK_MONTH , ISNULL(A.STOCK_MONTH_PER,0) AS STOCK_MONTH_PER  , ISNULL(A.REJECTION_MONTH, 0) AS REJECTION_MONTH , ISNULL(A.REJECTION_MONTH_PER,0) AS REJECTION_MONTH_PER , ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH  ,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER , ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                    FROM PIE_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER_PIE AS B ON B.FIN_YR=A.FIN_YR
                    GROUP BY B.FIN_YR,A.MACHINE_MONTH_PER,A.MACHINE_MONTH, A.TOTAL_MONTH,A.STOCK_MONTH , A.STOCK_MONTH_PER , A.REJECTION_MONTH, A.REJECTION_MONTH_PER"

        Dim str9_value = "SELECT PIE_FINAL_ALLDATA.FIN_YR, PIE_FINAL_ALLDATA.STOCK_MONTH_PER,PIE_FINAL_ALLDATA.MACHINE_MONTH_PER,PIE_FINAL_ALLDATA.REJECTION_MONTH_PER
                        From PIE_FINAL_ALLDATA
                        Where PIE_FINAL_ALLDATA.FIN_YR IN ('" & finYear & "')
                        ORDER BY PIE_FINAL_ALLDATA.FIN_YR"





        Dim rdr As SqlDataReader


        pie_smr_all_quality = New ArrayList

        Dim stock_str As String
        Dim machine_str As String
        Dim rejection_str As String
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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str9_value)


        While rdr.Read

            stock_str = rdr.Item("STOCK_MONTH_PER")
            pie_smr_all_quality.Add(stock_str)
            machine_str = rdr.Item("MACHINE_MONTH_PER")
            pie_smr_all_quality.Add(machine_str)
            rejection_str = rdr.Item("REJECTION_MONTH_PER")
            pie_smr_all_quality.Add(rejection_str)
        End While




        rdr.Close()

        con.Close()
    End Sub

    Sub pie_rejection_analysis_bgc(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)


        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear(A.TestDate) AS FIN_YR, A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND ProdType= '" & prodType & "' AND A.DEFECTCODES like concat (b.defect_code , '%')
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim str2 = "CREATE Or ALTER VIEW REJECTIONPIEDEFECT AS
                    Select REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_DESC, COUNT(*) As DEFECT_COUNT
                    From REJECTIONPIE
                    Group BY REJECTIONPIE.FIN_YR, REJECTIONPIE.DEFECT_DESC"


        Dim str3 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE_REJECTION AS
                    SELECT REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_DESC ,  REJECTIONPIEDEFECT.DEFECT_COUNT ,  CAST(ROUND(ISNULL((CAST(ROUND((REJECTIONPIEDEFECT.DEFECT_COUNT),0) As int) * 100.0 / NULLIF((SELECT SUM(REJECTIONPIEDEFECT.DEFECT_COUNT) FROM REJECTIONPIEDEFECT), 0)), 0) , 2) As Decimal(5,2)) As DEFECT_PER
                    FROM REJECTIONPIEDEFECT
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_DESC , REJECTIONPIEDEFECT.DEFECT_COUNT"

        Dim str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER_PIE AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR , -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR , number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR
                    from MONTH_YEAR_TABLE 
                    GROUP by FIN_YR"

        Dim str5_value = "SELECT B.FIN_YR , ISNULL(A.DEFECT_DESC,0) AS DEFECT_DESC , ISNULL(A.DEFECT_PER,0) AS DEFECT_PER
                        FROM FIN_MONTH_FIRSTDATE_MASTER_PIE_REJECTION AS A 
                        RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER_PIE AS B ON B.FIN_YR=A.FIN_YR
                        WHERE B.FIN_YR IN ('" & finYear & "')
                        GROUP BY B.FIN_YR,A.DEFECT_DESC,A.DEFECT_PER"

        Dim rdr As SqlDataReader


        rejection_analysis_defect_desc = New ArrayList
        rejection_analysis_defect_per = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5_value)

        While rdr.Read

            rejection_analysis_defect_desc.Add(rdr.Item("DEFECT_DESC"))
            rejection_analysis_defect_per.Add(rdr.Item("DEFECT_PER"))

        End While




        rdr.Close()

        con.Close()
    End Sub

    Sub percentage_fw_rejection_dr_combined(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)

        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                    GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear(A.TestDate) AS FIN_YR, A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES like concat (b.defect_code , '%')
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"


        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR, CAST((SUM(REJECTIONPIEDEFECT.DEFECT_COUNT)*1.0/12) as decimal(5,2)) AS REJECTION_PER
                    FROM REJECTIONPIEDEFECT
                    WHERE REJECTIONPIEDEFECT.FIN_YR NOT IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR"

        Dim str4 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


        Dim str5 = "CREATE OR ALTER VIEW DARKROOM_FINAL AS
                    SELECT TOTAL_COUNT_NEW.FIN_YR,TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(REJECTIONPIEDEFECT.DEFECT_COUNT , 0) AS DEFECT_COUNT , CAST(ROUND(ISNULL((CAST(ROUND((REJECTIONPIEDEFECT.DEFECT_COUNT),0) As int) * 100.0 / NULLIF(TOTAL_COUNT_NEW.TOTAL, 0)), 0) , 2) As Decimal(5,2)) As DEFECT_PER
                    FROM TOTAL_COUNT_NEW
                    LEFT JOIN REJECTIONPIEDEFECT ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTIONPIEDEFECT.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str7 = "CREATE OR ALTER VIEW DARKROOM_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.DEFECT_COUNT,0) AS DEFECT_COUNT , ISNULL(A.DEFECT_PER,0) AS DEFECT_PER
                    FROM DARKROOM_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.DEFECT_PER,a.DEFECT_COUNT"

        Dim str8_value = "SELECT DARKROOM_FINAL_ALLDATA.MONTH_YEAR , DARKROOM_FINAL_ALLDATA.First_Date , DARKROOM_FINAL_ALLDATA.DEFECT_COUNT , DARKROOM_FINAL_ALLDATA.DEFECT_PER
                        From DARKROOM_FINAL_ALLDATA
                        Where DARKROOM_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY DARKROOM_FINAL_ALLDATA.First_Date"

        Dim rdr As SqlDataReader
        percent_label = New ArrayList
        percent_value = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)

        While rdr.Read

            If rdr.HasRows Then
                percent_label.Add(rdr.Item("FIN_YR"))

                percent_value.Add(rdr.Item("REJECTION_PER"))
            End If

        End While

        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8_value)

        While rdr.Read
            percent_label.Add(rdr.Item("MONTH_YEAR"))

            percent_value.Add(rdr.Item("DEFECT_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()

        con.Close()
    End Sub
    Sub percentage_fw_rejection_dr_bgc(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)


        Dim str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                    SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                    WHERE WheelType='F' AND ProdType= '" & prodType & "' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                    GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear(A.TestDate) AS FIN_YR, A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) AS REJECTION_COUNT
                    FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                    WHERE WheelType='F' AND ProdType= '" & prodType & "' AND FinalStatus='XC' AND A.DEFECTCODES like concat (b.defect_code , '%')
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"


        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR, CAST((SUM(REJECTIONPIEDEFECT.DEFECT_COUNT)*1.0/12) as decimal(5,2)) AS REJECTION_PER
                    FROM REJECTIONPIEDEFECT
                    WHERE REJECTIONPIEDEFECT.FIN_YR NOT IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR"

        Dim str4 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


        Dim str5 = "CREATE OR ALTER VIEW DARKROOM_FINAL AS
                    SELECT TOTAL_COUNT_NEW.FIN_YR,TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH, ISNULL(REJECTIONPIEDEFECT.DEFECT_COUNT , 0) AS DEFECT_COUNT , CAST(ROUND(ISNULL((CAST(ROUND((REJECTIONPIEDEFECT.DEFECT_COUNT),0) As int) * 100.0 / NULLIF(TOTAL_COUNT_NEW.TOTAL, 0)), 0) , 2) As Decimal(5,2)) As DEFECT_PER
                    FROM TOTAL_COUNT_NEW
                    LEFT JOIN REJECTIONPIEDEFECT ON TOTAL_COUNT_NEW.MONTH_YEAR = REJECTIONPIEDEFECT.MONTH_YEAR"

        Dim str6 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                    WITH MONTH_YEAR_TABLE AS (
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                    UNION ALL
                    SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                    from MONTH_YEAR_TABLE 
                    where number<38
                    )
                    select FIN_YR, MONTH_YEAR, First_Date 
                    from MONTH_YEAR_TABLE 
                    GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str7 = "CREATE OR ALTER VIEW DARKROOM_FINAL_ALLDATA AS
                    SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date, ISNULL(A.DEFECT_COUNT,0) AS DEFECT_COUNT , ISNULL(A.DEFECT_PER,0) AS DEFECT_PER
                    FROM DARKROOM_FINAL AS A 
                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.DEFECT_PER,a.DEFECT_COUNT"

        Dim str8_value = "SELECT DARKROOM_FINAL_ALLDATA.MONTH_YEAR , DARKROOM_FINAL_ALLDATA.First_Date , DARKROOM_FINAL_ALLDATA.DEFECT_COUNT , DARKROOM_FINAL_ALLDATA.DEFECT_PER
                        From DARKROOM_FINAL_ALLDATA
                        Where DARKROOM_FINAL_ALLDATA.First_Date BETWEEN '" & startYear & "' AND '" & endYear & "'
                        ORDER BY DARKROOM_FINAL_ALLDATA.First_Date"

        Dim rdr As SqlDataReader
        percent_label = New ArrayList
        percent_value = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)

        While rdr.Read

            If rdr.HasRows Then
                percent_label.Add(rdr.Item("FIN_YR"))

                percent_value.Add(rdr.Item("REJECTION_PER"))
            End If

        End While

        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str8_value)

        While rdr.Read
            percent_label.Add(rdr.Item("MONTH_YEAR"))

            percent_value.Add(rdr.Item("DEFECT_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()

        con.Close()



    End Sub

    Sub percentage_rejection_bad_chemistry(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)


        Dim str1 = "CREATE OR ALTER VIEW OFF_HEAT_TOTAL AS
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year, CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(heat_number) AS Off_Heat_Total 
                            FROM wap.dbo.mm_offheat_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"


        Dim str2 = "CREATE OR ALTER VIEW HEAT_SHEET_TOTAL AS
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year , CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(heat_number) AS Heat_Sheet_Total 
                            FROM wap.dbo.mm_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"

        Dim str3 = "CREATE OR ALTER VIEW BAD_CHEM_FINAL AS
                            SELECT OFF_HEAT_TOTAL.FIN_YR , OFF_HEAT_TOTAL.Month_Year , OFF_HEAT_TOTAL.Off_Heat_Total , HEAT_SHEET_TOTAL.Heat_Sheet_Total , CAST(ROUND(ISNULL((OFF_HEAT_TOTAL.Off_Heat_Total * 100.0 / NULLIF((HEAT_SHEET_TOTAL.Heat_Sheet_Total+OFF_HEAT_TOTAL.Off_Heat_Total), 0)), 0) , 2) as decimal(5,2)) AS Bad_Chem_Per
                            FROM OFF_HEAT_TOTAL
                            LEFT JOIN HEAT_SHEET_TOTAL ON OFF_HEAT_TOTAL.Month_Year = HEAT_SHEET_TOTAL.Month_Year
                            GROUP BY year(OFF_HEAT_TOTAL.First_Date),month(OFF_HEAT_TOTAL.First_Date),OFF_HEAT_TOTAL.FIN_YR,OFF_HEAT_TOTAL.Month_Year,OFF_HEAT_TOTAL.Off_Heat_Total,HEAT_SHEET_TOTAL.Heat_Sheet_Total"

        Dim str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim str5_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.Bad_Chem_Per,0) as Bad_Chem_Per
                                FROM BAD_CHEM_FINAL AS A 
                                RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                WHERE B.FIN_YR IN ('" & finYear & "')
                                GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.Bad_Chem_Per
                                ORDER BY B.First_Date"





        Dim rdr As SqlDataReader
        badchem_month = New ArrayList
        badchem_percent = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5_value)

        While rdr.Read
            badchem_month.Add(rdr.Item("MONTH_YEAR"))

            badchem_percent.Add(rdr.Item("Bad_Chem_Per"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()


        con.Close()
    End Sub

    Sub func1_pr_mw_rejection_badchem(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim badchem_str1 = "CREATE OR ALTER VIEW OFF_HEAT_TOTAL AS
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year, CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(heat_number) AS Off_Heat_Total 
                            FROM wap.dbo.mm_offheat_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"


        Dim badchem_str2 = "CREATE OR ALTER VIEW HEAT_SHEET_TOTAL AS
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year , CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(heat_number) AS Heat_Sheet_Total 
                            FROM wap.dbo.mm_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"

        Dim badchem_str3 = "CREATE OR ALTER VIEW BAD_CHEM_FINAL AS
                            SELECT OFF_HEAT_TOTAL.FIN_YR , OFF_HEAT_TOTAL.Month_Year , OFF_HEAT_TOTAL.Off_Heat_Total , HEAT_SHEET_TOTAL.Heat_Sheet_Total , CAST(ROUND(ISNULL((OFF_HEAT_TOTAL.Off_Heat_Total * 100.0 / NULLIF((HEAT_SHEET_TOTAL.Heat_Sheet_Total+OFF_HEAT_TOTAL.Off_Heat_Total), 0)), 0) , 2) as decimal(5,2)) AS Bad_Chem_Per
                            FROM OFF_HEAT_TOTAL
                            LEFT JOIN HEAT_SHEET_TOTAL ON OFF_HEAT_TOTAL.Month_Year = HEAT_SHEET_TOTAL.Month_Year
                            GROUP BY year(OFF_HEAT_TOTAL.First_Date),month(OFF_HEAT_TOTAL.First_Date),OFF_HEAT_TOTAL.FIN_YR,OFF_HEAT_TOTAL.Month_Year,OFF_HEAT_TOTAL.Off_Heat_Total,HEAT_SHEET_TOTAL.Heat_Sheet_Total"

        Dim badchem_str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim badchem_str5_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.Bad_Chem_Per,0) as Bad_Chem_Per
                                FROM BAD_CHEM_FINAL AS A 
                                RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                                GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.Bad_Chem_Per
                                ORDER BY B.First_Date"



        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str5_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("Bad_Chem_Per"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim mrxc_str1 = "CREATE OR ALTER VIEW MRXCMONTH AS
                        SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(*) AS MRXC_COUNT
                        FROM wap.dbo.mm_pouring
                        WHERE rejection_code LIKE 'XC%'
                        GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str2 = "CREATE OR ALTER VIEW MRXCTOTAL AS
                        SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(engraved_number) AS MRXC_COUNT_TOTAL
                        FROM wap.dbo.mm_pouring
                        GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str3 = "CREATE OR ALTER VIEW MRXC_FINAL AS
                        SELECT MRXCTOTAL.FIN_YR, MRXCTOTAL.MONTH_YEAR , MRXCTOTAL.MRXC_COUNT_TOTAL , MRXCMONTH.MRXC_COUNT , CAST(ROUND(ISNULL((MRXCMONTH.MRXC_COUNT * 100.0 / NULLIF(MRXCTOTAL.MRXC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MRXC_PER
                        FROM MRXCTOTAL
                        LEFT JOIN MRXCMONTH ON MRXCTOTAL.MONTH_YEAR = MRXCMONTH.MONTH_YEAR
                        GROUP BY year(MRXCTOTAL.First_Date),month(MRXCTOTAL.First_Date),MRXCTOTAL.FIN_YR, MRXCTOTAL.MONTH_YEAR , MRXCTOTAL.MRXC_COUNT_TOTAL , MRXCMONTH.MRXC_COUNT"

        Dim mrxc_str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                        WITH MONTH_YEAR_TABLE AS (
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                        UNION ALL
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                        from MONTH_YEAR_TABLE 
                        where number<38
                        )
                        select FIN_YR, MONTH_YEAR, First_Date 
                        from MONTH_YEAR_TABLE 
                        GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim mrxc_str5_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.MRXC_PER,0) as MRXC_PER
                            FROM MRXC_FINAL AS A 
                            RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                             WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MRXC_PER
                            ORDER BY B.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str5_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_pr_mw_rejection_defect(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim defect_str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                            SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) REJECTION_COUNT
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                            WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES like concat (b.defect_code , '%')
                            GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim defect_str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                            SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                            FROM REJECTIONPIE
                            GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"

        Dim defect_str3 = "CREATE OR ALTER VIEW TOTALPIE AS
                            SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL_COUNT
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim defect_str4 = "CREATE OR ALTER VIEW DEFECT_FINAL AS
                                SELECT TOTALPIE.FIN_YR,TOTALPIE.MONTH_YEAR,TOTALPIE.TOTAL_COUNT,REJECTIONPIEDEFECT.DEFECT_COUNT,
                                CAST(ROUND(ISNULL((REJECTIONPIEDEFECT.DEFECT_COUNT * 100.0 / NULLIF(TOTALPIE.TOTAL_COUNT, 0)), 0) , 2) as decimal(5,2)) AS REJECTION_PER
                                FROM TOTALPIE
                                LEFT JOIN REJECTIONPIEDEFECT ON TOTALPIE.MONTH_YEAR=REJECTIONPIEDEFECT.MONTH_YEAR"

        Dim defect_str5 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim defect_str6_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.REJECTION_PER,0) as REJECTION_PER
                                FROM DEFECT_FINAL AS A 
                                RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                                GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.REJECTION_PER
                                ORDER BY B.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_defect = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str6_value)

        While rdr.Read
            pr_mw_rejection_defect.Add(rdr.Item("REJECTION_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_pr_mw_rejection_machining(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim machining_str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                            SELECT  dbo.GetFinancialYear(TestDate) AS FIN_YR,CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%')
                            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim machining_str2 = "CREATE OR ALTER VIEW MACHINE_NEW AS
                                SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
                                FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%')
                                GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim machining_str3 = "CREATE OR ALTER VIEW TSMR_ALL AS
                            SELECT TOTAL_COUNT_NEW.FIN_YR, TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH,ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH
                            FROM TOTAL_COUNT_NEW
                            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR"

        Dim machining_str4 = "CREATE OR ALTER VIEW MACHINING_FINAL AS
                                SELECT TSMR_ALL.FIN_YR, TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                                From TSMR_ALL
                                GROUP BY TSMR_ALL.First_Date,TSMR_ALL.FIN_YR, TSMR_ALL.MONTH_YEAR , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.TOTAL_MONTH"

        Dim machining_str5 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                                WITH MONTH_YEAR_TABLE AS (
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                                UNION ALL
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                                from MONTH_YEAR_TABLE 
                                where number<38
                                )
                                select FIN_YR, MONTH_YEAR, First_Date 
                                from MONTH_YEAR_TABLE 
                                GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim machining_str6_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER
                                    FROM MACHINING_FINAL AS A 
                                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                    --WHERE B.First_Date BETWEEN '2020-04-01' AND '2021-03-31'
                                     WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER
                                    ORDER BY B.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str6_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINE_MONTH_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func1_bgc_boxn_pr_mw_rejection_badchem(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL

        Dim badchem_str1 = "CREATE OR ALTER VIEW BADCHEMBGC AS
                            SELECT dbo.GetFinancialYear(a.pour_time) AS FIN_YR, CONCAT(FORMAT(a.pour_time, 'MMM'),'-',FORMAT(a.pour_time, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(a.pour_time, 'yyyy'),'-',FORMAT(a.pour_time, 'MM'),'-','01') AS First_Date , ISNULL(COUNT(b.heat_number),0) AS BADCHEMBGC_COUNT
                            FROM wap.dbo.mm_pouring AS a , wap.dbo.mm_offheat_heatsheet_header as b
                            WHERE a.rejection_code LIKE 'XC%' AND a.wheel_type IN ('" & Prod_Type_Value & "') AND a.heat_number=b.heat_number
                            GROUP BY year(a.pour_time),month(a.pour_time),dbo.GetFinancialYear(a.pour_time),FORMAT(a.pour_time, 'MMM'),FORMAT(a.pour_time, 'yy'),FORMAT(a.pour_time, 'yyyy'),FORMAT(a.pour_time, 'MM')"

        Dim badchem_str2 = "CREATE OR ALTER VIEW BADCHEMBGCTOTAL AS
                            SELECT dbo.GetFinancialYear (a.pour_time) AS FIN_YR, CONCAT(FORMAT(a.pour_time, 'MMM'),'-',FORMAT(a.pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(a.pour_time, 'yyyy'),'-',FORMAT(a.pour_time, 'MM'),'-','01') AS First_Date , ISNULL(COUNT(b.heat_number), 0) AS BADCHEMBGC_COUNT_TOTAL
                            FROM wap.dbo.mm_pouring AS a, wap.dbo.mm_heatsheet_header as b
                            WHERE wheel_type IN ('" & Prod_Type_Value & "') AND a.heat_number=b.heat_number
                            GROUP BY year(a.pour_time),month(a.pour_time),dbo.GetFinancialYear (a.pour_time),FORMAT(a.pour_time, 'MMM'),FORMAT(a.pour_time, 'yy'),FORMAT(a.pour_time, 'yyyy'),FORMAT(a.pour_time, 'MM')"

        Dim badchem_str3 = "CREATE OR ALTER VIEW BADCHEMBGC_FINAL AS
                            SELECT BADCHEMBGCTOTAL.FIN_YR, BADCHEMBGCTOTAL.MONTH_YEAR , BADCHEMBGCTOTAL.BADCHEMBGC_COUNT_TOTAL , BADCHEMBGC.BADCHEMBGC_COUNT , CAST(ROUND(ISNULL((BADCHEMBGC.BADCHEMBGC_COUNT * 100.0 / NULLIF(BADCHEMBGCTOTAL.BADCHEMBGC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_PER
                            FROM BADCHEMBGCTOTAL
                            LEFT JOIN BADCHEMBGC ON BADCHEMBGCTOTAL.MONTH_YEAR = BADCHEMBGC.MONTH_YEAR
                            WHERE BADCHEMBGCTOTAL.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY year(BADCHEMBGCTOTAL.First_Date),month(BADCHEMBGCTOTAL.First_Date),BADCHEMBGCTOTAL.FIN_YR, BADCHEMBGCTOTAL.MONTH_YEAR , BADCHEMBGCTOTAL.BADCHEMBGC_COUNT_TOTAL , BADCHEMBGC.BADCHEMBGC_COUNT"

        Dim badchem_str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim badchem_str5_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.BADCHEM_PER,0) as BADCHEM_PER
                            FROM BADCHEMBGC_FINAL AS A 
                            RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                            WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.BADCHEM_PER
                            ORDER BY B.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str5_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("BADCHEM_PER"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_bgc_boxn_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL


        Dim mrxc_str1 = "CREATE OR ALTER VIEW MRXCMONTH AS
                        SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(*) AS MRXC_COUNT
                        FROM wap.dbo.mm_pouring
                        WHERE rejection_code LIKE 'XC%' AND wheel_type IN ('" & Prod_Type_Value & "')
                        GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str2 = "CREATE OR ALTER VIEW MRXCTOTAL AS
                        SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(engraved_number) AS MRXC_COUNT_TOTAL
                        FROM wap.dbo.mm_pouring
						WHERE wheel_type IN ('" & Prod_Type_Value & "')
                        GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str3 = "CREATE OR ALTER VIEW MRXC_FINAL AS
                        SELECT MRXCTOTAL.FIN_YR, MRXCTOTAL.MONTH_YEAR , MRXCTOTAL.MRXC_COUNT_TOTAL , MRXCMONTH.MRXC_COUNT , CAST(ROUND(ISNULL((MRXCMONTH.MRXC_COUNT * 100.0 / NULLIF(MRXCTOTAL.MRXC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MRXC_PER
                        FROM MRXCTOTAL
                        LEFT JOIN MRXCMONTH ON MRXCTOTAL.MONTH_YEAR = MRXCMONTH.MONTH_YEAR
                        GROUP BY year(MRXCTOTAL.First_Date),month(MRXCTOTAL.First_Date),MRXCTOTAL.FIN_YR, MRXCTOTAL.MONTH_YEAR , MRXCTOTAL.MRXC_COUNT_TOTAL , MRXCMONTH.MRXC_COUNT"

        Dim mrxc_str4 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                        WITH MONTH_YEAR_TABLE AS (
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                        UNION ALL
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                        from MONTH_YEAR_TABLE 
                        where number<38
                        )
                        select FIN_YR, MONTH_YEAR, First_Date 
                        from MONTH_YEAR_TABLE 
                        GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim mrxc_str5_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.MRXC_PER,0) as MRXC_PER
                            FROM MRXC_FINAL AS A 
                            RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                             WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MRXC_PER
                            ORDER BY B.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str5_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_bgc_boxn_pr_mw_rejection_defect(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN

        Dim defect_str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                            SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(WheelNo) REJECTION_COUNT
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords as A, wap.dbo.defect_master as B
                            WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES like concat (b.defect_code , '%') AND ProdType= '" & Prod_Type_Value & "'
                            GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim defect_str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                            SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                            FROM REJECTIONPIE
                            GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"

        Dim defect_str3 = "CREATE OR ALTER VIEW TOTALPIE AS
                            SELECT dbo.GetFinancialYear(TestDate) AS FIN_YR, CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL_COUNT
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%') AND ProdType= '" & Prod_Type_Value & "'
                            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim defect_str4 = "CREATE OR ALTER VIEW DEFECT_FINAL AS
                                SELECT TOTALPIE.FIN_YR,TOTALPIE.MONTH_YEAR,TOTALPIE.TOTAL_COUNT,REJECTIONPIEDEFECT.DEFECT_COUNT,
                                CAST(ROUND(ISNULL((REJECTIONPIEDEFECT.DEFECT_COUNT * 100.0 / NULLIF(TOTALPIE.TOTAL_COUNT, 0)), 0) , 2) as decimal(5,2)) AS REJECTION_PER
                                FROM TOTALPIE
                                LEFT JOIN REJECTIONPIEDEFECT ON TOTALPIE.MONTH_YEAR=REJECTIONPIEDEFECT.MONTH_YEAR"

        Dim defect_str5 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim defect_str6_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.REJECTION_PER,0) as REJECTION_PER
                                FROM DEFECT_FINAL AS A 
                                RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                                GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.REJECTION_PER
                                ORDER BY B.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_defect = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str6_value)

        While rdr.Read
            pr_mw_rejection_defect.Add(rdr.Item("REJECTION_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()


    End Sub


    Sub func4_bgc_boxn_pr_mw_rejection_machining(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN

        Dim machining_str1 = "CREATE OR ALTER VIEW TOTAL_COUNT_NEW AS
                            SELECT  dbo.GetFinancialYear(TestDate) AS FIN_YR,CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(TestDate, 'yyyy'),'-',FORMAT(TestDate, 'MM'),'-','01') AS First_Date, count(distinct concat(heatno, wheelno)) AS TOTAL
                            FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F' and (finalstatus not like 'R%'  and finalstatus not like 'G%') AND ProdType='" & Prod_Type_Value & "'
                            GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy'),FORMAT(TestDate, 'yyyy'),FORMAT(TestDate, 'MM'),dbo.GetFinancialYear(TestDate)"

        Dim machining_str2 = "CREATE OR ALTER VIEW MACHINE_NEW AS
                                SELECT CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, count(distinct concat(heatno, wheelno)) AS MACHINE_COUNT
                                FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F' AND (Machining like 'H%' or Machining like 'B%' or Machining like 'V%') AND ProdType='" & Prod_Type_Value & "'
                                GROUP BY year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim machining_str3 = "CREATE OR ALTER VIEW TSMR_ALL AS
                            SELECT TOTAL_COUNT_NEW.FIN_YR, TOTAL_COUNT_NEW.MONTH_YEAR, TOTAL_COUNT_NEW.First_Date , ISNULL(TOTAL_COUNT_NEW.TOTAL , 0) AS TOTAL_MONTH,ISNULL(MACHINE_NEW.MACHINE_COUNT , 0) AS MACHINE_MONTH
                            FROM TOTAL_COUNT_NEW
                            LEFT JOIN MACHINE_NEW ON TOTAL_COUNT_NEW.MONTH_YEAR = MACHINE_NEW.MONTH_YEAR"

        Dim machining_str4 = "CREATE OR ALTER VIEW MACHINING_FINAL AS
                                SELECT TSMR_ALL.FIN_YR, TSMR_ALL.MONTH_YEAR , TSMR_ALL.First_Date , TSMR_ALL.MACHINE_MONTH , CAST(ROUND(ISNULL((TSMR_ALL.MACHINE_MONTH * 100.0 / NULLIF(TSMR_ALL.TOTAL_MONTH, 0)), 0) , 2) As Decimal(5,2)) As MACHINE_MONTH_PER , TSMR_ALL.TOTAL_MONTH 
                                From TSMR_ALL
                                GROUP BY TSMR_ALL.First_Date,TSMR_ALL.FIN_YR, TSMR_ALL.MONTH_YEAR , TSMR_ALL.MACHINE_MONTH , TSMR_ALL.TOTAL_MONTH"

        Dim machining_str5 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                                WITH MONTH_YEAR_TABLE AS (
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, -62 as number
                                UNION ALL
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, number+1
                                from MONTH_YEAR_TABLE 
                                where number<38
                                )
                                select FIN_YR, MONTH_YEAR, First_Date 
                                from MONTH_YEAR_TABLE 
                                GROUP by First_Date,FIN_YR, MONTH_YEAR"

        Dim machining_str6_value = "SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date,ISNULL(A.MACHINE_MONTH_PER,0) as MACHINE_MONTH_PER
                                    FROM MACHINING_FINAL AS A 
                                    RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year
                                    --WHERE B.First_Date BETWEEN '2020-04-01' AND '2021-03-31'
                                     WHERE B.FIN_YR IN ('" & Fin_Year_Value & "')
                                    GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.MACHINE_MONTH_PER
                                    ORDER BY B.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str4)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str5)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str6_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINE_MONTH_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()


    End Sub

    Sub func1_cum_com_pr_mw_rejection_badchem(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim badchem_str1 = "CREATE OR ALTER VIEW CUMCOMBINEDBADCHEMFINYR AS
                            SELECT CUMCOMBINEDBADCHEM.FIN_YR, CUMCOMBINEDBADCHEM.MONTH_YEAR , CUMCOMBINEDBADCHEM.First_Date, CUMCOMBINEDBADCHEM.Off_Heat_Total, CUMCOMBINEDBADCHEM.Heat_Sheet_Total, CUMCOMBINEDBADCHEM.Bad_Chem_Per
                            FROM CUMCOMBINEDBADCHEM
                            WHERE CUMCOMBINEDBADCHEM.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY year(CUMCOMBINEDBADCHEM.First_Date),month(CUMCOMBINEDBADCHEM.First_Date),CUMCOMBINEDBADCHEM.FIN_YR, CUMCOMBINEDBADCHEM.MONTH_YEAR , CUMCOMBINEDBADCHEM.First_Date, CUMCOMBINEDBADCHEM.Off_Heat_Total, CUMCOMBINEDBADCHEM.Heat_Sheet_Total , CUMCOMBINEDBADCHEM.Bad_Chem_Per"

        '('" & Fin_Year_Value & "')



        Dim badchem_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.Heat_Sheet_Total , SUM(B2.Heat_Sheet_Total) AS BADCHEM_COUNT_TOTAL_CUM , B1.Off_Heat_Total , SUM(B2.Off_Heat_Total) AS BADCHEMBGC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.Off_Heat_Total) * 100.0 / NULLIF(SUM(B2.Heat_Sheet_Total+B2.Off_Heat_Total), 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_CUM_PER
                                    FROM CUMCOMBINEDBADCHEMFINYR B1
                                    INNER JOIN CUMCOMBINEDBADCHEMFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.Heat_Sheet_Total , B1.Off_Heat_Total
                                    ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2_value)


        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("BADCHEM_CUM_PER"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_cum_com_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList 

        ' IN ('" & Fin_Year_Value & "')

        Dim mrxc_str1 = "CREATE OR ALTER VIEW CUMCOMBINEDMRXCFINYR AS
                        SELECT CUMCOMBINEDMRXC.FIN_YR, CUMCOMBINEDMRXC.MONTH_YEAR , CUMCOMBINEDMRXC.First_Date , CUMCOMBINEDMRXC.MRXC_COUNT_TOTAL , CUMCOMBINEDMRXC.MRXC_COUNT
                        FROM CUMCOMBINEDMRXC
                        WHERE CUMCOMBINEDMRXC.FIN_YR IN ('" & Fin_Year_Value & "')
                        GROUP BY year(CUMCOMBINEDMRXC.First_Date),month(CUMCOMBINEDMRXC.First_Date),CUMCOMBINEDMRXC.FIN_YR,CUMCOMBINEDMRXC.MONTH_YEAR ,CUMCOMBINEDMRXC.First_Date , CUMCOMBINEDMRXC.MRXC_COUNT_TOTAL , CUMCOMBINEDMRXC.MRXC_COUNT"

        Dim mrxc_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.MRXC_COUNT_TOTAL , SUM(B2.MRXC_COUNT_TOTAL) AS MRXC_COUNT_TOTAL_CUM , B1.MRXC_COUNT , SUM(B2.MRXC_COUNT) AS MRXC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.MRXC_COUNT) * 100.0 / NULLIF(SUM(B2.MRXC_COUNT_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS MRXC_CUM_PER
                                FROM CUMCOMBINEDMRXCFINYR B1
                                INNER JOIN CUMCOMBINEDMRXCFINYR B2 ON B1.First_Date>=B2.First_Date
                                GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.MRXC_COUNT_TOTAL , B1.MRXC_COUNT
                                ORDER BY B1.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_cum_com_pr_mw_rejection_defect(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList '" & Fin_Year_Value & "'

        ' IN ('" & Fin_Year_Value & "')

        Dim defect_str1 = "CREATE OR ALTER VIEW CUMCOMBINEDDARKROOMFINYR AS
                            SELECT CUMCOMBINEDDARKROOM.FIN_YR, CUMCOMBINEDDARKROOM.MONTH_YEAR , CUMCOMBINEDDARKROOM.First_Date , CUMCOMBINEDDARKROOM.TOTAL_COUNT , CUMCOMBINEDDARKROOM.DEFECT_COUNT
                            FROM CUMCOMBINEDDARKROOM
                            WHERE CUMCOMBINEDDARKROOM.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY year(CUMCOMBINEDDARKROOM.First_Date),month(CUMCOMBINEDDARKROOM.First_Date),CUMCOMBINEDDARKROOM.FIN_YR,CUMCOMBINEDDARKROOM.MONTH_YEAR ,CUMCOMBINEDDARKROOM.First_Date , CUMCOMBINEDDARKROOM.TOTAL_COUNT , CUMCOMBINEDDARKROOM.DEFECT_COUNT"


        Dim defect_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.TOTAL_COUNT , SUM(B2.TOTAL_COUNT) AS TOTAL_COUNT_CUM , B1.DEFECT_COUNT , SUM(B2.DEFECT_COUNT) AS DEFECT_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.DEFECT_COUNT) * 100.0 / NULLIF(SUM(B2.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2)) AS DARKROOM_CUM_PER
                                FROM CUMCOMBINEDDARKROOMFINYR B1
                                INNER JOIN CUMCOMBINEDDARKROOMFINYR B2 ON B1.First_Date>=B2.First_Date
                                GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.TOTAL_COUNT , B1.DEFECT_COUNT
                                ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_defect = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str2_value)

        While rdr.Read
            pr_mw_rejection_defect.Add(rdr.Item("DARKROOM_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_cum_com_pr_mw_rejection_machining(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList '" & Fin_Year_Value & "'

        ' IN ('" & Fin_Year_Value & "')

        Dim machining_str1 = "CREATE OR ALTER VIEW CUMCOMBINEDMACHININGFINYR AS
                                SELECT CUMCOMBINEDMACHINING.FIN_YR , CUMCOMBINEDMACHINING.MONTH_YEAR , CUMCOMBINEDMACHINING.First_Date , CUMCOMBINEDMACHINING.TOTAL_MONTH , CUMCOMBINEDMACHINING.MACHINE_MONTH 
                                FROM CUMCOMBINEDMACHINING
                                WHERE CUMCOMBINEDMACHINING.FIN_YR IN ('" & Fin_Year_Value & "')
                                GROUP BY CUMCOMBINEDMACHINING.FIN_YR ,year(CUMCOMBINEDMACHINING.First_Date),month(CUMCOMBINEDMACHINING.First_Date),CUMCOMBINEDMACHINING.MONTH_YEAR ,CUMCOMBINEDMACHINING.First_Date , CUMCOMBINEDMACHINING.MACHINE_MONTH,CUMCOMBINEDMACHINING.TOTAL_MONTH "

        Dim machining_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.TOTAL_MONTH , SUM(B2.TOTAL_MONTH) AS MACHINING_TOTAL_CUM , B1.MACHINE_MONTH , SUM(B2.MACHINE_MONTH) AS MACHINE_MONTH_CUM , CAST(ROUND(ISNULL((SUM(B2.MACHINE_MONTH) * 100.0 / NULLIF(SUM(B2.TOTAL_MONTH), 0)), 0) , 2) as decimal(5,2)) AS MACHINING_CUM_PER
                                    FROM CUMCOMBINEDMACHININGFINYR B1
                                    INNER JOIN CUMCOMBINEDMACHININGFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.TOTAL_MONTH , B1.MACHINE_MONTH
                                    ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func1_cum_bgc_boxn_pr_mw_rejection_badchem(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        'Dim badchem_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNBADCHEMFINYR AS
        '                    SELECT CUMBGCBOXNBADCHEM.FIN_YR, CUMBGCBOXNBADCHEM.MONTH_YEAR , CUMBGCBOXNBADCHEM.First_Date, CUMBGCBOXNBADCHEM.WHEEL_TYPE , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT_TOTAL , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT 
        '                    FROM CUMBGCBOXNBADCHEM
        '                    WHERE CUMBGCBOXNBADCHEM.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNBADCHEM.WHEEL_TYPE IN ('" & Prod_Type_Value & "')
        '                    GROUP BY year(CUMBGCBOXNBADCHEM.First_Date),month(CUMBGCBOXNBADCHEM.First_Date),CUMBGCBOXNBADCHEM.FIN_YR,CUMBGCBOXNBADCHEM.MONTH_YEAR, CUMBGCBOXNBADCHEM.First_Date, CUMBGCBOXNBADCHEM.WHEEL_TYPE , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT_TOTAL , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT"


        ' --AND CUMBGCBOXNBADCHEM.WHEEL_TYPE IN ('BOXN WHL') ADD PROD TYPE

        ' IN ('" & Fin_Year_Value & "')


        Dim badchem_str1 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date, '" & Prod_Type_Value & "' as WHEEL_TYPE, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date, '" & Prod_Type_Value & "' as WHEEL_TYPE, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date, WHEEL_TYPE 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR,WHEEL_TYPE"

        Dim badchem_str2 = "CREATE OR ALTER VIEW BGCBOXNBADCHEMCUM AS
                            SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date , ISNULL(A.WHEEL_TYPE,'" & Prod_Type_Value & "') AS WHEEL_TYPE ,ISNULL(A.BADCHEMBGC_COUNT,0) AS BADCHEMBGC_COUNT ,ISNULL(A.BADCHEMBGC_COUNT_TOTAL,0) AS BADCHEMBGC_COUNT_TOTAL
                            FROM CUMBGCBOXNBADCHEM AS A 
                            RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year AND A.WHEEL_TYPE=B.WHEEL_TYPE
                            GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.WHEEL_TYPE,A.BADCHEMBGC_COUNT,A.BADCHEMBGC_COUNT_TOTAL"


        Dim badchem_str3 = "CREATE OR ALTER VIEW CUMBGCBOXNBADCHEMFINYR AS
                            SELECT BGCBOXNBADCHEMCUM.FIN_YR, BGCBOXNBADCHEMCUM.MONTH_YEAR , BGCBOXNBADCHEMCUM.First_Date, BGCBOXNBADCHEMCUM.WHEEL_TYPE , BGCBOXNBADCHEMCUM.BADCHEMBGC_COUNT_TOTAL , BGCBOXNBADCHEMCUM.BADCHEMBGC_COUNT 
                            FROM BGCBOXNBADCHEMCUM
                            WHERE BGCBOXNBADCHEMCUM.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY year(BGCBOXNBADCHEMCUM.First_Date),month(BGCBOXNBADCHEMCUM.First_Date),BGCBOXNBADCHEMCUM.FIN_YR,BGCBOXNBADCHEMCUM.MONTH_YEAR, BGCBOXNBADCHEMCUM.First_Date, BGCBOXNBADCHEMCUM.WHEEL_TYPE , BGCBOXNBADCHEMCUM.BADCHEMBGC_COUNT_TOTAL , BGCBOXNBADCHEMCUM.BADCHEMBGC_COUNT"

        Dim badchem_str4_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.BADCHEMBGC_COUNT_TOTAL , SUM(B2.BADCHEMBGC_COUNT_TOTAL) AS BADCHEMBGC_COUNT_TOTAL_CUM , B1.BADCHEMBGC_COUNT , SUM(B2.BADCHEMBGC_COUNT) AS BADCHEMBGC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.BADCHEMBGC_COUNT) * 100.0 / NULLIF(SUM(B2.BADCHEMBGC_COUNT_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_CUM_PER
                                FROM CUMBGCBOXNBADCHEMFINYR B1
                                INNER JOIN CUMBGCBOXNBADCHEMFINYR B2 ON B1.First_Date>=B2.First_Date
                                GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.BADCHEMBGC_COUNT_TOTAL , B1.BADCHEMBGC_COUNT
                                ORDER BY B1.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str4_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("BADCHEM_CUM_PER"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_cum_bgc_boxn_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        'Dim mrxc_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNMRXCFINYR AS
        '                SELECT CUMBGCBOXNMRXC.FIN_YR, CUMBGCBOXNMRXC.MONTH_YEAR , CUMBGCBOXNMRXC.First_Date, CUMBGCBOXNMRXC.WHEEL_TYPE , CUMBGCBOXNMRXC.MRXC_COUNT_TOTAL , CUMBGCBOXNMRXC.MRXC_COUNT
        '                FROM CUMBGCBOXNMRXC
        '                WHERE CUMBGCBOXNMRXC.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNMRXC.WHEEL_TYPE IN ('" & Prod_Type_Value & "')
        '                GROUP BY CUMBGCBOXNMRXC.FIN_YR ,year(CUMBGCBOXNMRXC.First_Date),month(CUMBGCBOXNMRXC.First_Date),CUMBGCBOXNMRXC.MONTH_YEAR ,CUMBGCBOXNMRXC.First_Date, CUMBGCBOXNMRXC.WHEEL_TYPE , CUMBGCBOXNMRXC.MRXC_COUNT_TOTAL , CUMBGCBOXNMRXC.MRXC_COUNT"

        ' --AND CUMBGCBOXNMRXC.WHEEL_TYPE IN ('BOXN WHL') IN ('" & Fin_Year_Value & "')

        Dim mrxc_str1 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                        WITH MONTH_YEAR_TABLE AS (
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as WHEEL_TYPE, -62 as number
                        UNION ALL
                        SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as WHEEL_TYPE, number+1
                        from MONTH_YEAR_TABLE 
                        where number<38
                        )
                        select FIN_YR, MONTH_YEAR, First_Date, WHEEL_TYPE 
                        from MONTH_YEAR_TABLE 
                        GROUP by First_Date,FIN_YR, MONTH_YEAR,WHEEL_TYPE"


        Dim mrxc_str2 = "CREATE OR ALTER VIEW BGCBOXNMRXCCUM AS
                        SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date , ISNULL(A.WHEEL_TYPE,'" & Prod_Type_Value & "') AS WHEEL_TYPE ,ISNULL(A.MRXC_COUNT,0) AS MRXC_COUNT ,ISNULL(A.MRXC_COUNT_TOTAL,0) AS MRXC_COUNT_TOTAL
                        FROM CUMBGCBOXNMRXC AS A 
                        RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year AND A.WHEEL_TYPE=B.WHEEL_TYPE
                        GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.WHEEL_TYPE,A.MRXC_COUNT,A.MRXC_COUNT_TOTAL"

        Dim mrxc_str3 = "CREATE OR ALTER VIEW CUMBGCBOXNMRXCFINYR AS
                        SELECT BGCBOXNMRXCCUM.FIN_YR, BGCBOXNMRXCCUM.MONTH_YEAR , BGCBOXNMRXCCUM.First_Date, BGCBOXNMRXCCUM.WHEEL_TYPE , BGCBOXNMRXCCUM.MRXC_COUNT_TOTAL , BGCBOXNMRXCCUM.MRXC_COUNT
                        FROM BGCBOXNMRXCCUM
                        WHERE BGCBOXNMRXCCUM.FIN_YR IN ('" & Fin_Year_Value & "')
                        GROUP BY BGCBOXNMRXCCUM.FIN_YR ,year(BGCBOXNMRXCCUM.First_Date),month(BGCBOXNMRXCCUM.First_Date),BGCBOXNMRXCCUM.MONTH_YEAR ,BGCBOXNMRXCCUM.First_Date, BGCBOXNMRXCCUM.WHEEL_TYPE , BGCBOXNMRXCCUM.MRXC_COUNT_TOTAL , BGCBOXNMRXCCUM.MRXC_COUNT"

        Dim mrxc_str4_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.MRXC_COUNT_TOTAL , SUM(B2.MRXC_COUNT_TOTAL) AS MRXC_COUNT_TOTAL_CUM , B1.MRXC_COUNT , SUM(B2.MRXC_COUNT) AS MRXC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.MRXC_COUNT) * 100.0 / NULLIF(SUM(B2.MRXC_COUNT_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS MRXC_CUM_PER
                                FROM CUMBGCBOXNMRXCFINYR B1
                                INNER JOIN CUMBGCBOXNMRXCFINYR B2 ON B1.First_Date>=B2.First_Date
                                GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.MRXC_COUNT_TOTAL , B1.MRXC_COUNT
                                ORDER BY B1.First_Date"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str4_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_cum_bgc_boxn_pr_mw_rejection_defect(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim defect_str1 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                            WITH MONTH_YEAR_TABLE AS (
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as PROD_TYPE, -62 as number
                            UNION ALL
                            SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as PROD_TYPE, number+1
                            from MONTH_YEAR_TABLE 
                            where number<38
                            )
                            select FIN_YR, MONTH_YEAR, First_Date, PROD_TYPE 
                            from MONTH_YEAR_TABLE 
                            GROUP by First_Date,FIN_YR, MONTH_YEAR,PROD_TYPE"

        Dim defect_str2 = "CREATE OR ALTER VIEW BGCBOXNDARKROOMCUM AS
                            SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date , ISNULL(A.PROD_TYPE,'" & Prod_Type_Value & "') AS PROD_TYPE ,ISNULL(A.DEFECT_COUNT,0) AS DEFECT_COUNT ,ISNULL(A.TOTAL_COUNT,0) AS TOTAL_COUNT
                            FROM CUMBGCBOXNDARKROOM AS A 
                            RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year AND A.PROD_TYPE=B.PROD_TYPE
                            GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.PROD_TYPE,A.DEFECT_COUNT,A.TOTAL_COUNT"

        Dim defect_str3 = "CREATE OR ALTER VIEW CUMBGCBOXNDARKROOMFINYR AS
                            SELECT BGCBOXNDARKROOMCUM.FIN_YR , BGCBOXNDARKROOMCUM.MONTH_YEAR , BGCBOXNDARKROOMCUM.First_Date, BGCBOXNDARKROOMCUM.PROD_TYPE , BGCBOXNDARKROOMCUM.TOTAL_COUNT,BGCBOXNDARKROOMCUM.DEFECT_COUNT
                            FROM BGCBOXNDARKROOMCUM
                            WHERE BGCBOXNDARKROOMCUM.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY BGCBOXNDARKROOMCUM.FIN_YR ,year(BGCBOXNDARKROOMCUM.First_Date),month(BGCBOXNDARKROOMCUM.First_Date), BGCBOXNDARKROOMCUM.PROD_TYPE,BGCBOXNDARKROOMCUM.MONTH_YEAR ,BGCBOXNDARKROOMCUM.First_Date , BGCBOXNDARKROOMCUM.TOTAL_COUNT,BGCBOXNDARKROOMCUM.DEFECT_COUNT"

        Dim defect_str4_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.TOTAL_COUNT , SUM(B2.TOTAL_COUNT) AS TOTAL_COUNT_CUM , B1.DEFECT_COUNT , SUM(B2.DEFECT_COUNT) AS DEFECT_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.DEFECT_COUNT) * 100.0 / NULLIF(SUM(B2.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2)) AS DARKROOM_CUM_PER
                                FROM CUMBGCBOXNDARKROOMFINYR B1
                                INNER JOIN CUMBGCBOXNDARKROOMFINYR B2 ON B1.First_Date>=B2.First_Date
                                GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.TOTAL_COUNT , B1.DEFECT_COUNT
                                ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_defect = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, defect_str4_value)

        While rdr.Read
            pr_mw_rejection_defect.Add(rdr.Item("DARKROOM_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_cum_bgc_boxn_pr_mw_rejection_machining(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim machining_str1 = "CREATE OR ALTER VIEW FIN_MONTH_FIRSTDATE_MASTER AS
                                WITH MONTH_YEAR_TABLE AS (
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, -62, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, -62, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, -62, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as PROD_TYPE, -62 as number
                                UNION ALL
                                SELECT dbo.GetFinancialYear(CAST(DATEADD(MONTH, number, getdate()) AS DATE)) AS FIN_YR ,CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'MMM'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(DATEADD(MONTH, number, getdate()), 'yyyy'),'-',FORMAT(DATEADD(MONTH, number, getdate()), 'MM'),'-','01') AS First_Date,'" & Prod_Type_Value & "' as PROD_TYPE, number+1
                                from MONTH_YEAR_TABLE 
                                where number<38
                                )
                                select FIN_YR, MONTH_YEAR, First_Date, PROD_TYPE 
                                from MONTH_YEAR_TABLE 
                                GROUP by First_Date,FIN_YR, MONTH_YEAR,PROD_TYPE"

        Dim machining_str2 = "CREATE OR ALTER VIEW BGCBOXNMACHININGCUM AS
                                SELECT B.FIN_YR , B.MONTH_YEAR ,B.First_Date , ISNULL(A.ProdType,'" & Prod_Type_Value & "') AS PROD_TYPE ,ISNULL(A.MACHINE_MONTH,0) AS MACHINE_MONTH ,ISNULL(A.TOTAL_MONTH,0) AS TOTAL_MONTH
                                FROM CUMBGCBOXNMACHINING AS A 
                                RIGHT OUTER JOIN wap.dbo.FIN_MONTH_FIRSTDATE_MASTER AS B ON B.MONTH_YEAR=A.Month_Year AND A.ProdType=B.PROD_TYPE
                                GROUP BY B.First_Date,B.FIN_YR,B.MONTH_YEAR,A.ProdType,A.MACHINE_MONTH,A.TOTAL_MONTH"

        Dim machining_str3 = "CREATE OR ALTER VIEW CUMBGCBOXNMACHININGFINYR AS
                                SELECT BGCBOXNMACHININGCUM.FIN_YR , BGCBOXNMACHININGCUM.MONTH_YEAR , BGCBOXNMACHININGCUM.First_Date, BGCBOXNMACHININGCUM.PROD_TYPE , BGCBOXNMACHININGCUM.TOTAL_MONTH , BGCBOXNMACHININGCUM.MACHINE_MONTH 
                                FROM BGCBOXNMACHININGCUM
                                WHERE BGCBOXNMACHININGCUM.FIN_YR IN ('" & Fin_Year_Value & "')
                                GROUP BY BGCBOXNMACHININGCUM.FIN_YR ,year(BGCBOXNMACHININGCUM.First_Date),month(BGCBOXNMACHININGCUM.First_Date),BGCBOXNMACHININGCUM.MONTH_YEAR, BGCBOXNMACHININGCUM.PROD_TYPE ,BGCBOXNMACHININGCUM.First_Date , BGCBOXNMACHININGCUM.TOTAL_MONTH,BGCBOXNMACHININGCUM.MACHINE_MONTH "

        Dim machining_str4_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.TOTAL_MONTH , SUM(B2.TOTAL_MONTH) AS MACHINING_TOTAL_CUM , B1.MACHINE_MONTH , SUM(B2.MACHINE_MONTH) AS MACHINE_MONTH_CUM , CAST(ROUND(ISNULL((SUM(B2.MACHINE_MONTH) * 100.0 / NULLIF(SUM(B2.TOTAL_MONTH), 0)), 0) , 2) as decimal(5,2)) AS MACHINING_CUM_PER
                                    FROM CUMBGCBOXNMACHININGFINYR B1
                                    INNER JOIN CUMBGCBOXNMACHININGFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.TOTAL_MONTH , B1.MACHINE_MONTH
                                    ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str3)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str4_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_CUM_PER"))

            Dim time As DateTime = DateTime.Now
            Dim format As String = "MMM-yy"
            Dim currentmonyr As String = time.ToString(format)
            Dim datamonyr As String = rdr.Item("MONTH_YEAR")

            If String.Compare(currentmonyr, datamonyr) = 0 Then
                Exit While
            End If
        End While

        rdr.Close()
        con.Close()

    End Sub

    ' Sub analysis_boxn(ByVal startYear As Integer, ByVal endYear As Integer, ByVal prodType As String)
    '     Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
    'SELECT DISTINCT CAST(TestDate AS DATE) TestDate
    'FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
    'GROUP BY TestDate"
    '     Dim str2 = "CREATE OR ALTER VIEW STOCK AS
    '	SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
    '	FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
    '	WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='BOXN'
    '	GROUP BY TestDate"
    '     Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
    '	SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
    '	FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
    '	WHERE WheelType='F' AND Machining IN ('HH','HT') and prodtype='BOXN'
    '	GROUP BY TestDate"
    '     Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
    '	SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
    '	FROM wap.dbo.mm_magnaglow_new_shiftwiserecords
    '	WHERE WheelType='F' AND FinalStatus='XC' and prodtype='BOXN'
    '	GROUP BY TestDate"
    '     Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
    '	SELECT TESTDATE.TestDate , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
    '	FROM TESTDATE
    '	LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
    '	LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
    '	LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
    '     Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
    '                 FROM TOTALPERMONTH
    '                 GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
    '                 ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"


    '     Dim rdr As SqlDataReader
    '     month_year_boxn = New ArrayList
    '     stock_month_per_boxn = New ArrayList
    '     machine_month_per_boxn = New ArrayList
    '     rejection_month_per_boxn = New ArrayList
    '     con.Open()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
    '     rdr.Close()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
    '     rdr.Close()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
    '     rdr.Close()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)
    '     rdr.Close()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str5)
    '     rdr.Close()
    '     rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str6)
    '     While rdr.Read
    '         month_year_boxn.Add(rdr.Item("MONTH_YEAR"))
    '         stock_month_per_boxn.Add(rdr.Item("STOCK_MONTH_PER"))
    '         machine_month_per_boxn.Add(rdr.Item("MACHINE_MONTH_PER"))
    '         rejection_month_per_boxn.Add(rdr.Item("REJECTION_MONTH_PER"))
    '     End While
    '     rdr.Close()
    '     con.Close()
    ' End Sub

    ' Dim startFYInt As Integer
    ' Dim endFYInt As Integer


    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click



        fnYrStr = Fin_Year.SelectedValue

        strArr = fnYrStr.Split("-")

        startFY = strArr(0) + "-04-01"
        endFY = "20" + strArr(1) + "-03-31"

        prodTypeStr = Prod.SelectedValue

        reportTypeStr = Report_Type.SelectedValue

        'Response.Write("***************************************")
        Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startFY & "' AND '" & endFY & "'
                    GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
                    ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"

        ' Response.Write(str6)


        If String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS") = 0 Then
            analysis_all(startFY, endFY)



        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS") = 0 Then

            analysis_bgc(startFY, endFY, prodTypeStr)

        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS") = 0 Then

            analysis_bgc(startFY, endFY, prodTypeStr)



        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS REJECTION") = 0 Then
            analysis_all_rejection(startFY, endFY)

        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS REJECTION") = 0 Then
            analysis_bgc_rejection(startFY, endFY, prodTypeStr)

        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "MONTHWISE ANALYSIS REJECTION") = 0 Then
            analysis_bgc_rejection(startFY, endFY, prodTypeStr)

        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "QUALITY ANALYSIS") = 0 Then
            pie_quality_analysis(fnYrStr, startFY, endFY)
        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "REJECTION ANALYSIS") = 0 Then
            pie_rejection_analysis(fnYrStr, startFY, endFY)
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "QUALITY ANALYSIS") = 0 Then
            pie_quality_analysis_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "QUALITY ANALYSIS") = 0 Then
            pie_quality_analysis_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "REJECTION ANALYSIS") = 0 Then
            pie_rejection_analysis_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "REJECTION ANALYSIS") = 0 Then
            pie_rejection_analysis_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "PERCENTAGE FRESH WHEEL") = 0 Then
            percentage_fw_rejection_dr_combined(fnYrStr, startFY, endFY)
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "PERCENTAGE FRESH WHEEL") = 0 Then
            percentage_fw_rejection_dr_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "PERCENTAGE FRESH WHEEL") = 0 Then
            percentage_fw_rejection_dr_bgc(fnYrStr, startFY, endFY, prodTypeStr)
        ElseIf String.Compare(reportTypeStr, "BAD CHEMISTRY") = 0 Then
            percentage_rejection_bad_chemistry(fnYrStr, startFY, endFY)
        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "PERCENTAGE MONTHWISE REJECTION") = 0 Then
            func1_pr_mw_rejection_badchem(fnYrStr)
            func2_pr_mw_rejection_mrxc(fnYrStr)
            func3_pr_mw_rejection_defect(fnYrStr)
            func4_pr_mw_rejection_machining(fnYrStr)
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "PERCENTAGE MONTHWISE REJECTION") = 0 Then
            func1_bgc_boxn_pr_mw_rejection_badchem(fnYrStr, "ICF WHL")
            func2_bgc_boxn_pr_mw_rejection_mrxc(fnYrStr, "ICF WHL")
            func3_bgc_boxn_pr_mw_rejection_defect(fnYrStr, "BGC")
            func4_bgc_boxn_pr_mw_rejection_machining(fnYrStr, "BGC")
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "PERCENTAGE MONTHWISE REJECTION") = 0 Then
            func1_bgc_boxn_pr_mw_rejection_badchem(fnYrStr, "BOXN WHL")
            func2_bgc_boxn_pr_mw_rejection_mrxc(fnYrStr, "BOXN WHL")
            func3_bgc_boxn_pr_mw_rejection_defect(fnYrStr, "BOXN")
            func4_bgc_boxn_pr_mw_rejection_machining(fnYrStr, "BOXN")
        ElseIf String.Compare(prodTypeStr, "COMBINED") = 0 And String.Compare(reportTypeStr, "PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") = 0 Then
            func1_cum_com_pr_mw_rejection_badchem(fnYrStr)
            func2_cum_com_pr_mw_rejection_mrxc(fnYrStr)
            func3_cum_com_pr_mw_rejection_defect(fnYrStr)
            func4_cum_com_pr_mw_rejection_machining(fnYrStr)
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") = 0 Then
            func1_cum_bgc_boxn_pr_mw_rejection_badchem(fnYrStr, "ICF WHL")
            func2_cum_bgc_boxn_pr_mw_rejection_mrxc(fnYrStr, "ICF WHL")
            func3_cum_bgc_boxn_pr_mw_rejection_defect(fnYrStr, "BGC")
            func4_cum_bgc_boxn_pr_mw_rejection_machining(fnYrStr, "BGC")
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") = 0 Then
            func1_cum_bgc_boxn_pr_mw_rejection_badchem(fnYrStr, "BOXN WHL")
            func2_cum_bgc_boxn_pr_mw_rejection_mrxc(fnYrStr, "BOXN WHL")
            func3_cum_bgc_boxn_pr_mw_rejection_defect(fnYrStr, "BOXN")
            func4_cum_bgc_boxn_pr_mw_rejection_machining(fnYrStr, "BOXN")
        End If

        ' Response.Write() BAD CHEMISTRY PER MW REJECTION COMBINED
    End Sub


End Class