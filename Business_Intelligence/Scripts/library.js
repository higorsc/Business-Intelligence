//var url = "api/VendasClienteProduto";
//var url = "api/SearchObjects/"
var url = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/";
var url2 = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/Segment";
var url3 = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/Clients";


//funcao para mostrar o text field referente ao filtro selecionado
       function chFilter(num, id) {
   
           var obj = document.getElementById(id);
           var txtObj = "txt" + id.substring(3, id.length);
           var txt = document.getElementById(txtObj);

           var divFields = document.getElementById("divAttributeFields")
           
           if(divFields.hidden == true){
               divFields.hidden = false;
           }
           
            if (obj.checked == true) {
             
                txt.hidden = false;
 
            } else {
                removeParamFromURL(obj);
                txt.value = "";
                txt.innerText = "";
                txt.hidden = true;
            
            }

}

//funcao para mostrar o div de atributos
       function showAttributes() {

    var chbObj = document.getElementById("divAttributes");
    var chBoxes = document.getElementsByClassName("chbAttribute");

    if (chbObj.hidden == true) {
        document.getElementById("divAttributes").hidden = false;

        for (var i = 0; i < chBoxes.length; i++) {

            if (chBoxes[i].type == "checkbox") {
                chBoxes[i].checked = false;
            }
        }
        
    } else {

        document.getElementById("divAttributes").hidden = true;
        document.getElementById("divAttributeFields").hidden = true;

        var txtFields = document.getElementsByTagName("input");
        
        for (var i = 0; i < chBoxes.length; i++) {

            removeParamFromURL(chBoxes[i]);

        }

        for (var i = 0; i < txtFields.length; i++) {

            if (txtFields[i].type == "text") {

                txtFields[i].value = "";
                txtFields[i].innerText = "";
                txtFields[i].hidden = true;

            }
        }

    }
    
}
        //funcao para que pegue o nome do label e passe para checkbox para manipular em outras funcoes
       function transformObj(id, typeToBe){
           var txtObj;

           if (typeToBe == 'text') {

          return  txtObj = "txt" + id.substring(3, id.length);

           }

           else if(typeToBe == 'checkbox'){
               return  txtObj = "chb" + id.substring(3, id.length);
           }

       }
        
//funcao para que ao clicar em algum label, checar o Check Box referente
       function checkChBox(num, id){
         
           var txtObj = "chb" + id.substring(3, id.length);
           var isChecked = document.getElementById(txtObj).checked;

           if (isChecked == true) {
               
               var txt = document.getElementById(txtObj).checked = false;

           } else {
              
               var txt = document.getElementById(txtObj).checked = true;
           }

           if (txtObj != ("chbShowAttributes")) {

               chFilter(num, transformObj(id, 'checkbox'));

           } else {
               showAttributes();
        }
       }

        //valida as datas inseridas, se a final eh menor que a inicial
       function validateDates(txtDataIni, txtDataFim) {
       
           var dataIni = document.getElementById(txtDataIni).value;
           var dataFim = document.getElementById(txtDataFim).value;

          // var objDataIni = document.getElementById(txtDataIni);
           var objDataFim = document.getElementById(txtDataFim);
           
               if (dataFim != "") {
                   
                   if (dataFim < dataIni) {

                       objDataFim.style.borderColor = "red";
                       alert("Erro nas datas");
                       
                       return false;
                   } else {
                       changeBorderColor(objDataFim.id, "aqua");
                      // objDataFim.style.borderColor = "aqua"
                       return true;

                   }
           }
       }
//muda a borda da cor do campo que for preenchido incorretamente
       function changeBorderColor(id, color) {

           var elem = document.getElementById(id);

           if (elem.style.borderColor == "red") {

               elem.style.borderColor = color;

           }

       }

//fun��o para gerar os graficos
      
     // 
//funcao para enviar os requests
       function sendRequest(url) {
           //   alert(url);
           document.getElementById("lblLoading").innerText = 'Loading';

           document.getElementById("loadingDiv").color = "green";
           document.getElementById("loadingDiv").hidden = false;
           var xhtp = new XMLHttpRequest();
           var xhtp2 = new XMLHttpRequest();
           var xhtp3 = new XMLHttpRequest();

           var jsonResponse;
       //    alert(1);
        //   alert(url);

           //xhtp para os dois primeiros divs
           xhtp.onreadystatechange = function f () {
           //    alert(3);
               if (this.status == 200 && this.readyState == 4) {
     
                   jsonResponse = JSON.parse(xhtp.response);
                //   drawChart(jsonResponse, 'ProductsDiv');
                //   drawChart(jsonResponse, 'ClientsDiv');
                   drawChart(jsonResponse, 'SegmentsDiv');
                   console.log("before open URL - > " + url);

                   var URI = getValueFromFields(url);
                   xhtp2.open("GET", URI, true);
                   xhtp2.send();

               }

           //    resetURLParamValues();

         /*      var chBoxes = document.getElementsByTagName("chbAttribute");

               for (var i = 0; i < chBoxes.length; i++) {
                   removeParamFromURL(chBoxes[i]);
               }*/
               document.getElementById("loadingDiv").hidden = true;

               

               return jsonResponse;
           }
           jsonResponse = "";
           console.log('jsonresponse reseted:  ' + jsonResponse);
           //nova funcao para teste por segmentos
           xhtp2.onreadystatechange = function f() {
               //    alert(3);
               if (this.status == 200 && this.readyState == 4) {

                   jsonResponse = JSON.parse(xhtp.response);
                   drawChart(jsonResponse, 'ProductsDiv');

                   var URI = getValueFromFields(url3);
                   xhtp3.open("GET", URI, true);
                   xhtp3.send();

               }

            //   resetURLParamValues();

               var chBoxes = document.getElementsByTagName("chbAttribute");

           /*    for (var i = 0; i < chBoxes.length; i++) {
                   removeParamFromURL(chBoxes[i]);
               */
               document.getElementById("loadingDiv").hidden = true;
               return jsonResponse;
           }

           xhtp3.onreadystatechange = function f() {
               //    alert(3);
               if (this.status == 200 && this.readyState == 4) {

                   jsonResponse = JSON.parse(xhtp.response);
                   drawChart(jsonResponse, 'ClientsDiv');

               }

               resetURLParamValues();

               var chBoxes = document.getElementsByTagName("chbAttribute");

               for (var i = 0; i < chBoxes.length; i++) {
                   removeParamFromURL(chBoxes[i]);
               }
               document.getElementById("loadingDiv").hidden = true;
               return jsonResponse;
           }

           /*
           xhtp2.open("GET", url2, true);
           xhtp2.send();*/

           xhtp.open("GET", url2, true);
           xhtp.send();
         
         //  return jsonResponse.cliente;
       }

    //   function drawChart(response) {
           function drawChart(response, divID) {
           validateDates('txtDataIni', 'txtDataFim');
            //   getValueFromFields(url);
            //   getValueFromFields(url3);


           var jsonData = response;
           // var jsonData = sendRequest(url);
           console.log(jsonData);

           var data = new google.visualization.DataTable();
           console.log(data);
           data.addColumn('string', 'nome');
               data.addColumn('number', 'qtd');
           //    console.log('columns created' + divID);
           //alert(1 + 'teste');

           var vector = jsonData;

      //     console.log('vetor criado' + vector[1].length);

               for (var i = 0; i < vector.length; i++) {

                 //  console.log('iterando por resultados');
               
               if (vector[i] != null) {

                  // data.addRow([vector[i].produto, parseInt(vector[i].id_produto)]);
                   console.log('VALORES OBJETO ' + Object.getOwnPropertyNames(vector[1]));

                   var objIteration = vector[i];
                //   console.log('obj1  - > ' + objIteration);
                //   console.log('length do objeto: ' + objIteration.length);

                   if (divID == 'SegmentsDiv' && i == 1) {
                       for (var j = 0; j < objIteration.length; j++) {
                           // for (var j = 1; j < 3; j++) {

                           var objIteraction1 = objIteration[j];
                 //          console.log('obj2  - > ' + objIteraction1.produto + 'length do objeto: ' + objIteration.length);
                           data.addRow(['Segmento ' + objIteraction1.id_cliente, parseInt(objIteraction1.cliente)]);
                       }
                   } else if (divID == 'ProductsDiv' && i == 0) {

                       for (var j = 0; j < objIteration.length; j++) {

                           var objIteraction1 = objIteration[j];
                   //        console.log('obj2  - > ' + objIteraction1.produto + 'length do objeto: ' + objIteration.length);
                           data.addRow(['Produto ' + objIteraction1.id_cliente, parseInt(objIteraction1.cliente)]);
                       }
                   }

                   else if (divID == 'ClientsDiv' && i == 2) {

                       for (var j = 0; j < objIteration.length; j++) {

                           var objIteraction1 = objIteration[j];
                           console.log('obj2  - > ' + objIteraction1.produto + 'length do objeto: ' + objIteration.length);
                           data.addRow(['Cliente ' + objIteraction1.id_cliente, parseInt(objIteraction1.cliente)]);
                       }
                   }
                   
                   }
        
               }

               var p;

               var options = {
                //   'title': 'Products Insights',
                   'width': 500,
                   'height': 400
               };

               // Set chart options
               if (divID == 'SegmentsDiv') {

                   options.title = 'Segments Insights',
                       options.width = 1000,
                       options.height = 500 

               } else if (divID == 'ClientsDiv') {
                   options.title = 'Clients Insights'

               } else if (divID == 'ProductsDiv') {
                   options.title = 'Products Insights'
               }
               
           // Instantiate and draw our chart, passing in some options.
               //    var chartProducts = new google.visualization.PieChart(document.getElementById('ProductsDiv'));
            var chartProducts = new google.visualization.PieChart(document.getElementById(divID));
           chartProducts.draw(data, options);

           var chBoxes = document.getElementsByTagName("chbAttribute");

         //  var url = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/";
               console.log(url);
               console.log(url2);
           document.getElementById("lblLoading").innerText = 'Loaded';
       }
      

//pega o valor do objeto passado como parametro
       function getValue(id) {
        
           var obj = document.getElementById(id);
           
           return obj.value;
       }
//pega os valores dos campos
function getValueFromFields(param) {

    var obj = document.getElementsByClassName("txtFieldsSize");

    for (var i = 0; i < obj.length; i++) {
        var currObj = document.getElementById(transformObj(obj[i].id, "checkbox"));
        if (obj[i].hidden == false && obj[i].value != '') {
            //if (param.includes(document.getElementById(transformObj(obj[i].id, "checkbox")).value)) { //valida��o para ver se o valor do campo ja esta inserido na param
            if (((param.includes(currObj.value + '//') == false) || (param.includes(currObj.value + "/''/") == true)) && obj[i].value == '') {
                console.log('test ' + currObj.value + '// - ' + param.includes(currObj.value + '//') + ' - ' + param.includes(currObj.value + "/''/"));
                // alert('test' + currObj.value + '//');
            } else if (!(param.includes(currObj.value + '/' + obj[i].value))) {
                // param += document.getElementById(transformObj(obj[i].id, "checkbox")).value + '/' + getValue(obj[i].id) + '/';
                //  var pos = param.indexOf(currObj.value);
                param = param.replace(currObj.value + "/''", currObj.value + "/" + getValue(obj[i].id));
                console.log(currObj.value + '/', currObj.value + '/' + getValue(obj[i].id));
                //  alert(currObj.value + '/', currObj.value + '/' + getValue(obj[i].id));
            } else {
                if (obj[i].value == '') {
                    param = param.replace(currObj.value + '/', currObj.value + "/''");
                }

            }
        } console.log(param);//alert(param);
        //    console.log(param2);
    }
    return param;
}

//fun��o que valida, e pega informa���es dos campos quando submeter a busca
       function validate() {

          validateDates('txtDataIni', 'txtDataFim');
          // getValueFromFields(url);
          // getValueFromFields(url3);


           //    sendRequest(url + '/' + document.getElementById("txtCPF").value);
          sendRequest(url);
          resetURLParamValues();

           //  drawChart();
         
          resetURLParamValues();
       }

//remove os parametros de busca da URL quando as checkboxes sao desmarcadas
       function removeParamFromURL(obj) {
          // alert(1);
           var txtObj = document.getElementById(transformObj(obj.id, 'text'));
          // console.log(txtObj);
           url = url.replace(obj.value + '/' + txtObj.value + '/', obj.value + "/''/");
           url3 = url3.replace(obj.value + '/' + txtObj.value + '/', obj.value + "/''/");
       }

       function resetURLParamValues() {

           url = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/";
           url3 = "api/SearchObjects/CPF/''/Produto/''/Segmento/''/Cliente/''/Cidade/''/DataIni/''/DataFim/''/Clients";

       }