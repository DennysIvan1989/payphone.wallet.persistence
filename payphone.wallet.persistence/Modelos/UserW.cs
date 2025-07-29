using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace payphone.wallet.persistence.Modelos;

[Table("UserW")]
public partial class UserW
{
    [Key]
    [Column("cod")]
    [StringLength(20)]
    [Unicode(false)]
    public string Cod { get; set; } = null!;

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("createAt")]
    public DateTime CreateAt { get; set; }

    [Column("active")]
    public bool Active { get; set; }

    [InverseProperty("UserCreateNavigation")]
    public virtual ICollection<WalletMovement> WalletMovements { get; set; } = new List<WalletMovement>();

    [InverseProperty("UserCreateNavigation")]
    public virtual ICollection<Wallet> WalletUserCreateNavigations { get; set; } = new List<Wallet>();

    [InverseProperty("UserUpdateNavigation")]
    public virtual ICollection<Wallet> WalletUserUpdateNavigations { get; set; } = new List<Wallet>();
}
