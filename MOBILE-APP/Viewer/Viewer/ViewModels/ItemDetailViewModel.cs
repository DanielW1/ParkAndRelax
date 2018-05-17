using System;

using Viewer.Models;

namespace Viewer.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Category Item { get; set; }
        public ItemDetailViewModel(Category item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}