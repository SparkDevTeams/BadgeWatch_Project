﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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