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

        void znamkachange(object sender, ValueChangedEventArgs e) {
            double value = e.NewValue;
            znamka.Text = string.Format("{0}", value);
        }

        void vahachange(object sender, ValueChangedEventArgs e) {
            double value = e.NewValue;
            vaha.Text = string.Format("{0}", value);
        }

        private void SubmitMark(object sender, EventArgs e) {
            try {
                AddMark(Subject.SelectedItem.ToString(), Convert.ToDouble(znamka.Text), Int32.Parse(vaha.Text));
            } catch {
                DisplayAlert("Špatný vstup!", "Zadejte všechny hodnoty", "Hotovo");
            }
        }
        public async void AddMark(string subject, double mark, int weight) {
            await DisplayAlert("Přidáno!", "Známka přidána", "Potvrdit");
            await MySQL.Database.SaveItemAsync(new Marks { Subject = subject, Value = mark, Weight = weight });     
        }
	}
}