using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace Business_Intelligence.Models
{
    public class SearchAttributes
    {

        public string CPF { get; set; }
        public string Produto { get; set; }
        public string Cliente { get; set; }
        public string Cidade { get; set; }
        public DateTime dataInicial { get; set; }
        public DateTime dataFinal { get;set;}

       // public JsonResult<> search(string attributes)
        //{



        //}

    }
}