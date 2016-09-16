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

    public sealed partial class ViewNote : Page
    {
        public ViewNote()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            // var id = sender as Button;
            // var id2 = int.Parse(id.Tag.ToString());
            var id = idnote.Text;
            int id2 = int.Parse(id);
            using (var db = new NotesContext())
            {
                Notatka note = db.Notes.First(x => x.NoteId == id2);
                note.NoteTitle = TytulNotatki.Text;
                note.NoteText = TekstNotatki.Text;

                //NotesList.ItemsSource = db.Notes.ToList();


                //var note = new Notatka { NoteTitle = TytulNotatki.Text, NoteText = TekstNotatki.Text };
                //db.Notes.Add(note);

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


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var text = e.Parameter.ToString();
            if (text != null)
            {
                int id = Int32.Parse(text);
                idnote.Text = id.ToString();

                using (var db = new NotesContext())
                {
   
                    TytulNotatki.Text = db.Notes.First(x => x.NoteId == id).NoteTitle;
                    TekstNotatki.Text = db.Notes.First(x => x.NoteId == id).NoteText;

                }

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new NotesContext())
            {

                //NotesList.ItemsSource = db.Notes.ToList();
            }
        }
    }
}
