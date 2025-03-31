using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    [Column("FeedbackID")]
    public int FeedbackId { get; set; }

    [Column("HocSinhID")]
    public int HocSinhId { get; set; }

    [Column("LopHocID")]
    public int? LopHocId { get; set; }

    [Column("GiaSuID")]
    public int? GiaSuId { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal DiemSo { get; set; }

    [StringLength(1000)]
    public string? NhanXet { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayDanhGia { get; set; }

    [ForeignKey("GiaSuId")]
    [InverseProperty("Feedbacks")]
    public virtual GiaSu? GiaSu { get; set; }

    [ForeignKey("HocSinhId")]
    [InverseProperty("Feedbacks")]
    public virtual HocSinh HocSinh { get; set; } = null!;

    [ForeignKey("LopHocId")]
    [InverseProperty("Feedbacks")]
    public virtual LopHoc? LopHoc { get; set; }
}
