using CompraAi.Dominio.Exemplos;
using CompraAi.Repositorios.Exemplos.Interfaces;
using CompraAi.Servicos.Exemplo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompraAi.Servicos.Exemplo
{
    public class TempoServico : ITempoServico
    {
        private readonly ITempoRepositorio _tempoRepositorio;
        public TempoServico(ITempoRepositorio tempoRepositorio)
        {
            _tempoRepositorio = tempoRepositorio 
                ?? throw new ArgumentNullException(nameof(ITempoRepositorio), "O parâmetro não pode ser nulo.");
        }

        public List<Tempo> RetornarTodos()
        {
            return _tempoRepositorio.RetornarTodos();
        }
    }
}
