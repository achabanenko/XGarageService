using System;

using XGarageService.Models;

namespace XGarageService.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null):base(null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
