using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL;

[Table("Rol")]
public partial class Rol
{
    [Key]
    public int IdRol { get; set; }

    [StringLength(30)]
    public string NameRol { get; set; } = null!;

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<UserDev> UserDevs { get; } = new List<UserDev>();
}
