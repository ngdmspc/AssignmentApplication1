using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("HocSinh")]
[Index("SoDienThoai", Name = "UQ__HocSinh__0389B7BD1387A370", IsUnique = true)]
[Index("Email", Name = "UQ__HocSinh__A9D1053425ADCCD5", IsUnique = true)]
public partial class HocSinh
{
    [Key]
    [Column("HocSinhID")]
    public int HocSinhId { get; set; }

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string MatKhau { get; set; } = null!;

    [StringLength(20)]
    public string? SoDienThoai { get; set; }

    [InverseProperty("HocSinh")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    [InverseProperty("HocSinh")]
    public virtual ICollection<HocSinhLopHoc> HocSinhLopHocs { get; set; } = new List<HocSinhLopHoc>();
}
