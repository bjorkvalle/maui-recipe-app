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
            const int newWidth = 600;
            const int newHeight = 800;
            //const int newWidth = 360;
            //const int newHeight = 700;

            window.Width = newWidth;
            window.Height = newHeight;
#endif
            return window;
        }
    }
}
