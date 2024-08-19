using Microsoft.Graph.Models;

namespace ConsoleApp1
{
    public class CreateUser
    {
        public async Task NewUser()
        {
			try
			{
                Console.Write("Display Name: ");
                var displayName = Console.ReadLine();
                Console.Write("User Id (Email): ");
                var email = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();

                var requestBody = new User
                {
                    AccountEnabled = true,
                    DisplayName = displayName,
                    //MailNickname = id,
                    //UserPrincipalName = id + "@aposta1staging.onmicrosoft.com",
                    PasswordProfile = new PasswordProfile
                    {
                        ForceChangePasswordNextSignIn = true,
                        Password = password,
                    },
                    PasswordPolicies = "DisablePasswordExpiration",
                    Identities = new List<ObjectIdentity>
                    {
                        new ObjectIdentity()
                        {
                            SignInType = "emailAddress",
                            Issuer = "aposta1staging.onmicrosoft.com",
                            IssuerAssignedId = email
                        }
                    },
                    //AdditionalData = new Dictionary<string, object>
                    //{
                    //    { "personalId", "404.617.073-57" }
                    //}
                };

                var graphClient = new GraphClient().CreateClient();

                // To initialize your graphClient, see https://learn.microsoft.com/en-us/graph/sdks/create-client?from=snippets&tabs=csharp
                var result = await graphClient.Users.PostAsync(requestBody);

                //    var result = await graphClient.Users[]
                //.GetAsync();

                Console.WriteLine(result);
                Console.ReadLine();
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
