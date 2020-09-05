using CompraAi.Dominio.Exemplos;
using CompraAi.Repositorios.Exemplos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompraAi.Repositorios.Exemplos
{
    public class TempoRepositorio : ITempoRepositorio
    {
        private static readonly string[] _tempo = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public List<Tempo> RetornarTodos()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Tempo
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _tempo[rng.Next(_tempo.Length)]
            })
            .ToList();
        }
    }
}
