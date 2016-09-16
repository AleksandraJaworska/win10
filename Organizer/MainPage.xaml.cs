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



namespace Organizer
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ListView NotesList = new ListView();

        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsPaneOpen = !Menu.IsPaneOpen;
            if (Menu.IsPaneOpen)
            {
                btnMainPage.Content = "\uE00E";
                NotesList.Margin = new Thickness(190, 0, 0, 0);

            }
            else
            {
                btnMainPage.Content = "\uE00F";
                NotesList.Margin = new Thickness(10, 0, 0, 0);

            }

        }
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNote));

        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEvents));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new NotesContext())
            {

                NotesList.ItemsSource = db.Notes.ToList();
            }
        }

        public void dbItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var id = sender as TextBlock;
            var id2 = int.Parse(id.Tag.ToString());

            this.Frame.Navigate(typeof(ViewNote), id2);



        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = sender as Button;
            var id2 = int.Parse(id.Tag.ToString());
            using (var db = new NotesContext())
            {
                Notatka note = db.Notes.First(x => x.NoteId == id2);
                db.Notes.Remove(note);
                await db.SaveChangesAsync();
                NotesList.ItemsSource = db.Notes.ToList();
            }
        }

        private void btnTitle_Click(object sender, RoutedEventArgs e)
        {
            var id = sender as Button;
            var id2 = int.Parse(id.Tag.ToString());

            this.Frame.Navigate(typeof(ViewNote), id2);
        }





        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender,
                                   CalendarViewDayItemChangingEventArgs args)
        {
          //  this.Frame.Navigate(typeof(EventView));      
        }
    }
}
