using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inside : ContentPage
    {
        public Inside()
        {
            InitializeComponent();
        }

        public Inside(LoginData _loginData)
        {
            InitializeComponent();

            BindingContext = _loginData;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
        }
    }
}