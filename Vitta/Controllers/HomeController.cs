// Vitta/Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vitta.Models; // Necessário para o ErrorViewModel

namespace Vitta.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        // 1. O construtor é corrigido para Injeção de Dependência (DI)
        // Ele só pede o ILogger, que é o padrão.
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        // 2. A Action Index (GET) apenas retorna a View da homepage.
        // A lógica de listar usuários foi REMOVIDA daqui.
        public IActionResult Index() {
            return View();
        }

        // 3. A Action Index (POST) de cadastro foi COMPLETAMENTE REMOVIDA daqui.
        // O lugar dela é no UsuarioController.

        // (Opcional, mas padrão do template)
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}