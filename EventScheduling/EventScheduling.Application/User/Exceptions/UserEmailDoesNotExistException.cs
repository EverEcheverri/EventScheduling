namespace EventScheduling.Application.User.Exceptions;

using Domain.SharedKernel.Exceptions;

public class UserEmailDoesNotExistException : BusinessException
{
  public UserEmailDoesNotExistException(string email)
    : base($"the email {email} does not exist")
  {
  }
}
