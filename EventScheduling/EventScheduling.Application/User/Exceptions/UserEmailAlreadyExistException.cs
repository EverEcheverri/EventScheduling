namespace EventScheduling.Application.User.Exceptions;

using Domain.SharedKernel.Exceptions;

public class UserEmailAlreadyExistException : BusinessException
{
  public UserEmailAlreadyExistException(string email)
    : base($"the email {email} already exist")
  {
  }
}
