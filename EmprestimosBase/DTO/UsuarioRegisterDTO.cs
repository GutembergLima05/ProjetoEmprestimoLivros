using System.ComponentModel.DataAnnotations;

namespace EmprestimosBase.DTO
{
    public class UsuarioRegisterDTO
    {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Sobrenome!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a Confirmação de Senha!")]
        [Compare("Senha", ErrorMessage = "As senhas precisam ser iguais!")]
        public string ConfirmaSenha { get; set; }
    }
}
