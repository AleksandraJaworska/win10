using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Organizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEvents : Page
    {
        public AddEvents()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }



        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {

            //string notatka = TekstNotatki.Text;
            //string tytul = TytulNotatki.Text;

            using (var db = new NotesContext())
            {
              var ev = new Wydarzenie { EventTitle = NazwaEventu.Text, EventText = OpisEventu.Text, EventDate = DataEventu.ToString() };
                db.Events.Add(ev);
                db.SaveChanges();

            }

            this.Frame.Navigate(typeof(MainPage));

        }

        private void btnRozwin_Click(object sender, RoutedEventArgs e)
        {
            Add.IsPaneOpen = !Add.IsPaneOpen;
            if (Add.IsPaneOpen)
            {
                btnRozwin.Content = "\uE00E";
                DataEventu.Margin = new Thickness(190, 0, 0, 584);
                NazwaEventu.Margin = new Thickness(190, 61, 15, 0);
                OpisEventu.Margin = new Thickness(190, 98, 15, 0);
            }
            else
            {
                btnRozwin.Content = "\uE00F";
                DataEventu.Margin = new Thickness(80, 0, 0, 584);
                NazwaEventu.Margin = new Thickness(80, 61, 15, 0);
                OpisEventu.Margin = new Thickness(80, 98, 15, 0);
            }
        }
    }
}
