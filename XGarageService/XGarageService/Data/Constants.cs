using Xamarin.Forms;

namespace XGarageService
{
	public static class Constants
	{
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = "http://192.168.0.94/XGarageService.Web";
        public static string PostOrderPATH = "/api/orderservice/add";
    }
}
