using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FileRepo:IEntity
    {
        public int Id { get; set; }
        public int? AddedUserId { get; set; }
        public string? FileType { get; set; }
        public int? EntityId { get; set; }
        public string? Collection { get; set; }
        public string? FileName { get; set; }
        public bool? State { get; set; }
    }
}
