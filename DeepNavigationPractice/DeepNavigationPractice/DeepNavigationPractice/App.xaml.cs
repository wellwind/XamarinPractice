using Prism.Unity;
using DeepNavigationPractice.Views;

namespace DeepNavigationPractice
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainNavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Page2>();
            Container.RegisterTypeForNavigation<Page3>();
            Container.RegisterTypeForNavigation<Page4>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
        }
    }
}
