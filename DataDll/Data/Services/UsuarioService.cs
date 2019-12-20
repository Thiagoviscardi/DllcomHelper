using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDll.Data.Services
{
    public class UsuarioService
    {
        private Model.TreinamentoThiagoEntities _db = new Model.TreinamentoThiagoEntities();
        //////////////////////////////////////SALVA USUARIO///////////////////////////////////////

        public Entidades.UsuarioEntidade Salvar(Entidades.UsuarioEntidade usuario)
        {
            Model.Usuarios usuarioDB = new Model.Usuarios();

            if (usuario.Id > 0)
            {
                usuarioDB = (from n in _db.Usuarios where n.Id == usuario.Id select n).SingleOrDefault();
            }

            usuarioDB.Id = usuario.Id;
            usuarioDB.Idade = usuario.Idade;
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Sexo = usuario.Sexo;
            usuarioDB.Ativo = usuario.Ativo;

            if (usuario.Id == 0)
            {
                _db.Usuarios.Add(usuarioDB);
            }

            _db.SaveChanges();

            usuario.Id = usuarioDB.Id;
            
            return usuario;
        }
        //////////////////////////////////////DELETA UM USUARIO///////////////////////////////////////

        public bool Deletar(int id)
        {
            var usuarioDB = (from n in _db.Usuarios where n.Id == id select n).SingleOrDefault();// aqui faz o select para achar o usuario do id que queremos
            if (usuarioDB != null)
            {
                _db.Usuarios.Remove(usuarioDB);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        //////////////////////////////////////LISTA TODOS USUARIOS///////////////////////////////////////

        public List<Data.Entidades.UsuarioEntidade> listarTodos()
        {
            List<Entidades.UsuarioEntidade> lista = new List<Entidades.UsuarioEntidade>();
            Entidades.UsuarioEntidade usuario = null;
            foreach (var item in from n in _db.Usuarios select n)
            {
                usuario = new Entidades.UsuarioEntidade();
                usuario.Id = item.Id;
                usuario.Nome = item.Nome;
                usuario.Idade = item.Idade;
                usuario.Sexo = item.Sexo;
                usuario.Ativo = item.Ativo;

                lista.Add(usuario);
            }
            return lista;
        }//////////////////////////////////////BUSCA USUARIO UNICO///////////////////////////////////////
        public Entidades.UsuarioEntidade carregarUsuario(int id)
        {
            List<Entidades.UsuarioEntidade> lista = new List<Entidades.UsuarioEntidade>();

            Entidades.UsuarioEntidade usuario = null;

            var buscardUsuario = (from n in _db.Usuarios where n.Id == id select n).SingleOrDefault();

            if(buscardUsuario!=null)
            {
                usuario = new Entidades.UsuarioEntidade();
                usuario.Id = buscardUsuario.Id;
                usuario.Idade = buscardUsuario.Idade;
                usuario.Nome = buscardUsuario.Nome;
                usuario.Sexo = buscardUsuario.Sexo;
                usuario.Ativo = buscardUsuario.Ativo;

            }
            return usuario;
        }
    }
}
