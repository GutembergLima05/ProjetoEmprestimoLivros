using EmprestimosBase.Data;
using EmprestimosBase.DTO;
using EmprestimosBase.Models;
using EmprestimosBase.Services.SenhaService;
using Npgsql.Replication;

namespace EmprestimosBase.Services.LoginService
{
    public class LoginService : ILoginInterface
    {

        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public LoginService(ApplicationDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDTO usuarioRegisterDTO)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificarSeEmailExiste(usuarioRegisterDTO))
                {
                     response.Mensagem = "Email/Usuário Cadastrado!";
                     response.Status = false;
                     return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDTO.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel
                {
                    Nome = usuarioRegisterDTO.Nome,
                    Sobrenome = usuarioRegisterDTO.Sobrenome,
                    Email = usuarioRegisterDTO.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário Cadastrado Com Sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }


        private bool VerificarSeEmailExiste(UsuarioRegisterDTO usuarioRegisterDTO)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDTO.Email);

            if (usuario == null)
            {
                return false;
            }

            return true;
        }
    }
}
