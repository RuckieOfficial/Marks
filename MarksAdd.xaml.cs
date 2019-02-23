using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Znamky
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarksAdd : ContentPage
	{
		public MarksAdd ()
		{
			InitializeComponent ();
		}
        private void SubmitMark(object sender, EventArgs e) {
            try {
                if (Convert.ToDouble(Mark.Text) >= 6 || Int32.Parse(Weight.Text) > 100 || Int32.Parse(Weight.Text) < 1) {
                    DisplayAlert("Špatný vstup!", "Známky mohou být pouze od 1 do 5 a Váha od 1 do 100!", "Hotovo");
                }else {
                    AddMark(Subject.SelectedItem.ToString(), Convert.ToDouble(Mark.Text), Int32.Parse(Weight.Text));
                }
                
            }catch {
                DisplayAlert("Špatný vstup!", "Zadejte hodnoty znovu", "Hotovo");
            }
        }
        public async void AddMark(string subject, double mark, int weight) {
            await DisplayAlert("Přidáno!", "Známka přidána", "Potvrdit");
            await MySQL.Database.SaveItemAsync(new Marks { Subject = subject, Value = mark, Weight = weight });     
        }
	}
}