using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notes
{
    public partial class NewNoteForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        // all temp variables used
        List<NoteModel> notes = new List<NoteModel>();
        private Dictionary<(string title, DateTime date), byte[]> noteMessages = new Dictionary<(string title, DateTime date), byte[]>();
        private (string title, DateTime date) selectedNote;

        public NewNoteForm()
        {
            InitializeComponent();
            LoadNotes();
            AccordionControl();
            lblDate.Text = "";
        }

        /// <summary>
        /// loads all notes
        /// </summary>
        private void LoadNotes()
        {
            notes = SqliteDataAccess.LoadNotes();
        }

        /// <summary>
        /// saves notes by pulling the date from the computer. the title from the title bar, 
        /// and the message, using rtf to preserve data, from the message box
        /// </summary>
        private void AddNote()
        {
            NoteModel n = new NoteModel
            {
                Title = txtTitle.Text
            };

            // Save the RTF content
            SqliteDataAccess.SaveNote(n, txtMessage.RtfText); // Save the RTF content

            txtMessage.RtfText = ""; // Clear the RichTextBox
            txtTitle.Text = "";
        }

        /// <summary>
        /// all controls for the accordion control (left side of the app)
        /// </summary>
        private void AccordionControl()
        {
            // Check if the "Notes" group already exists
            AccordionControlElement notesGroup = accordionCtlNotes.Elements
                .FirstOrDefault(e => e.Text == "Notes");

            // If it doesn't exist, create it
            if (notesGroup == null)
            {
                notesGroup = new AccordionControlElement
                {
                    Text = "Notes",
                    Style = ElementStyle.Group
                };
                accordionCtlNotes.Elements.Add(notesGroup);
            }
            else
            {
                // Clear existing items if needed (optional)
                notesGroup.Elements.Clear();
            }

            string query = "SELECT title, date, message FROM messages"; // Include message column
            Dictionary<string, List<DateTime>> noteEntries = new Dictionary<string, List<DateTime>>();

            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Open(); // Open the connection
                using (SQLiteCommand command = new SQLiteCommand(query, (SQLiteConnection)cnn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader.GetString(0);
                            DateTime date = reader.GetDateTime(1); // Adjust based on your column type
                            string message = reader.GetString(2); // Retrieve message

                            if (!noteEntries.ContainsKey(title))
                            {
                                noteEntries[title] = new List<DateTime>();
                            }

                            noteEntries[title].Add(date);

                            // Store the message along with the title and date in a separate dictionary
                            noteMessages[(title, date)] = System.Text.Encoding.UTF8.GetBytes(message);
                        }
                    }
                }
            }

            // Add entries to the accordion
            foreach (var entry in noteEntries)
            {
                if (entry.Value.Count > 1)
                {
                    // Create a subgroup for titles with multiple entries
                    AccordionControlElement titleGroup = new AccordionControlElement
                    {
                        Text = entry.Key,
                        Style = ElementStyle.Group
                    };

                    // Add the title group to the notes group
                    notesGroup.Elements.Add(titleGroup);

                    // Sort dates before adding them
                    entry.Value.Sort();

                    // Add date options as sub-items
                    foreach (var date in entry.Value)
                    {
                        AccordionControlElement dateItem = new AccordionControlElement
                        {
                            Text = date.ToString("yyyy-MM-dd"), // Format as needed
                            Style = ElementStyle.Item
                        };

                        // Add event handler for date selection
                        dateItem.Click += (s, e) => OnNoteItemClick(entry.Key, date);

                        titleGroup.Elements.Add(dateItem);
                    }
                }
                else
                {
                    // For unique entries, add them as standalone items
                    AccordionControlElement uniqueItem = new AccordionControlElement
                    {
                        Text = entry.Key,
                        Style = ElementStyle.Item
                    };

                    // Add event handler for unique entry selection
                    uniqueItem.Click += (s, e) => OnNoteItemClick(entry.Key, entry.Value[0]);

                    notesGroup.Elements.Add(uniqueItem);
                }
            }
        }

        /// <summary>
        /// saves data temporarily that you selected from the accordion control
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        private void OnNoteItemClick(string title, DateTime date)
        {
            if (noteMessages.TryGetValue((title, date), out byte[] rtfData))
            {
                txtTitle.Text = title;
                lblDate.Text = date.ToString("yyyy-MM-dd");
                txtMessage.RtfText = System.Text.Encoding.UTF8.GetString(rtfData); // Load RTF data into RichTextBox

                selectedNote = (title, date);
            }
            else
            {
                MessageBox.Show("No message found for the selected entry.");
            }
        }

        /// <summary>
        /// allows for the creation of new notes to be saved into the database and reloaded into the accordion control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                AddNote();
                LoadNotes();
                lblDate.Text = "";
                AccordionControl();
            }
            else
            {
                MessageBox.Show("Please complete your note.");
            }
            
        }

        /// <summary>
        /// clears fields to allow for the creation of new notes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accordionControlElementNewNote_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtTitle.Text = "";
            lblDate.Text = "";
        }

        /// <summary>
        /// allows for you to delete records from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedNote.title))
            {
                // Call your data access method to delete the note
                SqliteDataAccess.DeleteNote(selectedNote.title, selectedNote.date);

                // Refresh the notes display
                LoadNotes();
                AccordionControl();

                // Clear the selected note
                selectedNote = (null, DateTime.MinValue);
                txtMessage.Text = "";
                txtTitle.Text = "";
                lblDate.Text = "";
                MessageBox.Show("Note deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a note to delete.");
            }
        }

        /// <summary>
        /// opens the help documentation into the main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                // Assuming your RTF file is named "HelpDocument.rtf" and located in a folder named "Resources"
                string filePath = @".\Help.rtf"; // Adjust the path as necessary

                // Load the RTF file into the RichTextBox
                txtTitle.Text = "Help";
                lblDate.Text = "";
                txtMessage.LoadDocument(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading help documentation: " + ex.Message);
            }
        }
    }
}
