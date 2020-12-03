using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormMobile
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private Regex hasLength = new Regex(@"^.{8,}$");
        private Regex hasNumber = new Regex(@"\d");
        private Regex hasSpecChar = new Regex(@"\W");
        private LoginData loginData;
        private bool isLegit = false;
        private string uname = string.Empty;
        private string pass = string.Empty;

        public MainPage()
        {
            InitializeComponent();

            loginData = new LoginData();
            BindingContext = loginData;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(isLegit && uname != null)
            {
                Application.Current.MainPage.Navigation.PushAsync(new Inside(loginData));
            }
            else
            {
                string output = string.Empty;
                uname = loginData.Username;
                pass = loginData.Password;

                if (pass != null && uname != null)
                {
                    if (!hasLength.IsMatch(pass))
                    {
                        output += "\n alespoň 8 znaků";
                    }

                    if (!hasNumber.IsMatch(pass))
                    {
                        output += "\n číslici";
                    }

                    if (!hasSpecChar.IsMatch(pass))
                    {
                        output += "\n speciální znak";
                    }
                
                    Application.Current.MainPage.DisplayAlert("Nadpis: Neplatné heslo", $"Heslo neobsahuje: {output}!", "Zavřít");
                }
                else
                    Application.Current.MainPage.DisplayAlert("Nadpis: Neplatné údaje", "Zadejte heslo nebo uživatelské jméno!", "Zavřít");

            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string pass = loginData.Password;
            isLegit = hasLength.IsMatch(pass) && hasNumber.IsMatch(pass) && hasSpecChar.IsMatch(pass);

            if (isLegit)
            {
                checkPass.BackgroundColor = Color.Green;
                checkPass.Text = "Vyhovující";
            }
            else
            {
                checkPass.BackgroundColor = Color.Red;
                checkPass.Text = "Neplatné heslo";
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
        }
    }
}
