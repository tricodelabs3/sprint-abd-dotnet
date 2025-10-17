using Microsoft.AspNetCore.Mvc;
using Vitta.Models;
using Vitta.Services;

namespace Vitta.Controllers {
    public class UsuarioController : Controller {
        private readonly UsuarioService _service;

        public UsuarioController() {
            var repo = new UsuarioRepository();
            _service = new UsuarioService(repo);
        }

        public IActionResult Index() {
            var usuarios = _service.ListarTodos();
            return View(usuarios);
        }



        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Usuario usuario) {
            try {
                _service.Cadastrar(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                ViewBag.Erro = ex.Message;
                return View(usuario);
            }
        }



        public IActionResult Edit(int id) {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario) {
            _service.Atualizar(usuario);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Delete(int id) {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id) {
            _service.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
