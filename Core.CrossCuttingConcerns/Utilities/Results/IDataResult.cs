namespace Core.CrossCuttingConcerns.Utilities.Result;

public interface IDataResult<T>:IResult
{
    T Data { get; }
}
