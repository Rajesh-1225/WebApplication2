<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProdMaterialDumpRegister.aspx.vb" Inherits="WebApplication2.ProdMaterialDumpRegister" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>ProdMaterialDumpRegister</title>
	<link rel="stylesheet" type="text/css" href="css/jquery-ui.css">

		
 
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
	</head>
     <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE;
    
}
         </style>
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
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav>
         <div class="container" align="center">
             
              <form id="Form1" method="post" runat="server">  
                <asp:panel id="Panel1"  runat="server">
                 <div class ="row">
                
               <%-- style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"--%>
				<div class="table">
                    <%--cellSpacing="1" cellPadding="1" width="300"--%>
					<div class="row">
						<div class="col"  vAlign="top" align="center">
							<asp:label id="lblConsignee" runat="server"></asp:label>&nbsp;<strong><h2> Material Dump 
							Register</strong></h2></div >
						
					</div ></div>
					
							<div  class="table" >
                               <%-- border="1"--%>
								<div class="row">
									<div class="col"  colspan="3">
										<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></div >
								</div >
								<div class="row">
									<div class="col">PL Number &nbsp &nbsp  &nbsp &nbsp&nbsp</div >
								
									<div class="col">
										<asp:DropDownList id="ddlPLs" CssClass="form-control" runat="server" Width="100px" AutoPostBack="True"></asp:DropDownList></div >
								 <div class="col"></div>
										 <div class="col"></div>
                                </div >
								<br><div class="row">
									<div class="col"  colspan="3">
										<asp:Label id="lblPLDescr" runat="server"></asp:Label></div >
                                     <div class="col"></div>
										 <div class="col"></div>
								</div >
							<br>	<div class="row">
									<div class="col">DBR Date From&nbsp&nbsp</div >
							
									<div class="col">
										<asp:TextBox id="txtFrom" runat="server" Width="100px" CssClass="form-control" ></asp:TextBox></div >
                                <div class="col"></div>
										 <div class="col"></div>
                                         
										 

								</div >
								<br><div class="row">
									<div class="col">DBR Date To&nbsp&nbsp&nbsp&nbsp&nbsp</div >
									
									<div class="col">
										<asp:TextBox id="txtTo" runat="server"  Width="100px" CssClass="form-control"></asp:TextBox></div >
                                    <div class="col"></div>
										 <div class="col"></div>
                                     
								</div >
                                <div class="table">
								<br><div class="row">
									<div class="col" >
										<asp:Button id="bntShow" runat="server"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  Text="Show DBR Details On Grid"></asp:Button></div >
								</div >

							</div>
                                </div>
                    <div class="table">
                        <div class="row" >
						<div class="col"   align="left">Following Grid For Editing Only</div ></div >
						<div class="row">
								<asp:DataGrid id="DataGrid2" runat="server" CssClass="table">
                                   <%-- PageSize="3" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></div >
					
				</div>
				
				<div class="table" >
                    </div>
                    <%--border="1"
					<div class="row">
						<div class="col"   vAlign="top" align="left">
                          <%--  style="WIDTH: 331px"--%>
							<div class="table" >
                               <%--border="1"cellSpacing="1" cellPadding="1" width="300"--%>
								<div class="row">
									<div class="col">From Heat&nbsp&nbsp&nbsp</div >
									
									<div class="col">
										<asp:TextBox id="txtFromHeat" runat="server" Width="100px" CssClass="form-control"></asp:TextBox></div >
									<div class="col">To Heat&nbsp&nbsp</div >
								
									<div class="col">
										<asp:TextBox id="txtToHeat" runat="server" Width="100px" CssClass="form-control"></asp:TextBox></div >
								</div >
							<br>	<div class="row">
									<div class="col">Used Qty&nbsp&nbsp&nbsp&nbsp</div >
									
									<div class="col">
										<asp:TextBox id="txtUsedQty" runat="server" Width="100px" CssClass="form-control"></asp:TextBox></div >
									<div class="col">DBR No</div >
								
									<div class="col">
										<asp:Label id="lblDBRNo" runat="server"></asp:Label></div >
								</div >
							<br>	<div class="row">
									<div class="col">Inspected By</div >
								
									<div class="col"  colspan="4">
										<asp:TextBox id="txtInspectedBy" runat="server" Width="100px" CssClass="form-control"></asp:TextBox></div >
                                    <div class="col"></div>
										 <div class="col"></div>
								</div >
							<br>	<div class="row">
									<div class="col">Remarks&nbsp&nbsp&nbsp&nbsp&nbsp</div >
								
									<div class="col"  colspan="4">
										<asp:TextBox id="txtRemarks" runat="server" Width="100px" CssClass="form-control"></asp:TextBox></div >
                                    <div class="col"></div>
										 <div class="col"></div>
								</div >
								<br><div class="row">
									<div class="col"  align="center" colspan="6">
										<asp:Button id="btnSave"  Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"  runat="server" Text="Save"></asp:Button>
										<asp:Label id="lblSl" runat="server"></asp:Label></div >
								</div >
							 <div class="row">
						 
						<div class="col"  >
							<asp:Label id="lblInspectedBy" runat="server"></asp:Label>&nbsp;</div >
					</div >
				</div>
				<br><asp:DataGrid id="DataGrid1" runat="server" CssClass="table"  AutoGenerateColumns="False">
                    <%--BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" --%>
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<Columns>
						<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
						<asp:BoundColumn DataField="DumpNo" ReadOnly="True" HeaderText="DumpNo"></asp:BoundColumn>
						<asp:BoundColumn DataField="dbr_number" ReadOnly="True" HeaderText="dbr_number"></asp:BoundColumn>
						<asp:BoundColumn DataField="dbr_date" ReadOnly="True" HeaderText="dbr_date"></asp:BoundColumn>
						<asp:BoundColumn DataField="SupplierName" ReadOnly="True" HeaderText="SupplierName"></asp:BoundColumn>
						<asp:BoundColumn DataField="po_number" ReadOnly="True" HeaderText="po_number"></asp:BoundColumn>
						<asp:BoundColumn DataField="PODate" ReadOnly="True" HeaderText="PODate"></asp:BoundColumn>
						<asp:BoundColumn DataField="AccQty" ReadOnly="True" HeaderText="AccQty"></asp:BoundColumn>
						<asp:BoundColumn DataField="RejQty" ReadOnly="True" HeaderText="RejQty"></asp:BoundColumn>
						<asp:BoundColumn DataField="RejReasons" ReadOnly="True" HeaderText="RejReasons"></asp:BoundColumn>
						<asp:BoundColumn DataField="idn_number" ReadOnly="True" HeaderText="idn_number"></asp:BoundColumn>
						<asp:BoundColumn DataField="idn_date" ReadOnly="True" HeaderText="idn_date"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
				<div class="table" >
                   <%-- border="1"--%>
					<div class="row">
						<div class="col" align="center" >Following Grid For Observing Consumption Rate Only </div >
                        <%--style="background-color:pink; font-weight: bold;"--%>
					</div >
					<br><div class="row">
						<div class="col" align="center" >
							<asp:DataGrid id="DataGrid3" CssClass="table" BackColor="#DEBA84" runat="server" >
                               <%-- BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"  CellPadding="3" CellSpacing="2"--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C"></SelectedItemStyle>
								<ItemStyle ForeColor="#8C4510" BackColor="#FFF7E7"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#A55129"></HeaderStyle>
								<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></div >
						<div class="col"  >
							<asp:DataGrid id="DataGrid4" CssClass="table" runat="server"  >
                               <%-- BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"--%>
								<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></div >
					</div >
				</div>
                    
                    </div>
			</asp:panel></form>   </div>
            
              
         <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	 <script>
 $(document).ready(function () {
                       
                        $('#txtFrom').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtFrom').datepicker('getDate');           
                                                 
                              
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
                       
                        $('#txtTo').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#txtTo').datepicker('getDate');           
                                                 
                              
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
