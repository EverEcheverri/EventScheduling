namespace EventScheduling.Domain.SharedKernel.Exceptions;

public class NameNullOrEmptyException : BusinessException
{
  public NameNullOrEmptyException() : base("Name is null or empty")
  {
  }
}
