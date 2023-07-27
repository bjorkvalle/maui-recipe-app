namespace bjorkvalle.app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
#if WINDOWS
            const int newWidth = 500;
            const int newHeight = 800;

            window.Width = newWidth;
            window.Height = newHeight;
#endif
            return window;
        }
    }
}
