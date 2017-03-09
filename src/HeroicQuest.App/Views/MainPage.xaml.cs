using App3.ViewModels;
using Prism.Windows.Mvvm;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : SessionStateAwarePage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContextChanged += Changed;
        }

        private void Changed(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
            ViewModel = args.NewValue as MainPageViewModel;
        }

        public MainPageViewModel ViewModel { get; set; }
    }
}
