using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MovieDetailDto:IDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string CategoryName { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

    }
}
