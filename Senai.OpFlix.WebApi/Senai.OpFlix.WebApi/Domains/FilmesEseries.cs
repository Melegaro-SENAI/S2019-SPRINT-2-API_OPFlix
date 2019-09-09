using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class FilmesEseries
    {
        public int IdFilmesEseries { get; set; }
        public string Nome { get; set; }
        public DateTime DataLançamento { get; set; }
    }
}
