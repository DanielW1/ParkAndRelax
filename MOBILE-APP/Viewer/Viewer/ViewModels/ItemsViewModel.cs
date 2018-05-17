using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Viewer.Models;
using Viewer.Services;

namespace Viewer.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {   
        public ObservableCollection<Category> Items { get; set; }
        //public ICommand LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Viewer";
            Items = new ObservableCollection<Category>();
            //LoadItemsCommand = new ICommand(async () => await ExecuteLoadItemsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Category>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Category;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                //foreach (var item in items)
                //{
                //    Items.Add(item);
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}