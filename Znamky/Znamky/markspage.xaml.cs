using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Znamky {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Markspage : ContentPage {
        public Markspage() {
            InitializeComponent();
        }
        public async void Marksnav(Button button) {
            if (button.Text == "Anglický jazyk") {
                await Navigation.PushAsync(new Marksp("Anglický jazyk"));
            } else if (button.Text == "Animační a vizualizační systémy") {
                await Navigation.PushAsync(new Marksp("Animační a vizualizační systémy"));
            } else if (button.Text == "Český jazyk a literatura") {
                await Navigation.PushAsync(new Marksp("Český jazyk a literatura"));
            } else if (button.Text == "Ekonomika") {
                await Navigation.PushAsync(new Marksp("Ekonomika"));
            } else if (button.Text == "Matematika") {
                await Navigation.PushAsync(new Marksp("Matematika"));
            } else if (button.Text == "Německý jazyk") {
                await Navigation.PushAsync(new Marksp("Německý jazyk"));
            } else if (button.Text == "Operační systémy") {
                await Navigation.PushAsync(new Marksp("Operační systémy"));
            } else if (button.Text == "Počítačové sítě") {
                await Navigation.PushAsync(new Marksp("Počítačové sítě"));
            } else if (button.Text == "Praktická cvičení") {
                await Navigation.PushAsync(new Marksp("Praktická cvičení"));
            } else if (button.Text == "Tělesná výchova") {
                await Navigation.PushAsync(new Marksp("Tělesná výchova"));
            } else if (button.Text == "Vývoj aplikací a her") {
                await Navigation.PushAsync(new Marksp("Vývoj aplikací a her"));
            } else if (button.Text == "Základy společenských věd") {
               await Navigation.PushAsync(new Marksp("Základy společenských věd"));
            }
        }
        private void ShowMarks(object sender, EventArgs args) {
            Button button = (sender as Button);
            Marksnav(button);

        }
    }
}