namespace DietApp.Application.Common.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email) 
            : base($"Bu email adresi ({email}) başka bir kullanıcı tarafından kullanılıyor.")
        {
        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid userId) 
            : base($"Kullanıcı bulunamadı. (ID: {userId})")
        {
        }
    }
} 