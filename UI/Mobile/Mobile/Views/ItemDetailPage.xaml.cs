using MedGame.UI.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MedGame.UI.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}