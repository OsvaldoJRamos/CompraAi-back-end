using CompraAi.Dominio.Base;
using CompraAi.Dominio.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompraAi.Dominio
{
    public class UsuarioFamilia : EntidadeBase
    {
        public UsuarioFamilia(Guid usuarioId, Guid familiaId)
        {
            UsuarioId = usuarioId;
            FamiliaId = familiaId;
        }

        [Key]
        public Guid UsuarioFamiliaId { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public Guid FamiliaId { get; set; } = Guid.NewGuid();
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public override void Validar()
        {
            if (FamiliaId == null)
                throw new ValidacaoEntidadeException("O ID da família não pode ser nulo.", nameof(FamiliaId));

            if (UsuarioId == null)
                throw new ValidacaoEntidadeException("O ID do usuário não pode ser nulo.", nameof(UsuarioId));
        }
    }
}
