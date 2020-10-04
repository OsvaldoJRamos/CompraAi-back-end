using System;

namespace CompraAi.Dominio
{
    public class Convite
    {
        public Convite(Guid usuarioId, Guid familiaId)
        {
            UsuarioId = usuarioId;
            FamiliaId = familiaId;

            ExpiraEm = CriadoEm.AddDays(4);
        }

        public Guid ConviteId { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public Guid FamiliaId { get; set; } = Guid.NewGuid();
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public DateTime ExpiraEm { get; set; }
        public bool Usado { get; set; } = false;
    }
}
