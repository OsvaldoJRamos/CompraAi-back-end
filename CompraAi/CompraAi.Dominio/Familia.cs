using System;

namespace CompraAi.Dominio
{
    public class Familia
    {
        public Familia(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public Guid FamiliaId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime? AlteradoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public bool ValidarFamilia()
        {
            var valido = true;

            if (Codigo.Length > 10 ||
                Nome.Length > 30)
                valido = false;

            return valido;
        }
    }
}
