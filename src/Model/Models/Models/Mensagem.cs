//  @ Project :GEFALA Untitled
//  @ Date : 20/03/2013 20/03/2013
//  @ Author : Marcelo do Nascimento Rocha

using System;
using System.ComponentModel.DataAnnotations;

namespace GEFALA.Models
{
    public class Mensagem
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo conte�do � obrigat�rio")]
        [StringLength(600, ErrorMessage = "Sua mensagem est� grande demais o campo conte�do permite apenas 600 caracteres")]
        public virtual string Conteudo { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Assunto � obrigat�rio")]
        public virtual string Assunto { get; set; }

        public virtual string Setor { get; set; }
        public virtual string User { get; set; }
        public virtual string hostName { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual Boolean Estatus { get; set; }
        public virtual Boolean Respondida { get; set; }
        public virtual Resposta Resposta { get; set; }

        //public void EnviarMenssagem()
        //{
        //}
    }
}