//  @ Project :GEFALA Untitled
//  @ Date : 20/03/2013 20/03/2013
//  @ Author : Marcelo do Nascimento Rocha

using Models.Interfaces;
using System;

namespace GEFALA.Models
{
    public class Resposta 
    {
        public virtual int Id { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual string User { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Mensagem Mensagem { get; set; }
        public virtual Respondedor Respondedor { get; set; }
    }
}