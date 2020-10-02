using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace GEFALA.Controllers
{
    public class RespondedorController : Controller
    {
        //
        // GET: /Respondedor/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(AdministradorViewModel respondedor)
        {
            AdministradorViewModel resp = RespondedorRepository.getInstance().GetByAccount(respondedor.Nome, respondedor.Senha);
            if (resp != null)
            {
                RespondedorRepository Repository = RespondedorRepository.getInstance();

                Session["usuario"] = respondedor.Nome;
                Session["userName"] = "Wellcome " + respondedor.Nome + "!!";
                return RedirectToAction("ListarMensagens", "Mensagem");
            }
            else
            {
                return RedirectToAction("LoginInvalido", "Respondedor");
            }
        }

        public ActionResult LoginInvalido()
        {
            return View();
        }

        public ActionResult LoginValido()
        {
            return View();
        }
    }
}