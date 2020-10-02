 
//  @ Project : GEFALAUntitled
//  @ Date : 20/03/2013 20/03/2013
//  @ Author : Marcelo do Nascimento Rocha

using System.Collections.Generic;

namespace GEFALA.Models
{
    public class Respondedor
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Matricula { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Setor { get; set; }
        public virtual IList<Resposta> Respostas { get; set; }
    }
}