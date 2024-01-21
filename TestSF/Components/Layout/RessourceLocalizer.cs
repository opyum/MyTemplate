using System.Text.Json;

namespace CoolPlanner.Web.Components
{
    public class RessourceLocalizer
    {
        // To get the locale key from mapped resources file

        public string? GetText(string key)
        {
            var culture = Thread.CurrentThread.CurrentUICulture;
            return this.ResourceManager.GetString(key, culture);
        }

        // To access the resource file and get the exact value for locale key

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return CrossCutting.ResourcesText.ResourceManager;
            }
        }
    }
}
