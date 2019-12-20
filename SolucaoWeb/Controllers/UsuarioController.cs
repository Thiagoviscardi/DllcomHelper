using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolucaoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        //////////////////////////////////////SALVA USUARIO///////////////////////////////////////

        public Helper.JsonRetorno salvaController(DataDll.Data.Entidades.UsuarioEntidade usuario)
        {
            Helper.JsonRetorno JsonRetorno = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();
            var retorno = usuarioService.Salvar(usuario);
            return JsonRetorno;
        }
        //////////////////////////////////////DELETA USUARIO///////////////////////////////////////

        public Helper.JsonRetorno deletaController(int id)
        {
            Helper.JsonRetorno JsonRetorno = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioservice = new DataDll.Data.Services.UsuarioService();

            var retorno = usuarioservice.Deletar(id);
            if (retorno == true)
            {
                JsonRetorno.Mensagem = "Usuario deletado com sucesso!";
            } else
            {
                JsonRetorno.Mensagem = "Usuario não encontrado!";
            }

            
            return JsonRetorno;
        }

        public Helper.JsonRetorno listaTodosController()// tenho que pegar a resposta do front aqui no parametro
        {
            Helper.JsonRetorno jsonRetorno = new Helper.JsonRetorno();
            DataDll.Data.Services.UsuarioService usuarioService = new DataDll.Data.Services.UsuarioService();
            var retorno = usuarioService.listarTodos();
            jsonRetorno.Data = retorno;
            return jsonRetorno;
        }

    }
}