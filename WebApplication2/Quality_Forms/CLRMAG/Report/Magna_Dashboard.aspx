<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Magna_Dashboard.aspx.vb" Inherits="WebApplication2.Magna_Dashboard" %>

<!DOCTYPE html>

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
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

      <script src=" https://code.jquery.com/jquery-3.5.1.js"></script>
 <script src=" https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
 <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">

    <script src="js/html2pdf.bundle.min.js"></script>

    <title>Magna Dashboard</title>
    <style>
      #tdWorkDayNew1 {background-color:rgb(255, 253, 163);}
        #tdWorkDayNew2 {background-color:rgb(198, 252, 255);}

        
body { padding-right: 0 !important; }

.modal-open{overflow:auto;padding-right:0 !important;}

.custom {
    width: 130px !important;
}



.custom2 {
    width: 110px !important;
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

     
        h4 {
        
          font-weight: bold;
          font-style: italic;
        }


.sameline {
display: inline-block;

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
    <div class="container" >
        <br />
                 <%-- ROW 1 --%>


           <div class="row" >
             
            
                   <div class="col-sm-9">

                                     
                          <div align="center">
                        
                          <form id="form1" runat="server">
                       

                            
                                 <asp:DropDownList ID="Fin_Year" runat="server" CssClass="font-weight-bold btn btn-primary custom mb-1 sameline">
                                 </asp:DropDownList>
                          

                                 <asp:DropDownList ID="Prod" runat="server" CssClass="font-weight-bold btn btn-primary custom mb-1 sameline">
                                 </asp:DropDownList>
                           
                                 <asp:DropDownList ID="Report_Type" runat="server" CssClass="font-weight-bold btn btn-primary mb-1 sameline" Width="300px"> <%--Width="285px"--%>
                                 </asp:DropDownList>

                           



                       
                                <asp:Button ID="btnSubmit" runat="server" Text="VIEW" CssClass="font-weight-bold btn btn-primary custom mb-1 sameline" />
                          
                        </form>
                      

                            

                     </div>
                 



             </div>

                <div class="col-sm-3">

                                     
                          <div align="right">
                        
                         

                            
                                <button type="button" class="font-weight-bold btn btn-primary custom2 mb-1 sameline" data-toggle="modal" data-target="#myChartModal">VIEW DATA</button>
                
                                <a class="btn btn-primary font-weight-bold custom2 mb-1 sameline" style="color:white" id="downloadPdf" onclick="printDiv()">EXPORT PDF</a>


                     </div>
                 


                      

             </div>

               <hr />

            
       </div>


           

           <%-- ROW 2 --%>

        <div class="row" >

          






             <div class="col-sm-12" id="printThis" align="center">

               <%--  <div align="right">

                        <!-- onClick="printDiv()" -->

                        <h6 style="font-weight: bold;"><a href="#" id="downloadPdf" onclick="printDiv()" >Export PDF</a></h6>  
                
                </div>--%>
                 
                 <div class="chart-wrapper" align="center">
                <canvas id="chart10" height="130" > </canvas>

                     </div>
                     

             <%--    <div align="center">
                <button type="button" class="font-weight-bold btn btn-primary mb-2" data-toggle="modal" data-target="#myChartModal">View Data</button>
                </div>--%>


                  <!-- Modal myDPModal -->
            
  <div class="modal fade" id="myChartModal" role="dialog">
    <div class="modal-dialog modal-lg">
    
      <!-- Modal content-->
      <div class="modal-content">
          
         <%-- <button type="button" class="close" data-dismiss="modal" style="position: absolute; right: 0;">&times;</button>--%>
              
     <div class="modal-header">
          
         <h4 onload="setname()" id="ModalHeader" class="modal-title" align="center"><b><i></i></b></h4>
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
                 <br />
        <br />
        <br />
                 <br />
        <br />
                 <br />
        <br />

                  <div id="printSection" style =" display: none; " align="center">
           <div class="table-responsive">
			<table id="example2" class="display example" width="50%">
			</table>
		    </div>
            </div>



             </div>




        </div>
        
        
        


    </div>
        </section>
        </main>

<%--    <script>
        //document.getElementById("downloadPdf").onclick = function () {

        function printDiv() {
            printElement(document.getElementById("printThis1"), document.getElementById("printThis2"));
        }

        function printElement(elem1,elem2) {
            var domClone1 = elem1.cloneNode(true);

            var domClone2 = elem2.cloneNode(true);

            var $printSection = document.getElementById("printSection");

            if (!$printSection) {
                var $printSection = document.createElement("div");
                $printSection.id = "printSection";
                document.body.appendChild($printSection);
            }

            $printSection.innerHTML = "";
            $printSection.appendChild(domClone1);
            $printSection.appendChild(domClone2);
            window.print();
        }


    </script>--%>


    


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
        	  filename:     'magnadashboard.pdf',
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

    

   <%-- <script>

        function printDiv() {

            var element1 = document.getElementById("printThis1");

            var element2 = document.getElementById("printThis2");

            

            var domClone1 = element1.cloneNode(true);

            var domClone2 = element2.cloneNode(true);

            var printSection = document.getElementById("printSectionNew");

            if (!printSection) {
                var printSection = document.createElement("div");
                printSection.id = "printSection";
                document.body.appendChild($printSection);
            }

            printSection.innerHTML = "";
            printSection.appendChild(domClone1);
            printSection.appendChild(domClone2);

            printSection.style.display = 'block';

          

           
            var opt = {
                margin: 1,
                filename: 'magnadashboard.pdf',
                image: { type: 'jpeg', quality: 1 },
                html2canvas: { scale: 4 },
                jsPDF: { unit: 'px', format: [1400, 1100], orientation: 'landscape' }
            };


            html2pdf(printSection, opt);

            printSection.style.display = 'none';



        } 

    </script>
   --%>     

     <%-- <script type="text/javascript">
          var yearsLength = 30;
          var currentYear = new Date().getFullYear();
          for (var i = 0; i < 30; i++) {
              var next = currentYear + 1;
              var year = currentYear + '-' + next.toString().slice(-2);
              $('#financialYear').append(new Option(year, year));
              currentYear--;
          }
    </script>--%>

    <script type="text/javascript">
        var myChart10;

        var mon_yr = new Array();
        var stock_mon_per = new Array();
        var mac_mon_per = new Array();
        var reject_mon_per = new Array();

        var pie_quality_analysis = new Array();

        var rejection_analysis_defect_desc = new Array();
        var rejection_analysis_defect_per = new Array();

        var label_value = new Array();
        var percent_value = new Array();

        var badchem_month = new Array();
        var badchem_percent = new Array();

        
        var pr_mw_rejection_label = new Array();
        var pr_mw_rejection_badchem = new Array();
        var pr_mw_rejection_mrxc = new Array();
        var pr_mw_rejection_defect = new Array();
        var pr_mw_rejection_machining = new Array();
        var pr_mw_rejection_total = new Array();

      

        $(document).ready(function () {

            ctx10 = document.getElementById('chart10').getContext('2d');
            ctx10.save();

           <%-- mon_yr = new Array();
            stock_mon_per = new Array();
            mac_mon_per = new Array();
            reject_mon_per = new Array();



           <% For i = 0 To month_year.Count - 1%> 
            mon_yr.push('<%=month_year.Item(i)%>');
            stock_mon_per.push('<%=stock_month_per.Item(i)%>');
            mac_mon_per.push('<%=machine_month_per.Item(i)%>');
            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');
                      <%Next%> --%>


            function setname() {

                var fnYearValue = document.getElementById('Fin_Year').value;
                var prodValue = document.getElementById('Prod').value;
                var reportValue = document.getElementById('Report_Type').value;

                var all_string = reportValue + " " + prodValue + " " + fnYearValue;

               // document.getElementById("ModalHeader").value = all_string;

                


                document.getElementById("ModalHeader").innerText = all_string;
            }

            setname();

            var fnYearValue = document.getElementById('Fin_Year').value;
            var prodValue = document.getElementById('Prod').value;
            var reportValue = document.getElementById('Report_Type').value;

            

            if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("MONTHWISE ANALYSIS REJECTION") == 0) {

                createChartRejection(fnYearValue, prodValue);

            } else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("MONTHWISE ANALYSIS REJECTION") == 0) {

                createChartRejection(fnYearValue, prodValue);

            } else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("MONTHWISE ANALYSIS REJECTION") == 0) {

                createChartRejection(fnYearValue, prodValue);

            } else if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("QUALITY ANALYSIS") == 0) {

              //  var newPStr = prodValue;
               // var newProdValue = newPStr.substring(9, 17);
                createChartPie(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("REJECTION ANALYSIS") == 0) { 

               // var newPStr = "COMBINED";
                createChartPieRejection(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("QUALITY ANALYSIS") == 0) {

                //var newPStr = "BGC";
                createChartPie(fnYearValue, prodValue);
                

            }
            else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("QUALITY ANALYSIS") == 0) {

                //var newPStr = "BOXN";
                createChartPie(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("REJECTION ANALYSIS") == 0) {

               // var newPStr = "BGC";
                createChartPieRejection(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("REJECTION ANALYSIS") == 0) {

                //var newPStr = "BOXN";
                createChartPieRejection(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("PERCENTAGE FRESH WHEEL") == 0) {

                //var newPStr = "COMBINED";
                createPercentFreshWheel(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("PERCENTAGE FRESH WHEEL") == 0) {

                //var newPStr = "BGC";
                createPercentFreshWheel(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("PERCENTAGE FRESH WHEEL") == 0) {

                //var newPStr = "BOXN";
                createPercentFreshWheel(fnYearValue, prodValue);

            }
            else if (reportValue.localeCompare("BAD CHEMISTRY") == 0) {

                
                createBadChemistry(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("PERCENTAGE MONTHWISE REJECTION") == 0) {

                //var newPStr = "COMBINED";
                createPerMWRejectionCombined(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("PERCENTAGE MONTHWISE REJECTION") == 0) {

                //var newPStr = "BGC";
                createPerMWRejectionCombined(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("PERCENTAGE MONTHWISE REJECTION") == 0) {

                //var newPStr = "BOXN";
                createPerMWRejectionCombined(fnYearValue, prodValue);

            }
            else if (prodValue.localeCompare("COMBINED") == 0 && reportValue.localeCompare("PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") == 0) {

                //var newPStr = "COMBINED";
                createPerMWCumulativeRejectionCombined(fnYearValue, prodValue);

            } else if (prodValue.localeCompare("BGC") == 0 && reportValue.localeCompare("PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") == 0) {

                //var newPStr = "BGC";
                createPerMWCumulativeRejectionCombined(fnYearValue, prodValue);

            } else if (prodValue.localeCompare("BOXN") == 0 && reportValue.localeCompare("PERCENTAGE CUMULATIVE  MONTHWISE REJECTION") == 0) {

                //var newPStr = "BOXN";
                createPerMWCumulativeRejectionCombined(fnYearValue, prodValue);

            }

            else {


                createChart(fnYearValue, prodValue);

            }

        });

       <%-- $('#btnSubmit').click(function () {

            mon_yr = new Array();
            stock_mon_per = new Array();
            mac_mon_per = new Array();
            reject_mon_per = new Array();

           <% For i = 0 To month_year.Count - 1%> 
             mon_yr.push('<%=month_year.Item(i)%>');
             stock_mon_per.push('<%=stock_month_per.Item(i)%>');
             mac_mon_per.push('<%=machine_month_per.Item(i)%>');
             reject_mon_per.push('<%=rejection_month_per.Item(i)%>');
                      <%Next%> 

             var fnYearValue = document.getElementById('financialYear').value;
             var prodValue = document.getElementById('prod_type').value;

             createChart(fnYearValue, prodValue);

         });--%>

       <%-- $(document).load(function () {

            ctx10 = document.getElementById('chart10').getContext('2d');
            ctx10.save();

            mon_yr = new Array();
            stock_mon_per = new Array();
            mac_mon_per = new Array();
            reject_mon_per = new Array();

           <% For i = 0 To month_year.Count - 1%> 
            mon_yr.push('<%=month_year.Item(i)%>');
            stock_mon_per.push('<%=stock_month_per.Item(i)%>');
            mac_mon_per.push('<%=machine_month_per.Item(i)%>');
            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');
                      <%Next%> 

            var fnYearValue = document.getElementById('financialYear').value;
            var prodValue = document.getElementById('prod_type').value;

            createChart(fnYearValue, prodValue);


        });--%>

        function createChart(fnYearVal,prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            mon_yr = new Array();
            stock_mon_per = new Array();
            mac_mon_per = new Array();
            reject_mon_per = new Array();

            
            var table = new Array();

           
            //For i = 0 To month_year.Count - 1   Dim index As Integer = Array.IndexOf(month_year, time.ToString(format))          
            //Dim time As DateTime = DateTime.Now
           // Dim format As String = "MMM"

           // Dim j As Integer

          //  For i = 0 To month_year.Count - 1

         //   If month_year.Contains(time.ToString(format)) Then

         //   j = i

         //   End If

            //Dim currentDate As DateTime = DateTime.Now
            //Dim index As Integer = currentDate.Month
            //Dim finalvalue As Integer

            //If index >= 1 And index <= 3 Then
            //index = index + 12
            //End If
            //finalvalue = index - 4


         //   Next

           <%  For i = 0 To month_year.Count - 1 %> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 

            


            //var dataSet = [
            //    ["Apr-20", "75", "12.5", "12.5"],
            //    ["May-20", "59", "30", "11"],
            //    ["Jun-20", "48", "35", "17"],
            //    ["Jul-20", "70", "17", "13"],
            //    ["Aug-20", "50", "38", "13"],
            //    ["Sep-20", "39", "39", "13"],
            //    ["Oct-20", "61", "22", "17"],
            //    ["Nov-20", "52", "33", "14"],
            //    ["Dec-20", "48", "32", "20"],
            //    ["Jan-21", "70", "15", "15"],
            //    ["Feb-21", "50", "35", "15"],
            //    ["Mar-21", "57", "32", "11"]


            //"columnDefs": [{ targets: [3, 4, 5, 6, 7], className: 'dt-body-right' },
            //{ targets: [0, 1, 2], className: 'dt-body-center' }],

              
            //];

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1,2,3], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1, 2, 3], className: 'dt-right' }
                    ]
                });
            });

            var max_percent_stock = Math.max.apply(null, stock_mon_per);

            var max_percent_machine = Math.max.apply(null, stock_mon_per);

            var max_percent;

            if (max_percent_stock > max_percent_machine) {

                max_percent = max_percent_stock;

            } else {

                max_percent = max_percent_machine

            }


            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent < 40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }


            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: mon_yr,
                    datasets: [

                        {
                            label: "Stock",
                            backgroundColor: 'rgba(0,128,0,1)',
                            borderColor: 'rgba(0,128,0,1)',
                            data: stock_mon_per,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Machine", 
                //            backgroundColor: 'rgb(132, 151, 176)',
                //borderColor: 'rgb(132, 151, 176)',
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: mac_mon_per,
                            lineTension: 0,
                            showLine: true,
                            fill: false


                        },
                        {
                            label: "Rejection",
                            backgroundColor: 'rgba(255,0,0,1)',
                            borderColor: 'rgba(255,0,0,1)',
                            data: reject_mon_per,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Month Wise Analysis - Fresh Wheels ' + '(' + prodTypeVal+')'+ ' F.Y. '+fnYearVal,
                        fontSize: 20,
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
                                max: Math.round(max_percent),
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },
                            
                            //gridLines: {
                            //    display: false
                            //},
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                            }
                        }
                    }
                }     
            });
         }



        function createChartRejection(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            mon_yr = new Array();
          
            reject_mon_per = new Array();





            var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');
           
            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });


          <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


           var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });--%>






            var max_percent = Math.max.apply(null, reject_mon_per);

            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent < 40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }





            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: mon_yr,
                    datasets: [

                       
                       
                        {
                            label: "Rejection",
                            backgroundColor: 'rgba(255,0,0,1)',
                            borderColor: 'rgba(255,0,0,1)',
                            data: reject_mon_per,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Month Wise Analysis Rejection - Fresh Wheels ' + '(' + prodTypeVal + ')' + ' F.Y. ' + fnYearVal,
                        fontSize: 20,
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
                                max: Math.round(max_percent), //100
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                 return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                             }
                         }
                    }
                }
            });



        }



        function createChartPie(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

           
             
        pie_quality_analysis = new Array();

            var table = new Array();

           <% For i = 0 To pie_smr_all_quality.Count - 1%> 
            
            pie_quality_analysis.push('<%=pie_smr_all_quality.Item(i)%>');



                      <%Next%> 

            table.push(pie_quality_analysis);

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                      
                        { targets: [0,1,2], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                       
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                       
                        { targets: [0, 1, 2], className: 'dt-right' }
                    ]
                });
            });
            


        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });
            });--%>









            myChart10 = new Chart(ctx10, {
                type: 'pie',
                data: {
                    labels: ["Stock", "Machine", "Rejection"],
                    datasets: [{
                        label: "Quality Analysis",
                        backgroundColor: ['rgba(0, 128, 0, 0.7)', 'rgba(0, 0, 255,0.7)', 'rgba(255,0,0,0.7)'],
                        data: pie_quality_analysis
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Quality Analysis - Fresh Wheels ' + '(' + prodTypeVal + ')' + ' F.Y. ' + fnYearVal,
                        fontSize: 20,
                        // padding: 15
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

                            color: 'white',
                            anchor: 'auto',
                            align: 'auto',
                            display: 'auto',
                            backgroundColor: function (context) {
                                return context.dataset.backgroundColor;
                            },
                            borderColor: 'white',
                            borderRadius: 25,
                            borderWidth: 2,
                            formatter: function (value, context) {
                                return Math.round(value) + '%';
                            },
                            font: {
                                weight: 'bold',
                                size: 18

                            }

                        }

                    }
                }
            });






        }


        function createChartPieRejection(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            var bgColor = [];

            var dynamicColors = function () {
                var r = Math.floor(Math.random() * 255);
                var g = Math.floor(Math.random() * 255);
                var b = Math.floor(Math.random() * 255);
                return "rgb(" + r + "," + g + "," + b + ")";
            };

             rejection_analysis_defect_desc = new Array();
             rejection_analysis_defect_per = new Array();


            var table = new Array();

           <% For i = 0 To rejection_analysis_defect_desc.Count - 1%> 

            var row = new Array();

            rejection_analysis_defect_desc.push('<%=rejection_analysis_defect_desc.Item(i)%>');

            row.push('<%=rejection_analysis_defect_desc.Item(i)%>');

            rejection_analysis_defect_per.push('<%=rejection_analysis_defect_per.Item(i)%>');

            row.push('<%=rejection_analysis_defect_per.Item(i)%>');

            bgColor.push(dynamicColors());

            table.push(row);
            <%Next%> 




            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        
                       
                        { title: "Defect" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [


                        { title: "Defect" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });



        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });
            });--%>



            myChart10 = new Chart(ctx10, {
                type: 'pie',
                data: {
                    labels: rejection_analysis_defect_desc,
                    datasets: [{
                        label: "Rejection Analysis",
                        //backgroundColor: ["#56568f", "#92589b", "#cc5590", "#f75d73", "#ff7b48", 'rgba(255,0,0,0.7)', 'rgba(255,0,12,1)', 'rgba(255,135,0,0.5)', 'rgba(255,0,217,1)', 'rgba(0,0,128,1)'],
                        backgroundColor: bgColor,
                        data: rejection_analysis_defect_per
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Rejection Analysis - Fresh Wheels ' + '(' + prodTypeVal + ')' + ' F.Y. ' + fnYearVal,
                        fontSize: 20,
                        // padding: 15
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

                            color: 'white',
                            anchor: 'cenetr',
                            align: 'end',
                            display: 'auto',
                            backgroundColor: function (context) {
                                return context.dataset.backgroundColor;
                            },
                            borderColor: 'white',
                            borderRadius: 25,
                            borderWidth: 2,
                            formatter: function (value, context) {
                                return Math.round(value) + '%';
                            },
                            font: {
                                weight: 'bold',
                                size: 16

                            }

                        }

                    }
                }
            });
        }


        function createPercentFreshWheel(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            label_value = new Array();

            percent_value = new Array();


            var table = new Array();


           <% For i = 0 To percent_label.Count - 1%> 

            var row = new Array();

            label_value.push('<%=percent_label.Item(i)%>');

            row.push('<%=percent_label.Item(i)%>');

            percent_value.push('<%=percent_value.Item(i)%>');

            row.push('<%=percent_value.Item(i)%>');

            table.push(row);


                      <%Next%> 


            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        
                        { title: "Financial Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                       
                        { title: "Financial Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });



        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Stock (%)" },
                        { title: "Machine (%)" },
                        { title: "Rejection (%)" }
                    ]
                });
            });--%>











            var max_percent = Math.max.apply(null, percent_value);

            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent <40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }



            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: label_value,
                    datasets: [



                        {
                            label: "Rejection in Dark Room",
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: percent_value,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Percentage of Fresh Wheels Rejection in Dark Room' + '(' + prodTypeVal + ')', // + ' F.Y. ' + fnYearVal
                        fontSize: 20,
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
                                max: Math.round(max_percent),
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                            }
                        }
                    }
                }
            });



        }


        function createBadChemistry(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            badchem_month = new Array();

            badchem_percent = new Array();


            var table = new Array();

           <% For i = 0 To badchem_month.Count - 1%> 

            var row = new Array();

            badchem_month.push('<%=badchem_month.Item(i)%>');

            row.push('<%=badchem_month.Item(i)%>');

            badchem_percent.push('<%=badchem_percent.Item(i)%>');

            row.push('<%=badchem_percent.Item(i)%>');

            table.push(row);

                      <%Next%> 


            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });



        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


           var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });
        
        --%>






            var max_percent = Math.max.apply(null, badchem_percent);

            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent < 40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }




            //var max_percent = Math.max.apply(null, percent_value) * 120 / 100

            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: badchem_month,
                    datasets: [



                        {
                            label: "Bad Chemistry",
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: badchem_percent,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Percentage of Rejection Due To Bad Chemistry' + ' F.Y. ' + fnYearVal, //+ '(' + prodTypeVal + ')'
                        fontSize: 20,
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
                                max: Math.round(max_percent), //Math.round(max_percent) 100
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                            }
                        }
                    }
                }
            });



        }



        function createPerMWRejectionCombined(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;

            
             pr_mw_rejection_label = new Array();
             pr_mw_rejection_badchem = new Array();
             pr_mw_rejection_mrxc = new Array();
             pr_mw_rejection_defect = new Array();
             pr_mw_rejection_machining = new Array();
             pr_mw_rejection_total = new Array();


            var table = new Array();

           <% For i = 0 To pr_mw_rejection_badchem.Count - 1%> 

            var row = new Array();

            pr_mw_rejection_label.push('<%=pr_mw_rejection_label.Item(i)%>');

            row.push('<%=pr_mw_rejection_label.Item(i)%>');

            pr_mw_rejection_badchem.push('<%=pr_mw_rejection_badchem.Item(i)%>');

            row.push('<%=pr_mw_rejection_badchem.Item(i)%>');

            pr_mw_rejection_mrxc.push('<%=pr_mw_rejection_mrxc.Item(i)%>');

            row.push('<%=pr_mw_rejection_mrxc.Item(i)%>');

            pr_mw_rejection_defect.push('<%=pr_mw_rejection_defect.Item(i)%>');

            row.push('<%=pr_mw_rejection_defect.Item(i)%>');

            pr_mw_rejection_machining.push('<%=pr_mw_rejection_machining.Item(i)%>');

            row.push('<%=pr_mw_rejection_machining.Item(i)%>');

            pr_mw_rejection_total.push('<%=pr_mw_rejection_badchem.Item(i)+pr_mw_rejection_mrxc.Item(i)+pr_mw_rejection_defect.Item(i)+pr_mw_rejection_machining.Item(i)%>');

            row.push('<%=pr_mw_rejection_badchem.Item(i)+pr_mw_rejection_mrxc.Item(i)+pr_mw_rejection_defect.Item(i)+pr_mw_rejection_machining.Item(i)%>');

            table.push(row);

                      <%Next%> 

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Bad Chemistry (%)" },
                        { title: "MR XC (%)" },
                        { title: "Dark Room (%)" },
                        { title: "Machining (%)" },
                        { title: "Total (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1, 2, 3, 4, 5], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Bad Chemistry (%)" },
                        { title: "MR XC (%)" },
                        { title: "Dark Room (%)" },
                        { title: "Machining (%)" },
                        { title: "Total (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1,2,3,4,5], className: 'dt-right' }
                    ]
                });
            });



        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


           var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });
        
        --%>





            var max_percent = Math.max.apply(null, pr_mw_rejection_total);

            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent < 40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }




            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: pr_mw_rejection_label,
                    datasets: [

                        {
                            label: "Bad Chemistry",
                            backgroundColor: 'rgba(0,128,0,1)',
                            borderColor: 'rgba(0,128,0,1)',
                            data: pr_mw_rejection_badchem,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "MR XC",
                            //            backgroundColor: 'rgb(132, 151, 176)',
                            //borderColor: 'rgb(132, 151, 176)',
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: pr_mw_rejection_mrxc,
                            lineTension: 0,
                            showLine: true,
                            fill: false


                        },
                        {
                            label: "Dark Room",
                            backgroundColor: 'rgba(255,0,0,1)',
                            borderColor: 'rgba(255,0,0,1)',
                            data: pr_mw_rejection_defect,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Machining",
                            backgroundColor: 'rgba(0,255,255,1)',
                            borderColor: 'rgba(0,255,255,1)',
                            data: pr_mw_rejection_machining,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Total",
                            backgroundColor: 'rgba(71, 71, 107,1)', 
                            borderColor: 'rgba(71, 71, 107,1)',
                            data: pr_mw_rejection_total,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Percentage Month Wise Rejection ' + '(' + prodTypeVal + ')' + ' F.Y. ' + fnYearVal,
                        fontSize: 20,
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
                                max: max_percent,
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },

                            //gridLines: {
                            //    display: false
                            //},
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                            }
                        }
                    }
                }
            });
        }



        function createPerMWCumulativeRejectionCombined(fnYearVal, prodTypeVal) {

            if (myChart10) myChart10.destroy();
            ctx10.restore;


            pr_mw_rejection_label = new Array();
            pr_mw_rejection_badchem = new Array();
            pr_mw_rejection_mrxc = new Array();
            pr_mw_rejection_defect = new Array();
            pr_mw_rejection_machining = new Array();
            pr_mw_rejection_total = new Array();

            var table = new Array();

           <% For i = 0 To pr_mw_rejection_badchem.Count - 1%> 

            var row = new Array();

            pr_mw_rejection_label.push('<%=pr_mw_rejection_label.Item(i)%>');

            row.push('<%=pr_mw_rejection_label.Item(i)%>');

            pr_mw_rejection_badchem.push('<%=pr_mw_rejection_badchem.Item(i)%>');

            row.push('<%=pr_mw_rejection_badchem.Item(i)%>');

            pr_mw_rejection_mrxc.push('<%=pr_mw_rejection_mrxc.Item(i)%>');

            row.push('<%=pr_mw_rejection_mrxc.Item(i)%>');

            pr_mw_rejection_defect.push('<%=pr_mw_rejection_defect.Item(i)%>');

            row.push('<%=pr_mw_rejection_defect.Item(i)%>');

            pr_mw_rejection_machining.push('<%=pr_mw_rejection_machining.Item(i)%>');

            row.push('<%=pr_mw_rejection_machining.Item(i)%>');

            pr_mw_rejection_total.push('<%=pr_mw_rejection_badchem.Item(i)+pr_mw_rejection_mrxc.Item(i)+pr_mw_rejection_defect.Item(i)+pr_mw_rejection_machining.Item(i)%>');

            row.push('<%=pr_mw_rejection_badchem.Item(i)+pr_mw_rejection_mrxc.Item(i)+pr_mw_rejection_defect.Item(i)+pr_mw_rejection_machining.Item(i)%>');

            table.push(row);

             <%Next%> 

            var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Bad Chemistry (%)" },
                        { title: "MR XC (%)" },
                        { title: "Dark Room (%)" },
                        { title: "Machining (%)" },
                        { title: "Total (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1, 2, 3, 4, 5], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Bad Chemistry (%)" },
                        { title: "MR XC (%)" },
                        { title: "Dark Room (%)" },
                        { title: "Machining (%)" },
                        { title: "Total (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1, 2, 3, 4, 5], className: 'dt-right' }
                    ]
                });
            });

        <%--  var table = new Array();

           <% For i = 0 To month_year.Count - 1%> 

            var row = new Array();

            mon_yr.push('<%=month_year.Item(i)%>');

            row.push('<%=month_year.Item(i)%>');

            stock_mon_per.push('<%=stock_month_per.Item(i)%>');

            row.push('<%=stock_month_per.Item(i)%>')

            mac_mon_per.push('<%=machine_month_per.Item(i)%>');

            row.push('<%=machine_month_per.Item(i)%>');

            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');

            row.push('<%=rejection_month_per.Item(i)%>');

            table.push(row);

                      <%Next%> 


           var dataSet = table;

            $(document).ready(function () {
                $('#example').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });

                $('#example2').DataTable({

                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searchable": false,
                    data: dataSet,

                    columns: [
                        { title: "Month Year" },
                        { title: "Rejection (%)" }
                    ],
                    columnDefs: [
                        { targets: [0], className: 'dt-left' },
                        { targets: [1], className: 'dt-right' }
                    ]
                });
            });
        
        --%>





            var max_percent = Math.max.apply(null, pr_mw_rejection_total);

            if (max_percent < 20) {

                max_percent = 20;

            } else if (max_percent > 20 && max_percent < 40) {

                max_percent = 40;

            } else if (max_percent > 40 && max_percent < 60) {

                max_percent = 60;

            } else if (max_percent > 60 && max_percent < 80) {

                max_percent = 80;

            } else if (max_percent > 80 && max_percent < 100) {

                max_percent = 100;
            }




            myChart10 = new Chart(ctx10, {
                type: 'line',
                data: {
                    labels: pr_mw_rejection_label,
                    datasets: [

                        {
                            label: "Bad Chemistry",
                            backgroundColor: 'rgba(0,128,0,1)',
                            borderColor: 'rgba(0,128,0,1)',
                            data: pr_mw_rejection_badchem,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "MR XC",
                            //            backgroundColor: 'rgb(132, 151, 176)',
                            //borderColor: 'rgb(132, 151, 176)',
                            backgroundColor: 'rgba(0, 0, 255,1)',
                            borderColor: 'rgba(0, 0, 255,1)',
                            data: pr_mw_rejection_mrxc,
                            lineTension: 0,
                            showLine: true,
                            fill: false


                        },
                        {
                            label: "Dark Room",
                            backgroundColor: 'rgba(255,0,0,1)',
                            borderColor: 'rgba(255,0,0,1)',
                            data: pr_mw_rejection_defect,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Machining",
                            backgroundColor: 'rgba(0,255,255,1)',
                            borderColor: 'rgba(0,255,255,1)',
                            data: pr_mw_rejection_machining,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        },
                        {
                            label: "Total",
                            backgroundColor: 'rgba(71, 71, 107,1)',
                            borderColor: 'rgba(71, 71, 107,1)',
                            data: pr_mw_rejection_total,
                            lineTension: 0,
                            showLine: true,
                            fill: false

                        }
                    ],



                },
                options: {
                    responsive: true,
                    maintainAspectRatio: true,
                    title: {
                        display: true,
                        text: 'Percentage Cumulative Month Wise Rejection ' + '(' + prodTypeVal + ')' + ' F.Y. ' + fnYearVal,
                        fontSize: 20,
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
                                max: max_percent,
                                maxTicksLimit: 10,
                                callback: function (value) { return value + "%" }
                            },

                            //gridLines: {
                            //    display: false
                            //},
                            scaleLabel: {
                                display: true,
                                labelString: "Percentage (%)",
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
                                return Chart.defaults.global.tooltips.callbacks.label(tooltipItem, data) + '%';
                            }
                        }
                    }
                }
            });
        }




        <%--function updateChartNew() {

            mon_yr = new Array();
            stock_mon_per = new Array();
            mac_mon_per = new Array();
            reject_mon_per = new Array();

           <% For i = 0 To month_year.Count - 1%> 
            mon_yr.push('<%=month_year.Item(i)%>');
            stock_mon_per.push('<%=stock_month_per.Item(i)%>');
            mac_mon_per.push('<%=machine_month_per.Item(i)%>');
            reject_mon_per.push('<%=rejection_month_per.Item(i)%>');
                      <%Next%> 

            var fnYearValue = document.getElementById('financialYear').value;
            var prodValue = document.getElementById('prod_type').value;

            createChart(fnYearValue, prodValue);

        }--%>
        <%--function updateChart() {
           

            var val = document.getElementById('prod_type').value;


            if (val == 'COMBINED') {
                mon_yr = new Array();
                stock_mon_per = new Array();
                mac_mon_per = new Array();
                reject_mon_per = new Array();

           <% For i = 0 To month_year.Count - 1%> 
                  mon_yr.push('<%=month_year.Item(i)%>');
                  stock_mon_per.push('<%=stock_month_per.Item(i)%>');
                  mac_mon_per.push('<%=machine_month_per.Item(i)%>');
                  reject_mon_per.push('<%=rejection_month_per.Item(i)%>');
                      <%Next%> 

                createChart(val);
              }
              else if (val == 'BGC') {
                  mon_yr = new Array();
                  stock_mon_per = new Array();
                  mac_mon_per = new Array();
                  reject_mon_per = new Array();

           <% For i = 0 To month_year_bgc.Count - 1%> 
                  mon_yr.push('<%=month_year_bgc.Item(i)%>');
                  stock_mon_per.push('<%=stock_month_per_bgc.Item(i)%>');
                  mac_mon_per.push('<%=machine_month_per_bgc.Item(i)%>');
                  reject_mon_per.push('<%=rejection_month_per_bgc.Item(i)%>');
                      <%Next%> 
                createChart(val);
              }
              else if (val == 'BOXN') {
                  mon_yr = new Array();
                  stock_mon_per = new Array();
                  mac_mon_per = new Array();
                  reject_mon_per = new Array();

           <% For i = 0 To month_year_boxn.Count - 1%> 
                  mon_yr.push('<%=month_year_boxn.Item(i)%>');
                  stock_mon_per.push('<%=stock_month_per_boxn.Item(i)%>');
                  mac_mon_per.push('<%=machine_month_per_boxn.Item(i)%>');
                  reject_mon_per.push('<%=rejection_month_per_boxn.Item(i)%>');
                      <%Next%> 
                createChart(val);
              }
        }--%>
  
        </script>
</body>
</html>


