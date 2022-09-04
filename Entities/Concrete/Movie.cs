using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie: IEntity
    {
        public int Id { get; set; }
        //? = VERİ TABANINDA KARŞILIĞI OLMAK ZORUNDA DEĞİLDİR DEMEKTİR.NULL OLABİLİR DEMEKTİR , BU SAYEDE İSTEK YAPILDIĞINDA NULL VALUED HATASI VERMEZ
        //YADA VERİ YAPANINDA O DEĞERLERİ NULL YAPILAMAZ DERSİN , BU İKİ ÇÖZÜMDEN BİRİSİ OLMALI 
        public int? CategoryId { get; set; }

        public string Photo { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
