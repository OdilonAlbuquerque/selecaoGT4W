using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ClienteModel
    {
        public int ClienteID { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteNascimento { get; set; }
        public string ClientePeso { get; set; }
        public string ClienteUF { get; set; }

        //public ClienteModel(string nome)
        //{
        //    this.ClienteNome = nome;
        //}
    }
}