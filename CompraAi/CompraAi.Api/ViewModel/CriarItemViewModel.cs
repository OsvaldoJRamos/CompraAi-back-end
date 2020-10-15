using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraAi.Api.ViewModel
{
    public class CriarItemViewModel
    {
        public Guid FamiliaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
        //public byte[] ImagemProduto { get; set; }
    }
}
