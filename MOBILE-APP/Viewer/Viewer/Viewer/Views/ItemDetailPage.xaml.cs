using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Viewer.Models;
using Viewer.ViewModels;

namespace Viewer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Category
            {
                Text = "Item 1",

            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}