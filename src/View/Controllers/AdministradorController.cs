using GEFALA.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GEFALA.Controllers
{
    [AuthenticationFilter]
    public class AdministradorController : Controller
    {
        /*Metódo usado para elaboração de paginação no mural de recados do Admistrador Geral
         *
         */

        public ActionResult Index(int? page)
        {
            const int pageSize = 10;

            var respostas = RespostaRepository.getInstance().ListAll();

            var paginatedrespostas = respostas.Skip((page ?? 0) * pageSize)
            .Take(pageSize)
            .ToList();

            return View(paginatedrespostas);
        }

        /*Metódo usado para elaboração de paginação no mural de recados do Admistrador Geral
         *
         *
         */

        public ActionResult MostrarMuralDeMensagensAdmistrador(int? page)
        {
            const int pageSize = 10;
            //List<Resposta> respostas = RespostaRepository.getInstance().ListAll().Skip((page) * pageSize)
            //   .Take(pageSize).ToList();

            var upcomingAnswers = RespostaRepository.getInstance().ListAll();
            //var paginatedrespostas = upcomingAnswers.Skip(10).Take(20).ToList();

            var paginatedrespostas = new PaginatedList<Resposta>(upcomingAnswers, page ?? 0, pageSize);
            return View(paginatedrespostas);
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        [AuthenticationFilter]
        public ActionResult MostrarMensagemParaAdmistrador()
        {
            MensagemRepository msgRepository = MensagemRepository.getInstance();
            List<Mensagem> mensagens = msgRepository.ListAll();
            return View(mensagens);
        }
    }
}