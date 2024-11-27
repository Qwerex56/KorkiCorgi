namespace KorkiCorgi.Models;

public class EducationMaterial {
    public int Id { get; set; }
    
    public PathString PathOnServer { get; set; }
    public PathString CustomClientPath { get; set; }
    
    public object MaterialType { get; set; }
    public string[] MaterialTags { get; set; }
    
    public int UserId { get; set; }
}