//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _190410_BlogV1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uyeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uyeler()
        {
            this.Makaleler = new HashSet<Makaleler>();
            this.Yorumlar = new HashSet<Yorumlar>();
        }
    
        public int UyelerID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Kullanicisifresi { get; set; }
        public string MailAdres { get; set; }
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public Nullable<bool> Yazarmi { get; set; }
        public Nullable<int> YetkiID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makaleler> Makaleler { get; set; }
        public virtual Yetkiler Yetkiler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlar { get; set; }
    }
}
