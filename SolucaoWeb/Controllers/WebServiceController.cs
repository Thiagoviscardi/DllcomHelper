using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SolucaoWeb.Controllers
{
    public class WebServiceController : ApiController
    {
        [HttpPost]
        [Route ("~/insereusuario")]
        public string insereUsuario([FromBody] DataDll.Data.Entidades.UsuarioEntidade usuario)// aqui n~çao precisa do formcollection pois já está no formato json
        {
            Helper.JsonRetorno jsonRetorno = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();
            usuarioService.Salvar(usuario);
            return jsonRetorno.Mensagem = "Usuario inserido com sucesso!";
        }
        [HttpPost]
        [Route ("~/deletausuario/{id}")]
        public Helper.JsonRetorno deletaUsuario (int id)// se eu colocar o tipo JsonResult ele da erro em [httppost] e em [Route]
        {
            Helper.JsonRetorno jsonRetorno = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();

            

            var retorno = usuarioService.Deletar(id);
            if(retorno == true)
            {
                jsonRetorno.Mensagem = "Usuario deletado com sucesso!";
            }
            else
            {
                jsonRetorno.Mensagem = "Usuario não encontrado.";
            }
            return jsonRetorno;
        }

        [HttpGet]
        [Route ("~/listartodos")]
        public Helper.JsonRetorno ListarTodos()
        {
            Helper.JsonRetorno retornoJson = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();
            var listatodos = usuarioService.listarTodos();
            retornoJson.Data = listatodos; // nesse caso o retornoJson.data vai receber uma lista entao vai retornar depois a lista
            return retornoJson;
        }

        [HttpGet]
        [Route ("~/buscarusuario/{id}")]
        public Helper.JsonRetorno buscaUsuario (int id)
        {
            Helper.JsonRetorno retornoJson = new Helper.JsonRetorno();

            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();
            var retorno = usuarioService.carregarUsuario(id);
            if(retorno == null)
            {
                
                retornoJson.Mensagem = "usuario não encontrado.";
                
            }
            else
            {
                retornoJson.Data = retorno;
            }

            return retornoJson; // esse retornoJson vai trazer ou a string da mensagem ou o retorno do data
        }
    }
}