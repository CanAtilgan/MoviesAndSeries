using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Series:IEntity
    {
        public int Id { get; set; }
        public string SeriesName { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Seaseon { get; set; }
        public string Photo { get; set; }
    }
}
