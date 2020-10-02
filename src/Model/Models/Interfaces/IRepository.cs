using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T value);
        void Update(T value);
        void Remove(T value);
        IList<T> ListAll();

    }

}
