using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SystemTaimsalDevs.EL;

[Table("Client")]
public partial class Client
{
    [Key]
    public int IdClient { get; set; }

    [StringLength(40)]
    public string NameClient { get; set; } = null!;

    [StringLength(10)]
    public string PhoneNumber { get; set; } = null!;

    [InverseProperty("IdClientNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();
}
