using Prism.Unity;
using MasterDetailPagePractice.Views;

namespace MasterDetailPagePractice
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainMasterDetailPage/MainNavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<MainMasterDetailPage>();
            Container.RegisterTypeForNavigation<NextPage>();
            Container.RegisterTypeForNavigation<Page1Page>();
            Container.RegisterTypeForNavigation<Page2Page>();
        }
    }
}
