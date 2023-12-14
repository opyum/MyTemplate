using CoolPlanner.CrossCutting;
using System.Text.Json;
using System.Transactions;

namespace CoolPlanner.Web;

public class LoginApiClient(HttpClient httpClient)
{
    public async Task<bool> RegisterUser(RegisterRequest request)
    {
        var data = JsonSerializer.Serialize(request);
        var test = httpClient.BaseAddress;
        var response = await httpClient.PostAsJsonAsync("register", request);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Donn�es envoyées avec succès.");
            // Traitez la r�ponse si n�cessaire
        }
        else
        {
            Console.WriteLine($"Erreur : {response.StatusCode}");
            return false;
        }
        return true;
    }
}


