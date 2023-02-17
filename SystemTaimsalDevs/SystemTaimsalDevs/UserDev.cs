using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL;

[Index("IdRol", Name = "IX_UserDevs_IdRol")]
public partial class UserDev
{
    [Key]
    public int IdUser { get; set; }

    public int IdRol { get; set; }

    [StringLength(30)]
    public string NameUser { get; set; } = null!;

    [StringLength(30)]
    public string LastNameUser { get; set; } = null!;

    [StringLength(25)]
    public string Login { get; set; } = null!;

    [StringLength(32)]
    public string Password { get; set; } = null!;

    [Column("Status_User")]
    public byte StatusUser { get; set; }

    public DateTime RegistrationUser { get; set; }
    [ForeignKey("IdRol")]
    [InverseProperty("UserDevs")]
    public virtual Rol IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
