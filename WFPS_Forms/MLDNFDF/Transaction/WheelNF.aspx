<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelNF.aspx.vb" Inherits="WebApplication2.WheelNF" %>
<!DOCTYPE HTML>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>WheelNF</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>

         <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
         <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
       <%--<link rel="stylesheet" href="StyleSheet1.css" />--%>
            <script>

//function OnlyNumericEntry() {
//        if ((event.keyCode < 48 || event.keyCode > 57)) {
//        event.returnValue = false;
//    }
//                }

                //for date
                 function isNumber1(evt, element) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;
                    return true;
        } 
              
        function ValidateAlpha(evt)
    {
        var keyCode = (evt.which) ? evt.which : evt.keyCode
        if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)
         
        return false;
            return true;
    }
</script>
	</head>
	<body >
           <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
 <a class="navbar-brand p-0" href="#"><img src="../../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item"> <a class="nav-link" href="#" style="color:white; font-size:25px;">Rail Wheel Plant Bela</a></li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px;"></i>
        </a></li>
       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px;"></i>
        </a></li> 
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
<!--/.Navbar -->
        <div class="container">
		<form id="Form1" method="post" runat="server">
  <div class="row">
    
                  <%--<h4>Select Your Theme : &nbsp&nbsp&nbsp </h4>
            
                 <asp:DropDownList ID="Dd1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dd1_SelectedIndexChanged" CssClass="form-control ll" Width="400px">
                     <asp:ListItem>select</asp:ListItem>
                     <asp:ListItem>Theme1</asp:ListItem>
                     <asp:ListItem>Theme2</asp:ListItem>
                     <asp:ListItem>Theme3</asp:ListItem>
                 </asp:DropDownList>
                 <br />--%>
      </div>            <div class="row"><div class="table-responsive">
			<asp:panel id="Panel2"  runat="server">
				<TABLE id="Table1" class="table"></TABLE>
					
							<asp:panel id="Panel1" runat="server" >
								<TABLE id="Table2" class="table">
									<TR>
										<TD vAlign="top" align="middle" colSpan="8">NF Loading (Wheel ID Noting)<hr class="prettyline" /></TD>
									</TR>
									<TR>
										<TD colSpan="8">
											<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
									</TR>
                                    <TR>
										<TD colSpan="2" style="width:100px">
											<asp:RadioButtonList id="rblCold" runat="server" autopostback="true" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="Regular">Regular</asp:ListItem>
											    <asp:ListItem Value="Cold" Selected="True">Cold</asp:ListItem>        
											</asp:RadioButtonList> </TD>
                                        <TD colSpan="2">
                                            <asp:DropDownList ID="ddHTType" runat="server" AutoPostBack="true" CssClass="form-control ll" Width="100px">                       	
												<asp:ListItem Value="FHT" Selected="True">FHT</asp:ListItem>
												<asp:ListItem Value="RHT1">RHT1</asp:ListItem>
												<asp:ListItem Value="RHT2">RHT2</asp:ListItem>
											 </asp:DropDownList></TD>

									</TR>
									<TR>
										<TD>Date</TD>
										<TD>
											<asp:textbox id="txtDate" runat="server"  CssClass="form-control"  onkeypress="return isNumber1(event,this)" MaxLength="10"></asp:textbox></TD>
										<TD colSpan="2">
											<asp:radiobuttonlist id="rblShift" runat="server" CssClass="rbl" RepeatDirection="Horizontal" RepeatLayout="Flow">
												<asp:ListItem Value="A" Selected="True">A</asp:ListItem>
												<asp:ListItem Value="B">B</asp:ListItem>
												<asp:ListItem Value="C">C</asp:ListItem>
												<asp:ListItem Value="G">G</asp:ListItem>
											</asp:radiobuttonlist></TD>
										<TD>SIC</TD>
										<TD>
											<asp:TextBox id="txtShiftInC" runat="server" CssClass="form-control" MaxLength="3" ToolTip="Enter only character" onKeyPress="return ValidateAlpha(event);"></asp:TextBox></TD>
										<TD>Operator</TD>
										<TD style="WIDTH: 100px">
											<asp:textbox id="txtOperator" runat="server" CssClass="form-control" AutoPostBack="True" ToolTip="Enter Operator" ></asp:textbox></TD>
									</TR>
									<TR>
										<TD>HeatNo<span class="glyphicon-asterisk" style="color:red"></span></TD>
										<TD>
											<asp:textbox id="txtHeat" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="6" ToolTip="Enter Heat Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></TD>
										<TD>WheelNo<span class="glyphicon-asterisk"></span></TD>
										<TD>
											<asp:textbox id="txtWheel" runat="server" CssClass="form-control" AutoPostBack="True" MaxLength="3" ToolTip="Enter Wheel Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox></TD>
										<TD>Sr. No</TD>
										<TD>
											<asp:textbox id="txtSrNo" runat="server" CssClass="form-control" ToolTip="Enter Ped Number(only numeric)" onkeypress="OnlyNumericEntry()"></asp:textbox>
                                            <%--<asp:Button ID="addsrno" runat="server" Text="reset SrNo" CssClass="button button1"/>--%>
										</TD>
                                        <asp:panel ID="PourPanel" runat="server" >
                                        <TD>
											<asp:textbox id="txtpour" runat="server" CssClass="form-control"></asp:textbox>
                                           
                                           </TD>
                                            </asp:panel>									

									</TR>
                                    
									<TR>
										
										<td>
                                              <asp:Label id="lblSl_No" runat="server"></asp:Label>
                                            <asp:Label id="lblsrbit" runat="server" Visible="false"></asp:Label>
										</td>
											
                                        
									   </TR>					
									
									<TR>
										<TD vAlign="top" align="middle" colSpan="8">
											<asp:Button id="btnSave" runat="server" Text="Save" CssClass="button button2"></asp:Button></TD>
									</TR>
								</TABLE>

                                 <asp:DataGrid ID="PreIDGrid" runat="server" CssClass="table" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                               <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                               <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                              <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                              </asp:DataGrid>

                                <asp:DataGrid id="DataGrid2" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<Columns>
                                <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
                                </Columns>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
							   </asp:DataGrid>

								<asp:DataGrid id="DataGrid1" runat="server" CssClass="table" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" OnItemDataBound="OnItemDataBound">
									<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
									<ItemStyle ForeColor="#330099" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
									<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
									<Columns>	
                                        <asp:TemplateColumn HeaderText = "S.No" ItemStyle-Width="100">
                                         <ItemTemplate>
                                           <asp:Label ID="lblRowNumber" runat="server" />
            
                                     </ItemTemplate>
                                     </asp:TemplateColumn>										
                                        <asp:ButtonColumn CommandName="Select" Text="Select"></asp:ButtonColumn>
                                        <asp:BoundColumn DataField="heat_number" HeaderText="Heat Number" ></asp:BoundColumn>
                                        <asp:BoundColumn DataField="wheel_number" HeaderText="Wheel Number" ></asp:BoundColumn>
                                        <asp:BoundColumn DataField="wheel_sr_no" HeaderText="SrNo" ReadOnly="True"></asp:BoundColumn>                                        
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
								</asp:DataGrid>
                            
							</asp:panel>
						
							

				
			</asp:panel></div></div></form></div>

         <div class="card-footer" style="text-align:right;"><h4>MAINTAINED BY CRIS</h4></div>
	</body>
</html>