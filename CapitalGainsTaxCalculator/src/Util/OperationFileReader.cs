using CapitalGainsTaxCalculator.Models;
using Newtonsoft.Json;

namespace CapitalGainsTaxCalculator.Util;

public class OperationFileReader
{
    public List<OperationDto> ReadOperationsFromFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var operationsDto = JsonConvert.DeserializeObject<List<OperationDto>>(jsonData);

        if (operationsDto == null)
        {
            throw new InvalidOperationException("Erro ao carregar as operações do arquivo JSON.");
        }

        return operationsDto;
    }
}