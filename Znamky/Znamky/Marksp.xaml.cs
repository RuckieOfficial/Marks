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
        ScrollView view = new ScrollView { };
        StackLayout layout = new StackLayout { };
        Color color = Color.Black;
        private string Subject;
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
            layout.Children.Clear();
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
                
                var lab = new Label { Text = "V předmětu nejsou žádné známky!", FontSize = 20, FontAttributes = FontAttributes.Bold };
                layout.Children.Add(lab);
            }
            view.Content = layout;
            this.Content = view;
        }
        
        private async void DeleteMark(object sender, EventArgs e) {
            bool x =  await DisplayAlert("Smazání známky", "Opravdu chcete smazat známku?", "Smazat", "Zrušit");
            if (x == true) {
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
                double x = Convert.ToInt32(mark);
                return x + "-";
            }
        }
        private void MarkAvg(double avg, double avg2) {
            double avgfinal = avg / avg2;
            string x = String.Format("{0:0.00}", avgfinal);
            var label3 = new Label { Text = "Průměr:" + x, FontSize = 25 };
            layout.Children.Add(label3);
        }
        private void CreateMark(Marks item) {
            if (item.Value == 4.5) {
                color = Color.Red;
            } else {
                color = Color.Black;
            }
            var layout2 = new StackLayout { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightGray };
            var label = new Label { Text = item.Value.ToString(), FontSize = 25, FontAttributes = FontAttributes.Bold, TextColor = color, Margin = 2, WidthRequest = 100 };
            var label2 = new Label { Text = item.Weight.ToString(), FontSize = 20, HorizontalTextAlignment = TextAlignment.End, WidthRequest = 300, Margin = 2, VerticalTextAlignment = TextAlignment.Center };
            var del = new ImageButton { Source = "delete.png", WidthRequest = 20, HeightRequest = 20 };
            del.Clicked += new EventHandler(DeleteMark);
            layout2.Children.Add(label);
            layout2.Children.Add(label2);
            layout2.Children.Add(del);
            layout.Children.Add(layout2);
            mark.Add(del, item);
        }

	}
}