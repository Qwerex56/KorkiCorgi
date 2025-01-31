using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KorkiCorgi.DataTransferObjects;

public class SearchFilterDto {
    public string? Title { get; set; }
    public string? City { get; set; }
    public string? Class { get; set; }
    public bool? IsOnline { get; set; }
    public int? CostMin { get; set; }
    public int? CostMax { get; set; }

    public string BuildQueryString() {
        var stringBuilder = new StringBuilder("?");
        List<string> s = [];
        
        foreach (var prop in GetType().GetProperties()) {
            var val = prop.GetValue(this);
            
            if (val is null) continue;
            
            s.Add($"{prop.Name}={val}");
        }
        stringBuilder.AppendJoin("&", s);
        return stringBuilder.ToString();
    }
}