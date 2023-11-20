using ConsoleAppMinimumMaximumExclusive.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json;

Console.WriteLine("***** Testes com .NET 8 | MinimumIsExclusive e MaximumIsExclusive *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

var anosEraComum = new AnoEraComum[]
{
    new() { Valor = 476, FatoRelevante = "Queda do Imperio Romano do Ocidente" },
    new() { Valor = 1492, FatoRelevante = "Descoberta da America" },
    new() { Valor = 0, FatoRelevante = "Ano invalido" }
};
foreach (var anoEraComum in anosEraComum)
    ValidarAno<AnoEraComum>(anoEraComum);

var anosEraAnteriorComum = new AnoAnteriorEraComum[]
{
    new() { Valor = 0, FatoRelevante = "Outro ano invalido" },
    new() { Valor = -753, FatoRelevante = "Fundacao de Roma" },
    new() { Valor = -2500, FatoRelevante = "Construcao da Grande Esfinge" }
};
foreach (var anoEraAnteriorComum in anosEraAnteriorComum)
    ValidarAno<AnoAnteriorEraComum>(anoEraAnteriorComum);

static void ValidarAno<T>(T ano)
{
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(ano));
    var validationResults = new List<ValidationResult>();
    if (!Validator.TryValidateObject(ano!, new ValidationContext(ano!),
        validationResults, validateAllProperties: true))
    {
        Console.WriteLine("Dados invalidos para essa instancia...");
        foreach (var validationResult in validationResults)
            Console.WriteLine($"ErrorMessage = {validationResult.ErrorMessage}");
    }
}