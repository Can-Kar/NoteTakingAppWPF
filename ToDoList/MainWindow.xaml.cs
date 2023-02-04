using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static ToDoList.MainWindow;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Note
        {
            public string title = string.Empty;
            public string content = string.Empty;
        }

        List<Note> notes = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        //Adds the entered note into note list and then adds a ListBoxItem in ListBox to display it's title
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Add(new Note() { title = NoteTitleTbx.Text, content = NoteBodyTbx.Text});

            ListBoxItem item = new ListBoxItem();
            item.Content = NoteTitleTbx.Text;
            NotesListBox.Items.Add(item);
        }

        //Clears the text inside textboxes
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NoteTitleTbx.Clear();
            NoteBodyTbx.Clear();
        }

        /// <summary>
        /// This method first retrieves the selected ListBoxItem from the ListBox, then gets its Content property as a string (the title of the selected note). It then loops through the notes list and removes the note that has a matching title. Finally, it removes the selected ListBoxItem from the ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem != null)
            {
                string valueRemove = ((ListBoxItem)NotesListBox.SelectedItem).Content.ToString();

                foreach (Note note in notes)
                {
                    if (valueRemove == note.title)
                    {
                        notes.Remove(note);
                        break;
                    }
                }

                NotesListBox.Items.Remove(NotesListBox.SelectedItem);

                foreach (Note item in notes)
                {
                    Trace.WriteLine(item.title);
                }
            }
        }


        /// <summary>
        /// This method is called whenever the selection in the ListBox changes. It retrieves the selected ListBoxItem and gets its Content property as a string (the title of the selected note). It then loops through the notes list and finds the note that has a matching title. The textboxes' Text properties are then set to the title and content of the selected note.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotesListBox.SelectedItem != null)
            {
                string value = ((ListBoxItem)NotesListBox.SelectedItem).Content.ToString();

                foreach (Note note in notes)
                {
                    if (value == note.title)
                    {
                        NoteTitleTbx.Text = note.title;
                        NoteBodyTbx.Text = note.content;
                        break;
                    }
                }
            }
        }

    }

}
