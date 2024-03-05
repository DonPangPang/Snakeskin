namespace Snakeskin.Core;

public interface ISnakeskinGenerator
{
    
}

public interface ISnakeskinGenerator<T>: ISnakeskinGenerator
{
    T Generate();
}

public interface IPasswordSnakeskinGenerator:ISnakeskinGenerator<string>
{
}

public interface IPhoneSnakeskinGenerator:ISnakeskinGenerator<string>
{
}

public interface IUrlSnakeskinGenerator:ISnakeskinGenerator<string>
{
}

public interface IUriSnakeskinGenerator:ISnakeskinGenerator<Uri>
{
}

public interface IIPAddressSnakeskinGenerator:ISnakeskinGenerator<string>
{
}

public interface IByteSnakeskinGenerator:ISnakeskinGenerator<byte>
{
}

public interface IBooleanSnakeskinGenerator:ISnakeskinGenerator<bool>
{

}

public interface IDateTimeSnakeskinGenerator:ISnakeskinGenerator<DateTime>
{

}

public interface IGuidSnakeskinGenerator:ISnakeskinGenerator<Guid>
{

}

public interface IEnumSnakeskinGenerator: ISnakeskinGenerator<Enum>
{

}

public interface INumberSnakeskinGenerator: ISnakeskinGenerator
{

}

public interface IInitSnakeskinGenerator: ISnakeskinGenerator<int>, INumberSnakeskinGenerator
{
    
}

public interface IIntSnakeskinGenerator: ISnakeskinGenerator<long>, INumberSnakeskinGenerator
{
    
}

public interface IFloatSnakeskinGenerator: ISnakeskinGenerator<float>, INumberSnakeskinGenerator
{
    
}

public interface IDoubleSnakeskinGenerator: ISnakeskinGenerator<double>, INumberSnakeskinGenerator
{
    
}

public interface IDecimalSnakeskinGenerator: ISnakeskinGenerator<decimal>, INumberSnakeskinGenerator
{
    
}