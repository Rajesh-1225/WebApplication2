Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mN104= new Menu();var mgg1= new Menu();var mRH01= new Menu();var mI02= new Menu();var mY02= new Menu();var mL02= new Menu();var mS02= new Menu();var mT80= new Menu();var mF00= new Menu();var mQ00= new Menu();var mZ02= new Menu();var mQYM= new Menu();var mL50= new Menu();var mQ01= new Menu();var mT81= new Menu();var mT86= new Menu();var mZ12= new Menu();var mZ20= new Menu();var mZ66= new Menu();var mF52= new Menu();var mN105= new Menu();var mPR00= new Menu();
var tmp;
mF00.add(tmp = new MenuItem("Application Prints","/ppms/Reports/Formats/rptPF/pfPrintApplications.aspx"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Leave","/ppms/reports/formats/rptQuest/rptPFLogin.aspx?task_id=gg2"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("P.F.Balance","/ppms/Reports/Formats/rptQuest/rptPFLogin.aspx?task_id=gg3"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Know Your Income Tax","/ppms/reports/formats/rptIT/itRep.aspx?rptName=incomeTaxRpt"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Holiday Home Availability","/ppms/quest/QHolidayHome.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Rates Summary Report","/ppms/Reports/Formats/rptIncentive/ibRatesSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("IB Earnings Summary","/ppms/Reports/Formats/rptIncentive/ibEarningSummary.aspx"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Incentive Bill","/ppms/Reports/Formats/rptIncentive/ppinc091.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mI02.add(tmp = new MenuItem("Group wise Emp Summary","/ppms/Reports/Formats/rptIncentive/incemp.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mPR00.add(tmp = new MenuItem("SALARY CERTIFICATE","/ppms/others/SalaryCertificate.aspx"));tmp.mnemonic = ' ';mQ00.add(tmp = new MenuItem("Priority Register",null,null, mQ01) );
tmp.mnemonic = '';
mQYM.add(tmp = new MenuItem("HR-General Queries","/ppms/hrquery.aspx"));tmp.mnemonic = '';mRH01.add(tmp = new MenuItem("View Availability","/ppms/quest/QRestHouse.aspx"));tmp.mnemonic = '';mS02.add(tmp = new MenuItem("Application","/ppms/passes/applicationForPassPTO.aspx?mode=add"));tmp.mnemonic = '';mT80.add(tmp = new MenuItem("TA Journal entry",null,null, mT81) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("Contingency/conveyance",null,null, mT86) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("TA Journal/Contingency printing","/ppms/ta/RptTravellingAllowance.aspx"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Add","/ppms/ta/ta1.aspx?mode=add"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Delete","/ppms/ta/editTA.aspx?mode=delete"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Add","/ppms/ta/ta2.aspx?mode=add"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Delete","/ppms/ta/deleteTA2.aspx?mode=delete"));tmp.mnemonic = '';mY02.add(tmp = new MenuItem("Income Tax Calc./Printing","/ppms/it/itprocess.aspx"));tmp.mnemonic = '';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("ChequeStatement",null,null, mZ20) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Payroll Reports",null,null, mZ66) );
tmp.mnemonic = '';
mF00.add(tmp = new MenuItem("PF Nominations",null,null, mF52) );
tmp.mnemonic = '';
mgg1.add(tmp = new MenuItem("Pay Slip Details","/ppms/quest/SalaryDetails.aspx"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Pass Account Details","/ppms/Quest/passdetailsquery.aspx"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Blood Group","/ppms/quest/frmBloodBank.aspx"));tmp.mnemonic = '';mgg1.add(tmp = new MenuItem("Total Salary","/ppms/quest/TotalSalary.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Account Statement","/ppms/leave/frmLeaveAnnualStatement.aspx?mode=employee"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Add","/ppms//quarters/QuarterPriorityRegister.aspx?mode=add"));tmp.mnemonic = '';mQ01.add(tmp = new MenuItem("Delete","/ppms/quarters/QuarterPriorityRegister.aspx?mode=delete"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Employeewise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=EmployeeWise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("AccountNowise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=AccountNowise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankstatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankstatement"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankwisestatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankwisestatement"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Bill Unit Wise Bank Statement","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptBUwiseBankStatement"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Bill Unit Wise CO7","/ppms/supplementary/printCO7.aspx?mode=Reports/formats/rptPayRoll/payrollCO7.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Consolidated Debit Summary","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptConsolidatedDebitSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Consolidated credit Summary","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptConsolidatedCreditSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Net pay summary Employeewise","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptnetFileSummaryEmployeewise"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Net Pay summary BillUnitWise","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptnetFileSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("OT paid summary shopwise","/ppms/Reports/formats/rptPayRoll/frmPPPR26.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("OT paid summary employeewise","/ppms/Reports/formats/rptPayRoll/frmPPPR28.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Monthly OT Details of Artisans and Staff","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptOTdetailsGm"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("A4 PaySlip Printing","/ppms/Reports/Formats/rptPayroll/hr_rpt_Payslips_report.aspx"));tmp.mnemonic = '';mF52.add(tmp = new MenuItem("ADD","/ppms/pf/pfnomination.aspx?mode=add"));tmp.mnemonic = '';mF52.add(tmp = new MenuItem("PRINT","/ppms/pf/pfnomination.aspx?mode=PRINT"));tmp.mnemonic = '';mN105.add(tmp = new MenuItem("Pay Fixation Charts",""));tmp.mnemonic = '';mN104.add(tmp = new MenuItem("7PC As Drawn Edit","/ppms/PayCommission/hr_PC_ArrearsEdit.aspx"));tmp.mnemonic = '';mN104.add(tmp = new MenuItem("7th PC Career Events",null,null, mN105) );
tmp.mnemonic = '';

var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("7th Pay Commission", mN104) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("General", mgg1) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Rest House", mRH01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Incentive", mI02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Income Tax", mY02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pass Issues", mS02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("POST T.A./CONVAYANCE", mT80) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Provident Fund", mF00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Quarters", mQ00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("HR-QUERIES", mQYM) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Other Reports", mPR00) );
tmp.mnemonic = ' ';

menuBar.write();
