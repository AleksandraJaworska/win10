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
using Microsoft.EntityFrameworkCore;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Organizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNote : Page
    {
        public AddNote()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

 

        private  void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
                   
            string notatka = TekstNotatki.Text;
            string tytul = TytulNotatki.Text;

            using (var db = new NotesContext())
            {
                var note = new Notatka { NoteTitle = TytulNotatki.Text, NoteText = TekstNotatki.Text };
                db.Notes.Add(note);
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
                TekstNotatki.Margin = new Thickness(190, 60, 15, 237);
                TytulNotatki.Margin = new Thickness(190, 20, 15, 237);
            }
            else
            {
                btnRozwin.Content = "\uE00F";
                TekstNotatki.Margin = new Thickness(80, 60, 15, 237);
                TytulNotatki.Margin = new Thickness(80, 20, 15, 237);
            }
        }
    }
}
