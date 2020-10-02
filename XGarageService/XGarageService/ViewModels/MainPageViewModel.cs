using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XGarageService.Services;
using XGarageService.Views;

namespace XGarageService.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        [JsonIgnore]
        public const string CLICK_HERE = "(Click Here)";
        public DateTime SelectedDate { get; set; }
        public string RegNumber { get; set; }
        public bool IsRepair { get; set; }
        public bool IsService { get; set; }
        public bool IsPickupMyCar { get; set; }
        public bool IsReturnMyCar { get; set; }
        public string Remarks { get; set; }

        public Models.Order order { get; set; }

        [JsonIgnore]
        public Command OnSubmitCommand { get; set; }


        public MainPageViewModel(ContentPage _page) : base(_page)
        {
            order = new Models.Order()
            {
                RegNumber = "1111"
            };
            RegNumber = ViewModels.MainPageViewModel.CLICK_HERE;
            OnSubmitCommand = new Command(async () => 
            { 
            //var request = new ApiRequest<string>("XGarageService.Web/api/item");
                var request = new ApiRequest<Models.Order>("XGarageService.Web/api/Orders/Submit", this.order);
                var s = await request.Post();
                //var s = await request.GetString();
            //Console.WriteLine(s);
            //(Models.ProductWihPicture)item)
                await m_page.Navigation.PushAsync(new Views.ItemsPage());
            });
        }
        
    }
}
