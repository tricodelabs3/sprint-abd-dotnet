// Vitta/Controllers/UsuarioController.cs
using Microsoft.AspNetCore.Mvc;
using Vitta.Models;
using Vitta.Services;
using Vitta.ViewModels; // Importar o ViewModel

namespace Vitta.Controllers {
    public class UsuarioController : Controller {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service) {
            _service = service;
        }

        public IActionResult Index() {
            var usuarios = _service.ListarTodos();
            return View(usuarios);
        }

        // Mudança no CREATE

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(UsuarioCreateViewModel viewModel) // <-- Mudou para ViewModel
        {
            // 1. Verifica se as validações [Required], [EmailAddress] etc. passaram
            if (!ModelState.IsValid) {
                return View(viewModel); // Retorna à tela de cadastro com os erros
            }

            try {
                // 2. "Mapeia" o ViewModel para a Entidade
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



        public IActionResult Edit(int id) {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null) return NotFound();

            // Mapeia a Entidade para o ViewModel
            var viewModel = new UsuarioEditViewModel {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Objetivo = usuario.Objetivo
            };

            return View(viewModel); // Envia o ViewModel para a tela
        }

        // POST: /Usuario/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, UsuarioEditViewModel viewModel) {
            // Verifica se o ID da rota é o mesmo do ViewModel (segurança)
            if (id != viewModel.Id) return NotFound();

            // Verifica se as validações do ViewModel ([Required], etc.) passaram
            if (!ModelState.IsValid) {
                return View(viewModel); // Retorna para a tela de edição com os erros
            }

            try {
                // Mapeia o ViewModel de volta para a Entidade
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





        //DELETE
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
