using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("LopHoc")]
public partial class LopHoc
{
    [Key]
    [Column("LopHocID")]
    public int LopHocId { get; set; }

    [Column("GiaSuID")]
    public int GiaSuId { get; set; }

    [StringLength(255)]
    public string TenMonHoc { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ThoiGianBatDau { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ThoiGianKetThuc { get; set; }

    [StringLength(50)]
    public string TrangThai { get; set; } = null!;

    [InverseProperty("LopHoc")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    [ForeignKey("GiaSuId")]
    [InverseProperty("LopHocs")]
    public virtual GiaSu GiaSu { get; set; } = null!;

    [InverseProperty("LopHoc")]
    public virtual ICollection<HocSinhLopHoc> HocSinhLopHocs { get; set; } = new List<HocSinhLopHoc>();
}
