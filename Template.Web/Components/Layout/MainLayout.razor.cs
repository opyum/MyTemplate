using MudBlazor;

namespace Template.Web.Components.Layout
{
    public partial class MainLayout
    {
        private bool _isDarkMode = true;

        private MudTheme _theme = Themes.CustomTheme;
        bool open = true;

        void ToggleDrawer()
        {
            Console.WriteLine("coucou");
            open = !open;
        }


    }

    public static class Themes
    {

        // Source : https://www.mudblazor.com/customization/default-theme#palette
        public static readonly MudTheme CustomTheme = new()
        {
            Palette = new PaletteLight()
            {

            },
            PaletteDark = new PaletteDark()
            {
                Primary = "rgba(208, 188, 255, 100)",          // Violet foncé     #7B1FA2
                Secondary = "rgba(204, 194, 220,100)",       // Rose clair       #F8BBD0
                Info = "rgba(33,150,243,1)",
                Success = "rgba(0,200,83,1)",
                Warning = "rgba(255,152,0,1)",
                Error = "rgba(244,67,54,1)",
                AppbarBackground = "rgba(28, 27,31,100)",
                AppbarText = "rgb(162, 162, 162)",
                TableHover = "rgba(0,0,0,0.0392156862745098)",
                TextPrimary = "rgb(162, 162, 162)",
                Background = "rgba(28, 27,31,100)",
                DrawerBackground = "rgba(28, 27,31,100)",
                DrawerText = "rgb(162, 162, 162)",

            },
            LayoutProperties = new LayoutProperties()
            {
                //DrawerWidthLeft = "260px",
                //DrawerWidthRight = "300px"
            }
        };
    }
}