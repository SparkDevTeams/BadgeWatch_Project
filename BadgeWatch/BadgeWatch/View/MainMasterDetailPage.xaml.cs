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
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();
            navigationDrawerList.ItemsSource = GetMasterPageLists();
        }

        private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageList)e.SelectedItem;

            Application.Current.Properties["MenuName"] = item.Title;
            Detail = new NavigationPage(new HomeTabbedPage());
            IsPresented = false;
        }
        List<MasterPageList> GetMasterPageLists()
        {
            return new List<MasterPageList>
            {
                new MasterPageList() { Title = "Profile", Icon = "home.png" },
                new MasterPageList() { Title = "Saved", Icon = "admin.png" },
                new MasterPageList() { Title = "About", Icon = "setting.png" }
            };
        }
    }

    //This class used for binding ListView. We can move it to other separate files as well   
    public class MasterPageList
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}