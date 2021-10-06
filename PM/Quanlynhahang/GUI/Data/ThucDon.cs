namespace GUI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDon")]
    public partial class ThucDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucDon()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMon { get; set; }

        [StringLength(50)]
        public string TenMon { get; set; }

        public int? MaLoai { get; set; }

        public int? DonGia { get; set; }

        [StringLength(50)]
        public string DVT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual NhomMon NhomMon { get; set; }
    }
}
