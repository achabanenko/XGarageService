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
    public partial class SelectRegNumber : ContentPage
    {
        public ViewModels.MainPageViewModel m_model { get; set; }
        Action m_OnChangeRegNumber { get; set; }
        public SelectRegNumber(ViewModels.MainPageViewModel model,Action OnChangeRegNumber)
        {
            InitializeComponent();
            m_model = model;
            this.BindingContext = m_model;
            m_OnChangeRegNumber = OnChangeRegNumber;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //m_model.RegNumber = DateTime.Now.ToString();
            m_OnChangeRegNumber();
            this.Navigation.PopAsync();
        }
    }
}