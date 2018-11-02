using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business_Intelligence.Models
{
    public class VendasClienteProduto
    {

        public string cliente { get; set; }
        public int id_cliente { get; set; }
        public string produto { get; set; }
        public int id_produto { get; set; }

        public VendasClienteProduto(string cliente, int id_cliente, string produto, int id_produto)
        {

            this.cliente = cliente;
            this.id_cliente = id_cliente;
            this.produto = produto;
            this.id_produto = id_produto;
        }

    }
}