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
    public partial class Page1 : ContentPage
    {
        public ViewModels.MainPageViewModel m_view { get; set; }
        public Page1()
        {
            InitializeComponent();
            m_view = new ViewModels.MainPageViewModel(this)
            {
                OnRemoteNotifcation = (body) => {
                    //Label1.Text = body;
                }
            };
            BindingContext = m_view;
            calendar.BlackoutDatesViewMode = Syncfusion.SfCalendar.XForms.BlackoutDatesViewMode.Stripes;

            List<DateTime> black_Dates = new List<DateTime>();
            black_Dates.Add(new DateTime(2020, 06, 9));
            black_Dates.Add(new DateTime(2020, 06, 10));
            black_Dates.Add(new DateTime(2020, 06, 11));
            black_Dates.Add(new DateTime(2020, 06, 12));
            black_Dates.Add(new DateTime(2020, 06, 13));
            black_Dates.Add(new DateTime(2020, 06, 14));
            black_Dates.Add(new DateTime(2020, 06, 15));
            black_Dates.Add(new DateTime(2020, 06, 16));
            black_Dates.Add(new DateTime(2020, 06, 17));
            black_Dates.Add(new DateTime(2020, 06, 18));
            calendar.BlackoutDates = black_Dates;
        }
    }
}