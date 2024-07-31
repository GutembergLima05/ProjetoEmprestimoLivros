using EmprestimosBase.DTO;
using EmprestimosBase.Models;

namespace EmprestimosBase.Services.LoginService
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDTO usuarioRegisterDTO);
    }
}
