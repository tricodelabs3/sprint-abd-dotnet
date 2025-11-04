// Vitta/Models/UsuarioRepository.cs
using Vitta.Data; // Importar o DbContext

namespace Vitta.Models {
    // A classe agora implementa a interface IUsuarioRepository
    public class UsuarioRepository : IUsuarioRepository {
        // 1. Variável privada para guardar o contexto do banco
        private readonly VittaDbContext _context;

        // 2. Construtor que RECEBE o DbContext via Injeção de Dependência
        public UsuarioRepository(VittaDbContext context) {
            _context = context;
        }

        // 3. Implementação dos métodos usando EF Core
        public void Add(Usuario usuario) {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges(); // Salva no banco
        }

        public void Update(Usuario usuario) {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null) {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public List<Usuario> GetAll() {
            // Retorna todos os usuários do banco
            return _context.Usuarios.ToList();
        }

        public Usuario? GetById(int id) {
            // Busca um usuário pelo ID
            return _context.Usuarios.Find(id);
        }
    }
}