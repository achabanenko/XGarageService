using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

using XGarageService.Models;
using XGarageService.Services;

namespace XGarageService.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        [JsonIgnore]
        public ContentPage m_page { get; set; }
        
        public BaseViewModel(ContentPage mainPage)
        {

            m_page = mainPage;
            m_page.Appearing += OnAppearPage;
            m_page.Disappearing += Disappearing;

        }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        [JsonIgnore]
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        [JsonIgnore]
        public Action<string> OnRemoteNotifcation;
        public void OnAppearPage(object sender, EventArgs e)
        {
            if(OnRemoteNotifcation!=null)
            //if (mainpage != null)
                MessagingCenter.Subscribe<NetCoreNotification.Notification.Message, string>(this, "OnNewNotification", (msg, body) =>
                {
                    MainThread.InvokeOnMainThreadAsync(() =>
                    {
                        OnRemoteNotifcation(body);
                        //Label1.Text = body;
                    });
                    Console.WriteLine(body);
                });
        }
        public void Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<NetCoreNotification.Notification.Message, string>(this, "OnNewNotification");
        }
        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
