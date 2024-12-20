using POO_25453_TP.DAL;

namespace POO_25453_TP.BLL
{
    /// <summary>
    /// Business Logic Layer class for handling login authentication.
    /// </summary>
    public class LoginBLL
    {
        /// <summary>
        /// Authenticates a user based on their type (client or account).
        /// </summary>
        /// <param name="username">The username to authenticate.</param>
        /// <param name="password">The password to authenticate.</param>
        /// <param name="userType">The type of user ("client" or "account").</param>
        /// <returns>True if authentication is successful, false otherwise.</returns>
        public bool Authenticate(string username, string password, string userType)
        {
            if (userType == "client")
            {
                return Login.ValidateClientLogin(username, password);
            }
            else if (userType == "account")
            {
                return Login.ValidateAccountLogin(username, password);
            }

            return false; // Invalid userType
        }
    }
}
