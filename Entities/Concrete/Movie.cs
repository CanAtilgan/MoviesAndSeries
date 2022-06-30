using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie: IEntity
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
    }
}
