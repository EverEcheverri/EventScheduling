namespace EventScheduling.Domain.SharedKernel.ValueObjects;

using Exceptions;

public sealed class GuidValueObject
{
  private readonly Guid _guid;

  public GuidValueObject(Guid guid)
  {
    if (!Guid.TryParse(guid.ToString(), out _))
    {
      throw new NoValidCountryIdException();
    }

    _guid = guid;
  }

  public static implicit operator GuidValueObject(Guid value)
  {
    return new GuidValueObject(value);
  }

  public static implicit operator Guid(GuidValueObject guid)
  {
    return guid._guid;
  }
}
