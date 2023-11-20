using System.ComponentModel.DataAnnotations;

namespace ConsoleAppMinimumMaximumExclusive.Models;

public class AnoEraComum
{
    [Range(minimum: 0, maximum: int.MaxValue, MinimumIsExclusive = true)]
    public int Valor { get; set; }
    
    public string Ano => $"{Valor} d.C.";

    [Required]
    public string? FatoRelevante { get; set; }
}

public class AnoAnteriorEraComum
{
    [Range(minimum: int.MinValue, maximum: 0, MaximumIsExclusive = true)]
    public int Valor { get; set; }

    public string Ano => $"{Valor * -1} a.C.";

    [Required]
    public string? FatoRelevante { get; set; }
}
