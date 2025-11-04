// Vitta/ViewModels/UsuarioCreateViewModel.cs
using System.ComponentModel.DataAnnotations; // Precisamos disso para as validações

namespace Vitta.ViewModels {
    public class UsuarioCreateViewModel {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        public string Objetivo { get; set; } = string.Empty;
    }
}