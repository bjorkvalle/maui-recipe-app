namespace bjorkvalle.app.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public DatabaseHandler<Recipe> Db { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string dbFolderPath, filePath,
            dbFullPath;
        private RichTextEditor refRichText;

        private string html,
            delta;

        protected override async Task OnInitializedAsync()
        {
            //SecureStorage.Default.RemoveAll();
            filePath = await SecureStorage.Default.GetAsync(Constants.Storage.Keys.DB_FILE_PATH);

            if (!Db.ConnectionExists(filePath))
            {
                //await Toast.Make("asd").Show(default);
                NavigationManager.NavigateTo("config");
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
    }
}
