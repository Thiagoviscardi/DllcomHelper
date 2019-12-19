using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucaoWeb.Helper
{
    public class JsonRetorno
    {
        public JsonRetorno() // isso é o contrutor da classe!
        {
            Mensagem = string.Empty;// essa mensagem vem da public string Mensagem logo abaixo
            
            Criticas = new List<Criticas>();
        }
        public object Data { get; set; } //  ele vai retornar um objeto. ou seja retorna qualquer tipo: string, object, int, bool, list e etc
        public string Mensagem { get; set; }//aqui é por que é uma mensagem fora da critica.
        public List<Criticas> Criticas { get; set; }
    }


    public class Criticas
    {
        public string Mensagem { get; set; }
        public string CampoId { get; set; }// aqui vem do front o id do campo input por exemplo
    }
}