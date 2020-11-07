using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraAi.Api.ViewModel
{
    public class ItemViewModel
    {
        public Guid ItemId { get; set; }
        public Guid FamiliaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
        public byte[] ImagemProduto { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
    }
}
