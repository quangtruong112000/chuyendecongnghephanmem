namespace GUI.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat()
        {
            CT_PhieuXuat = new HashSet<CT_PhieuXuat>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Ma_Phieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuXuat> CT_PhieuXuat { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
