using Business_Intelligence.Models;
using Business_Intelligence.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Business_Intelligence.Controllers
{
    public class VendasClienteProdutoController : ApiController
    {
        // GET: api/VendasClienteProduto
        public IEnumerable<string> Get()

        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VendasClienteProduto/5
        [Route ("api/VendasClienteProduto/{cpf}")]
        public JsonResult<List<VendasClienteProduto>> Get(int cpf)
        {
            List<VendasClienteProduto> lista = new List<VendasClienteProduto>();

            if (DBConnection.isConnected == false)
            {
                DBConnection.connect();
            }

            try
            {
                //SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto WHERE CLIENTE_ID = " + cpf + " AND PRODUCT_ID = 1");
                SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto WHERE CLIENTE_ID = " + cpf);

                while (reader.Read() != false)
                {
                    lista.Add(new VendasClienteProduto(reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(3))));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            DBConnection.closeConnections();

            return Json(lista);
        }

        // POST: api/VendasClienteProduto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VendasClienteProduto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VendasClienteProduto/5
        public void Delete(int id)
        {
        }
    }
}
