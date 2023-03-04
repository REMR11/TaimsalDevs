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

    public int? IdRol { get; set; }

    [StringLength(30)]
    public string NameUser { get; set; } = null!;

    [StringLength(30)]
    public string LastNameUser { get; set; } = null!;
    [Key]
    [StringLength(25)]
    public string Login { get; set; } = null!;

    [StringLength(32)]
    public string Password { get; set; } = null!;

    [Column("Status_User")]
    public byte StatusUser { get; set; }

    public DateTime RegistrationUser { get; set; }
    [ForeignKey("IdRol")]
    [InverseProperty("UserDevs")]
    public virtual Rol? IdRolNavigation { get; set; } = null!;

    [InverseProperty("IdUserNavigation")]
    public virtual ICollection<Report> Reports { get; } = new List<Report>();

    [NotMapped]
    public int Top_Aux { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Confirmar el password")]
    [StringLength(32, ErrorMessage = "Password debe estar entre 5 a 32 caracteres", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password y confirmar password deben de ser iguales")]
    [Display(Name = "Confirmar password")]
    public string ConfirmPassword_aux { get; set; }
    public enum Status_Users
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}
