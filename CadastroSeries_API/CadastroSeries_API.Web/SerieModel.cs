using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace CadastroSeries_API.Web
{
    public class SerieModel
    {
        public int Id { get; set; }
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }
        public SerieModel() { }

        public SerieModel(Serie serie)
        {
            Id = serie.retornaId();
            Genero = serie.retornaGenero();
            Titulo = serie.retornaTitulo();
            Sinopse = serie.retornaDescricao();
            Ano = serie.retornaAno();
            Excluido = serie.retornaExcluido();
        }

        public Serie ToSerie()
        {
            return new Serie(Id, Genero, Titulo, Sinopse, Ano);
        }

    }
}
