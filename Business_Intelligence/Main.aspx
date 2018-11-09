<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Business_Intelligence.Views.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>
    
  <script src="../Scripts/library.js"></script>

    <script>

        google.charts.load('current', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        
        google.charts.setOnLoadCallback(execFuncs);

        function execFuncs() {

            validate();
          
        }

    </script>


    <style >

        .txtRows{
            margin-left:4%;
            width:8%
        }

        .txtFieldsSize{
            width:90%;
            border-color:aqua;
            border-style:solid;
            border-radius: 8px 8px
        }

        .lblPercentage{
            font-size:75%
        }

        input[type=text]:hover{
            border-color:#80aaff;
            border-image-width:4px;
            border-style:solid
        }

        .chbAttribute{

        }

        .divAttributes {
            height:2%;
            border-top:solid; 
            border-left:solid; 
            border-right:solid; 
            border-color:slategray; 
            border-top-left-radius:5px; 
            border-top-right-radius:5px ; 
            border-bottom-left-radius:0px; 
            border-bottom-right-radius:0px
        }

         .divAttributeFields {
            height:2%;
            border-bottom:solid; 
            border-left:solid; 
            border-right:solid; 
            border-color:slategray; 
            border-top-left-radius:0px; 
            border-top-right-radius:0px ; 
            border-bottom-left-radius:5px; 
            border-bottom-right-radius:5px;

        }
         .divCharts{
             height:25%; 
             width:30%
         }

         .divLoading{
             height:5%;
             width: 100%;
             text-align:center;
             align-items:center
         }

    </style>

</head>
<body>
    
    <form id="form1" runat="server">
   <div class="container-fluid">
       <div class="row" style="align-items:center; height:85% ;text-align:center">
    <div class="" style=" width:100%; align-self:center; height:30px; text-align:center; margin:2% 3% 3% 3%; height:10%">
        <p style="font-size:40px;"></p>
    </div>
           </div>

       <div style="height:1%; max-height:3%" >
           <input type="checkbox" id="chbShowAttributes" onclick="showAttributes()"/>
           <label onclick="checkChBox(1, this.id)" id="lblShowAttributes">Filtro por atributos: </label>
      </div>

    <!--   <div class="row" style="height:2%;border-top:solid; border-left:solid; border-right:solid; border-color:slategray; border-radius:5px;" hidden="hidden" id="divAttributes"> !-->
        <div class="row divAttributes" hidden="hidden" id="divAttributes"> 
           <div class="txtRows">
               <input class="chbAttribute" id="chbCPF" value="CPF" type="checkbox" title="CPF" onchange="chFilter(1, this.id)"/>
                <label id="lblCPF" class="lblPercentage" onclick="checkChBox(1, this.id)">CPF:</label>
           </div>
           
           <div class="txtRows" >
                <input class="chbAttribute" id="chbProduto" value="Produto" type="checkbox" title="CPF" onchange="chFilter(2, this.id)"/>
                <label id="lblProduto" class="lblPercentage" onclick="checkChBox(2, this.id)">Produto:</label>
           </div>

            <div class="txtRows" >
                <input class="chbAttribute" id="chbSegmento" value="Segmento" type="checkbox" title="Segmento" onchange="chFilter(2, this.id)"/>
                <label id="lblSegmento" class="lblPercentage" onclick="checkChBox(2, this.id)">Segmento:</label>
           </div>

           <div class="txtRows" >
                <input class="chbAttribute" id="chbCliente" value="Cliente" type="checkbox" title="CPF" onchange="chFilter(3, this.id)"/>
                <label id="lblCliente" class="lblPercentage" onclick="checkChBox(3, this.id)">Cliente:</label>
           </div>

           <div class="txtRows">
                <input class="chbAttribute" id="chbCidade" value="Cidade" type="checkbox" title="CPF" onchange="chFilter(4, this.id)"/>
                <label id="lblCidade" class="lblPercentage" onclick="checkChBox(4, this.id)">Cidade:</label>
           </div>

           <div class="txtRows">
                <input class="chbAttribute" id="chbDataIni" value="DataIni" type="checkbox" title="CPF" onchange="chFilter(4, this.id)"/>
                <label id="lblDataIni" class="lblPercentage" onclick="checkChBox(4, this.id)">Data Inicial:</label>
           </div>

            <div class="txtRows">
                <input class="chbAttribute" id="chbDataFim" value="DataFim" type="checkbox" title="CPF" onchange="chFilter(4, this.id)"/>
                <label id="lblDataFim" class="lblPercentage" onclick="checkChBox(4, this.id)">Data Final:</label>
           </div>
           
       <!--     <input type="button" onclick="validateDates('txtDataIni','txtDataFim')"/> !-->
           <!--   <input type="button" onclick="validate()" value="Gerar Graficos"/>  !-->
            <label id="lblValue"></label>
           <input type="button" onclick="execFuncs()" value="Gerar Graficos" class="btn btn-primary"/> 
       </div>
    

   <!--    <div class="row" style="height:5%; border-bottom:solid; border-left:solid; border-right:solid; border-color:slategray; border-radius:5px;" id="divAttributeFields"> !-->
         <div class="row divAttributeFields" style="" id="divAttributeFields">
           <div class="txtRows">
                <input type="text" id="txtCPF" hidden="hidden" class="txtFieldsSize"/>
           </div>

           <div class="txtRows">
                <input type="text" id="txtProduto" hidden="hidden" class="txtFieldsSize"/>
           </div>

            <div class="txtRows">
                <input type="text" id="txtSegmento" hidden="hidden" class="txtFieldsSize"/>
           </div>

           <div class="txtRows">
                <input type="text" id="txtCliente" hidden="hidden" class="txtFieldsSize"/>
           </div>

           <div class="txtRows">
                <input type="text" id="txtCidade" hidden="hidden" class="txtFieldsSize"/>
           </div>

           <div class="txtRows">
                <input type="date" style="width:105%; font-size:90" id="txtDataIni" hidden="hidden" class="txtFieldsSize"/>
           </div>

           <div class="txtRows">
                <input type="date" style="width:105%; font-size:90%" id="txtDataFim" hidden="hidden" class="txtFieldsSize" onclick="changeBorderColor(this.id, aqua)"/>
           </div>
            
       </div>

       <div style="height:1%; max-height:3%" >
           <input type="checkbox" id="chbShowFacts" onclick="showFacts()"/>
           <label onclick="checkChBox(1, this.id)" id="lblShowFacts">Filtro por area: </label>
           <label id="lblLoading"></label>
       </div>

       <div id="loadingDiv" class="divLoading" hidden="hidden">
           <label id="lblLoadingCharts"></label>
       </div>

       <div class="row" style="margin-left:10px">

            <div class="divCharts">
          
            </div>

            <div class="divCharts">

            </div>
       </div>

      </div>     

        <div class="container-fluid" style="align-content:center; align-items:center">

            <div class="row" style="align-content:center; align-items:center">

                <div class="col-lg-5" id="ProductsDiv" style="border-color:black; border:solid; margin-right:5px; margin-left:100px">

                </div>

                <div class="col-lg-5" id="ClientsDiv" style="border-color:black; border:solid">

                </div>

            </div>

             <div class="row" style="align-content:center; align-items:center">

                <div class="col-lg-5" id="SegmentsDiv" style="border-color:black; border:solid; margin-right:5px; margin-left:100px">

                </div>
<!--
                <div class="col-lg-5" id="ClientsDiv" style="border-color:black; border:solid">

                </div>     !-->

            </div>

        </div>
    </form>
</body>
</html>
