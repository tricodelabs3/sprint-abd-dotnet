using System.Collections.Generic;
using System.Linq;

namespace Vitta.Models {
    public class UsuarioRepository : IUsuarioRepository {
        private static List<Usuario> usuarios = new List<Usuario>();
        private static int nextId = 1;

        public List<Usuario> GetAll() => usuarios;

        public Usuario? GetById(int id) => usuarios.FirstOrDefault(u => u.Id == id);

        public void Add(Usuario usuario) {
            usuario.Id = nextId++;
            usuarios.Add(usuario);
        }

        public void Update(Usuario usuario) {
            var existente = GetById(usuario.Id);
            if (existente != null) {
                existente.Nome = usuario.Nome;
                existente.Email = usuario.Email;
                existente.Objetivo = usuario.Objetivo;
            }
        }

        public void Delete(int id) {
            var usuario = GetById(id);
            if (usuario != null)
                usuarios.Remove(usuario);
        }
    }
}
