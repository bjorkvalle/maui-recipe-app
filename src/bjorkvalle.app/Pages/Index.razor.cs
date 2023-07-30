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

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        private string filePath;

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

#if DEBUG
                TimeoutHelper.SetTimeout(async () =>
                {
                    await ScrollToStart();
                }, 1000);
#endif
            }
        }

        private async Task Insert()
        {
            await RecipeService.Create(new RecipeDto
            {
                Title = "Random" + Guid.NewGuid().ToString().Substring(0, 5),
            });
            recipes = await RecipeService.GetAll();
        }

        private async Task ScrollToStart()
        {
            await JsRuntime.InvokeVoidAsync("scrollTo", "index-start");
        }
    }
}
