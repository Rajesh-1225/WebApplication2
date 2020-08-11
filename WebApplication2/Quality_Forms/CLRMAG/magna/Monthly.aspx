<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Monthly.aspx.vb" Inherits="WebApplication2.Monthly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Daily Report</title>
 <link rel="stylesheet" type="text/css" href="css/jquery-ui.css"/>
        <link id="mss" href="/wap.css" rel="stylesheet"/>
        <link content="Microsoft Visual Studio.NET 7.0" name="GENERATOR"/>
        <META content="Visual Basic 7.0" name="CODE_LANGUAGE"/>
        <META content="JavaScript" name="vs_defaultClientScript"/>
        <META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
        <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css"/>
        <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
        <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css"/>
        <link href="jQuery.datetimepicker.min.css" rel="stylesheet"/>
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script type="text/javascript" src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>


        <%-- <link rel="stylesheet" href="../../../../StyleSheet1.css" />--%>
  <style type="text/css">
         .ui-datepicker {
    background: #333;
    border: 1px solid #555;
    color: #EEE; 
}
</style>
	</head>
	<body style="overflow-x:hidden">

      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent-333"
    aria-controls="navbarSupportedContent-333" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse " id="navbarSupportedContent-333">
      <ul class="navbar-nav ml-auto  navbar-center">
          <li class="nav-item" style="font-weight: bold">
             <h1 style="color:white; font-size:30px; margin-left:430px; margin-top:5px">Rail Wheel Plant, Bela</h1> 
         </li>
      </ul>
    <ul class="navbar-nav ml-auto  navbar-right">
        <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="Drop.aspx">
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
        <!--/.Navbar -->
         <script>
              function isNumber1(evt, element) {

                    var charCode = (evt.which) ? evt.which : event.keyCode

                      if (
                           (charCode != 45 ) && (charCode != 47 ) &&     // 
                           (charCode < 48 || charCode > 57))
                      return false;

                  return true;
            };


            $(document).ready(function () {
                       
                        $('#TextToDate').datepicker({
                            dateFormat: "dd-mm-yy", 
                       
                            onSelect: function(date){            
                                var date1 = $('#TextToDate').datepicker('getDate');           
                                                 
                              
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
        
         <div class="container">
             <form id="Form1" method="post" runat="server">
                 

             <asp:Panel id="Panel1" runat="server">
				
				<div class="table">
					<div class="row">
						<div class="col" align="center" ><h2><b> <center>Monthly Report</h2></b></center></div>
					</div>
                    </div>
					
                       <br/>
                 <div class="row">
                                      

                       
						
						
				
					
						<div class="col" align="center" style="margin-left:400px">
							
                            <asp:Label ID="Label1" runat="server" Text="Month"></asp:Label>
                          
                     <asp:DropDownList ID="DropDownList1" runat="server">
                         <asp:ListItem Value="1" >Jan</asp:ListItem>
                              <asp:ListItem Value="2">Feb</asp:ListItem>
                              <asp:ListItem Value="3">Mar</asp:ListItem>
                            <asp:ListItem Value="4">Apr</asp:ListItem>
                         <asp:ListItem Value="5">May</asp:ListItem>
                              <asp:ListItem Value="6">June</asp:ListItem>
                              <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">Aug</asp:ListItem>
                         <asp:ListItem Value="9">Sep</asp:ListItem>
                              <asp:ListItem Value="10">Oct</asp:ListItem>
                              <asp:ListItem Value="11">Nov</asp:ListItem>
                            <asp:ListItem Value="12">Dec</asp:ListItem>
                     </asp:DropDownList>
         
                 </div>

                     <div class="col" style="margin-right:300px">

                            <asp:Label ID="Label2" runat="server" Text="Year"></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem>2019</asp:ListItem>
                              <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                              <asp:ListItem>2022</asp:ListItem>

                            </asp:DropDownList>
                </div>
                     </div>
                <br/>
                            
                 <br/>
                 <br/>
                
                      <div class="row">
                       <div class="col"></div>
                         <div class="col">

                             <asp:Button id="btnRLCRL" runat="server" CssClass="btn btn-info btn-lg " width="250px" style="color:crimson"  Text="RLCRL" ValidationGroup="a"></asp:Button></div>
                            <div class="col">
                                <asp:Button id="btnHFMC" runat="server" CssClass="btn btn-info btn-lg " width="250px"  style="color:crimson" Text="HFMC" ValidationGroup="a"></asp:Button>
                             
						</div>
                        <div class="col"></div>
                        </div>
                     <br/>
                
                  <div class="row">
                      <div class="col"></div>

                          <div class="col" >
                          
                               <asp:Button id="btnHP" runat="server" CssClass="btn btn-info  btn-lg"  width="250px" style="color:crimson"  Text="HP" ValidationGroup="a"></asp:Button></div>
                              <div class="col" > <asp:Button id="btnHRMC" runat="server" CssClass="btn btn-info  btn-lg" width="250px" style="color:crimson"  Text="HRMC " ValidationGroup="a"></asp:Button>
                               
                                               
                              
                               </div>
                      <div class="col"></div>

                  </div>
                      </br/>


                 <div class="row">
                     <div class="col"></div>
                          <div class="col" >


                 <asp:Button id="btnVTL" runat="server" CssClass="btn btn-info  btn-lg " width="250px" style="color:crimson"  Text="VTL" ValidationGroup="a"></asp:Button></div>

                                                                                                                                                      
                    <div class="col" > <asp:Button id="btnHBMC" runat="server" CssClass="btn btn-info  btn-lg" width="250px" style="color:crimson"  Text="HBMC" ValidationGroup="a"></asp:Button>

                                    
                               </div>
                     <div class="col"></div>

                  </div>
                      </br>
                              <div class="row">
                                  <div class="col"></div>
                          <div class="col" >

                             <asp:Button id="btnGM" runat="server" CssClass="btn btn-info  btn-lg " width="250px"  style="color:crimson"  Text="Grand Mark " ValidationGroup="a"></asp:Button></div>

             
           <div class="col" >  <asp:Button id="btnHT" runat="server" CssClass="btn btn-info  btn-lg" width="250px" style="color:crimson"  Text="HT" ValidationGroup="a"></asp:Button>
                 
                                
                               </div>
                                  <div class="col"></div>

                  </div>
                      </br>
                      <div class="row">
                          <div class="col"></div>
                          <div class="col" >

                               <asp:Button id="btnMM" runat="server" CssClass="btn btn-info  btn-lg" width="250px" style="color:crimson"  Text="Machine Marked" ValidationGroup="a"></asp:Button> </div>
                             
                         <div class="col" > <asp:Button id="btnRHT" runat="server" CssClass="btn btn-info  btn-lg"  width="250px" style="color:crimson " Text="RHT" ValidationGroup="a"></asp:Button>
                            
                               </div>
                          <div class="col"></div>

                  </div>
                      </br>
                 

               </asp:Panel> 
                 </form>
		
             </div></div>
            <div class="card-footer" style="text-align:right;background-color:#cccccc;vertical-align:middle;position:relative;bottom:0;width:100%;height:60px"><h4 style="color: black;font-size:15px">MAINTAINED BY CRIS</h4></div>
    
</body>
</html>

