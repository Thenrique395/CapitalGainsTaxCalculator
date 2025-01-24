using System.Globalization;
using CapitalGainsTaxCalculator.Models;
using CapitalGainsTaxCalculator.Util;
using Newtonsoft.Json;

namespace CapitalGainsTaxCalculator;

class Program
{
    public static void Main(string[] args)
    {
        var jsonFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "src", "DataJson", "operations.json");
        Console.WriteLine($"Caminho do arquivo JSON: {jsonFilePath}");

        try
        {
            var operationFileReader = new OperationFileReader();
            var operationsDto = operationFileReader.ReadOperationsFromFile(jsonFilePath);

            if (operationsDto is null || operationsDto.Count == 0)
            {
                Console.WriteLine("Nenhuma operação encontrada no arquivo JSON.");
                return;
            }

            var operations = OperationMapper.MapToOperations(operationsDto);

            var calculator = new Services.CapitalGainsTaxCalculator();
            var results = calculator.ProcessOperations(operations);

            var cultureInfo = new CultureInfo("pt-BR");

            foreach (var result in results)
            {
                Console.WriteLine($"Imposto: {result.TaxAmount.ToString("C2", cultureInfo)}, Valor Total: {result.TotalValue.ToString("C2", cultureInfo)}");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Erro: Arquivo não encontrado. Detalhes: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao processar o arquivo JSON. Detalhes: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
        }
    }
}