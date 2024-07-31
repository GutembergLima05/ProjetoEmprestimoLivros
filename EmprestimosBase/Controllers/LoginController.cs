using EmprestimosBase.DTO;
using EmprestimosBase.Services.LoginService;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosBase.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginInterface _loginInterface;
        public LoginController(ILoginInterface loginInterface)
        {
            _loginInterface = loginInterface;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDTO usuarioRegisterDTO)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _loginInterface.RegistrarUsuario(usuarioRegisterDTO);

                if (usuario.Status)
                {
                    TempData["MensagemSucesso"] = usuario.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View(usuarioRegisterDTO);
                }

                return RedirectToAction("Index");
            }else
            {
                return View(usuarioRegisterDTO);
            }
        }
    }
}
