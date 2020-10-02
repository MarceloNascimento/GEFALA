using GEFALA.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web;
using ViewModels;

namespace GEFALA.Controllers
{
    public class MensagemController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarMensagem(MensagemViewModel mensagem)
        {
            try
            {
                if (mensagem.Conteudo != null)
                {
                    MensagemRepository msgRepository = MensagemRepository.getInstance();
                    // FuncionarioRepository funcRepository = FuncionarioRepository.getInstance();
                    // funcRepository.Add(mensagem.Funcionario);
                    mensagem.Data = (DateTime.Now);
                    mensagem.hostName = HttpContext.Request.UserHostName.ToString();
                    msgRepository.Add(mensagem);
                    Session["erroConteudo"] = "";
                    return View();
                }
                else
                {
                    Session["erroConteudo"] = "O campo conteúdo é obrigatório";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*Este metódo libera a visualização de todas as mensagens para a Admistrador geral
         */

        [AuthenticationFilter]
        public ActionResult ListarMensagens()
        {
            List<Mensagem> mensagens = MensagemRepository.getInstance().ListAll();
            List<Mensagem> mensagens2 = new List<Mensagem>();

            foreach (var mensagensTratadas in mensagens)
            {
                if (mensagensTratadas.Conteudo.Length >= 40)
                {
                    mensagensTratadas.Conteudo = mensagensTratadas.Conteudo.Substring(0, 40);
                    mensagens2.Add(mensagensTratadas);
                }
                else
                {
                    mensagens2.Add(mensagensTratadas);
                }
            }

            return View(mensagens2);
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        [AuthenticationFilter]
        public ActionResult MostrarMensagemParaAdmistrador()
        {
            MensagemRepository msgRepository = MensagemRepository.getInstance();
            List<Mensagem> mensagens = msgRepository.ListAll();
            return View(mensagens);
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        /* Este é para o Admistrador responder a Mensagem
         */

        [HttpGet]
        [AuthenticationFilter]
        public ActionResult ResponderMensagemEnviadaAoAdmistrador(int Id)
        {
            MensagemRepository msgRepository = MensagemRepository.getInstance();
            Mensagem mensagem = msgRepository.GetById(Id);
            ViewBag.mensagem = mensagem;

            return View();
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        /* Este é para o Admistrador responder a Mensagem
         */

        [HttpPost]
        public ActionResult ProcessarMensagemRespondidaPeloAdmistrador(Resposta resposta)
        {
            RespostaRepository respRepository = RespostaRepository.getInstance();
            Mensagem mensagem = MensagemRepository.getInstance().GetById(resposta.Mensagem.Id);
            resposta.Mensagem = mensagem;
            resposta.Mensagem.Estatus = true;//utilizar true para mensagem que deverá ser ocultada do painel e false para a mensagem a listar.
            resposta.Mensagem.Respondida = true;// utilizar true para relatar a mensagem como respondida, e assim listar a mesma no mural.
            //mensagem.Resposta.Add(resposta);
            Respondedor respondedor = RespondedorRepository.getInstance().GetById(resposta.Respondedor.Id);
            resposta.Respondedor = respondedor;
            resposta.Data = (DateTime.Now);
            respRepository.Add(resposta);
            //MensagemRepository.getInstance().Update(mensagem);

            return RedirectToAction("ListarMensagens", "Mensagem");
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        /* Este é para o Admistrador ocultar a Mensagem que o mesmo não desejar responder
         */

        public ActionResult ocultarMensagemPeloAdmistrador(Mensagem mensagem)
        {
            MensagemRepository Repository = MensagemRepository.getInstance();
            Mensagem msg = Repository.GetById(mensagem.Id);
            msg.Estatus = true;
            Repository.Update(msg);

            return RedirectToAction("ListarMensagens", "Mensagem");
        }

        // Este método deverá ser validado para exigir login sempre que solicitado
        /* Este é para o Admistrador responder a Mensagem
         */

        public ActionResult MostrarMuralDeMensagens()
        {
            List<Resposta> respostas = RespostaRepository.getInstance().ListParaMural(User.Identity.Name);
            return View(respostas);
        }
    }
}