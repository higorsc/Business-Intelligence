using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business_Intelligence.Models;
using System.Web.Http.Results;
using System.Collections;

namespace Business_Intelligence.Controllers
{
    public class SearchObjectsController : ApiController
    {
        // GET: api/SearchObjects
  /*      public JsonResult<List<VendasClienteProduto>> Get([FromUri] SearchObjects obj)
        {
         //   return Json(SearchObjects.getResults(obj));

        }*/

        public JsonResult<List<VendasClienteProduto>> Get()
        {
            return Json(SearchObjects.getResults());

        }

        // GET: api/SearchObjects/5
        [Route ("api/SearchObjects/CPF/{obj.Cpf}/Produto/{obj.Produto}/Segmento/{obj.Segmento}/Cliente/{obj.Cliente}/Cidade/{obj.Cidade}/DataIni/{obj.DataIni}/DataFim/{obj.DataFim}")]
        //   public JsonResult<VendasClienteProduto> Get([FromUri]SearchObjects obj)
       // public JsonResult<List<VendasClienteProduto>> Get([FromUri]SearchObjects obj)

        public JsonResult<List<List<VendasClienteProduto>>> Get([FromUri]SearchObjects obj)
        {
           // SearchObjects.requestsResponses = null;

            //  return Json(SearchObjects.getResultsByID(obj));
            return Json(SearchObjects.getProductsInsights(obj));
        }

        [Route("api/SearchObjects/CPF/{obj.Cpf}/Produto/{obj.Produto}/Segmento/{obj.Segmento}/Cliente/{obj.Cliente}/Cidade/{obj.Cidade}/DataIni/{obj.DataIni}/DataFim/{obj.DataFim}/Segment")]
         //  public JsonResult<VendasClienteProduto> Get([FromUri]SearchObjects obj)
       //public JsonResult<List<VendasClienteProduto>> GetSegments([FromUri]SearchObjects obj)
        public JsonResult<List<List<VendasClienteProduto>>> GetSegments([FromUri]SearchObjects obj)
        {
           /// SearchObjects.requestsResponses = null;
              //return Json(SearchObjects.getResultsByID(obj));
            return Json(SearchObjects.getSegmentsInsights(obj));
        }

        // POST: api/SearchObjects
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SearchObjects/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SearchObjects/5
        public void Delete(int id)
        {
        }
    }
}
