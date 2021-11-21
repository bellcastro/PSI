using System;
using System.Collections.Generic;

namespace NutriMais.Models
{
    public class PlanoAtualViewModel
    {
        public PlanosModel Plano { get; set;}
        public IEnumerable<PlanoSemanalModel> PlanosSemanais { get; set; }

		public PlanoAtualViewModel(IEnumerable<PlanoSemanalModel> planosSemanais, PlanosModel plano)
        {
            PlanosSemanais = planosSemanais;
            Plano = plano;
        }
    }
}
