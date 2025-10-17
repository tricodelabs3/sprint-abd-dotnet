using Microsoft.AspNetCore.Mvc;
using Vitta.Models;
using Vitta.Services;

namespace Vitta.Controllers {
    public class HomeController : Controller {
        private readonly UsuarioService _service;

        public HomeController() {
            var repo = new UsuarioRepository();
            _service = new UsuarioService(repo);
        }

        public IActionResult Index() {
            var usuarios = _service.ListarTodos();
            return View(usuarios);
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario) {
            try {
                _service.Cadastrar(usuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
            }
            catch (Exception ex) {
                TempData["MensagemErro"] = ex.Message;
            }

            var usuarios = _service.ListarTodos();
            return View(usuarios);
        }
    }
}
