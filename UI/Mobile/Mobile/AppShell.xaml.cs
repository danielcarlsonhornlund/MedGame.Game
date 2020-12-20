using MedGame.UI.Mobile.ViewModels;
using MedGame.UI.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedGame.UI.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
