Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mY02= new Menu();var mTO00= new Menu();var mZ02= new Menu();var mPPR0= new Menu();var mTO03= new Menu();var mZ12= new Menu();var mZ43= new Menu();var mZ53= new Menu();var mZ27= new Menu();var mZ61= new Menu();var mZ63= new Menu();var mZ49= new Menu();var mZ20= new Menu();var mZ66= new Menu();var mTO32= new Menu();var mZ13= new Menu();var mPR00= new Menu();
var tmp;
mPPR0.add(tmp = new MenuItem("View","/ppms/payslip/frmPayslip.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("OT NDA","/ppms/others/rptOTNDA.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("SALARY CERTIFICATE","/ppms/others/SalaryCertificate.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("Scale Check","/ppms/others/scale_check.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("Service Register","/ppms/others/ServiceRegister.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("Scale Check /year wise","/ppms/others/scalecheck_year.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("LIC Floppy Data Generation","/ppms/others/GenLicFlpdata.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("ECS Statistics - Salary","/ppms/others/hrECSStatistics.aspx"));tmp.mnemonic = ' ';mPR00.add(tmp = new MenuItem("NDA/FOT-NOT/SHOER-DHOER - 5PC","/ppms/ot/hr_5pc_not_fot_hoer_calculation.aspx"));tmp.mnemonic = '';mPR00.add(tmp = new MenuItem("AddtionalPayrollReports","/ppms/others/ppmsAdditionalReports.aspx"));tmp.mnemonic = '';mTO00.add(tmp = new MenuItem("Monthly",null,null, mTO03) );
tmp.mnemonic = '';
mY02.add(tmp = new MenuItem("Income Tax Form 16  Print","/ppms/Reports/Formats/rptIT/frmForm16Report.aspx"));tmp.mnemonic = '';mZ02.add(tmp = new MenuItem("Reports",null,null, mZ12) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Employee Details",null,null, mZ43) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Deduction Statements",null,null, mZ53) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Check List",null,null, mZ27) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Increment Reports",null,null, mZ61) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Employee Lists",null,null, mZ63) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Exception Reports",null,null, mZ49) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("ChequeStatement",null,null, mZ20) );
tmp.mnemonic = '';
mZ12.add(tmp = new MenuItem("Payroll Reports",null,null, mZ66) );
tmp.mnemonic = '';
mTO03.add(tmp = new MenuItem("Reports",null,null, mTO32) );
tmp.mnemonic = '';
mTO32.add(tmp = new MenuItem("Monthly Attendance Statement","/ppms/Reports/Formats/rptTimeOffice/repMonthlyAttendanceGeneration.aspx"));tmp.mnemonic = '';mZ12.add(tmp = new MenuItem("Code Directory",null,null, mZ13) );
tmp.mnemonic = '';
mZ13.add(tmp = new MenuItem("CodeDirectory-AllocationWise","/ppms/Reports/formats/CodeDirectory/allocationwise.aspx?mode=CodeDirectory-AllocationWise"));tmp.mnemonic = '';mZ13.add(tmp = new MenuItem("CodeDirectory-FileGroupWise","/ppms/Reports/formats/CodeDirectory/allocationwise.aspx?mode=CodeDirectory-FileGroupWise"));tmp.mnemonic = '';mZ13.add(tmp = new MenuItem("CodeDirectory-DescWise","/ppms/Reports/formats/CodeDirectory/GeneralCodes.aspx?mode=CodeDirectory-DescWise"));tmp.mnemonic = '';mZ13.add(tmp = new MenuItem("CodeDirectory-Designations","/ppms/Reports/formats/CodeDirectory/allocationwise.aspx?mode=CodeDirectory-Designations"));tmp.mnemonic = '';mZ13.add(tmp = new MenuItem("CodeDirectory-ScaleCodes","/ppms/Reports/formats/CodeDirectory/allocationwise.aspx?mode=CodeDirectory-ScaleCodes"));tmp.mnemonic = '';mZ13.add(tmp = new MenuItem("GenreralCodes","/ppms/Reports/formats/CodeDirectory/GeneralCodes.aspx?mode=GenreralCodes"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Employeewise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=EmployeeWise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("AccountNowise","/ppms/Reports/formats/chequestatement/employee.aspx?mode=AccountNowise"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Societies","/ppms/Reports/formats/chequestatement/societies.aspx?mode=Societies"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankstatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankstatement"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("PLI","/ppms/Reports/formats/chequestatement/societies.aspx?mode=PLI"));tmp.mnemonic = '';mZ20.add(tmp = new MenuItem("Bankwisestatement","/ppms/Reports/formats/chequestatement/BankwiseStatement.aspx?mode=Bankwisestatement"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistBankdetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistBankdetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("Checklist Fixed/Earnings/Deductions","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistEarningsDeductions"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistFamilyDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistFamilyDetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistLoansAdvances","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistLoansAdvances"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("CheckListLocalAddress","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=CheckListLocalAddress"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistMiscAttendanceDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistMiscAttendanceDetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistMiscellaneousDeductions","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistMiscellaneousDeductions"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistPayrates","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistPayrates"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("CheckListPermanentAddress","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=CheckListPermanentAddress"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistPunishmentDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistPunishmentDetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistQualificationDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistQualificationDetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("ChecklistTrainingDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistTrainingDetails"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("EmployeePersonalDetails","/ppms/Reports/formats/CheckList/ChecklistEmployeePerDetails.rpt?user0=report&password0=report"));tmp.mnemonic = '';mZ27.add(tmp = new MenuItem("CheckListAwardDetails","/ppms/Reports/formats/CheckList/Checklist.aspx?mode=ChecklistAwardDetails"));tmp.mnemonic = '';mZ43.add(tmp = new MenuItem("Employee Bio-Data","/ppms/Reports/formats/Employee/rptEmployeeDetails.aspx?mode=rptEmployeeBioData"));tmp.mnemonic = '';mZ43.add(tmp = new MenuItem("Employee Court Details","/ppms/Reports/formats/Employee/rptEmployeeDetails.aspx?mode=rptEmployeeCourtDetails"));tmp.mnemonic = '';mZ43.add(tmp = new MenuItem("Employee Local Address","/ppms/Reports/formats/Employee/rptEmployeeDetails.aspx?mode=rptEmployeeLocalAddress"));tmp.mnemonic = '';mZ43.add(tmp = new MenuItem("Employee Permanent Address","/ppms/Reports/formats/Employee/rptEmployeeDetails.aspx?mode=rptEmployeePermanentAddress"));tmp.mnemonic = '';mZ43.add(tmp = new MenuItem("Employee Family Details","/ppms/Reports/formats/Employee/rptEmployeeDetails.aspx?mode=rptEmployeeRelations"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("No Insurance","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptNoInsurance"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("House Rent - No E/D","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptHouseRentNoED"));tmp.mnemonic = '';mZ49.add(tmp = new MenuItem("House Rent - Both E/D","/ppms/Reports/formats/ExceptionReports/rptExceptions.aspx?mode=rptHouseRentBothED"));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("Debit Summary","/ppms/Reports/formats/rptDeductionStatements/rptDeductions.aspx?mode=rptDebitSummary"));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("Debit Summary - Hours & Days","/ppms/Reports/formats/rptDeductionStatements/rptDeductionsHoursDays.aspx?mode=rptDebitSummaryHoursDays"));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("Credit Summary","/ppms/Reports/formats/rptDeductionStatements/rptDeductions.aspx?mode=rptCreditSummary"));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("PF",""));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("BU Wise PF Summary",""));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("Other Deduction Statements","/ppms/Reports/formats/rptDeductionStatements/rptDeductions.aspx?mode=rptDeductionStatements"));tmp.mnemonic = '';mZ53.add(tmp = new MenuItem("Other Railways","/ppms/Reports/formats/rptDeductionStatements/rptDeductions.aspx?mode=rptOtherRailways"));tmp.mnemonic = '';mZ61.add(tmp = new MenuItem("Due List","/ppms/Reports/formats/rptIncrements/rptIncrement.aspx?mode=rptIncrementDueList"));tmp.mnemonic = '';mZ63.add(tmp = new MenuItem("Without PF Nomination","/ppms/Reports/formats/rptEmployeeList/rptEmployeeWithoutPF.aspx?mode=rptEmployeeListWithoutPF"));tmp.mnemonic = '';mZ63.add(tmp = new MenuItem("Without DRA Recovery","/ppms/Reports/formats/rptEmployeeList/rptEmployeeWithoutPF.aspx?mode=rptEmployeeListWithoutDRA"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Bill Unit Wise Bank Statement","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptBUwiseBankStatement"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Bill Unit Wise CO7","/ppms/supplementary/printCO7.aspx?mode=Reports/formats/rptPayRoll/payrollCO7.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Memo Of Diff - Basic","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptMemorandumofDiffs"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Memo Of Diff - %","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptBill_memofDiff%"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Catg Wise for a ED","/ppms/Reports/formats/rptPayRoll/CatgwiseEED.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Profession Tax form 5 monthly report","/ppms/Reports/formats/rptPayRoll/form5.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("NDA/OT/TA allowances monthly report","/ppms/Reports/formats/rptPayRoll/NDA_OT_Adv.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Quarters recoveries not done","/ppms/Reports/formats/rptPayRoll/?mode="));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Consolidated Debit Summary","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptConsolidatedDebitSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Consolidated Debit Summary Days & Hours","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptConsolidatedDebitSummaryHoursDays"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Consolidated credit Summary","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptConsolidatedCreditSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Net pay summary Employeewise","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptnetFileSummaryEmployeewise"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Net Pay summary BillUnitWise","/ppms/Reports/formats/rptPayRoll/NetFileReport.aspx?mode=rptnetFileSummary"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Paybill BillUnitWise","/ppms/Reports/formats/rptPayRoll/rptPayBillUnitwiseRep.rpt?user0=report&password0=report"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Paybill for Pay Category","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptPayBillforCatg"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Deduction carried to next month","/ppms/Reports/formats/rptPayRoll/rpt_carry_forward_recoveries.rpt?user0=report&password0=report"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("BillUnit / NRB Summary -Ed Code wise","/ppms/Reports/formats/rptPayRoll/rptSalaryVoucher.aspx?mode=rpt_nrb_edcode_wise"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("NRB / BillUnit  Summary Group Unit wise","/ppms/Reports/formats/rptPayRoll/rptSalaryVoucher.aspx?mode=rpt_nrb_group_unit"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("OT paid summary shopwise","/ppms/Reports/formats/rptPayRoll/frmPPPR26.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("OT paid summary employeewise","/ppms/Reports/formats/rptPayRoll/frmPPPR28.aspx"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Salary Register","/ppms/Reports/formats/rptPayRoll/SalaryRegister.rpt?user0=report&password0=report"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Statement on payment through bank","/ppms/Reports/formats/rptPayRoll/rpt_payment_thru_bank.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Deduction Carried to Next Month Cummulative","/ppms/Reports/formats/rptPayRoll/rptSalaryVoucher.aspx?mode=rpt_carry_forward_recoveries_cummalative"));tmp.mnemonic = ' ';mZ66.add(tmp = new MenuItem("salary_voucher_register","/ppms/Reports/formats/rptPayRoll/rptSalaryVoucher.aspx?mode=rpt_salary_voucher_register"));tmp.mnemonic = ' ';mZ66.add(tmp = new MenuItem("Emp. drawing Sal. by Cash","/ppms/Reports/Formats/rptPayRoll/rptSalCash.rpt?user0=report&password0=report"));tmp.mnemonic = ' ';mZ66.add(tmp = new MenuItem("Professional Tax -Form-5","/ppms/Reports/formats/rptPayRoll/form5.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("ProfessionalTax Form-9","/ppms/Reports/formats/rptPayRoll/form9.rpt?user0=wap&password0=wap"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Monthly OT Details of Artisans and Staff","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptOTdetailsGm"));tmp.mnemonic = '';mZ66.add(tmp = new MenuItem("Transport Allowance Drawn but Staff on Leave","/ppms/Reports/formats/rptPayRoll/ConsolidatedReport.aspx?mode=rptTransportAllowance"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Income Tax", mY02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Time Office", mTO00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Reports", mZ02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Pay Slip View", mPPR0) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("Other Reports", mPR00) );
tmp.mnemonic = ' ';

menuBar.write();
