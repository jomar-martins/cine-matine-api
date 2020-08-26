using System.Collections;
using System.Collections.Generic;

namespace cine_matine_api.Models
{
    public class FilmeModel
    {
        public int? Id { get; set; }
        public string NomeOriginal { get; set; }
        public string NomeBrasil { get; set; }
        public string Descricao { get; set; }
        public short Ano { get; set; }
        public string Diretor { get; set; }
        public string LinkDiretor { get; set; }
        public GeneroModel Genero { get; set; }
        public decimal Nota { get; set; }
        public string LinkImdb { get; set; }
        public string LinkAlternativo { get; set; }
        public string LinkYoutube { get; set; }
        public string ImageURI { get; set; } // https://css-tricks.com/data-uris/  //  System.Convert.ToBase64String()
        public IList<ComentarioModel> Comentarios { get; set; }
    }
}