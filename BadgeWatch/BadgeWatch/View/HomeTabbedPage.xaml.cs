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
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("MenuName"))
            {
                var menuName = Application.Current.Properties["MenuName"].ToString();
                if (menuName == "Movies")
                {
                    this.CurrentPage = Children[1];
                }
            }
        }
    }
}