using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FileRequestDto: IDto
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Base64 { get; set; }
        public string DataType { get; set; }
        public string Collection{ get; set; }
        public string FileName{ get; set; }
    }
}
