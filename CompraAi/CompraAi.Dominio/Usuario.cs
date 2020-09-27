using System;

namespace CompraAi.Dominio
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {

            Nome = nome;
            Email = email;
        }

        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }
    }
}
