namespace bjorkvalle.app.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public DatabaseContext Db { get; set; }

        [Inject]
        public IRecipeService RecipeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        private string filePath, currentTheme;
        private bool isLoading = true;
        private List<RecipeDto> recipes;
        private Dropdown drp;
        private readonly Dictionary<string, string> themeItems =
            new()
            {
                { "wireframe", "Wireframe" },
                { "light", "Light" },
                { "dark", "Dark" },
                { "cupcake", "Cupcake" },
                { "bumblebee", "Bumblebee" },
                { "emerald", "Emerald" },
                { "corporate", "Corporate" },
                { "synthwave", "Synthwave" },
                { "retro", "Retro" },
                { "cyberpunk", "Cyberpunk" },
                { "valentine", "Valentine" },
                { "halloween", "Halloween" },
                { "garden", "Garden" },
                { "forest", "Forest" },
                { "aqua", "Aqua" },
                { "lofi", "Lo-fi" },
                { "pastel", "Pastel" },
                { "fantasy", "Fantasy" },
                { "black", "Black" },
                { "luxury", "Luxury" },
                { "dracula", "Dracula" },
                { "cmyk", "CMYK" },
                { "autumn", "Autumn" },
                { "business", "Business" },
                { "acid", "Acid" },
                { "lemonade", "Lemonade" },
                { "night", "Night" },
                { "coffee", "Coffee" },
                { "winter", "Winter" },
            };

        protected override async Task OnInitializedAsync()
        {
            //SecureStorage.Default.RemoveAll();
            filePath = await SecureStorage.Default.GetAsync(
                Constants.Storage.Keys.DB_FILE_FULLPATH
            );
            currentTheme = await SecureStorage.Default.GetAsync(
                Constants.Storage.Keys.THEME
            );
            await SetTheme(currentTheme);

            if (!await Db.TryDbConnection(filePath))
            {
                SecureStorage.Remove(Constants.Storage.Keys.DB_FILE_NAME);
                SecureStorage.Remove(Constants.Storage.Keys.DB_FILE_PATH);
                SecureStorage.Remove(Constants.Storage.Keys.DB_FILE_FULLPATH);
                NavigationManager.NavigateTo("config");
            }
            else
            {
                recipes = await RecipeService.GetAll();
                isLoading = false;

#if DEBUG
                //TimeoutHelper.SetTimeout(async () =>
                //{
                //    await ScrollToStart();
                //}, 1000);
#endif
            }
        }

        private async Task SetTheme(string theme)
        {
            if (string.IsNullOrEmpty(theme))
                theme = "wireframe";

            currentTheme = theme;
            await SecureStorage.SetAsync(Constants.Storage.Keys.THEME, theme);
            await JsRuntime.InvokeVoidAsync("setDaisyUITheme", theme);
        }

        //private async Task ScrollToStart()
        //{
        //    await JsRuntime.InvokeVoidAsync("scrollTo", "index-start");
        //}
    }
}
