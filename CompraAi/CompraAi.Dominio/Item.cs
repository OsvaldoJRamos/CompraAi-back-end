using CompraAi.Dominio.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompraAi.Dominio
{
    public class Item
    {
        public Item(Guid familiaId, Guid usuarioId, string descricao)
        {
            FamiliaId = familiaId;
            UsuarioId = usuarioId;
            Descricao = descricao;
        }

        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();
        public Guid FamiliaId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
        public byte[] ImagemProduto { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public void Validar()
        {
            if (FamiliaId == null)
                throw new ValidacaoEntidadeException("O ID da família não pode ser nulo.", nameof(FamiliaId));

            if (UsuarioId == null)
                throw new ValidacaoEntidadeException("O ID do usuário não pode ser nulo.", nameof(UsuarioId));

            if (StatusId == null)
                throw new ValidacaoEntidadeException("O ID do status não pode ser nulo.", nameof(StatusId));

            if (string.IsNullOrEmpty(Descricao))
                throw new ValidacaoEntidadeException("A descrição não pode ser vazia ou nula.", nameof(Descricao));
        }
    }
}
