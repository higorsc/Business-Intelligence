﻿using Business_Intelligence.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web.Http.Results;

namespace Business_Intelligence.Models
{
    public class SearchObjects
    {

        public string Cpf { get; set; }
        public string Produto { get; set; }
        public string Segmento { get; set; }
        public string Cliente { get; set; }
        public string Cidade { get; set; }
        public string DataIni { get; set; }
        public string DataFim { get; set; }

        public int QtdProduto { get; set; }

        public SearchObjects(string cpf, string produto, string segmento, string cliente, string cidade, string dataIni, string dataFim)
        {
            Cpf = cpf;
            Produto = produto;
            Segmento = segmento;
            Cliente = cliente;
            Cidade = cidade;
            DataIni = dataIni;
            DataFim = dataFim;
        }

        public SearchObjects(string cpf)
        {
            Cpf = cpf;
           
        }

        public SearchObjects(int qtd, string cliente)
        {
            qtd = QtdProduto;
            cliente = Cliente;
        }

        public SearchObjects()
        {
            

        }

         // public static List<VendasClienteProduto> getResults(SearchObjects obj)
        public static List<VendasClienteProduto> getResults()
        {

            List<VendasClienteProduto> lista = new List<VendasClienteProduto>();

            if (DBConnection.isConnected == false)
            {
                DBConnection.connect();
            }

            try
            {
                //SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto WHERE CLIENTE_ID = " + cpf + " AND PRODUCT_ID = 1");
                SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto");

                while (reader.Read() != false)
                {
                    lista.Add(new VendasClienteProduto(reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(2)), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(3))));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            DBConnection.closeConnections();

            return lista;

        }


        public static VendasClienteProduto getResultsByID(SearchObjects obj)
        {
            string query = "SELECT * FROM VW_VendasClienteProduto WHERE 1 = 1 AND ";

            List<VendasClienteProduto> lista = new List<VendasClienteProduto>();

            if (DBConnection.isConnected == false)
            {
                DBConnection.connect();
            }

            try
            {
                if (obj.Cpf != null)
                {
                    query += " AND CLIENTE_ID = " + obj.Cpf;
                }
                if (obj.Cliente != null && !obj.Cliente.Equals("''"))
                {
                    query += " AND CLIENTE_NAME = '" + obj.Cliente + "'";
                }
                SqlDataReader reader = DBConnection.getResults(query);
                // SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto WHERE CLIENTE_ID = " + obj.Cpf);

                while (reader.Read() != false)
                {
                    lista.Add(new VendasClienteProduto(reader.GetValue(1).ToString(), Convert.ToInt32(reader.GetValue(0)), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(5))));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            DBConnection.closeConnections();

            /*
            for (int i = 0; i < 200; i++)
            {
                lista.Add(new VendasClienteProduto("cliente " + i, i, "produto " + i, i + 3));
            }*/
            // return lista;

            if (lista.Count > 0) {
                /* var data = (from item in lista
                             where item.id_cliente == Convert.ToInt32(obj.Cpf) && item.cliente == obj.Cliente
                             select item).First();*/

                return lista.FirstOrDefault(e => e.id_cliente == Convert.ToInt32(lista[0].id_cliente));
               
            }else
            {
                return null;
            }
         //   return data;
        }

        public static List<VendasClienteProduto> getProductsInsights(SearchObjects obj)
        {
            string query = "SELECT TOP(10) * FROM VW_VendasClienteProduto WHERE 1 = 1";

            List<VendasClienteProduto> lista = new List<VendasClienteProduto>();

            if (DBConnection.isConnected == false)
            {
                DBConnection.connect();
            }

            try
            {

                if (obj.Cpf != null && !obj.Cpf.Equals("''"))
                {
                    query += " AND CLIENTE_ID = " + obj.Cpf;
                }

                if (obj.Cliente != null && !obj.Cliente.Equals("''"))
                {
                    query += " AND CLIENTE_NAME = '" + obj.Cliente + "'";
                }

                if (obj.Produto != null && !obj.Produto.Equals("''"))
                {
                    query += " AND PRODUCT_ID = " + obj.Produto ;
                }

                if (obj.Segmento != null && !obj.Segmento.Equals("''"))
                {

                    if (obj.Segmento.Contains(","))
                    {
                        var segReplaced = obj.Segmento.Replace(",", " ");
                        string moreSegments = segReplaced.Substring(segReplaced.IndexOf(" ")-1, segReplaced.Length-1).Trim();
                        var firstSegReplaced = segReplaced.Replace(moreSegments, " ").Trim();
                        query += " AND (PRODUTO_SEGMENTO = " + moreSegments;
                        query += " OR PRODUTO_SEGMENTO = " + firstSegReplaced + ") ";

                    }

                    else
                    {
                        query += " AND PRODUTO_SEGMENTO = " + obj.Segmento;
                    }
                }

                if (obj.DataIni != null && !obj.DataIni.Equals("''"))
                {
                    query += " AND DATA_VENDA >= '" + obj.DataIni + "'";
                }

                if (obj.DataFim != null && !obj.DataFim.Equals("''"))
                {
                    query += " AND DATA_VENDA <= '" + obj.DataFim + "'";
                }

                if (obj.Cidade != null && !obj.Cidade.Equals("''"))
                {
                    query += " AND CIDADE = '" + obj.Cidade + "'";
                }

                SqlDataReader reader = DBConnection.getResults(query);
                // SqlDataReader reader = DBConnection.getResults("SELECT * FROM VW_VendasClienteProduto WHERE CLIENTE_ID = " + obj.Cpf);

                while (reader.Read() != false)
                {
                    var val1 = reader.GetValue(1).ToString();
                    var val2 = reader.GetValue(0);
                    var val3 = reader.GetValue(4).ToString();
                    var val4 = reader.GetValue(5);

                    lista.Add(new VendasClienteProduto(val1, Convert.ToInt32(val2), val3, Convert.ToInt32(val4)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            DBConnection.closeConnections();

            /*
            for (int i = 0; i < 200; i++)
            {
                lista.Add(new VendasClienteProduto("cliente " + i, i, "produto " + i, i + 3));
            }*/
            // return lista;

            if (lista.Count > 0)
            {
                /* var data = (from item in lista
                             where item.id_cliente == Convert.ToInt32(obj.Cpf) && item.cliente == obj.Cliente
                             select item).First();*/

                return lista;
            }
            else
            {
                return null;
            }
            //   return data;
        }


    }
}