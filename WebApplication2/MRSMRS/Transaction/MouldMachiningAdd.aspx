<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MouldMachiningAdd.aspx.vb" Inherits="WebApplication2.MouldMachiningAdd" Culture="en-GB" uiCulture="en-GB" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html>
	<head runat="server">
		<title>MouldMachiningAdd</title>
			<LINK id="mss" href="/wap.css" rel="stylesheet"/>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<META content="JavaScript" name="vs_defaultClientScript"/>
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js" type="text/javascript"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js" type="text/javascript"></script>
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
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
      
  </div>
</nav> 
        <script>

    function isInputNumber(evt) {

                    var ch = String.fromCharCode(evt.which);
        if (!(/[0-9]/.test(ch)))
        {
        evt.preventDefault();
    }

            }
               function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            } 

             </script>
         <div class="container ">

		<form id="Form1" method="post" runat="server">
             

			<asp:panel id="Panel1" runat="server" ><%--style="Z-INDEX: 101; LEFT: 9px; POSITION: absolute; TOP: 8px"  Width="638px"--%>

            <div class="row">
                <div class="table">
								<div class="row">  
									<div class="col" align="center"><FONT size="5">Mould&nbsp;Machining Details - New Add&nbsp; </FONT><hr class="prettyline" />
                                     
									</div>
                                 
                                
								</div>
								<div class="row">
									<div class="col" colspan="6">
										<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
										<asp:Label id="lblOperator" runat="server" Visible="False"></asp:Label></div>
								</div>
								<div class="row">
									<div class="col">Date</div>
									
									<div class="col">
										<asp:TextBox id="txtdate" runat="server"  AutoPostBack="true" CssClass="form-control" onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:TextBox></div>
									<div class="col">Shift</div>
									
									<div class="col">
										<asp:RadioButtonList id="rblShift" runat="server"  AutoPostBack="true" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
											<asp:ListItem Value="A" Selected="true">A</asp:ListItem>
											<asp:ListItem Value="B">B</asp:ListItem>
											<asp:ListItem Value="C">C</asp:ListItem>
										</asp:RadioButtonList></div>
								
									<div class="col">Mould Number</div>
									<div class="col">
										<asp:TextBox id="txtMould" runat="server"  AutoPostBack="true" CssClass="form-control" onkeypress="isInputNumber(event)"></asp:TextBox></div>
									</div><br />
								<div class="row">
                                    <div class="col" >Mould</div>
									
									<div class="col">
										<asp:RadioButtonList id="rblMould" runat="server"  AutoPostBack="true" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
											<asp:ListItem Value="C" Selected="true">Cope</asp:ListItem>
											<asp:ListItem Value="D">Drag</asp:ListItem>
										</asp:RadioButtonList>
										<asp:Label id="Eng" runat="server"></asp:Label></div>
								
									<div class="col">MachineCode</div>
									
									<div class="col">&nbsp;</div>
									<div class="col">Defect</div>
									
									<div class="col">
										<asp:RadioButtonList id="rblDefect" runat="server" Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
											<asp:ListItem Value="E">E</asp:ListItem>
											<asp:ListItem Value="D">D</asp:ListItem>
										</asp:RadioButtonList>
										<asp:label id="lblLife" runat="server" Visible="False"></asp:label></div>
								</div><br/>
								<div class="row">
									<div class="col" align="center">
										<asp:RadioButtonList id="rblMachine" runat="server"  Repeatdirection="Horizontal" RepeatLayout="Flow" CssClass="rbl">
											<asp:ListItem Value="MSVTLVT17">MSVTLVT17</asp:ListItem>
											<asp:ListItem Value="MSVTLVT18">MSVTLVT18</asp:ListItem>
										</asp:RadioButtonList></div>
								</div><br/>
								<div class="row">
									<div class="col">BeforeHt</div>
									<div class="col">
										<asp:TextBox id="txtBefore" runat="server"  AutoPostBack="true" ReadOnly="true" CssClass="form-control"></asp:TextBox></div>
									<div class="col">AfterHt</div>
									
									<div class="col">
										<asp:TextBox id="txtAfter" runat="server"  AutoPostBack="true" CssClass="form-control"></asp:TextBox>&nbsp;
										<asp:Label id="Loss" runat="server"></asp:Label></div>
								
									<div class="col" >StandardRemarks</div>
									
									<div class="col" colspan="4">
										<asp:DropDownList id="ddlRemarks" runat="server" CssClass="form-control l1"></asp:DropDownList></div>
								</div><br />
								<div class="row">
									<div class="col">AdditionalRemarks</div>
									
									<div class="col" colspan="4">
										<asp:TextBox id="txtremarks" runat="server" CssClass="form-control"></asp:TextBox></div>
                                    <div class="col"></div>
                                    <div class="col"></div>
                                     <div class="col"></div>
                                    <div class="col"></div>
								</div>
								<div class="row">
									<div class="col" vAlign="top" align="center" colspan="6">
										<asp:button id="btnSave" runat="server" Text="Save"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>

										<asp:Label id="lblSlNo" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;
									<asp:button id="Button1" runat="server" Text="Clear"  Font-Size="16px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark" ></asp:button>

								</div>
							
						</div>
						<div class="col" vAlign="top" align="left">
							<asp:DataGrid id="DataGrid3" runat="server"  BackColor="White" CssClass="table"><%--BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"  CellPadding="4"--%>
								<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid2" runat="server"  BackColor="White" CssClass="table"> <%-->BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"CellPadding="4"--%>
								<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid>
							<asp:DataGrid id="DataGrid1" runat="server" BackColor="White" CssClass="table">
								<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
								<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
								<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
							</asp:DataGrid></div>
					</div>
				</table>
				<asp:DataGrid id="dgMachining" runat="server"  BackColor="White" CssClass="table" >
					<SelectedItemStyle Font-Bold="true" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="true" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				</asp:DataGrid>
                    </div></div>
			</asp:panel></form></div>
      <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:fixed;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
 </body>
</html>
