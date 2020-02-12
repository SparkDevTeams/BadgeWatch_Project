using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}