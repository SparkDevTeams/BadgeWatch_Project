using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FormsVideoLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BadgeWatch.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoFeed : ContentPage
    {
        public VideoFeed()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                string key = ((string)args.SelectedItem).Replace(" ", "").Replace("'", "");
                videoPlayer.Source = (UriVideoSource)Application.Current.Resources[key];
            }
        }
    }
}