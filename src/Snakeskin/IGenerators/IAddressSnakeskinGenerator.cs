using Snakeskin.Generators;

namespace Snakeskin.IGenerators;

public interface IAddressSnakeskinGenerator : ISnakeskinGenerator
{
    string Generate(AddressType addressType = AddressType.Full);

    string GenerateCounty();

    string GenerateCity();

    string GenerateStreet();

    string GenerateHouseNumber();
}