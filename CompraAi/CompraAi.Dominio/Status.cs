using CompraAi.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraAi.Dominio
{
    public class Status : EntidadeBase
    {
        public Guid StatusId { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public string Nome { get; set; }

        public override void Validar()
        {
        }
    }
}
