using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XGarageService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicePage : ContentPage
    {
        public ServicePage()
        {
            InitializeComponent();
        }

        private async void Button_SubmitOrder(object sender, EventArgs e)
        {
            //var r=await new Services.ApiRequest<Models.ServiceOrder>(Constants.PostOrderPATH).Get();

            
            var rslt=await new Services.ApiRequest<Models.ServiceOrder>(Constants.PostOrderPATH, new Models.ServiceOrder()
            {
                RegNumber = "111",
                SelectedDate = DateTime.Now,
                Remarks = "222"
            }).Post();
            
            await this.Navigation.PopAsync();
        }
    }
}