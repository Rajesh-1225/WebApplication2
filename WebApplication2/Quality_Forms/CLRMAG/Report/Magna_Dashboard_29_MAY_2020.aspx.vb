Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data


Public Class Magna_Dashboard_29_MAY_2020
    Inherits System.Web.UI.Page

    'Protected WithEvents financialYear As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents prod_type As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents Fin_Year As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Prod As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Report_Type As System.Web.UI.WebControls.DropDownList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        analysis_all("2020-04-01", "2021-03-31")
        'initial_all()

        Dim rdr As SqlDataReader
        If Not IsPostBack Then
            con.Open()
            Dim sql As String = "SELECT DISTINCT dbo.GetFinancialYear(TestDate) AS FIN_YEAR FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords  ORDER BY FIN_YEAR DESC"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql)
            Fin_Year.DataValueField = "FIN_YEAR"
            Fin_Year.DataTextField = "FIN_YEAR"
            Fin_Year.DataSource = rdr
            Fin_Year.DataBind()
            rdr.Close()
            'Fin_Year.Items.Insert(0, "COMBINED")
            Dim sql1 As String = "SELECT DISTINCT ProdType AS PROD_TYPE FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords ORDER BY ProdType"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql1)
            Prod.DataValueField = "PROD_TYPE"
            Prod.DataTextField = "PROD_TYPE"
            Prod.DataSource = rdr
            Prod.DataBind()
            rdr.Close()
            Prod.Items.Insert(0, "COMBINED")

            Dim sql2 As String = "SELECT DISTINCT Report_Type AS REPORT_TYPE,Report_Id FROM wapdev.dbo.report_master ORDER BY Report_Id"
            rdr = SqlHelper.ExecuteReader(con, CommandType.Text, sql2)
            Report_Type.DataValueField = "REPORT_TYPE"
            Report_Type.DataTextField = "REPORT_TYPE"
            Report_Type.DataSource = rdr
            Report_Type.DataBind()
            rdr.Close()

            con.Close()
        End If



    End Sub

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

    'Public month_year_bgc As New ArrayList
    'Public stock_month_per_bgc As New ArrayList
    'Public machine_month_per_bgc As New ArrayList
    'Public rejection_month_per_bgc As New ArrayList

    'Public month_year_boxn As New ArrayList
    'Public stock_month_per_boxn As New ArrayList
    'Public machine_month_per_boxn As New ArrayList
    'Public rejection_month_per_boxn As New ArrayList

    Public fnYrStr As String
    Public prodTypeStr As String
    Public reportTypeStr As String
    Public startFY As String
    Public endFY As String
    Public strArr() As String

    'Dim con As SqlConnection = New SqlConnection("Data Source=DESKTOP-GRH9OU2\SQLEXPRESS;Initial Catalog=WAP;Persist Security Info=True;User ID=sa;Password=cris-sa")
    Dim con As New SqlConnection("Data Source=rwpbeladev.southindia.cloudapp.azure.com,1433;Initial Catalog=wapdev;User ID=sa;Password=sadev123")


    Sub initial_all()
        Dim str1 = "SELECT DISTINCT dbo.GetFinancialYear(TestDate) AS FIN_YEAR FROM wapdev.dbo.new_data_19_may GROUP BY TestDate"
        Dim str2 = "SELECT DISTINCT ProdType AS PROD_TYPE FROM wapdev.dbo.new_data_19_may ORDER BY ProdType"
        Dim str3 = ""

        Dim rdr As SqlDataReader
        initial_finyr = New ArrayList
        initial_prodtype = New ArrayList
        initial_reports = New ArrayList




        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        While rdr.Read
            initial_finyr.Add(rdr.Item("FIN_YEAR"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        While rdr.Read
            initial_prodtype.Add(rdr.Item("PROD_TYPE"))
        End While
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)
        rdr.Close()


        con.Close()
    End Sub

    Sub analysis_all(ByVal startYear As String, ByVal endYear As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT')
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
        Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
                    ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"


        '  Dim str7 = "SELECT DISTINCT ProdType from wapdev.dbo.mm_magnaglow_new_shiftwiserecords"



        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList
        ' prod_type = New ArrayList
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
        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))
        End While
        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub
    Sub analysis_bgc(ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT') and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC' and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
        Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
                    ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"
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
        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))
        End While
        rdr.Close()
        con.Close()
    End Sub
    Sub analysis_all_rejection(ByVal startYear As String, ByVal endYear As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT')
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
        Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
                    ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"


        '  Dim str7 = "SELECT DISTINCT ProdType from wapdev.dbo.mm_magnaglow_new_shiftwiserecords"



        Dim rdr As SqlDataReader
        month_year = New ArrayList
        stock_month_per = New ArrayList
        machine_month_per = New ArrayList
        rejection_month_per = New ArrayList
        ' prod_type = New ArrayList
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
        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add("")
            machine_month_per.Add("")
            'stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            ' machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))
        End While
        'stock_month_per.Clear()
        'machine_month_per.Clear()
        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub
    Sub analysis_bgc_rejection(ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT') and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC' and prodtype='" & prodType & "'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
        Dim str6 = "SELECT CONCAT(FORMAT(TOTALPERMONTH.TestDate, 'MMM'),'-',FORMAT(TOTALPERMONTH.TestDate, 'yy')) AS MONTH_YEAR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY FORMAT(TOTALPERMONTH.TestDate, 'MMM'),FORMAT(TOTALPERMONTH.TestDate, 'yy'),year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)
                    ORDER BY year(TOTALPERMONTH.TestDate),month(TOTALPERMONTH.TestDate)"
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
        While rdr.Read
            month_year.Add(rdr.Item("MONTH_YEAR"))
            stock_month_per.Add("")
            machine_month_per.Add("")
            'stock_month_per.Add(rdr.Item("STOCK_MONTH_PER"))
            'machine_month_per.Add(rdr.Item("MACHINE_MONTH_PER"))
            rejection_month_per.Add(rdr.Item("REJECTION_MONTH_PER"))
        End While
        rdr.Close()
        con.Close()
    End Sub
    Sub pie_quality_analysis(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT')
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate, '" & finYear & "' AS FIN_YR , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"
        Dim str6 = "SELECT TOTALPERMONTH.FIN_YR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / SUM( TOTALPERMONTH.TOTAL_COUNT) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY TOTALPERMONTH.FIN_YR
                    ORDER BY TOTALPERMONTH.FIN_YR"






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
        While rdr.Read

            stock_str = rdr.Item("STOCK_MONTH_PER")
            pie_smr_all_quality.Add(stock_str)
            machine_str = rdr.Item("MACHINE_MONTH_PER")
            pie_smr_all_quality.Add(machine_str)
            rejection_str = rdr.Item("REJECTION_MONTH_PER")
            pie_smr_all_quality.Add(rejection_str)
        End While




        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub
    Sub pie_rejection_analysis(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String)
        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, '" & finYear & "' AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                    FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES=B.DEFECT_CODE
                    GROUP BY A.TestDate,A.DefectCodes,B.Description;"

        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_CODE,REJECTIONPIE.DEFECT_DESC, COUNT(*) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    WHERE REJECTIONPIE.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_CODE,REJECTIONPIE.DEFECT_DESC"

        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_CODE , REJECTIONPIEDEFECT.DEFECT_DESC ,  REJECTIONPIEDEFECT.DEFECT_COUNT ,  CAST(ROUND(((REJECTIONPIEDEFECT.DEFECT_COUNT  * 100.0) / (SELECT SUM(REJECTIONPIEDEFECT.DEFECT_COUNT) FROM REJECTIONPIEDEFECT)) , 2) as decimal(5,2))  AS DEFECT_PER
                    FROM REJECTIONPIEDEFECT
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_CODE , REJECTIONPIEDEFECT.DEFECT_DESC , REJECTIONPIEDEFECT.DEFECT_COUNT"






        Dim rdr As SqlDataReader


        rejection_analysis_defect_desc = New ArrayList
        rejection_analysis_defect_per = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)

        While rdr.Read

            rejection_analysis_defect_desc.Add(rdr.Item("DEFECT_DESC"))
            rejection_analysis_defect_per.Add(rdr.Item("DEFECT_PER"))

        End While




        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub
    Sub pie_quality_analysis_bgc(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)
        Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
			SELECT DISTINCT CAST(TestDate AS DATE) TestDate
			FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
			GROUP BY TestDate"
        Dim str2 = "CREATE OR ALTER VIEW STOCK AS
				SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='STOCK' AND ProdType= '" & prodType & "'
				GROUP BY TestDate"
        Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND Machining IN ('HH','HT') AND ProdType= '" & prodType & "'
				GROUP BY TestDate"
        Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
				SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
				FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
				WHERE WheelType='F' AND FinalStatus='XC' AND ProdType= '" & prodType & "'
				GROUP BY TestDate"
        Dim str5 = "CREATE OR ALTER VIEW TOTALPERMONTH AS
				SELECT TESTDATE.TestDate, dbo.GetFinancialYear(TESTDATE.TestDate) AS FIN_YR , ISNULL(STOCK.STOCK_COUNT , 0) AS STOCK_COUNT, ISNULL(MACHINE.MACHINE_COUNT , 0) AS MACHINE_COUNT , ISNULL(REJECTION.REJECTION_COUNT , 0) AS REJECTION_COUNT , (ISNULL(STOCK.STOCK_COUNT , 0) + ISNULL(MACHINE.MACHINE_COUNT , 0) + ISNULL(REJECTION.REJECTION_COUNT , 0)) AS TOTAL_COUNT 
				FROM TESTDATE
				LEFT JOIN STOCK ON TESTDATE.TestDate = STOCK.TestDate
				LEFT JOIN MACHINE ON TESTDATE.TestDate = MACHINE.TestDate
				LEFT JOIN REJECTION ON TESTDATE.TestDate = REJECTION.TestDate"

        'ISNULL([Numerator] / NULLIF([Denominator], 0), 0)
        Dim str6 = "SELECT TOTALPERMONTH.FIN_YR, SUM( TOTALPERMONTH.STOCK_COUNT ) AS STOCK_MONTH, CAST(ROUND(ISNULL((SUM( TOTALPERMONTH.STOCK_COUNT ) * 100.0 / NULLIF(SUM( TOTALPERMONTH.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2)) AS STOCK_MONTH_PER , SUM( TOTALPERMONTH.MACHINE_COUNT ) AS MACHINE_MONTH , CAST(ROUND(ISNULL((SUM( TOTALPERMONTH.MACHINE_COUNT ) * 100.0 / NULLIF(SUM( TOTALPERMONTH.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2)) AS MACHINE_MONTH_PER , SUM( TOTALPERMONTH.REJECTION_COUNT ) AS REJECTION_MONTH, CAST(ROUND(ISNULL((SUM( TOTALPERMONTH.REJECTION_COUNT ) * 100.0 / NULLIF(SUM( TOTALPERMONTH.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2))  AS REJECTION_MONTH_PER , SUM( TOTALPERMONTH.TOTAL_COUNT)  AS TOTAL_MONTH
                    FROM TOTALPERMONTH
                    WHERE TOTALPERMONTH.FIN_YR = '" & finYear & "' AND TOTALPERMONTH.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY TOTALPERMONTH.FIN_YR
                    ORDER BY TOTALPERMONTH.FIN_YR"






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
        While rdr.Read

            stock_str = rdr.Item("STOCK_MONTH_PER")
            pie_smr_all_quality.Add(stock_str)
            machine_str = rdr.Item("MACHINE_MONTH_PER")
            pie_smr_all_quality.Add(machine_str)
            rejection_str = rdr.Item("REJECTION_MONTH_PER")
            pie_smr_all_quality.Add(rejection_str)
        End While




        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub

    Sub pie_rejection_analysis_bgc(ByVal finYear As String, ByVal startYear As String, ByVal endYear As String, ByVal prodType As String)
        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear(A.TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                    FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND ProdType= '" & prodType & "' AND A.DEFECTCODES=B.DEFECT_CODE
                    GROUP BY A.TestDate,A.DefectCodes,B.Description;"

        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_CODE,REJECTIONPIE.DEFECT_DESC, COUNT(*) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    WHERE REJECTIONPIE.FIN_YR = '" & finYear & "' AND REJECTIONPIE.TestDate BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY REJECTIONPIE.FIN_YR,REJECTIONPIE.DEFECT_CODE,REJECTIONPIE.DEFECT_DESC"

        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_CODE , REJECTIONPIEDEFECT.DEFECT_DESC ,  REJECTIONPIEDEFECT.DEFECT_COUNT ,  CAST(ROUND(((REJECTIONPIEDEFECT.DEFECT_COUNT  * 100.0) / (SELECT SUM(REJECTIONPIEDEFECT.DEFECT_COUNT) FROM REJECTIONPIEDEFECT)) , 2) as decimal(5,2))  AS DEFECT_PER
                    FROM REJECTIONPIEDEFECT
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR , REJECTIONPIEDEFECT.DEFECT_CODE , REJECTIONPIEDEFECT.DEFECT_DESC , REJECTIONPIEDEFECT.DEFECT_COUNT"






        Dim rdr As SqlDataReader


        rejection_analysis_defect_desc = New ArrayList
        rejection_analysis_defect_per = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)

        While rdr.Read

            rejection_analysis_defect_desc.Add(rdr.Item("DEFECT_DESC"))
            rejection_analysis_defect_per.Add(rdr.Item("DEFECT_PER"))

        End While




        rdr.Close()
        'rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str7)
        'While rdr.Read
        '    prod_type.Add(rdr.Item("ProdType"))
        'End While
        'rdr.Close()
        con.Close()
    End Sub

    Sub percentage_fw_rejection_dr_combined()
        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                    FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES=B.DEFECT_CODE
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"
        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR, CAST((SUM(REJECTIONPIEDEFECT.DEFECT_COUNT)*1.0/12) as decimal(5,2)) AS REJECTION_PER
                    FROM REJECTIONPIEDEFECT
                    WHERE REJECTIONPIEDEFECT.FIN_YR NOT IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR"

        Dim str4 = "SELECT CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR,REJECTIONPIE.FIN_YR, SUM(REJECTION_COUNT) AS DEFECT_COUNT,
                    CAST(ROUND(SUM(REJECTION_COUNT) * 100.0 /(select sum (rejection_count) from REJECTIONPIE WHERE REJECTIONPIE.FIN_YR IN (SELECT dbo.GetFinancialYear (GETDATE()))) , 2) as decimal(5,2))  AS REJECTION_PER
                    FROM REJECTIONPIE
                    WHERE REJECTIONPIE.FIN_YR IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate),FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


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
            percent_label.Add(rdr.Item("FIN_YR"))

            percent_value.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)

        While rdr.Read
            percent_label.Add(rdr.Item("MONTH_YEAR"))

            percent_value.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()

        con.Close()
    End Sub
    Sub percentage_fw_rejection_dr_bgc(ByVal prodType As String)
        Dim str1 = "CREATE OR ALTER VIEW REJECTIONPIE AS
                    SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                    FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                    WHERE WheelType='F' AND FinalStatus='XC' AND ProdType= '" & prodType & "' AND A.DEFECTCODES=B.DEFECT_CODE
                    GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                    SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                    FROM REJECTIONPIE
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


        Dim str3 = "SELECT REJECTIONPIEDEFECT.FIN_YR, CAST((SUM(REJECTIONPIEDEFECT.DEFECT_COUNT)*1.0/12) as decimal(5,2)) AS REJECTION_PER
                    FROM REJECTIONPIEDEFECT
                    WHERE REJECTIONPIEDEFECT.FIN_YR NOT IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIEDEFECT.FIN_YR"

        Dim str4 = "SELECT CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR,REJECTIONPIE.FIN_YR, SUM(REJECTION_COUNT) AS DEFECT_COUNT,
                    CAST(ROUND(SUM(REJECTION_COUNT) * 100.0 /(select sum (rejection_count) from REJECTIONPIE WHERE REJECTIONPIE.FIN_YR IN (SELECT dbo.GetFinancialYear (GETDATE()))) , 2) as decimal(5,2))  AS REJECTION_PER
                    FROM REJECTIONPIE
                    WHERE REJECTIONPIE.FIN_YR IN (SELECT dbo.GetFinancialYear (GETDATE()))
                    GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate),FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"


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
            percent_label.Add(rdr.Item("FIN_YR"))

            percent_value.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str4)

        While rdr.Read
            percent_label.Add(rdr.Item("MONTH_YEAR"))

            percent_value.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()

        con.Close()
    End Sub

    Sub percentage_rejection_bad_chemistry(ByVal startYear As String, ByVal endYear As String)
        Dim str1 = "CREATE OR ALTER VIEW OFF_HEAT_TOTAL AS
                    SELECT CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year, CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(*) AS Off_Heat_Total FROM wapdev.dbo.mm_offheat_heatsheet_header
                    WHERE melt_date BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM')"

        Dim str2 = "CREATE OR ALTER VIEW HEAT_SHEET_TOTAL AS
                    SELECT CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year , CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(*) AS Heat_Sheet_Total FROM wapdev.dbo.mm_heatsheet_header
                    WHERE melt_date BETWEEN '" & startYear & "' AND '" & endYear & "'
                    GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM')"


        Dim str3 = "SELECT OFF_HEAT_TOTAL.Month_Year , OFF_HEAT_TOTAL.Off_Heat_Total , HEAT_SHEET_TOTAL.Heat_Sheet_Total , CAST(ROUND(ISNULL((OFF_HEAT_TOTAL.Off_Heat_Total * 100.0 / NULLIF(HEAT_SHEET_TOTAL.Heat_Sheet_Total, 0)), 0) , 2) as decimal(5,2)) AS Bad_Chem_Per
                    FROM OFF_HEAT_TOTAL
                    LEFT JOIN HEAT_SHEET_TOTAL ON OFF_HEAT_TOTAL.Month_Year = HEAT_SHEET_TOTAL.Month_Year
                    ORDER BY year(OFF_HEAT_TOTAL.First_Date),month(OFF_HEAT_TOTAL.First_Date)"



        Dim rdr As SqlDataReader
        badchem_month = New ArrayList
        badchem_percent = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, str3)

        While rdr.Read
            badchem_month.Add(rdr.Item("Month_Year"))

            badchem_percent.Add(rdr.Item("Bad_Chem_Per"))
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
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year, CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(*) AS Off_Heat_Total 
                            FROM wapdev.dbo.mm_offheat_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"

        Dim badchem_str2 = "CREATE OR ALTER VIEW HEAT_SHEET_TOTAL AS
                            SELECT dbo.GetFinancialYear (melt_date) AS FIN_YR,CONCAT(FORMAT(melt_date, 'MMM'),'-',FORMAT(melt_date, 'yy')) AS Month_Year , CONCAT(FORMAT(melt_date, 'yyyy'),'-',FORMAT(melt_date, 'MM'),'-','01') AS First_Date , COUNT(*) AS Heat_Sheet_Total 
                            FROM wapdev.dbo.mm_heatsheet_header
                            GROUP BY year(melt_date),month(melt_date),FORMAT(melt_date, 'MMM'),FORMAT(melt_date, 'yy'),FORMAT(melt_date, 'yyyy'),FORMAT(melt_date, 'MM'),dbo.GetFinancialYear (melt_date)"

        Dim badchem_str3_value = "SELECT OFF_HEAT_TOTAL.FIN_YR , OFF_HEAT_TOTAL.Month_Year , OFF_HEAT_TOTAL.Off_Heat_Total , HEAT_SHEET_TOTAL.Heat_Sheet_Total , CAST(ROUND(ISNULL((OFF_HEAT_TOTAL.Off_Heat_Total * 100.0 / NULLIF(HEAT_SHEET_TOTAL.Heat_Sheet_Total, 0)), 0) , 2) as decimal(5,2)) AS Bad_Chem_Per
                            FROM OFF_HEAT_TOTAL
                            LEFT JOIN HEAT_SHEET_TOTAL ON OFF_HEAT_TOTAL.Month_Year = HEAT_SHEET_TOTAL.Month_Year
                            WHERE OFF_HEAT_TOTAL.FIN_YR IN ('" & Fin_Year_Value & "')
                            ORDER BY year(OFF_HEAT_TOTAL.First_Date),month(OFF_HEAT_TOTAL.First_Date)"

        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str3_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("Bad_Chem_Per"))
            pr_mw_rejection_label.Add(rdr.Item("Month_Year"))

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
                            FROM wapdev.dbo.mm_pouring
                            WHERE rejection_code LIKE 'XC%'
                            GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str2 = "CREATE OR ALTER VIEW MRXCTOTAL AS
                        SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(engraved_number) AS MRXC_COUNT_TOTAL
                        FROM wapdev.dbo.mm_pouring
                        GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str3_value = "SELECT MRXCTOTAL.FIN_YR, MRXCTOTAL.MONTH_YEAR , MRXCTOTAL.MRXC_COUNT_TOTAL , MRXCMONTH.MRXC_COUNT , CAST(ROUND(ISNULL((MRXCMONTH.MRXC_COUNT * 100.0 / NULLIF(MRXCTOTAL.MRXC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MRXC_PER
                                FROM MRXCTOTAL
                                LEFT JOIN MRXCMONTH ON MRXCTOTAL.MONTH_YEAR = MRXCMONTH.MONTH_YEAR
                                WHERE MRXCTOTAL.FIN_YR IN ('" & Fin_Year_Value & "')
                                ORDER BY year(MRXCTOTAL.First_Date),month(MRXCTOTAL.First_Date)"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str3_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_PER"))
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
                            SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                            FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                            WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES=B.DEFECT_CODE
                            GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim defect_str2 = "CREATE OR ALTER VIEW REJECTIONPIEDEFECT AS
                            SELECT REJECTIONPIE.FIN_YR,CONCAT(FORMAT(REJECTIONPIE.TestDate, 'MMM'),'-',FORMAT(REJECTIONPIE.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                            FROM REJECTIONPIE
                            GROUP BY REJECTIONPIE.FIN_YR,year(REJECTIONPIE.TestDate),month(REJECTIONPIE.TestDate), FORMAT(REJECTIONPIE.TestDate, 'MMM'),FORMAT(REJECTIONPIE.TestDate, 'yy')"

        Dim defect_str3 = "CREATE OR ALTER VIEW TOTALPIE AS
                            SELECT dbo.GetFinancialYear (TestDate) AS FIN_YR,CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR,COUNT(*) TOTAL_COUNT
                            FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F'
                            GROUP BY dbo.GetFinancialYear (TestDate),year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim defect_str4_value = "SELECT TOTALPIE.FIN_YR,TOTALPIE.MONTH_YEAR,TOTALPIE.TOTAL_COUNT,REJECTIONPIEDEFECT.DEFECT_COUNT,
                                CAST(ROUND(ISNULL((REJECTIONPIEDEFECT.DEFECT_COUNT * 100.0 / NULLIF(TOTALPIE.TOTAL_COUNT, 0)), 0) , 2) as decimal(5,2)) AS REJECTION_PER
                                FROM TOTALPIE
                                LEFT JOIN REJECTIONPIEDEFECT ON TOTALPIE.MONTH_YEAR=REJECTIONPIEDEFECT.MONTH_YEAR
                                WHERE TOTALPIE.FIN_YR IN ('" & Fin_Year_Value & "')"


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
            pr_mw_rejection_defect.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_pr_mw_rejection_machining(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList

        Dim machining_str1 = "CREATE OR ALTER VIEW TESTDATEMAGNA AS
                                SELECT DISTINCT CAST(TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                GROUP BY TestDate"

        Dim machining_str2 = "CREATE OR ALTER VIEW MACHINEMAGNA AS
                                SELECT CAST(TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR, COUNT(*) MACHINE_COUNT
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F' AND Machining IN ('HH','HT','HP')
                                GROUP BY TestDate"

        Dim machining_str3 = "CREATE OR ALTER VIEW MACHININGCOUNT AS
                                SELECT TESTDATEMAGNA.FIN_YR,TESTDATEMAGNA.TestDate , ISNULL(MACHINEMAGNA.MACHINE_COUNT , 0) AS MACHINE_COUNT
                                FROM TESTDATEMAGNA
                                LEFT JOIN MACHINEMAGNA ON TESTDATEMAGNA.TestDate = MACHINEMAGNA.TestDate"

        Dim machining_str4 = "CREATE OR ALTER VIEW MACHININGMONTH AS		
                                SELECT MACHININGCOUNT.FIN_YR , CONCAT(FORMAT(MACHININGCOUNT.TestDate, 'MMM'),'-',FORMAT(MACHININGCOUNT.TestDate, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(MACHININGCOUNT.TestDate, 'yyyy'),'-',FORMAT(MACHININGCOUNT.TestDate, 'MM'),'-','01') AS First_Date , SUM( MACHININGCOUNT.MACHINE_COUNT ) AS MACHINE_MONTH 
                                FROM MACHININGCOUNT
                                GROUP BY MACHININGCOUNT.FIN_YR,year(MACHININGCOUNT.TestDate),month(MACHININGCOUNT.TestDate),FORMAT(MACHININGCOUNT.TestDate, 'MMM'),FORMAT(MACHININGCOUNT.TestDate, 'yy'),FORMAT(MACHININGCOUNT.TestDate, 'yyyy'),FORMAT(MACHININGCOUNT.TestDate, 'MM')"

        Dim machining_str5 = "CREATE OR ALTER VIEW TOTALMONTHNEW AS
                                SELECT  dbo.GetFinancialYear (TestDate) AS FIN_YR , CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, COUNT(*) AS MACHINE_MONTH_TOTAL
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F'
                                GROUP BY dbo.GetFinancialYear (TestDate),year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim machining_str6_value = "SELECT TOTALMONTHNEW.FIN_YR , TOTALMONTHNEW.MONTH_YEAR , TOTALMONTHNEW.MACHINE_MONTH_TOTAL , MACHININGMONTH.MACHINE_MONTH , CAST(ROUND(ISNULL((MACHININGMONTH.MACHINE_MONTH * 10.0 / NULLIF(TOTALMONTHNEW.MACHINE_MONTH_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MACHINING_PER
                                    FROM TOTALMONTHNEW
                                    LEFT JOIN MACHININGMONTH ON TOTALMONTHNEW.MONTH_YEAR=MACHININGMONTH.MONTH_YEAR
                                    WHERE TOTALMONTHNEW.FIN_YR IN ('" & Fin_Year_Value & "')
                                    ORDER BY year(MACHININGMONTH.First_Date),month(MACHININGMONTH.First_Date)"


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
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_PER"))
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
                            SELECT dbo.GetFinancialYear (a.pour_time) AS FIN_YR, CONCAT(FORMAT(a.pour_time, 'MMM'),'-',FORMAT(a.pour_time, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(a.pour_time, 'yyyy'),'-',FORMAT(a.pour_time, 'MM'),'-','01') AS First_Date , COUNT(b.heat_number) AS BADCHEMBGC_COUNT
                            FROM wapdev.dbo.mm_pouring AS a , wapdev.dbo.mm_offheat_heatsheet_header as b
                            WHERE a.rejection_code LIKE 'XC%' AND a.wheel_type IN ('" & Prod_Type_Value & "') AND a.heat_number=b.heat_number
                            GROUP BY year(a.pour_time),month(a.pour_time),dbo.GetFinancialYear (a.pour_time),FORMAT(a.pour_time, 'MMM'),FORMAT(a.pour_time, 'yy'),FORMAT(a.pour_time, 'yyyy'),FORMAT(a.pour_time, 'MM')"

        Dim badchem_str2 = "CREATE OR ALTER VIEW BADCHEMBGCTOTAL AS
                            SELECT dbo.GetFinancialYear (a.pour_time) AS FIN_YR, CONCAT(FORMAT(a.pour_time, 'MMM'),'-',FORMAT(a.pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(a.pour_time, 'yyyy'),'-',FORMAT(a.pour_time, 'MM'),'-','01') AS First_Date , ISNULL(COUNT(b.heat_number), 0) AS BADCHEMBGC_COUNT_TOTAL
                            FROM wapdev.dbo.mm_pouring AS a, wapdev.dbo.mm_heatsheet_header as b
                            WHERE wheel_type IN ('" & Prod_Type_Value & "') AND a.heat_number=b.heat_number
                            GROUP BY year(a.pour_time),month(a.pour_time),dbo.GetFinancialYear (a.pour_time),FORMAT(a.pour_time, 'MMM'),FORMAT(a.pour_time, 'yy'),FORMAT(a.pour_time, 'yyyy'),FORMAT(a.pour_time, 'MM')"

        Dim badchem_str3_value = "SELECT BADCHEMBGCTOTAL.FIN_YR, BADCHEMBGCTOTAL.MONTH_YEAR , BADCHEMBGCTOTAL.BADCHEMBGC_COUNT_TOTAL , BADCHEMBGC.BADCHEMBGC_COUNT , CAST(ROUND(ISNULL((BADCHEMBGC.BADCHEMBGC_COUNT * 100.0 / NULLIF(BADCHEMBGCTOTAL.BADCHEMBGC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_PER
                                    FROM BADCHEMBGCTOTAL
                                    LEFT JOIN BADCHEMBGC ON BADCHEMBGCTOTAL.MONTH_YEAR = BADCHEMBGC.MONTH_YEAR
                                    WHERE BADCHEMBGCTOTAL.FIN_YR IN ('" & Fin_Year_Value & "')
                                    ORDER BY year(BADCHEMBGCTOTAL.First_Date),month(BADCHEMBGCTOTAL.First_Date)"

        Dim rdr As SqlDataReader

        pr_mw_rejection_badchem = New ArrayList
        pr_mw_rejection_label = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str3_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("BADCHEM_PER"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_bgc_boxn_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL

        Dim mrxc_str1 = "CREATE OR ALTER VIEW BGCMRXCMONTH AS
                            SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR, CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , ISNULL(COUNT(*) , 0) AS MRXC_COUNT
                            FROM wapdev.dbo.mm_pouring
                            WHERE rejection_code LIKE 'XC%' AND wheel_type IN ('" & Prod_Type_Value & "')
                            GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str2 = "CREATE OR ALTER VIEW BGCMRXCTOTAL AS
                            SELECT dbo.GetFinancialYear (pour_time) AS FIN_YR, CONCAT(FORMAT(pour_time, 'MMM'),'-',FORMAT(pour_time, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(pour_time, 'yyyy'),'-',FORMAT(pour_time, 'MM'),'-','01') AS First_Date , COUNT(engraved_number) AS MRXC_COUNT_TOTAL
                            FROM wapdev.dbo.mm_pouring
                            WHERE wheel_type IN ('" & Prod_Type_Value & "')
                            GROUP BY year(pour_time),month(pour_time),dbo.GetFinancialYear (pour_time),FORMAT(pour_time, 'MMM'),FORMAT(pour_time, 'yy'),FORMAT(pour_time, 'yyyy'),FORMAT(pour_time, 'MM')"

        Dim mrxc_str3_value = "SELECT BGCMRXCTOTAL.FIN_YR, BGCMRXCTOTAL.MONTH_YEAR , BGCMRXCTOTAL.MRXC_COUNT_TOTAL , BGCMRXCMONTH.MRXC_COUNT , CAST(ROUND(ISNULL((BGCMRXCMONTH.MRXC_COUNT * 100.0 / NULLIF(BGCMRXCTOTAL.MRXC_COUNT_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MRXC_PER
                                FROM BGCMRXCTOTAL
                                LEFT JOIN BGCMRXCMONTH ON BGCMRXCTOTAL.MONTH_YEAR = BGCMRXCMONTH.MONTH_YEAR
                                WHERE BGCMRXCTOTAL.FIN_YR IN ('" & Fin_Year_Value & "')
                                ORDER BY year(BGCMRXCTOTAL.First_Date),month(BGCMRXCTOTAL.First_Date)"

        Dim rdr As SqlDataReader

        pr_mw_rejection_mrxc = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str2)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, mrxc_str3_value)

        While rdr.Read
            pr_mw_rejection_mrxc.Add(rdr.Item("MRXC_PER"))
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_bgc_boxn_pr_mw_rejection_defect(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN

        Dim defect_str1 = "CREATE OR ALTER VIEW BGCBOXNDARKROOM AS
                            SELECT CAST(A.TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR , A.DefectCodes AS DEFECT_CODE, B.DESCRIPTION AS DEFECT_DESC, COUNT(*) REJECTION_COUNT
                            FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords as A, wapdev.dbo.defect_master as B
                            WHERE WheelType='F' AND FinalStatus='XC' AND A.DEFECTCODES=B.DEFECT_CODE AND ProdType= '" & Prod_Type_Value & "'
                            GROUP BY A.TestDate,A.DefectCodes,B.Description"

        Dim defect_str2 = "CREATE OR ALTER VIEW BGCBOXNDARKROOMMONTH AS
                            SELECT BGCBOXNDARKROOM.FIN_YR,CONCAT(FORMAT(BGCBOXNDARKROOM.TestDate, 'MMM'),'-',FORMAT(BGCBOXNDARKROOM.TestDate, 'yy')) AS MONTH_YEAR, SUM(REJECTION_COUNT) AS DEFECT_COUNT
                            FROM BGCBOXNDARKROOM
                            GROUP BY BGCBOXNDARKROOM.FIN_YR,year(BGCBOXNDARKROOM.TestDate),month(BGCBOXNDARKROOM.TestDate), FORMAT(BGCBOXNDARKROOM.TestDate, 'MMM'),FORMAT(BGCBOXNDARKROOM.TestDate, 'yy')"

        Dim defect_str3 = "CREATE OR ALTER VIEW BGCBOXNDARKROOMTOTAL AS
                            SELECT dbo.GetFinancialYear (TestDate) AS FIN_YR,CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR,COUNT(*) TOTAL_COUNT
                            FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                            WHERE WheelType='F' AND ProdType= '" & Prod_Type_Value & "'
                            GROUP BY dbo.GetFinancialYear (TestDate),year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim defect_str4_value = "SELECT BGCBOXNDARKROOMTOTAL.FIN_YR,BGCBOXNDARKROOMTOTAL.MONTH_YEAR,BGCBOXNDARKROOMTOTAL.TOTAL_COUNT,BGCBOXNDARKROOMMONTH.DEFECT_COUNT,
                                    CAST(ROUND(ISNULL((BGCBOXNDARKROOMMONTH.DEFECT_COUNT * 100.0 / NULLIF(BGCBOXNDARKROOMTOTAL.TOTAL_COUNT, 0)), 0) , 2) as decimal(5,2)) AS REJECTION_PER
                                    FROM BGCBOXNDARKROOMTOTAL
                                    LEFT JOIN BGCBOXNDARKROOMMONTH ON BGCBOXNDARKROOMTOTAL.MONTH_YEAR=BGCBOXNDARKROOMMONTH.MONTH_YEAR
                                    WHERE BGCBOXNDARKROOMTOTAL.FIN_YR IN ('" & Fin_Year_Value & "')"


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
            pr_mw_rejection_defect.Add(rdr.Item("REJECTION_PER"))
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_bgc_boxn_pr_mw_rejection_machining(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN

        Dim machining_str1 = "CREATE OR ALTER VIEW TESTDATEMAGNA AS
                                SELECT DISTINCT CAST(TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                GROUP BY TestDate"

        Dim machining_str2 = "CREATE OR ALTER VIEW MACHINEMAGNA AS
                                SELECT CAST(TestDate AS DATE) TestDate, dbo.GetFinancialYear (TestDate) AS FIN_YR, COUNT(*) MACHINE_COUNT
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F' AND Machining IN ('HH','HT','HP') AND ProdType='" & Prod_Type_Value & "'
                                GROUP BY TestDate"

        Dim machining_str3 = "CREATE OR ALTER VIEW MACHININGCOUNT AS
                                SELECT TESTDATEMAGNA.FIN_YR,TESTDATEMAGNA.TestDate , ISNULL(MACHINEMAGNA.MACHINE_COUNT , 0) AS MACHINE_COUNT
                                FROM TESTDATEMAGNA
                                LEFT JOIN MACHINEMAGNA ON TESTDATEMAGNA.TestDate = MACHINEMAGNA.TestDate"

        Dim machining_str4 = "CREATE OR ALTER VIEW MACHININGMONTH AS		
                                SELECT MACHININGCOUNT.FIN_YR , CONCAT(FORMAT(MACHININGCOUNT.TestDate, 'MMM'),'-',FORMAT(MACHININGCOUNT.TestDate, 'yy')) AS MONTH_YEAR , CONCAT(FORMAT(MACHININGCOUNT.TestDate, 'yyyy'),'-',FORMAT(MACHININGCOUNT.TestDate, 'MM'),'-','01') AS First_Date , SUM( MACHININGCOUNT.MACHINE_COUNT ) AS MACHINE_MONTH 
                                FROM MACHININGCOUNT
                                GROUP BY MACHININGCOUNT.FIN_YR,year(MACHININGCOUNT.TestDate),month(MACHININGCOUNT.TestDate),FORMAT(MACHININGCOUNT.TestDate, 'MMM'),FORMAT(MACHININGCOUNT.TestDate, 'yy'),FORMAT(MACHININGCOUNT.TestDate, 'yyyy'),FORMAT(MACHININGCOUNT.TestDate, 'MM')"

        Dim machining_str5 = "CREATE OR ALTER VIEW TOTALMONTHNEW AS
                                SELECT  dbo.GetFinancialYear (TestDate) AS FIN_YR , CONCAT(FORMAT(TestDate, 'MMM'),'-',FORMAT(TestDate, 'yy')) AS MONTH_YEAR, COUNT(*) AS MACHINE_MONTH_TOTAL
                                FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
                                WHERE WheelType='F' AND ProdType='" & Prod_Type_Value & "'
                                GROUP BY dbo.GetFinancialYear (TestDate),year(TestDate),month(TestDate),FORMAT(TestDate, 'MMM'),FORMAT(TestDate, 'yy')"

        Dim machining_str6_value = "SELECT TOTALMONTHNEW.FIN_YR , TOTALMONTHNEW.MONTH_YEAR , TOTALMONTHNEW.MACHINE_MONTH_TOTAL , MACHININGMONTH.MACHINE_MONTH , CAST(ROUND(ISNULL((MACHININGMONTH.MACHINE_MONTH * 10.0 / NULLIF(TOTALMONTHNEW.MACHINE_MONTH_TOTAL, 0)), 0) , 2) as decimal(5,2)) AS MACHINING_PER
                                    FROM TOTALMONTHNEW
                                    LEFT JOIN MACHININGMONTH ON TOTALMONTHNEW.MONTH_YEAR=MACHININGMONTH.MONTH_YEAR
                                    WHERE TOTALMONTHNEW.FIN_YR IN ('" & Fin_Year_Value & "')
                                    ORDER BY year(MACHININGMONTH.First_Date),month(MACHININGMONTH.First_Date)"


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
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_PER"))
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
                            SELECT CUMCOMBINEDBADCHEM.FIN_YR, CUMCOMBINEDBADCHEM.MONTH_YEAR , CUMCOMBINEDBADCHEM.First_Date , CUMCOMBINEDBADCHEM.Heat_Sheet_Total , CUMCOMBINEDBADCHEM.OFFHEAT_COUNT 
                            FROM CUMCOMBINEDBADCHEM
                            WHERE CUMCOMBINEDBADCHEM.FIN_YR IN ('" & Fin_Year_Value & "')
                            GROUP BY year(CUMCOMBINEDBADCHEM.First_Date),month(CUMCOMBINEDBADCHEM.First_Date),CUMCOMBINEDBADCHEM.FIN_YR, CUMCOMBINEDBADCHEM.MONTH_YEAR , CUMCOMBINEDBADCHEM.First_Date , CUMCOMBINEDBADCHEM.Heat_Sheet_Total , CUMCOMBINEDBADCHEM.OFFHEAT_COUNT "

        '('" & Fin_Year_Value & "')


        Dim badchem_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.Heat_Sheet_Total , SUM(B2.Heat_Sheet_Total) AS BADCHEM_COUNT_TOTAL_CUM , B1.OFFHEAT_COUNT , SUM(B2.OFFHEAT_COUNT) AS BADCHEMBGC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.OFFHEAT_COUNT) * 100.0 / NULLIF(SUM(B2.Heat_Sheet_Total), 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_CUM_PER
                                    FROM CUMCOMBINEDBADCHEMFINYR B1
                                    INNER JOIN CUMCOMBINEDBADCHEMFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.Heat_Sheet_Total , B1.OFFHEAT_COUNT
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

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_cum_com_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList '" & Fin_Year_Value & "'

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
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_cum_com_pr_mw_rejection_defect(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList '" & Fin_Year_Value & "'

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
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_cum_com_pr_mw_rejection_machining(ByVal Fin_Year_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList '" & Fin_Year_Value & "'


        Dim machining_str1 = "CREATE OR ALTER VIEW CUMCOMBINEDMACHININGFINYR AS
                            SELECT CUMCOMBINEDMACHINING.FIN_YR , CUMCOMBINEDMACHINING.MONTH_YEAR , CUMCOMBINEDMACHINING.First_Date , CUMCOMBINEDMACHINING.MACHINE_MONTH_TOTAL , CUMCOMBINEDMACHINING.MACHINE_MONTH 
                            FROM CUMCOMBINEDMACHINING
                            WHERE CUMCOMBINEDMACHINING.FIN_YR IN ('2020-21')
                            GROUP BY CUMCOMBINEDMACHINING.FIN_YR ,year(CUMCOMBINEDMACHINING.First_Date),month(CUMCOMBINEDMACHINING.First_Date),CUMCOMBINEDMACHINING.MONTH_YEAR ,CUMCOMBINEDMACHINING.First_Date , CUMCOMBINEDMACHINING.MACHINE_MONTH_TOTAL,CUMCOMBINEDMACHINING.MACHINE_MONTH"

        Dim machining_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.MACHINE_MONTH_TOTAL , SUM(B2.MACHINE_MONTH_TOTAL) AS MACHINING_TOTAL_CUM , B1.MACHINE_MONTH , SUM(B2.MACHINE_MONTH) AS MACHINE_MONTH_CUM , CAST(ROUND(ISNULL((SUM(B2.MACHINE_MONTH) * 100.0 / NULLIF(SUM(B2.MACHINE_MONTH_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS MACHINING_CUM_PER
                                    FROM CUMCOMBINEDMACHININGFINYR B1
                                    INNER JOIN CUMCOMBINEDMACHININGFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.MACHINE_MONTH_TOTAL , B1.MACHINE_MONTH
                                    ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_CUM_PER"))
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func1_cum_bgc_boxn_pr_mw_rejection_badchem(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim badchem_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNBADCHEMFINYR AS
                            SELECT CUMBGCBOXNBADCHEM.FIN_YR, CUMBGCBOXNBADCHEM.MONTH_YEAR , CUMBGCBOXNBADCHEM.First_Date, CUMBGCBOXNBADCHEM.WHEEL_TYPE , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT_TOTAL , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT 
                            FROM CUMBGCBOXNBADCHEM
                            WHERE CUMBGCBOXNBADCHEM.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNBADCHEM.WHEEL_TYPE IN ('" & Prod_Type_Value & "')
                            GROUP BY year(CUMBGCBOXNBADCHEM.First_Date),month(CUMBGCBOXNBADCHEM.First_Date),CUMBGCBOXNBADCHEM.FIN_YR,CUMBGCBOXNBADCHEM.MONTH_YEAR, CUMBGCBOXNBADCHEM.First_Date, CUMBGCBOXNBADCHEM.WHEEL_TYPE , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT_TOTAL , CUMBGCBOXNBADCHEM.BADCHEMBGC_COUNT"


        Dim badchem_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.BADCHEMBGC_COUNT_TOTAL , SUM(B2.BADCHEMBGC_COUNT_TOTAL) AS BADCHEMBGC_COUNT_TOTAL_CUM , B1.BADCHEMBGC_COUNT , SUM(B2.BADCHEMBGC_COUNT) AS BADCHEMBGC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.BADCHEMBGC_COUNT) * 100.0 / NULLIF(SUM(B2.BADCHEMBGC_COUNT_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS BADCHEM_CUM_PER
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
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, badchem_str2_value)

        While rdr.Read
            pr_mw_rejection_badchem.Add(rdr.Item("BADCHEM_CUM_PER"))
            pr_mw_rejection_label.Add(rdr.Item("MONTH_YEAR"))

        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func2_cum_bgc_boxn_pr_mw_rejection_mrxc(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList ICF WHL , BOXN WHL ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim mrxc_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNMRXCFINYR AS
                        SELECT CUMBGCBOXNMRXC.FIN_YR, CUMBGCBOXNMRXC.MONTH_YEAR , CUMBGCBOXNMRXC.First_Date, CUMBGCBOXNMRXC.WHEEL_TYPE , CUMBGCBOXNMRXC.MRXC_COUNT_TOTAL , CUMBGCBOXNMRXC.MRXC_COUNT
                        FROM CUMBGCBOXNMRXC
                        WHERE CUMBGCBOXNMRXC.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNMRXC.WHEEL_TYPE IN ('" & Prod_Type_Value & "')
                        GROUP BY CUMBGCBOXNMRXC.FIN_YR ,year(CUMBGCBOXNMRXC.First_Date),month(CUMBGCBOXNMRXC.First_Date),CUMBGCBOXNMRXC.MONTH_YEAR ,CUMBGCBOXNMRXC.First_Date, CUMBGCBOXNMRXC.WHEEL_TYPE , CUMBGCBOXNMRXC.MRXC_COUNT_TOTAL , CUMBGCBOXNMRXC.MRXC_COUNT"


        Dim mrxc_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.MRXC_COUNT_TOTAL , SUM(B2.MRXC_COUNT_TOTAL) AS MRXC_COUNT_TOTAL_CUM , B1.MRXC_COUNT , SUM(B2.MRXC_COUNT) AS MRXC_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.MRXC_COUNT) * 100.0 / NULLIF(SUM(B2.MRXC_COUNT_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS MRXC_CUM_PER
                                FROM CUMBGCBOXNMRXCFINYR B1
                                INNER JOIN CUMBGCBOXNMRXCFINYR B2 ON B1.First_Date>=B2.First_Date
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
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func3_cum_bgc_boxn_pr_mw_rejection_defect(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim defect_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNDARKROOMFINYR AS
                            SELECT CUMBGCBOXNDARKROOM.FIN_YR , CUMBGCBOXNDARKROOM.MONTH_YEAR , CUMBGCBOXNDARKROOM.First_Date, CUMBGCBOXNDARKROOM.PROD_TYPE , CUMBGCBOXNDARKROOM.TOTAL_COUNT,CUMBGCBOXNDARKROOM.DEFECT_COUNT
                            FROM CUMBGCBOXNDARKROOM
                            WHERE CUMBGCBOXNDARKROOM.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNDARKROOM.PROD_TYPE IN ('" & Prod_Type_Value & "')
                            GROUP BY CUMBGCBOXNDARKROOM.FIN_YR ,year(CUMBGCBOXNDARKROOM.First_Date),month(CUMBGCBOXNDARKROOM.First_Date), CUMBGCBOXNDARKROOM.PROD_TYPE,CUMBGCBOXNDARKROOM.MONTH_YEAR ,CUMBGCBOXNDARKROOM.First_Date , CUMBGCBOXNDARKROOM.TOTAL_COUNT,CUMBGCBOXNDARKROOM.DEFECT_COUNT"

        Dim defect_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.TOTAL_COUNT , SUM(B2.TOTAL_COUNT) AS TOTAL_COUNT_CUM , B1.DEFECT_COUNT , SUM(B2.DEFECT_COUNT) AS DEFECT_COUNT_CUM , CAST(ROUND(ISNULL((SUM(B2.DEFECT_COUNT) * 100.0 / NULLIF(SUM(B2.TOTAL_COUNT), 0)), 0) , 2) as decimal(5,2)) AS DARKROOM_CUM_PER
                                FROM CUMBGCBOXNDARKROOMFINYR B1
                                INNER JOIN CUMBGCBOXNDARKROOMFINYR B2 ON B1.First_Date>=B2.First_Date
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
        End While

        rdr.Close()
        con.Close()

    End Sub

    Sub func4_cum_bgc_boxn_pr_mw_rejection_machining(ByVal Fin_Year_Value As String, ByVal Prod_Type_Value As String)

        'Public pr_mw_rejection_badchem As New ArrayList
        'Public pr_mw_rejection_mrxc As New ArrayList
        'Public pr_mw_rejection_defect As New ArrayList
        'Public pr_mw_rejection_machining As New ArrayList BGC BOXN ('" & Fin_Year_Value & "') ('" & Prod_Type_Value & "')

        Dim machining_str1 = "CREATE OR ALTER VIEW CUMBGCBOXNMACHININGFINYR AS
                                SELECT CUMBGCBOXNMACHINING.FIN_YR , CUMBGCBOXNMACHINING.MONTH_YEAR , CUMBGCBOXNMACHINING.First_Date, CUMBGCBOXNMACHINING.PROD_TYPE , CUMBGCBOXNMACHINING.MACHINE_MONTH_TOTAL , CUMBGCBOXNMACHINING.MACHINE_MONTH 
                                FROM CUMBGCBOXNMACHINING
                                WHERE CUMBGCBOXNMACHINING.FIN_YR IN ('" & Fin_Year_Value & "') AND CUMBGCBOXNMACHINING.PROD_TYPE IN ('" & Prod_Type_Value & "')
                                GROUP BY CUMBGCBOXNMACHINING.FIN_YR ,year(CUMBGCBOXNMACHINING.First_Date),month(CUMBGCBOXNMACHINING.First_Date),CUMBGCBOXNMACHINING.MONTH_YEAR, CUMBGCBOXNMACHINING.PROD_TYPE ,CUMBGCBOXNMACHINING.First_Date , CUMBGCBOXNMACHINING.MACHINE_MONTH_TOTAL,CUMBGCBOXNMACHINING.MACHINE_MONTH"

        Dim machining_str2_value = "SELECT B1.FIN_YR , B1.MONTH_YEAR , B1.MACHINE_MONTH_TOTAL , SUM(B2.MACHINE_MONTH_TOTAL) AS MACHINING_TOTAL_CUM , B1.MACHINE_MONTH , SUM(B2.MACHINE_MONTH) AS MACHINE_MONTH_CUM , CAST(ROUND(ISNULL((SUM(B2.MACHINE_MONTH) * 100.0 / NULLIF(SUM(B2.MACHINE_MONTH_TOTAL), 0)), 0) , 2) as decimal(5,2)) AS MACHINING_CUM_PER
                                    FROM CUMBGCBOXNMACHININGFINYR B1
                                    INNER JOIN CUMBGCBOXNMACHININGFINYR B2 ON B1.First_Date>=B2.First_Date
                                    GROUP BY B1.FIN_YR , B1.MONTH_YEAR , B1.First_Date , B1.MACHINE_MONTH_TOTAL , B1.MACHINE_MONTH
                                    ORDER BY B1.First_Date"


        Dim rdr As SqlDataReader

        pr_mw_rejection_machining = New ArrayList

        con.Open()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str1)
        rdr.Close()
        rdr = SqlHelper.ExecuteReader(con, CommandType.Text, machining_str2_value)

        While rdr.Read
            pr_mw_rejection_machining.Add(rdr.Item("MACHINING_CUM_PER"))
        End While

        rdr.Close()
        con.Close()

    End Sub

    ' Sub analysis_boxn(ByVal startYear As Integer, ByVal endYear As Integer, ByVal prodType As String)
    '     Dim str1 = "CREATE OR ALTER VIEW TESTDATE AS
    'SELECT DISTINCT CAST(TestDate AS DATE) TestDate
    'FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
    'GROUP BY TestDate"
    '     Dim str2 = "CREATE OR ALTER VIEW STOCK AS
    '	SELECT  CAST(TestDate AS DATE) TestDate, COUNT(*) STOCK_COUNT
    '	FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
    '	WHERE WheelType='F' AND FinalStatus='STOCK' and prodtype='BOXN'
    '	GROUP BY TestDate"
    '     Dim str3 = "CREATE OR ALTER VIEW MACHINE AS
    '	SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) MACHINE_COUNT
    '	FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
    '	WHERE WheelType='F' AND Machining IN ('HH','HT') and prodtype='BOXN'
    '	GROUP BY TestDate"
    '     Dim str4 = "CREATE OR ALTER VIEW REJECTION AS
    '	SELECT CAST(TestDate AS DATE) TestDate, COUNT(*) REJECTION_COUNT
    '	FROM wapdev.dbo.mm_magnaglow_new_shiftwiserecords
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


    'Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    Protected Sub Report_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Report_Type.SelectedIndexChanged


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
            percentage_fw_rejection_dr_combined()
        ElseIf String.Compare(prodTypeStr, "BGC") = 0 And String.Compare(reportTypeStr, "PERCENTAGE FRESH WHEEL") = 0 Then
            percentage_fw_rejection_dr_bgc(prodTypeStr)
        ElseIf String.Compare(prodTypeStr, "BOXN") = 0 And String.Compare(reportTypeStr, "PERCENTAGE FRESH WHEEL") = 0 Then
            percentage_fw_rejection_dr_bgc(prodTypeStr)
        ElseIf String.Compare(reportTypeStr, "BAD CHEMISTRY") = 0 Then
            percentage_rejection_bad_chemistry(startFY, endFY)
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