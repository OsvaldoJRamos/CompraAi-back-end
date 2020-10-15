using System;

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
                throw new ArgumentNullException(nameof(FamiliaId),$"{nameof(FamiliaId)} não pode ser nulo.");

            if (UsuarioId == null)
                throw new ArgumentNullException(nameof(FamiliaId), $"{nameof(UsuarioId)} não pode ser nulo.");

            if (StatusId == null)
                throw new ArgumentNullException(nameof(FamiliaId), $"{nameof(StatusId)} não pode ser nulo.");

            if (string.IsNullOrEmpty(Descricao))
                throw new ArgumentNullException(nameof(Descricao), $"{Descricao} não pode ser vazio ou nulo.");
        }
    }
}
