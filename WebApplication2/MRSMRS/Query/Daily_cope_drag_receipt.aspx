<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Daily_cope_drag_receipt.aspx.vb" Inherits="WebApplication2.Daily_cope_drag_receipt" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Axles_received_ams</title>
		 <LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet" />
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
            <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src= "https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">  </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
 
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
         .auto-style3 {
             display: block;
             font-size: 14px;
             font-weight: 400;
             line-height: 1.42857143;
             color: #555;
             background-clip: padding-box;
             border-radius: 4px;
             transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
             -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
             box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
             -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
             -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
             border: 1px solid #ccc;
             padding: 6px 12px;
             background-color: #fff;
             background-image: none;
         }
         </style>
	</head>
	<body>
                        <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333" >
      <ul class="navbar-nav ml-auto navbar-center">
         <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
       
         </li>
          </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>     
    
		<form id="Form1" method="post" runat="server">
             <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
		
				<asp:Panel id="Panel1" runat="server">
                    <div class="container">
				
                <div class="table">

						 <div  class="row">
							 <div  class="col" align="center"><h2><strong>Enter&nbsp;Cope or Drag&nbsp;Received Date.
                                 </strong></h2> </div >
						 </div ><br />
						 <div  class="row">
							 <div  class="col">
								<asp:Label id="lblerr" runat="server" ForeColor="Red"></asp:Label> </div >
						 </div ><br />
						 <div  class="row">
							<div class="col"> Date</div>
                                
                                <div class="col">     
								<asp:textbox id="txtDate" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" placeholder="dd/mm/yyyy" Width="104px"></asp:textbox> </div>
                             <div class="col"></div>
                             <div class="col"></div>
                             <div class="col"></div>
                             <div class="col"></div>
				</div>
                    <div class="row">
							 <div  class="col" align="center">
                                 <asp:button id="btnReceipt" runat="server" Text="Show Receipt Details"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							
							 </div >
						 </div >
					<br />
                    <br />
					
									 <div  class="row">
										 <div  class="col">MouldNumber </div >
										
										 <div  class="col">
											<asp:TextBox id="TextBox1" runat="server" CssClass="form-control" MaxLength="5" ToolTip="enter 5-digit mould number" onkeypress="OnlyNumericEntry()" Width="104px"></asp:TextBox> </div >
									 
										 <div  class="col">From Date </div >
										
										 <div  class="col">
											<asp:TextBox id="txtFromDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" Width="104px" MaxLength="10" placeholder="dd/mm/yyyy"></asp:TextBox> </div >
									
										 <div  class="col">To date </div >
									
										 <div  class="col">
											<asp:TextBox id="txtToDate" runat="server" CssClass="form-control" AutoPostBack="True" onkeypress="return isNumber1(event,this)" Width="104px" MaxLength="10" placeholder="dd/mm/yyyy"></asp:TextBox>
                                       
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtToDate" ControlToValidate="txtFromDate" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>

										 </div >

									 </div >
                        <br />
					
									 <div  class="row">
										 <div  class="col"  align="center">
                                         <asp:button id="Button1" runat="server" Text="Show Data"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
									 </div >
								
							<%-- </div >
							 <div  class="col">--%><br />
					
								
									 <div  class="row">
										 <div  class="col" align="center" >New Moulds PO Details </div >
									 </div >
                        <br />
					
									 <div  class="row">
										 <div  class="col">FromDate </div >
										
										 <div  class="col">
											<asp:TextBox id="txtFrDt" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" Width="104px" placeholder="dd/mm/yyyy"></asp:TextBox> </div >
									 
										 <div  class="col">ToDate </div >
										 
										 <div  class="col">
											<asp:TextBox id="txtToDt" runat="server" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10" Width="104px" placeholder="dd/mm/yyyy"></asp:TextBox>
                                             <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtToDt" ControlToValidate="txtFrDt" ErrorMessage="To Date should be greater than From Date" ForeColor="#FF3300" Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
										 </div >
									 </div ><br />
					<br />
									 <div  class="row">
										 <div  class="col" align="center" >
                                         <asp:button id="btnPODetails" runat="server" Text="Show PO Details"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>
							</div>
									 </div >
							
                                
						
						 <div  class="row">
							 <div  class="col" >
								<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#CC9966">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid>
								<asp:DataGrid id="DataGrid2" runat="server" CssClass="table" BorderStyle="None" CellPadding="4" BackColor="White" BorderWidth="1px" BorderColor="#3366CC">
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
								</asp:DataGrid>
								<asp:DataGrid id="DataGrid3" runat="server" CssClass="table" ForeColor="Black" BorderStyle="Solid" CellPadding="3" BackColor="White" BorderWidth="1px" BorderColor="#999999" GridLines="Vertical">
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#CCCCCC"></AlternatingItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Black"></HeaderStyle>
									<FooterStyle BackColor="#CCCCCC"></FooterStyle>
									<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999"></PagerStyle>
								</asp:DataGrid> </div >
						 </div >
					</div>
                        </div>
                    
				</asp:Panel>
			
		</form>
                    
                 
    <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:absolute;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
    <script type="text/javascript">
 $(document).ready(function () {
                       
                        $('#txtDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
        });
         $(document).ready(function () {
                       
                        $('#txtToDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtToDate').datepicker('getDate');           
                                                 
                              
                            }
             });
             function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
        });
         $(document).ready(function () {
                       
                        $('#txtFrDt').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFrDt').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
        });
         $(document).ready(function () {
                       
                        $('#txtToDt').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtToDt').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
             });
              
 $(document).ready(function () {
                       
                        $('#txtFromDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFromDate').datepicker('getDate');           
                                                 
                              
                            }
                        });
    
  function getDate( element ) {
    var date;
    var dateFormat = "dd-MM-yyyy";
    try {
      date = $.datepicker.parseDate( dateFormat, element.value );
    } catch( error ) {
      date = null;
    }

    return date;
  }
            });
            
            </script>

	</body>
</html>
