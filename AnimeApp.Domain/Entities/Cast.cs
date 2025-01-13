using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Domain.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimeShowId { get; set; }

        public AnimeShow AnimeShow { get; set; }
    }
}
