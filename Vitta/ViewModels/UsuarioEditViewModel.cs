// Vitta/ViewModels/UsuarioEditViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace Vitta.ViewModels {
    public class UsuarioEditViewModel {
        // O Id é necessário para saber qual usuário estamos atualizando.
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        public string Objetivo { get; set; } = string.Empty;
    }
}