namespace TestSF.Components.Pages.AI
{
    using OpenAI_API; // Assurez-vous d'importer l'espace de noms
    using OpenAI_API.Completions;

    public class OpenAIService
    {
        private OpenAIAPI openAIAPI;

        public OpenAIService()
        {
            // Configurer l'API avec votre clé d'API
            openAIAPI = new OpenAIAPI(new APIAuthentication(OpenAIConfiguration.ApiKey));
        }

        public async Task<string> GenerateTextAsync(string prompt)
        {
            //var response = await openAIAPI.Completions.CreateCompletionAsync(new CompletionRequest(prompt, model: new OpenAI_API.Models.Model("gpt-3.5-turbo")));
            //return response.ToString();
            return "[\r\n  {\r\n    \"Titre\": \"Soumission de la note de frais\",\r\n    \"Detail\": \"L'employé soumet sa note de frais accompagnée des justificatifs nécessaires via un système en ligne ou un formulaire physique.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Examen et approbation\",\r\n    \"Detail\": \"Le superviseur ou le gestionnaire examine la note de frais pour s'assurer de sa conformité avec les politiques de l'entreprise et l'approuve.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Traitement comptable\",\r\n    \"Detail\": \"Le département comptable traite la note de frais approuvée, en vérifiant les détails financiers et en saisissant les informations dans le système comptable.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Paiement\",\r\n    \"Detail\": \"Le remboursement est effectué au salarié par virement bancaire ou chèque, et le salarié reçoit une notification de paiement.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Archivage\",\r\n    \"Detail\": \"Les notes de frais traitées et les justificatifs sont archivés pour référence future et pour les audits.\"\r\n  }\r\n]";
        }       
        public string GenerateText(string prompt)
        {
            //var response = await openAIAPI.Completions.CreateCompletionAsync(new CompletionRequest(prompt, model: new OpenAI_API.Models.Model("gpt-3.5-turbo")));
            //return response.ToString();
            return "[\r\n  {\r\n    \"Titre\": \"Soumission de la note de frais\",\r\n    \"Detail\": \"L'employé soumet sa note de frais accompagnée des justificatifs nécessaires via un système en ligne ou un formulaire physique.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Examen et approbation\",\r\n    \"Detail\": \"Le superviseur ou le gestionnaire examine la note de frais pour s'assurer de sa conformité avec les politiques de l'entreprise et l'approuve.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Traitement comptable\",\r\n    \"Detail\": \"Le département comptable traite la note de frais approuvée, en vérifiant les détails financiers et en saisissant les informations dans le système comptable.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Paiement\",\r\n    \"Detail\": \"Le remboursement est effectué au salarié par virement bancaire ou chèque, et le salarié reçoit une notification de paiement.\"\r\n  },\r\n  {\r\n    \"Titre\": \"Archivage\",\r\n    \"Detail\": \"Les notes de frais traitées et les justificatifs sont archivés pour référence future et pour les audits.\"\r\n  }\r\n]";
        }
    }
}
