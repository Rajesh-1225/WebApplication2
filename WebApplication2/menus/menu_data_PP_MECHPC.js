Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mA04= new Menu();var mA01= new Menu();var mL02= new Menu();var mA03= new Menu();var mO20= new Menu();var mL03= new Menu();var mL50= new Menu();var mL04= new Menu();
var tmp;
mA01.add(tmp = new MenuItem("Update Taken Charge Date","/ppms/CareerEvents/careerEventsChargeUpdate.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Taken Charge Order","/ppms/CareerEvents/printTakenchargeorder.aspx"));tmp.mnemonic = '';mA01.add(tmp = new MenuItem("Print Unposted Entries","/ppms/CareerEvents/printUnpostedentries.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Create Noting","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=add"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Add Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=add"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Modify Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=edit"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Delete Employee","/ppms/miscEDs/miscErngDeductionNoting.aspx?mode=delete"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("View Noting","/ppms/miscEDs/miscErngDeductionNotingQuery.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Noting","/ppms/Reports/Formats/miscEDs/miscEdPrintNoting.aspx?mode=miscEdNoting.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Generate Memorandum","/ppms/miscEDs/miscEDOffOrdNumber.aspx"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Memorandum","/ppms/Reports/Formats/miscEds/miscEdPrintMemorandum.aspx?mode=miscEdMemorandum.rpt"));tmp.mnemonic = '';mA03.add(tmp = new MenuItem("Print Unposted","/ppms/Reports/Formats/miscEds/miscEdUnPostedEntries.aspx?mode=miscEdUnPosted.rpt"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Create Recomend Noting","/ppms/awards/awardNoting.aspx?mode=add"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Add Employee","/ppms/awards/awardNoting.aspx?mode=add"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Delete Employee","/ppms/awards/awardNoting.aspx?mode=delete"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Query Noting","/ppms/awards/awardNoting.aspx?mode=view"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Print Noting","/ppms/awards/awardReports.aspx?mode=note_number"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Generate Memorandum","/ppms/awards/awardOfficeOrdNumber.aspx"));tmp.mnemonic = '';mA04.add(tmp = new MenuItem("Print Memorandum","/ppms/awards/awardReports.aspx?mode=memorandum"));tmp.mnemonic = '';mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave/Absence",null,null, mL50) );
tmp.mnemonic = '';
mO20.add(tmp = new MenuItem("Enter Booking","/ppms/ot/NonPunchOTBookingEntry.aspx?mode=add"));tmp.mnemonic = '';mO20.add(tmp = new MenuItem("Delete Booking","/ppms/ot/NonPunchOTBookingDeletion.aspx?mode=delete"));tmp.mnemonic = '';mO20.add(tmp = new MenuItem("Query Bookings","/ppms/ot/NonPunchOTBookingQuery.aspx"));tmp.mnemonic = '';mO20.add(tmp = new MenuItem("OT Booking List","/ppms/ot/overTimeCheckList.aspx"));tmp.mnemonic = '';mO20.add(tmp = new MenuItem("OT Statement","/ppms/ot/overTimeStatement.aspx"));tmp.mnemonic = '';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Posting Leave Sanction","/ppms/leave/postSanctionToApplicationForLeave.aspx?mode=post"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplicationform.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("GenerateMemorandum","/ppms/leave/leaveMemorandum.aspx"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Print Memorandum","/ppms/leave/rptLeaveMemorandum.aspx?mode=memorandum"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("CheckList(Leave posting)","/ppms/Reports/formats/leave/leavePostingCheckList.aspx?mode=leaveAbsenseCheckList.rpt"));tmp.mnemonic = '';mL50.add(tmp = new MenuItem("Leave Query","/ppms/leave/leaveQuery.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Awards", mA04) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Career Events", mA01) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Misc. E/Ds", mA03) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Factory OT", mO20) );
tmp.mnemonic = '';

menuBar.write();
