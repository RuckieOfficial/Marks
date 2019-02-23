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
    public partial class Hlavni : TabbedPage
    {
        public Hlavni ()
        {
            InitializeComponent();
        }
    }
}