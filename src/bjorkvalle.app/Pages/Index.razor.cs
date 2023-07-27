namespace bjorkvalle.app.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public DatabaseHandler<Recipe> Db { get; set; }

        [Inject]
        public IRecipeService RecipeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string dbFolderPath, filePath,
            dbFullPath;
        private RichTextEditor refRichText;

        private string html,
            delta;

        private bool isLoading = true;
        private List<RecipeDto> recipes;

        protected override async Task OnInitializedAsync()
        {
            //SecureStorage.Default.RemoveAll();
            filePath = await SecureStorage.Default.GetAsync(Constants.Storage.Keys.DB_FILE_FULLPATH);

            if (!Db.TryDbConnection(filePath))
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
            }
        }

        private async Task Save()
        {
            //var recipe = new Recipe

            try
            {
                var recipes = await Db.GetAllAsync();
                await Toast.Make(recipes?.Count().ToString()).Show(default);
            }
            catch (Exception ex)
            {
                await Toast.Make(ex.Message, ToastDuration.Long).Show(default);
            }
        }

        private async Task Insert()
        {
            await RecipeService.Create(new RecipeDto
            {
                Title = "Random" + Guid.NewGuid().ToString().Substring(0, 5),
                Delta = "asd",
                Html = "dsa"
            });
            recipes = await RecipeService.GetAll();
        }
    }
}
