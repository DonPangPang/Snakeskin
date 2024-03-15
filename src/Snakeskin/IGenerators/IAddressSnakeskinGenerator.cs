namespace Snakeskin.IGenerators;

public interface IAddressSnakeskinGenerator: ISnakeskinGenerator
{
    string Generate();

    string GenerateCounty();
    string GenerateCity();
    string GenerateStreet();
    string GenerateHouseNumber();
}
