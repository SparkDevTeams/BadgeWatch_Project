using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//using Microsoft.SharePoint.Client;
//using Microsoft.SharePoint.Client.Social;


namespace BadgeWatch.View
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsFeed : ContentPage
    {
        public NewsFeed()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}