using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Znamky
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Marksp : ContentPage
	{

        Dictionary<ImageButton, Marks> mark = new Dictionary<ImageButton, Marks>();
        private string Subject;
        ScrollView view = new ScrollView { };
        StackLayout layout1 = new StackLayout { };
        Color color = Color.Black;
        public Marksp ()
		{
			InitializeComponent ();
		}
        public Marksp(string Subject) {
            this.Subject = Subject;
            this.Title = Subject;
            LoadMarks(Subject);            
        }
        public async void LoadMarks(string Subject) {
            layout1.Children.Clear();
            var Content = new ContentPage();
            List<Marks> marks = await MySQL.Database.GetItemsNotDoneAsync();
            List<Marks> matches = marks.Where(s => s.Subject == Subject).ToList();     
             double avg = 0;
            double avg2 = 0;
            if (matches.Count > 0) {
                foreach (Marks item in matches) {
                    
                    CreateMark(item);
                    avg += item.Value * item.Weight;
                    avg2 += item.Weight;
                    
                }
                MarkAvg(avg, avg2);
            }else {
                
                var lab = new Label { Text = "V předmětu nejsou žádné známky!", FontSize = 25, FontAttributes = FontAttributes.Bold };
                layout1.Children.Add(lab);
            }
            view.Content = layout1;
            this.Content = view;
        }
        
        private async void DeleteMark(object sender, EventArgs e) {
            bool t =  await DisplayAlert("Smazání známky", "Opravdu chcete smazat známku?", "Smazat", "Zrušit");
            if (t == true) {
                ImageButton button = (sender as ImageButton);
                await MySQL.Database.DeleteItemAsync(mark[button]);
                LoadMarks(Subject);
            }else {

            }

        }
        private string MarkCheck(double mark) {
            if ((mark % 1) == 0) {
                return mark.ToString();
            }else {
                double m = Convert.ToInt32(mark);
                return m + "-";
            }
        }
        private void MarkAvg(double avg, double avg2) {
            double avgfinal = avg / avg2;
            string f = String.Format("{0:0.00}", avgfinal);
            var label3 = new Label { Text = "Průměr:" + f, FontSize = 25 };
            layout1.Children.Add(label3);
        }
        private void CreateMark(Marks item) {
            if (item.Value >= 4.5) {
                color = Color.Red;
            } else {
                color = Color.Black;
            }
            var layout2 = new StackLayout { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightGray };
            var label = new Label { Text = item.Value.ToString(), FontSize = 30, FontAttributes = FontAttributes.Bold, TextColor = color, Margin = 2, WidthRequest = 100 };
            var label2 = new Label { Text = item.Weight.ToString(), FontSize = 20, HorizontalTextAlignment = TextAlignment.End, WidthRequest = 300, Margin = 2, VerticalTextAlignment = TextAlignment.Center };
            var img = new ImageButton { Source = "delete.png", WidthRequest = 20, HeightRequest = 20 };
            img.Clicked += new EventHandler(DeleteMark);
            layout2.Children.Add(label);
            layout2.Children.Add(label2);
            layout2.Children.Add(img);
            layout1.Children.Add(layout2);
            mark.Add(img, item);
        }

	}
}