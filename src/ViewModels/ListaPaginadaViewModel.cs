using System;
using System.Collections.Generic;
using System.Linq;

namespace GEFALA.Models
{
    public class ListaPaginadaViewModel<T> : List<T>
    {
        public int IndicePagina { get; private set; }
        public int TamanhoPagina { get; private set; }
        public int Total { get; private set; }
        public int TotalPagina { get; private set; }

        public List<T> Dados { get; set; }


        public ListaPaginadaViewModel(IList<T> source, int indicePagina, int tamanhoPagina)
        {
            IndicePagina = indicePagina;
            TamanhoPagina = tamanhoPagina;
            Total = source.Count();
            TotalPagina = (int)Math.Ceiling(Total / (double)TamanhoPagina);

            this.AddRange(source.Skip(IndicePagina * TamanhoPagina).Take(TamanhoPagina));
        }

        public bool HasPreviousPage
        {
            get
            {
                return (IndicePagina > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (IndicePagina + 1 < TotalPagina);
            }
        }
    }
}