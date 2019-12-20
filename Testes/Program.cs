using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            SolucaoWeb.Controllers.UsuarioController controller = new SolucaoWeb.Controllers.UsuarioController();
            //controller.Salvar();// por que não posso colocar DataDll.Data.Entidades.UsuarioEntidade usuario já que é o que lá em salvar vai ser recebido?
            // ou como mapeio e coloco o json aqui para ser salvo lá na controller?

            //controller.deletaController(70);
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            var retorno = controller.listaTodosController();
            foreach (var item in (List<DataDll.Data.Entidades.UsuarioEntidade>)retorno.Data)
            {
                Console.WriteLine(item.Nome);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////


            Console.ReadLine();// faz com que o console permaneça aberto!
        } 
    }
}
// no app config de testes não precisa colocar a connection string? E se eu referenciar a dll e a solução web,
//qual das connectionstring coloco aqui na testes?