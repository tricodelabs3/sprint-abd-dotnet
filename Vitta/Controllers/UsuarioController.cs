using Microsoft.AspNetCore.Mvc;
using Vitta.Models;
using Vitta.Services;
using Vitta.ViewModels;

namespace Vitta.Controllers {
    // Define uma rota base para o controller. Ex: "http://localhost/Usuario"
    [Route("[controller]")]
    public class UsuarioController : Controller {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service) {
            _service = service;
        }

        // Rota: /Usuario ou /Usuario/Index
        [Route("Index")]
        [Route("")] // Rota padrão para este controller
        public IActionResult Index() {
            var usuarios = _service.ListarTodos();
            return View(usuarios);
        }

        // Rota: /Usuario/Novo
        [Route("Novo")]
        public IActionResult Create() => View();

        [HttpPost]
        [Route("Novo")]
        public IActionResult Create(UsuarioCreateViewModel viewModel) {
            if (!ModelState.IsValid) {
                return View(viewModel);
            }
            try {
                var usuario = new Usuario {
                    Nome = viewModel.Nome,
                    Email = viewModel.Email,
                    Objetivo = viewModel.Objetivo
                };
                _service.Cadastrar(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                ViewBag.Erro = ex.Message;
                return View(viewModel);
            }
        }

        // Rota: /Usuario/Editar/5
        [Route("Editar/{id}")]
        public IActionResult Edit(int id) {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null) return NotFound();

            var viewModel = new UsuarioEditViewModel {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Objetivo = usuario.Objetivo
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public IActionResult Edit(int id, UsuarioEditViewModel viewModel) {
            if (id != viewModel.Id) return NotFound();
            if (!ModelState.IsValid) {
                return View(viewModel);
            }
            try {
                var usuario = new Usuario {
                    Id = viewModel.Id,
                    Nome = viewModel.Nome,
                    Email = viewModel.Email,
                    Objetivo = viewModel.Objetivo
                };
                _service.Atualizar(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                ViewBag.Erro = ex.Message;
                return View(viewModel);
            }
        }

        // Rota: /Usuario/Excluir/5
        [Route("Excluir/{id}")]
        public IActionResult Delete(int id) {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null) return NotFound();
            return View(usuario); // A view de delete ainda usa a Entidade, o que está OK.
        }

        [HttpPost]
        [Route("Excluir/{id}")]
        [ActionName("Delete")] // Mantém o ActionName para o formulário
        public IActionResult ConfirmDelete(int id) {
            _service.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}