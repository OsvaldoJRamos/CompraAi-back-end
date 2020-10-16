using CompraAi.Dominio.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompraAi.Dominio
{
    public class Convite : EntidadeBase
    {
        public Convite(Guid usuarioId, Guid familiaId)
        {
            UsuarioId = usuarioId;
            FamiliaId = familiaId;

            ExpiraEm = CriadoEm.AddDays(4);
        }

        [Key]
        public Guid ConviteId { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public Guid FamiliaId { get; set; } = Guid.NewGuid();
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }
        public DateTime ExpiraEm { get; set; }
        public bool Usado { get; set; } = false;

        public override void Validar()
        {
            if (FamiliaId == null)
                throw new ValidacaoEntidadeException("O ID da família não pode ser nulo.", nameof(FamiliaId));

            if (UsuarioId == null)
                throw new ValidacaoEntidadeException("O ID do usuário não pode ser nulo.", nameof(UsuarioId));
        }
    }
}
