using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PCStore.Domain.PCStoreEntities;

public partial class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Father { get; set; }
    [RegularExpression(@"^\\+?3?8?(0\\d{9})$")]
    public string Phone { get; set; }= null!;
    [EmailAddress]
    public string Email { get; set; }=null!;
    public string Role { get; set; }
}
