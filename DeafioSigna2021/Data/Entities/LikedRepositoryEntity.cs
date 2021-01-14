using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Data.Entities
{
    public class LikedRepositoryEntity
    {
        public int IdRepositorio { get; set; }
        public string NomeRepositorio { get; set; }
        public string Descricao { get; set; }
        public string UrlHttp { get; set; }
        public string Linguagem { get; set; }
    }
}
