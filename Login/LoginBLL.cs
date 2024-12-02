using POO_25453_TP.DAL;

namespace POO_25453_TP.BLL
{
    public class LoginBLL
    {
        // Authenticates a user based on their type
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
