Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';

Menu.prototype.cssFile = '/ppms/menus/skins/officexp/officexp.css';
var mH01= new Menu();var mV00= new Menu();var mL02= new Menu();var mLB00= new Menu();var mA03= new Menu();var mMGM= new Menu();var mHS01= new Menu();var mL03= new Menu();var mL10= new Menu();var mL14= new Menu();var mLB01= new Menu();var mLB06= new Menu();var mLB09= new Menu();var mV01= new Menu();var mV02= new Menu();var mL04= new Menu();
var tmp;
mA03.add(tmp = new MenuItem("Transport - Van Rate","/ppms/miscEDs/pbranchTransport.aspx"));tmp.mnemonic = '';mH01.add(tmp = new MenuItem("Post Allotment",null,null, mHS01) );
tmp.mnemonic = '';
mH01.add(tmp = new MenuItem("View HH Availability","/ppms/quest/QHolidayHome.aspx"));tmp.mnemonic = '';mH01.add(tmp = new MenuItem("Print Allotment","/ppms/quest/hr_holidayhomeAllotmentPrint.aspx"));tmp.mnemonic = '';mL02.add(tmp = new MenuItem("Leave Application",null,null, mL03) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave Master",null,null, mL10) );
tmp.mnemonic = '';
mL02.add(tmp = new MenuItem("Leave Special Debit/Credit",null,null, mL14) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Library Master",null,null, mLB01) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Issue Book",null,null, mLB06) );
tmp.mnemonic = '';
mLB00.add(tmp = new MenuItem("Library Reports",null,null, mLB09) );
tmp.mnemonic = '';
mMGM.add(tmp = new MenuItem("Post Messages","/ppms/frmNoticeBoard.aspx"));tmp.mnemonic = '';mV00.add(tmp = new MenuItem("Complaints",null,null, mV01) );
tmp.mnemonic = '';
mV00.add(tmp = new MenuItem("Remarks",null,null, mV02) );
tmp.mnemonic = '';
mHS01.add(tmp = new MenuItem("ADD","/ppms/quest/hrHolidayHomeApproval.aspx?mode=add"));tmp.mnemonic = '';mHS01.add(tmp = new MenuItem("EDIT","/ppms/quest/hrHolidayHomeApproval.aspx?mode=edit"));tmp.mnemonic = '';mHS01.add(tmp = new MenuItem("DELETE","/ppms/quest/hrHolidayHomeApproval.aspx?mode=delete"));tmp.mnemonic = '';mL03.add(tmp = new MenuItem("Application Posting",null,null, mL04) );
tmp.mnemonic = '';
mL03.add(tmp = new MenuItem("Posting Leave Sanction","/ppms/leave/postSanctionToApplicationForLeave.aspx?mode=post"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Add","/ppms/leave/leaveApplicationform.aspx?mode=add&task_id=L05"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Delete","/ppms/leave/editApplicationForLeave.aspx?mode=delete"));tmp.mnemonic = '';mL04.add(tmp = new MenuItem("Application Printing","/ppms/Reports/formats/ApplicationForms/rptLeaveApplication.aspx?mode=rptLeaveApplication"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Add","/ppms/leave/employeeLeaveMaster.aspx?mode=add"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Edit","/ppms/leave/employeeLeaveMaster.aspx?mode=edit"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Delete","/ppms/leave/employeeLeaveMaster.aspx?mode=delete"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Leave Crediting - I half","/ppms/leave/FstHalfLeaveCredit.aspx"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Leave Crediting - II half","/ppms/leave/SecondHalfLeaveCredit.aspx"));tmp.mnemonic = '';mL10.add(tmp = new MenuItem("Retrospective Leave Cr/Db","/ppms/leave/leaveRetrospectivePosting.aspx"));tmp.mnemonic = '';mL14.add(tmp = new MenuItem("Add","/ppms/leave/leaveSpecialDeditCredit.aspx?mode=add"));tmp.mnemonic = '';mL14.add(tmp = new MenuItem("Edit","/ppms/leave/leaveSpecialDeditCredit.aspx?mode=edit"));tmp.mnemonic = '';mL14.add(tmp = new MenuItem("Delete","/ppms/leave/leaveSpecialDeditCredit.aspx?mode=delete"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("Add","/ppms/library/libraryMaster.aspx?mode=add"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("Edit","/ppms/library/libraryMaster.aspx?mode=edit"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("Delete","/ppms/library/libraryMaster.aspx?mode=delete"));tmp.mnemonic = '';mLB01.add(tmp = new MenuItem("View","/ppms/library/libraryMaster.aspx?mode=view"));tmp.mnemonic = '';mLB06.add(tmp = new MenuItem("Issue","/ppms/library/libraryTransactions.aspx?mode=issue"));tmp.mnemonic = '';mLB06.add(tmp = new MenuItem("Return","/ppms/library/libraryTransactions.aspx?mode=return"));tmp.mnemonic = '';mLB09.add(tmp = new MenuItem("Books Available","/ppms/library/Library reports.aspx"));tmp.mnemonic = '';mV01.add(tmp = new MenuItem("View All","/ppms/greivances/viewAll.aspx"));tmp.mnemonic = '';mV02.add(tmp = new MenuItem("Remarks-New Cases","/ppms/greivances/answerGreivances.aspx?mode=add"));tmp.mnemonic = '';mV02.add(tmp = new MenuItem("View New Complaints","/ppms/rptGeneral.aspx?rptName=greivance_new_comp"));tmp.mnemonic = '';mV02.add(tmp = new MenuItem("View Remarks made","/ppms/rptGeneral.aspx?rptName=greivance_remakrs"));tmp.mnemonic = '';mV02.add(tmp = new MenuItem("View Particular Employee","/ppms/greivances/grievanceLogin.aspx?mode=view"));tmp.mnemonic = '';mV02.add(tmp = new MenuItem("Delete Old Cases","/ppms/greivances/grDeleteOldCasses.aspx"));tmp.mnemonic = '';
var menuBar = new MenuBar();
menuBar.add( tmp = new MenuButton("Holiday Home", mH01) );
tmp.mnemonic = ' ';
menuBar.add( tmp = new MenuButton("Grievance Monitoring", mV00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Leave Accounting", mL02) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Library", mLB00) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Misc. E/Ds", mA03) );
tmp.mnemonic = '';
menuBar.add( tmp = new MenuButton("Messages", mMGM) );
tmp.mnemonic = '';

menuBar.write();
