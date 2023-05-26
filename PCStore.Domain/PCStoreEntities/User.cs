using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PCStore.Domain.PCStoreEntities;

public partial class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = null!;
    [BsonElement("UserName")]
    public string UserName { get; set; }=null!;
    [BsonElement("Password")]
    public string? Password { get; set; }
    [BsonElement("FirstName")]
    public string FirstName { get; set; } = null!;
    [BsonElement("LastName")]
    public string LastName { get; set; } = null!;
    [BsonElement("Father")]
    public string? Father { get; set; }
    [BsonElement("Phone")]
    [RegularExpression(@"^\\+?3?8?(0\\d{9})$")]
    public string Phone { get; set; }= null!;
    [BsonElement("Email")]
    [EmailAddress]
    public string Email { get; set; }=null!;
    [BsonElement("Role")]
    public string Role { get; set; } = null!;
}
