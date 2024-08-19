using Azure.Identity;
using Microsoft.Graph;

namespace ConsoleApp1
{
    public class GraphClient
    {
        public GraphServiceClient CreateClient()
        {
			try
			{
                var scopes = new[] { "https://graph.microsoft.com/.default" };

                // Multi-tenant apps can use "common",
                // single-tenant apps must use the tenant ID from the Azure portal
                var tenantId = "your_tenant_id";

                // Value from app registration
                var clientId = "your_client_id";

                var clientSecret = "your_client_secret";

                // using Azure.Identity;
                var options = new ClientSecretCredentialOptions
                {
                    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
                };

                //// https://learn.microsoft.com/dotnet/api/azure.identity.devicecodecredential
                //var deviceCodeCredential = new DeviceCodeCredential(options);

                // https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
                var clientSecretCredential = new ClientSecretCredential(
                    tenantId, clientId, clientSecret, options);

                var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

                return graphClient;
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
