using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace App3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
	{

		// This MobileServiceClient has been configured to communicate with the Azure Mobile Service and
		// Azure Gateway using the application url. You're all set to start working with your Mobile Service!
		public static Microsoft.WindowsAzure.MobileServices.MobileServiceClient Remora_azureClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
		"http://remora-azure.azurewebsites.net");


		public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);

            Window.Current.Activate();

            return Task.CompletedTask;
        }
    }
}
