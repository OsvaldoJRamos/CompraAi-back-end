using System;

namespace CompraAi.Dominio.Base
{
    public abstract class EntidadeBase
    {
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public abstract void Validar();
    }
}
