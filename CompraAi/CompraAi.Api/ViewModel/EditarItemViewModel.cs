using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraAi.Api.ViewModel
{
    public class EditarItemViewModel
    {
        public Guid ItemId { get; set; }
        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
    }
}
