using GEFALA.Models;
using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class RespostaViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual string User { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Mensagem Mensagem { get; set; }
        public virtual Respondedor Respondedor { get; set; }
    }
}