using BCrypt.Net;

namespace dotnet_store_test.Tools
{
    public class LoginTools
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public bool VerifyPassword(string raw_password, string password2)
        {
            return BCrypt.Net.BCrypt.Verify(raw_password, password2);
        }
    }
}
