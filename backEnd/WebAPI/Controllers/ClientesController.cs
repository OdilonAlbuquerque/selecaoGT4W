using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClientesController : ApiController
    {
        private static List<Cliente> clientes = new List<Cliente>();

        //[HttpGet]
        //public IEnumerable<VW_Clientes> Get()
        //{
        //    using(gtDBEntities1 db = new gtDBEntities1())
        //    {
        //        return db.VW_Clientes.ToList();
        //    }
        //}

        [HttpGet]
        public List<ClienteModel> Get()


        {
            using (gtDBEntities1 db = new gtDBEntities1())
            {
                var _lista = db.VW_Clientes.ToList();

                List<ClienteModel> retorno = new List<ClienteModel>();
                foreach (var item in _lista)
                {
                    retorno.Add(new ClienteModel {
                        ClienteID = item.ClienteID,
                        ClienteNome = item.ClienteNome,
                        ClienteCPF = item.ClienteCPF,
                        ClienteNascimento = item.ClienteNascimento.Value.ToString("dd/MM/yyyy"),
                        ClienteUF = item.ClienteUF,
                        ClientePeso = item.ClientePeso
                    });
                }

                return retorno;
            }
        }

        [HttpGet]
        public Cliente Get(int id)
        {
            using (gtDBEntities1 db = new gtDBEntities1())
            {
                return db.Clientes.FirstOrDefault(e => e.ClienteID == id);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Cliente cli)
        {
            if(!string.IsNullOrEmpty(cli.ClienteCPF))
            {
                var c = new Cliente();

                c.ClienteNome = cli.ClienteNome;
                c.ClienteCPF = cli.ClienteCPF;
                c.ClienteNascimento = Convert.ToDateTime(cli.ClienteNascimento);
                c.ClientePeso = Convert.ToDecimal(cli.ClientePeso);
                c.ClienteUF = Convert.ToInt32(cli.ClienteUF);
                
                using (gtDBEntities1 db = new gtDBEntities1())
                {
                    string _vef;
                    try
                    {
                        _vef = db.Clientes.FirstOrDefault(v => v.ClienteCPF == c.ClienteCPF).ClienteCPF;
                        return Request.CreateResponse(HttpStatusCode.Conflict);
                    }
                    catch
                    {
                        db.Clientes.Add(c);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Delete(string nome)
        {
            clientes.RemoveAt(clientes.IndexOf(clientes.First(x => x.ClienteNome.Equals(nome))));
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
