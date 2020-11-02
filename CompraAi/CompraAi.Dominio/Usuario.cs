using CompraAi.Dominio.Base;
using CompraAi.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompraAi.Dominio
{
    public class Usuario : EntidadeBase
    {
        public Usuario(string nome, string email)
        {

            Nome = nome;
            Email = email;
        }

        [Key]
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public bool EstaAtivo()
        {
            return ExcluidoEm == null || ExcluidoEm > DateTime.Now;
        }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ValidacaoEntidadeException("O nome do usuário não pode ser vazio ou nulo.", nameof(Nome));

            if (string.IsNullOrEmpty(Email))
                throw new ValidacaoEntidadeException("O endereço de e-mail do usuário não pode ser vazio ou nulo.", nameof(Email));
        }
    }
}
