using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("GiaSu")]
[Index("SoDienThoai", Name = "UQ__GiaSu__0389B7BD74474506", IsUnique = true)]
[Index("Email", Name = "UQ__GiaSu__A9D105340626D763", IsUnique = true)]
public partial class GiaSu
{
    [Key]
    [Column("GiaSuID")]
    public int GiaSuId { get; set; }

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string MatKhau { get; set; } = null!;

    [StringLength(20)]
    public string SoDienThoai { get; set; } = null!;

    [StringLength(255)]
    public string? KinhNghiem { get; set; }

    [StringLength(255)]
    public string? BangCap { get; set; }

    [InverseProperty("GiaSu")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    [InverseProperty("GiaSu")]
    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
