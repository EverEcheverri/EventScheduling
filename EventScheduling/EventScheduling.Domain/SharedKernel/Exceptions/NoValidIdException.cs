namespace EventScheduling.Domain.SharedKernel.Exceptions;

public class NoValidIdException : BusinessException
{
    public NoValidIdException() : base("Id is null or empty")
    {
    }
}
