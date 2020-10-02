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
    public partial class SelectDatePage : ContentPage
    {
        public DateTime m_selectedDate { get; set; }
        public Action<DateTime> m_OnSetDate = null;
        public SelectDatePage(DateTime dt,Action<DateTime> OnSetDate)
        {
            
            InitializeComponent();
            m_selectedDate = dt;
            m_OnSetDate = OnSetDate;
            calendar.SelectedDate = dt;
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {

            m_selectedDate = calendar.SelectedDate??DateTime.Now;
                //m_selectedDate.AddDays(3);
            m_OnSetDate(m_selectedDate);
            this.Navigation.PopAsync();
        }
    }
}