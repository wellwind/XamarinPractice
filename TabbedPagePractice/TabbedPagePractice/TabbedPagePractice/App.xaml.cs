using Prism.Unity;
using TabbedPagePractice.Views;

namespace TabbedPagePractice
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("TabbedPageContainer");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<TabbedPageContainer>();
            Container.RegisterTypeForNavigation<GoogleWebPage>();
            Container.RegisterTypeForNavigation<FacebookWebPage>();
        }
    }
}
