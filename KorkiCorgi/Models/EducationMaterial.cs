using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(EducationMaterialEntityTypeConfiguration))]
public class EducationMaterial {
    public int Id { get; init; }
    
    public string PathOnServer { get; init; }
    public string CustomClientPath { get; set; }
    
    public ICollection<string> MaterialTags { get; init; }
    
    public int UserId { get; init; }
}