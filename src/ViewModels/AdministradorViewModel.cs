using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AdministradorViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Matricula { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Setor { get; set; }
        public virtual IList<RespostaViewModel> Respostas { get; set; }
    }
}
