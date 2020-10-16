using CompraAi.Dominio.Validacoes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CompraAi.Dominio
{
    public class Familia
    {
        public Familia(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        [Key]
        public Guid FamiliaId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public void Validar()
        {
            if (Codigo.Length > 10)
            {
                throw new ValidacaoEntidadeException(
                    "O código da família não pode ter tamanho menor do que 10 caracteres.",
                    nameof(Codigo));
            }

            if (Nome.Length > 30)
            {
                throw new ValidacaoEntidadeException(
                    "O nome da família não pode ter tamanho menor do que 30 caracteres.",
                    nameof(Nome));
            }
        }
    }
}
