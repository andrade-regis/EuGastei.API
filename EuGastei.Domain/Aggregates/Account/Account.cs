namespace EuGastei.Domain.Aggregates.Account;

public class Account
{
       public string Email { get; private set; }
       public string Password { get; private set; }

       private Account(){}

       public void CreateAccount(string email, string password)
       {
              if (string.IsNullOrEmpty(email) || 
                  string.IsNullOrEmpty(password))
                  throw new InvalidOperationException("E-mail ou senha está vazio");
              
              Email = email;
              Password = password;
       }
}