Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA04= new Menu();var mA01= new Menu();var mN12= new Menu();var mL02= new Menu();var mLB00= new Menu();var mA03= new Menu();var mT80= new Menu();var mL03= new Menu();var mL50= new Menu();var mLB01= new Menu();var mLB06= new Menu();var mLB09= new Menu();var mLB12= new Menu();var mT81= new Menu();var mT86= new Menu();var mL04= new Menu();
var tmp;
mA01.add(tmp = new MenuItem("Update Taken Charge Date","/ppms/CareerEvents/careerEventsChargeUpdate.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Taken Charge Order","/ppms/CareerEvents/printTakenchargeorder.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Unposted Entries","/ppms/CareerEvents/printUnpostedentries.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Create Noting","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=add"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Add Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=add"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Modify Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=edit"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Delete Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=delete"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("View Noting","/ppms/miscEDs/miscErngDeductionNotingQuery.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Noting","/ppms/Reports/Formats/miscEDs/miscEdPrintNoting.aspx?mode=miscEdNoting.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Generate Memorandum","/ppms/miscEDs/miscEDOffOrdNumber.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Memorandum","/ppms/Reports/Formats/miscEds/miscEdPrintMemorandum.aspx?mode=miscEdMemorandum.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Unposted","/ppms/Reports/Formats/miscEds/miscEdUnPostedEntries.aspx?mode=miscEdUnPosted.rpt"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Create Recomend Noting","/ppms/awards/awardNoting.aspx?mode=add"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Add Employee","/ppms/awards/awardNoting.aspx?mode=add"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Delete Employee","/ppms/awards/awardNoting.aspx?mode=delete"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Query Noting","/ppms/awards/awardNoting.aspx?mode=view"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Print Noting","/ppms/awards/awardReports.aspx?mode=note_number"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Generate Memorandum","/ppms/awards/awardOfficeOrdNumber.aspx"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Print Memorandum","/ppms/awards/awardReports.aspx?mode=memorandum"));tmp.mnemonic = '';mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Library Master",null,null, mLB01) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Issue Book",null,null, mLB06) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Library Reports",null,null, mLB09) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Library Query",null,null, mLB12) );
tmp.mnemonic = '';
mN12.add(tmp = new MenuItem("Create Noting","/ppms/hoer/creatingHoerNoting.aspx"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Add Employee","/ppms/hoer/miscAttandance.aspx?mode=add"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Modify","/ppms/hoer/miscAttandance.aspx?mode=edit"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("View","/ppms/hoer/miscAttandance.aspx?mode=view"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Delete","/ppms/hoer/miscAttandance.aspx?mode=delete"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Print Noting","/ppms/hoer/printNotingHoer.aspx"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Generate Memorandum","/ppms/hoer/MemoGeneration.aspx"));tmp.mnemonic = '';mN12.add(tmp = new MenuItem("Print Memorandum","/ppms/hoer/printMemorandum.aspx"));tmp.mnemonic = '';mT80.add(tmp = new MenuItem("TA Journal entry",null,null, mT81) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("Contingency/conveyance",null,null, mT86) );
tmp.mnemonic = '';
mT80.add(tmp = new MenuItem("TA Journal/Contingency printing","/ppms/ta/RptTravellingAllowance.aspx"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Add","/ppms/ta/ta1.aspx?mode=add"));tmp.mnemonic = '';mT81.add(tmp = new MenuItem("Delete","/ppms/ta/editTA.aspx?mode=delete"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Add","/ppms/ta/ta2.aspx?mode=add"));tmp.mnemonic = '';mT86.add(tmp = new MenuItem("Delete","/ppms/ta/deleteTA2.aspx?mode=delete"));tmp.mnemonic = '';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Posting Leave Sanction","/ppms/leave/postSanctionToApplicationForLeave.aspx?mode=post"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplicationform.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Cancel Leave","/ppms/leave/cancelapplicationforleave.aspx"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("GenerateMemorandum","/ppms/leave/leaveMemorandum.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memorandum","/ppms/leave/rptLeaveMemorandum.aspx?mode=memorandum"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("CheckList(Leave posting)","/ppms/Reports/formats/leave/leavePostingCheckList.aspx?mode=leaveAbsenseCheckList.rpt"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Account Statement","/ppms/leave/frmLeaveAnnualStatement.aspx?mode=employee"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Posting from application","/ppms/leave/lavanya.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("Add","/ppms/library/libraryMaster.aspx?mode=add"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("Edit","/ppms/library/libraryMaster.aspx?mode=edit"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("View","/ppms/library/libraryMaster.aspx?mode=view"));tmp.mnemonic = '';mLB06.add(tmp = new MenuItem("Issue","/ppms/library/libraryTransactions.aspx?mode=issue"));tmp.mnemonic = '';mLB06.add(tmp = new MenuItem("Return","/ppms/library/libraryTransactions.aspx?mode=return"));tmp.mnemonic = '';mLB09.add(tmp = new MenuItem("Books Available","/ppms/library/Library reports.aspx"));tmp.mnemonic = '';mLB09.add(tmp = new MenuItem("Books Issued","/ppms/library/Library reports.aspx"));tmp.mnemonic = '';mLB12.add(tmp = new MenuItem("Book Query","/ppms/library/booksQuery.aspx"));tmp.mnemonic = '';mLB12.add(tmp = new MenuItem("Employees Book Query","/ppms/library/employeeBooksQuery.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Awards", mA04) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Career Events", mA01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("HOER OT/NDA", mN12) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Library", mLB00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Misc. E/Ds", mA03) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("POST T.A./CONVAYANCE", mT80) );
tmp.mnemonic = '';

menuBar.write();
