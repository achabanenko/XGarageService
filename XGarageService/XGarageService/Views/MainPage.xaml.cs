using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Plugin.Calendar.Models;


namespace XGarageService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ViewModels.MainPageViewModel m_view { get; set; }

        
        public MainPage()
        {
            InitializeComponent();
            m_view = new ViewModels.MainPageViewModel(this)
            {
                OnRemoteNotifcation = (body) =>
                {
                    //Label1.Text = body;
                },
                SelectedDate=DateTime.Now,
                IsService=true
            };

            BindingContext = m_view;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new MainPage2());
        }
        private void ButtonService_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Views.ServicePage());
        }
        private void ButtonRepaiting_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Views.ServicePage());
        }
        private void ButtonRecovery_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Views.ServicePage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SelectDatePage(m_view.SelectedDate,(a)=>
            {
                m_view.order.SelectedDate = a;
                    m_view.order.OnPropertyChanged("SelectedDate");//
            }));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if (m_view.RegNumber == ViewModels.MainPageViewModel.CLICK_HERE)
                m_view.RegNumber = "";
            this.Navigation.PushAsync(new SelectRegNumber(m_view, () =>
            {
                if(string.IsNullOrEmpty(m_view.RegNumber))
                    m_view.order.RegNumber = ViewModels.MainPageViewModel.CLICK_HERE;
                m_view.OnPropertyChanged("RegNumber");
            }));
        }
    }
}