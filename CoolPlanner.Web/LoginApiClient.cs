using CoolPlanner.CrossCutting;
using System.Transactions;

namespace CoolPlanner.Web;

public class LoginApiClient(HttpClient httpClient)
{
    public async Task<bool> LoginUser(RegisterRequest request)
    {

        var response = await httpClient.PostAsJsonAsync("/register", request);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Donn�es envoy�es avec succ�s.");
            // Traitez la r�ponse si n�cessaire
        }
        else
        {
            Console.WriteLine($"Erreur : {response.StatusCode}");
        }
        return true;
    }
}


