<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WheelCostingReport.aspx.vb" Inherits="WebApplication2.WheelCostingReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css"/>
  <script  src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
   
        <script src="js/chart-all.js"></script>
    <script src="js/chartjs-plugin-datalabels.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    

  

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
 
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

      <script src=" https://code.jquery.com/jquery-3.5.1.js"></script>
 <script src=" https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
 <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">

    <script src="js/html2pdf.bundle.min.js"></script>

    <title>Wheel Costing Report</title>
    <style>


    .error-msg{
                   background-color: #FF0000;
                }

      #tdWorkDayNew1 {background-color:rgb(255, 253, 163);}
        #tdWorkDayNew2 {background-color:rgb(198, 252, 255);}

        
body { padding-right: 0 !important; }

.modal-open{overflow:auto;padding-right:0 !important;}

.custom {
    width: 130px !important;
}

        .dataTables_filter {
        display: none;
        }

         .example th
        
        {
            font-size: 14px;
            /*text-align: center;*/
        }
 
        .example td
        
        {
            /*text-align : center;*/
            font-weight: bold;
            font-size: 14px;
        }

    .lb-sm {
  font-size: 14px;
}

.lb-md {
  font-size: 16px;
}

.lb-lg {
  font-size: 20px;
}

	 </style> 

    <%--<script>

        $("#btnSubmit").click(function () {
            

           

            var from_month_value = document.getElementById('FROM_MONTH').value;
            var to_month_value = document.getElementById('TO_MONTH').value;

            if (from_month_value > to_month_value) {
                $("#errorMessage").html("From Date should be less than End Date")
                    .addClass("error-msg");
                return false;
            }

           
        });


    </script>--%>

</head>
<body>
      <nav class="mb-1 navbar navbar-expand-sm bg-dark navbar-dark " >
  <a class="navbar-brand p-0" href="#"><img src="../../NewFolder1/unnamed.png" class="rounded-circle z-depth-0"  height="45"/> </a>
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
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../wapframeset.aspx">
          <i class="fab glyphicon glyphicon-home "style="font-size:30px;"></i>
        </a></li>

       <li class="nav-item">
        <a class="nav-link waves-effect waves-light" style="{color:white; }:hover{color:grey;}" href="../../logon.aspx">
          <i class="fab glyphicon glyphicon-log-out"style="font-size:30px;"></i>
        </a></li>
    
        <li class="nav-item ">
        <a class="nav-link p-0" href="#">
          <img src="../../NewFolder1/CRIS-Recruitment.jpg" class="rounded-circle z-depth-0"  height="45"/>
        </a>
      </li>
     </ul>
      
  </div>
</nav>
    <main role="main">
    <section class="text-center">
        <br />
    <div class="container-fluid">

        <div id="errorMessage"></div>
        
       
        <%-- ROW 1 --%>
            <div class="row">
                 <div class="col-sm-9">

                <form id="form1" runat="server">

                     <asp:Label ID="Label2" runat="server" Text="From Year :" CssClass="font-weight-bold lb-sm m-1"></asp:Label>
                        <asp:DropDownList ID="START_FIN_YR" runat="server" CssClass="font-weight-bold btn btn-primary m-1"></asp:DropDownList>
                    
                     <asp:Label ID="Label3" runat="server" Text="From Month :" CssClass="font-weight-bold lb-sm m-1"></asp:Label>
                        <asp:DropDownList ID="FROM_MONTH" runat="server" CssClass="font-weight-bold btn btn-primary m-1">

                            <asp:ListItem Selected="True" Value="1">JAN</asp:ListItem>
                            <asp:ListItem Value="2">FEB</asp:ListItem>
                            <asp:ListItem Value="3">MAR</asp:ListItem>
                            <asp:ListItem Value="4">APR</asp:ListItem>
                            <asp:ListItem Value="5">MAY</asp:ListItem>
                            <asp:ListItem Value="6">JUN</asp:ListItem>
                            <asp:ListItem Value="7">JUL</asp:ListItem>
                            <asp:ListItem Value="8">AUG</asp:ListItem>
                            <asp:ListItem Value="9">SEP</asp:ListItem>
                            <asp:ListItem Value="10">OCT</asp:ListItem>
                            <asp:ListItem Value="11">NOV</asp:ListItem>
                            <asp:ListItem Value="12">DEC</asp:ListItem>

                        </asp:DropDownList>


                    <asp:Label ID="Label1" runat="server" Text="To Year :" CssClass="font-weight-bold lb-sm m-1"></asp:Label>
                        <asp:DropDownList ID="FIN_YR" runat="server" CssClass="font-weight-bold btn btn-primary m-1"></asp:DropDownList>
                   
                    <asp:Label ID="Label4" runat="server" Text="To Month :" CssClass="font-weight-bold lb-sm m-1"></asp:Label>
                         <asp:DropDownList ID="TO_MONTH" runat="server" CssClass="font-weight-bold btn btn-primary m-1">
                             <%--Selected="True"--%>
                            <asp:ListItem Value="1">JAN</asp:ListItem>
                            <asp:ListItem Value="2">FEB</asp:ListItem>
                            <asp:ListItem Value="3">MAR</asp:ListItem>
                            <asp:ListItem Value="4">APR</asp:ListItem>
                            <asp:ListItem Value="5">MAY</asp:ListItem>
                            <asp:ListItem  Value="6">JUN</asp:ListItem>
                            <asp:ListItem Value="7">JUL</asp:ListItem>
                            <asp:ListItem Value="8">AUG</asp:ListItem>
                            <asp:ListItem Value="9">SEP</asp:ListItem>
                            <asp:ListItem Value="10">OCT</asp:ListItem>
                            <asp:ListItem Value="11">NOV</asp:ListItem>
                            <asp:ListItem Selected="True" Value="12">DEC</asp:ListItem>

                        </asp:DropDownList>

                   <asp:Button ID="btnSubmit" runat="server" Text="VIEW CHART" CssClass="font-weight-bold btn btn-primary m-1" OnClientClick="javascript:return validateDrop();"/>

             </form>
                        <hr />
                </div>

                 <div class="col-sm-3">

                                     
                          <div align="right">
                        
                         

                            
                                <button type="button" class="font-weight-bold btn btn-primary custom2 mb-1 sameline" data-toggle="modal" data-target="#myChartModal">VIEW DATA</button>
                
                                <a class="btn btn-primary font-weight-bold custom2 mb-1 sameline" style="color:white" id="downloadPdf" onclick="printDiv()">EXPORT PDF</a>


                     </div>
                 


                      

             </div>


            </div>

            <%-- ROW 2 --%>
        <div class="container-fluid" id="printThis">
            <div class="row">
                
                <div class="col-sm-6" align="center">

                    
                        
                            <canvas id="wheelCostChart" width="320" height="450"> </canvas>

                     


                </div>


                <div class="col-sm-6" align="center">

                    
                        
                            <canvas id="wheelCostChart2" width="320" height="450"> </canvas>

                     


                </div>





            </div>


              <div id="printSection" style =" display: none; " align="center">
           <div class="table-responsive">
			<table id="example2" class="display example" width="50%">
			</table>
		    </div>
            </div>

            
     </div>

       </div>

       
                  <!-- Modal myDPModal -->
            
  <div class="modal fade" id="myChartModal" role="dialog">
    <div class="modal-dialog modal-lg">
    
      <!-- Modal content-->
      <div class="modal-content">
          
         <%-- <button type="button" class="close" data-dismiss="modal" style="position: absolute; right: 0;">&times;</button>--%>
              
      <div class="modal-header">
        <h4 class="modal-title" align="center"><b><i>Wheel Casting And Costing Data</i></b></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        <div class="modal-body">
          <!-- <p>Some text in the modal.</p> -->
          <!-- <h5><b><i>Daily Production Table</i></b></h5> -->
		   <%-- <div id="printThis">--%>
            <div class="table-responsive" id="printAll2">
			<table id="example" class="display example" width="100%">
			</table>
		    </div>
               <%-- </div>--%>
		
		
        </div>
       <!--  <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div> -->
      </div>
      
    </div>
  </div>
           
              
        
        
        


    
        </section>
        </main>


      


          <script type="text/javascript" language="javascript">


              function validateDrop() {

                  var from = document.getElementById('<%=FROM_MONTH.ClientID%>').value;
                  var to = document.getElementById('<%=TO_MONTH.ClientID%>').value

                  var fromyr = document.getElementById('<%=START_FIN_YR.ClientID%>').value;
                  var toyr = document.getElementById('<%=FIN_YR.ClientID%>').value

                  var fromInt = parseInt(from);
                  var toInt = parseInt(to);

                  var fromIntyr = parseInt(fromyr);
                  var toIntyr = parseInt(toyr);


                  if (fromInt > toInt) {
                      alert(" From Month Value Cant Be Greater Than To Month Value");
                      document.getElementById('<%=FROM_MONTH.ClientID%>').focus();
                      return false;
                  } 

                  if (fromIntyr > toIntyr) {
                      alert(" From Year Value Cant Be Greater Than To Year Value");
                      document.getElementById('<%=FROM_MONTH.ClientID%>').focus();
                      return false;
                  } 

             }



            </script>


    


        <script>
            function printDiv() {


                var hiddenDiv = document.getElementById("printSection");

                if (hiddenDiv.style.display === "none" || hiddenDiv.style.display === '') {
                    hiddenDiv.style.display = "block";
                } else {
                    hiddenDiv.style.display = "none";
                }
                //debugger

                var element = document.getElementById('printThis');

                
        	var opt = {
                margin:       1,
        	  filename:     'wheelcostingreport.pdf',
        	  image:        {type: 'jpeg', quality: 1 },
        	  html2canvas:  {scale: 4 },
        	  jsPDF:        {unit: 'px', format: [1200,1300], orientation: 'landscape' }
        	};

        	
                html2pdf(element, opt);

                //setTimeout(() => {

                //    html2pdf(element, opt);
                //}, 300)


                setTimeout(() => {


                    hiddenDiv = document.getElementById("printSection");

                    if (hiddenDiv.style.display === "block") {
                        hiddenDiv.style.display = "none";
                    } else {
                        hiddenDiv.style.display = "block";
                    }
                },700)       

                //setTimeout(() => {
                //}, 300) 
               
        } 
    </script>

    

  

  <script type="text/javascript">
        
    
      var myWheelCostChart;


      var myWheelCostChart2;


        var year_value = new Array();
        var month = new Array();
        var total_wheel_cast = new Array();
        var total_good_wheel = new Array();
        var total_wheel_xc = new Array();
        var total_debit = new Array();
        var wheel_cost = new Array();


      

      

        $(document).ready(function () {

            ctx10 = document.getElementById('wheelCostChart').getContext('2d');
            ctx10.save();


            ctx11 = document.getElementById('wheelCostChart2').getContext('2d');
            ctx11.save();

         



           <% For i = 0 To year_value.Count - 1%> 


            year_value.push('<%=year_value.Item(i)%>');
            month.push('<%=month.Item(i)%>');
            total_wheel_cast.push('<%=total_wheel_cast.Item(i)%>');
            total_good_wheel.push('<%=total_good_wheel.Item(i)%>');
            total_wheel_xc.push('<%=total_wheel_xc.Item(i)%>');
            total_debit.push('<%=total_debit.Item(i)%>');
            wheel_cost.push('<%=wheel_cost.Item(i)%>');




           <%Next%> 

            var startfnYearValue = document.getElementById('START_FIN_YR').value;
            var fnYearValue = document.getElementById('FIN_YR').value;
            var frommonthValue = document.getElementById('FROM_MONTH').value;
            var tomonthValue = document.getElementById('TO_MONTH').value;


            createWheelCostChart(startfnYearValue,fnYearValue, frommonthValue, tomonthValue);

            createWheelCostChart2(startfnYearValue,fnYearValue, frommonthValue, tomonthValue);

            

        });

   

      function createWheelCostChart(startfnYearVal,fnYearVal, frommonthVal, tomonthVal) {

          if (myWheelCostChart) myWheelCostChart.destroy();
            ctx10.restore;

            var year_value = new Array();
            var month = new Array();
            var total_wheel_cast = new Array();
            var total_good_wheel = new Array();
            var total_wheel_xc = new Array();
            var total_debit = new Array();
            var wheel_cost = new Array();


          var initial_month;
          var final_month;


            var table = new Array();

           <% For i = 0 To year_value.Count - 1%> 

            var row = new Array();

            year_value.push('<%=year_value.Item(i)%>');

            row.push('<%=year_value.Item(i)%>');

            month.push('<%=month.Item(i)%>');

            row.push('<%=month.Item(i)%>');

            total_wheel_cast.push('<%=total_wheel_cast.Item(i)%>');

            row.push('<%=total_wheel_cast.Item(i)%>');

            total_good_wheel.push('<%=total_good_wheel.Item(i)%>');

            row.push('<%=total_good_wheel.Item(i)%>');

            total_wheel_xc.push('<%=total_wheel_xc.Item(i)%>');

            row.push('<%=total_wheel_xc.Item(i)%>');

            total_debit.push('<%=total_debit.Item(i)%>');

            row.push('<%=total_debit.Item(i)%>');

            wheel_cost.push('<%=wheel_cost.Item(i)%>');

            row.push('<%=wheel_cost.Item(i)%>');

            table.push(row);

            <%Next%> 


          var initial_month = month[0];
          var final_month = month[month.length - 1];

          

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": true,
                    "pagingType": "full_numbers",
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    "lengthMenu": [[3, 5, 10, -1], [3, 5, 10, "All"]],
                    data: dataSet,

                    columns: [
                        { title: "Year" },
                        { title: "Month Year" },
                        { title: "Total Wheel Cast" },
                        { title: "Total Good Wheel" },
                        { title: "Total Wheel Rejection" },
                        { title: "Total Debit ( INR )" },
                        { title: "Wheel Cost ( INR )" }
                    ],
                    columnDefs: [
                        { targets: [0,1], className: 'dt-left' },
                        { targets: [2,3,4,5,6], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Year" },
                        { title: "Month Year" },
                        { title: "Total Wheel Cast" },
                        { title: "Total Good Wheel" },
                        { title: "Total Wheel Rejection" },
                        { title: "Total Debit ( INR )" },
                        { title: "Wheel Cost ( INR )" }
                    ],
                    columnDefs: [
                        { targets: [0, 1], className: 'dt-left' },
                        { targets: [2, 3, 4, 5, 6], className: 'dt-right' }
                    ]
                });
            });




          myWheelCostChart = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: month,
                    datasets: [

                        {
                            label: "Total Wheel Cast",
                            backgroundColor: 'rgba(0,128,0,1)',
                            borderColor: 'rgba(0,128,0,1)',
                            data: total_wheel_cast,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Total Good Wheel", 
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: total_good_wheel,
                            lineTension: 0,
                            showLine: true,
                            fill: false


                        },
                        {
                            label: "Total Wheel Rejection",
                            backgroundColor: 'rgba(255,0,0,1)',
                            borderColor: 'rgba(255,0,0,1)',
                            data: total_wheel_xc,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    layout: {
                        padding: {
                            left: 10,
                            right: 0,
                            top: 0,
                            bottom: 0
                        }
                    },
                    title: {
                        display: true,
                        text: 'Wheel Casting - ' + 'From : ' + initial_month +   ' To ' + final_month,
                        fontSize: 18,
                        padding: 15
                    },
                    legend: {
                        display: true,
                        position: 'bottom',
                        labels: {
                            fontStyle: 'bold',
                            fontSize: 14
                        }
                    },
                    plugins: {
                        datalabels: {
                            anchor: 'start',
                            align: 'top',
                            display: 'auto',
                            formatter: function (value, context) {
                                return Math.round(value) + '';
                            },
                            font: {
                                weight: 'bold',
                                size: 14
                            }
                            //,
                            //color: 'rgba(0,0,0,0.5)' #8497B0
                        }
                    },
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                fontStyle: 'bold',
                                fontSize: 12,
                                min: 0,
                                //max: 100,
                                maxTicksLimit: 3,
                                callback: function (value) { return value + "" }
                            },
                            
                            //gridLines: {
                            //    display: false
                            //},
                            scaleLabel: {
                                display: true,
                                labelString: "No. of Wheels",
                                fontStyle: 'bold'
                            }
                        }],
                        xAxes: [{
                            ticks: {
                                fontStyle: 'bold',
                                fontSize: 14
                            },
                            gridLines: {
                                display: false
                            }
                        }]
                    },
                    tooltips: {
                        enabled: true,
                        mode: 'single'
                        ,
                        callbacks: {
                            label: function (tooltipItem, data) {
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '';
                            }
                        }
                    }
                }     
            });
         }



      function createWheelCostChart2(startfnYearVal,fnYearVal, frommonthVal, tomonthVal) {

          if (myWheelCostChart2) myWheelCostChart2.destroy();
          ctx11.restore;

          var year_value = new Array();
          var month = new Array();
          var total_wheel_cast = new Array();
          var total_good_wheel = new Array();
          var total_wheel_xc = new Array();
          var total_debit = new Array();
          var wheel_cost = new Array();


          var table = new Array();

           <% For i = 0 To year_value.Count - 1%> 

            var row = new Array();

            <%--row.push('<%=month_year.Item(i)%>');--%>

            year_value.push('<%=year_value.Item(i)%>');

            row.push('<%=year_value.Item(i)%>');

            month.push('<%=month.Item(i)%>');

            row.push('<%=month.Item(i)%>');

            total_wheel_cast.push('<%=total_wheel_cast.Item(i)%>');

            row.push('<%=total_wheel_cast.Item(i)%>');

            total_good_wheel.push('<%=total_good_wheel.Item(i)%>');

            row.push('<%=total_good_wheel.Item(i)%>');

            total_wheel_xc.push('<%=total_wheel_xc.Item(i)%>');

            row.push('<%=total_wheel_xc.Item(i)%>');

            total_debit.push('<%=total_debit.Item(i)%>');

            row.push('<%=total_debit.Item(i)%>');

            wheel_cost.push('<%=wheel_cost.Item(i)%>');

            row.push('<%=wheel_cost.Item(i)%>');

            table.push(row);

            <%Next%> 

          var initial_month = month[0];
          var final_month = month[month.length - 1];

          //var dataSet = table;

          //$(document).ready(function () {
          //    $('#example').DataTable({

          //        "paging": false,
          //        "ordering": false,
          //        "info": false,
          //        "searchable": false,
          //        data: dataSet,

          //        columns: [
          //            { title: "Month Year" },
          //            { title: "Stock (%)" },
          //            { title: "Machine (%)" },
          //            { title: "Rejection (%)" }
          //        ],
          //        columnDefs: [
          //            { targets: [0], className: 'dt-left' },
          //            { targets: [1,2,3], className: 'dt-right' }
          //        ]
          //    });

          //    $('#example2').DataTable({

          //        "paging": false,
          //        "ordering": false,
          //        "info": false,
          //        "searchable": false,
          //        data: dataSet,

          //        columns: [
          //            { title: "Month Year" },
          //            { title: "Stock (%)" },
          //            { title: "Machine (%)" },
          //            { title: "Rejection (%)" }
          //        ],
          //        columnDefs: [
          //            { targets: [0], className: 'dt-left' },
          //            { targets: [1, 2, 3], className: 'dt-right' }
          //        ]
          //    });
          //});




          myWheelCostChart2 = new Chart(ctx11, {
              type: 'line',
              data: {
                  labels: month,
                  datasets: [

                      {
                          label: "Cost",
                          //backgroundColor: 'rgba(0,128,0,1)', 
                          //borderColor: 'rgba(0,128,0,1)',

                          backgroundColor: 'rgba(64, 255, 0,1)', //rgb(64, 255, 0)
                          borderColor: 'rgba(64, 255, 0,1)',

                          data: wheel_cost,
                          lineTension: 0,
                          showLine: true,
                          fill: false

                      }
                      //,
                      //{
                      //    label: "Total Good Wheel",
                      //    backgroundColor: 'rgba(0, 0, 255,1)',
                      //    borderColor: 'rgba(0, 0, 255,1)',
                      //    data: total_good_wheel,
                      //    lineTension: 0,
                      //    showLine: true,
                      //    fill: false


                      //},
                      //{
                      //    label: "Total Wheel XC",
                      //    backgroundColor: 'rgba(255,0,0,1)',
                      //    borderColor: 'rgba(255,0,0,1)',
                      //    data: total_wheel_xc,
                      //    lineTension: 0,
                      //    showLine: true,
                      //    fill: false

                      //}
                  ],



              },
              options: {
                  responsive: true,
                  maintainAspectRatio: false,
                  layout: {
                      padding: {
                          left: 0,
                          right: 10,
                          top: 0,
                          bottom: 0
                      }
                  },
                  title: {
                      display: true,
                      text: 'Per Month Per Wheel Cost (INR) - ' + 'From : ' + initial_month + ' To ' + final_month,
                      fontSize: 18,
                      padding: 15
                  },
                  legend: {
                      display: true,
                      position: 'bottom',
                      labels: {
                          fontStyle: 'bold',
                          fontSize: 14
                      }
                  },
                  plugins: {
                      datalabels: {
                          anchor: 'start',
                          align: 'top',
                          display: 'auto',
                          formatter: function (value, context) {
                              return Math.round(value) + '';
                          },
                          font: {
                              weight: 'bold',
                              size: 14
                          }
                          //,
                          //color: 'rgba(0,0,0,0.5)' #8497B0
                      }
                  },
                  scales: {
                      yAxes: [{
                          ticks: {
                              beginAtZero: true,
                              fontStyle: 'bold',
                              fontSize: 12,
                              min: 0,
                              //max: 100,
                              maxTicksLimit: 3,
                              callback: function (value) { return value + "" }
                          },

                          //gridLines: {
                          //    display: false
                          //},
                          scaleLabel: {
                              display: true,
                              labelString: "Cost (INR)",
                              fontStyle: 'bold'
                          }
                      }],
                      xAxes: [{
                          ticks: {
                              fontStyle: 'bold',
                              fontSize: 14
                          },
                          gridLines: {
                              display: false
                          }
                      }]
                  },
                  tooltips: {
                      enabled: true,
                      mode: 'single'
                      ,
                      callbacks: {
                          label: function (tooltipItem, data) {
                              return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '';
                          }
                      }
                  }
              }
          });
      }

      


  
        </script>
</body>
</html>


