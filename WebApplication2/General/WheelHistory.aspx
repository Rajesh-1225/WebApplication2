<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WheelHistory.aspx.vb" Inherits="WebApplication2.WheelHistory1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD runat="server">
		<title>Heat Details Query</title>
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
 
	</HEAD>
	<body >
         <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../..//NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home " style="font-size:30px"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out" style="font-size:30px"> </i>
        </a></li>
   
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
         
        <img src="../../../NewFolder1/CRIS-Recruitment.jpg" height="45" style="border-radius:43%"/>
       </a>
      </li>
     </ul>
     
  </div>
</nav>
         <div class="container" >

		<form id="Form1" method="post" runat="server">
        <div class="table">
                <div class="row">
                    <div class="col"  align="center">
      <asp:Label id="Label2"   ><b><h2>Wheel History</b></h2></asp:Label>
                    </div>
                </div></br></br>
			<div class="row">
                <div class="col">
                    <asp:label id="lblMessage"  runat="server"  ForeColor="Red"></asp:label>
                </div>
			</div>
                <div class="row">
                    <div class="col"></div><div class="col"></div>
                    <div class="col">
                        <asp:Label id="Label1"  runat="server" ><b> Wheel Number</b></asp:Label>

                    </div>
                    <div class="col"><asp:TextBox id="txtFrmdt"  runat="server"   Width="150px"></asp:TextBox>
                    </div>
                         <div class="col">
                        <asp:Label id="Label3"  runat="server" ><b>Heat Number</b></asp:Label> </div>
                    <div class="col"><asp:TextBox id="txtTodt"  runat="server" Width="150px"></asp:TextBox>
                    </div>
                    <div class="col"></div> <div class="col"></div>
               </div> 

                </br></br>
                <div class="row">
                    <div class="col"></div><div class="col"></div>
                    <div class="col" align="center">
                   <asp:button id="cmdReport"  runat="server"  Text="Show" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button></div> 
                 <div class="col"> </asp:button><asp:button id="cmdClear"  runat="server"  Text=" Clear"  CausesValidation="False" Font-Size="20px"  BorderStyle="Solid" Font-Bold="True"  CssClass="btn btn-dark"></asp:button>
                   <%--<asp:button id="cmdExit"  runat="server" Text="Exit"  CausesValidation="False" CssClass="button button2"></asp:button>  </div>--%>
                   
                
			</div>
                    <div class="col"></div>
                    <div class="col"></div>
                    </div></br>
                <%-- <asp:Label id="Label4"  runat="server" ><b>A. WHEEL DETAILS</b></asp:Label>--%>
			<div class="table" >
				<div class="row">
                       <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid1" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center" ></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center" ></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="wheel_number" ReadOnly="True" HeaderText="Wheel Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="heat_number" ReadOnly="True" HeaderText="Heat Number"></asp:BoundColumn>
                                <asp:BoundColumn DataField="description" ReadOnly="True" HeaderText="Type"></asp:BoundColumn>
								
								
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        
                    </div>
			</div>
                
                </div>
                
                 <%--<asp:Label id="Label12"  runat="server" ><b>B. Melt Statistics</b></asp:Label>--%>
                    			<div class="table" >
				<div class="row">
					<div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid10" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								
								<asp:BoundColumn DataField="date_melt" ReadOnly="True" HeaderText="Melt Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift_incharge" ReadOnly="True" HeaderText="Shift Incharge"></asp:BoundColumn>
                                <asp:BoundColumn DataField="furnace_incharge" ReadOnly="True" HeaderText="Furnace Incharge"></asp:BoundColumn>
								<asp:BoundColumn DataField="car_car" ReadOnly="True" HeaderText="Carbon"></asp:BoundColumn>
								<asp:BoundColumn DataField="man_man" ReadOnly="True" HeaderText="Manganese"></asp:BoundColumn>
                                <asp:BoundColumn DataField="sil_sil" ReadOnly="True" HeaderText="Silicon"></asp:BoundColumn>
								<asp:BoundColumn DataField="pho_pho" ReadOnly="True" HeaderText="Phosphorous"></asp:BoundColumn>
								<asp:BoundColumn DataField="sul_sul" ReadOnly="True" HeaderText="Sulphur"></asp:BoundColumn>
								<asp:BoundColumn DataField="chr_chr" ReadOnly="True" HeaderText="Chromium"></asp:BoundColumn>
								<asp:BoundColumn DataField="cop_cop" ReadOnly="True" HeaderText="Copper"></asp:BoundColumn>
								<asp:BoundColumn DataField="ven_ven" ReadOnly="True" HeaderText="Vanadium"></asp:BoundColumn>
                                <asp:BoundColumn DataField="alu_alu" ReadOnly="True" HeaderText="Aluminium"></asp:BoundColumn>
								 <asp:BoundColumn DataField="Ni" ReadOnly="True" HeaderText="Nickel"></asp:BoundColumn>
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></div>
                    </div>
</div>
	 

                              <%--      <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid3" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>--%>
                 
                   <%-- <asp:Label id="Label5"  runat="server" ><b>C. Mould Statistics</b></asp:Label>--%>
                    			<div class="table" >
				<div class="row">
					<div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid2" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								
								<asp:BoundColumn DataField="date_melt" ReadOnly="True" HeaderText="Casting Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="pour_order" ReadOnly="True" HeaderText="Pour Order"></asp:BoundColumn>
								<asp:BoundColumn DataField="cope_number" ReadOnly="True" HeaderText="Cope No."></asp:BoundColumn>
								<asp:BoundColumn DataField="drag_number" ReadOnly="True" HeaderText="Drag No."></asp:BoundColumn>
                                <asp:BoundColumn DataField="CopeAsh" ReadOnly="True" HeaderText="Cope Ash Content (%)"></asp:BoundColumn>
								<asp:BoundColumn DataField="DragAsh" ReadOnly="True" HeaderText="Drag Ash Content (%)"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopePer" ReadOnly="True" HeaderText="Cope Permeability (%)"></asp:BoundColumn>
								<asp:BoundColumn DataField="DragPer" ReadOnly="True" HeaderText="Drag Permeability (%)"></asp:BoundColumn>
								
								
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></div>
                    </div>

                                  <%--  <div class="table" >
				<div class="row">
					<div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid9" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></div>
                    </div>
                                        </div>--%>
                    
                 <%-- <asp:Label id="Label7"  runat="server" ><b>D.Final Inspection</b></asp:Label>--%>
                                    <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid4" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" HorizontalAlign="right" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center" ></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="date" ReadOnly="True"  HeaderText="Date" ></asp:BoundColumn>
								<asp:BoundColumn DataField="shift" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
                                <asp:BoundColumn DataField="wheelStatus" ReadOnly="True" HeaderText="Wheel Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="bore_status" ReadOnly="True" HeaderText="Bore Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="threaddia" ReadOnly="True" HeaderText="Tread Dia."></asp:BoundColumn>
								<asp:BoundColumn DataField="platethickness" ReadOnly="True" HeaderText="Plate"></asp:BoundColumn>
								<asp:BoundColumn DataField="Rim_status" ReadOnly="True" HeaderText="Rim Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="Remark" ReadOnly="True" HeaderText="Remarks"></asp:BoundColumn>
                               
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>
                </div>
                   <%--  <asp:Label id="Label8"  runat="server" ><b> E. Wheel Machining Details</b></asp:Label>--%>
                                    <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid5" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="McnDate" ReadOnly="True" HeaderText="Machining Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="ShiftCode" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
                                <asp:BoundColumn DataField="McnCodeSet" ReadOnly="True" HeaderText="M/C Code"></asp:BoundColumn>
								<asp:BoundColumn DataField="Status" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
								<asp:BoundColumn DataField="McnAgency" ReadOnly="True" HeaderText="Machining Agency"></asp:BoundColumn>
								<asp:BoundColumn DataField="GatePass" ReadOnly="True" HeaderText="Gate Pass"></asp:BoundColumn>
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>

                 <%--<asp:Label id="Label9"  runat="server" ><b> F. Magnaglow Summary</b></asp:Label>--%>
                                    <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid6" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="date" ReadOnly="True" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="utstatus" ReadOnly="True" HeaderText="UT Status"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Machining" ReadOnly="True" HeaderText="Machining"></asp:BoundColumn>
								<asp:BoundColumn DataField="linenumber" ReadOnly="True" HeaderText="Line Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
								<asp:BoundColumn DataField="typeofdefect" ReadOnly="True" HeaderText="XC Status"></asp:BoundColumn>
								
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>

                 <%--<asp:Label id="Label10"  runat="server" ><b> G. QCI Inspection</b></asp:Label>--%>
                                    <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid7" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="inspection_date" ReadOnly="True" HeaderText="Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="shift_code" ReadOnly="True" HeaderText="Shift"></asp:BoundColumn>
                                <asp:BoundColumn DataField="wheel_disposition" ReadOnly="True" HeaderText="Wheel Status"></asp:BoundColumn>
                                	
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>
                <%-- <asp:Label id="Label11"  runat="server" ><b> H. Despatch of Wheel</b></asp:Label>--%>
                                    <div class="table" >
				<div class="row">
                    <div class="col" vAlign="top" align="left" width="611" style="WIDTH: 611px">
						<asp:DataGrid id="DataGrid8" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" AutoGenerateColumns="False" CssClass="table">
					<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
					<ItemStyle ForeColor="#330099" BackColor="White" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="black" BackColor="white" HorizontalAlign="center"></HeaderStyle>
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="dc_date" ReadOnly="True" HeaderText=" Despatch Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="waglorry_number" ReadOnly="True" HeaderText="Lorry Number"></asp:BoundColumn>
                                <asp:BoundColumn DataField="name" ReadOnly="True" HeaderText="Consignee"></asp:BoundColumn>
                                	
                                </Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>

                    </div>
			</div>
		</div>
                </div>
                    
                       </div>
                    <style type="text/css">
             @media print {
           #printbtn {
        display :  none;
                  }
             }
</style>

             
                   
                </form>
        </div>
        <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
	</body>
</HTML>
