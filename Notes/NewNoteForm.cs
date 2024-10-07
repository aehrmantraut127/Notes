using DevExpress.LookAndFeel;
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
        private int selectedNotebook = -1;

        public NewNoteForm()
        {
            InitializeComponent();
            SqliteDataAccess.LoadNotebooks();
            SqliteDataAccess.LoadNotes();
            AccordionControl();
            lblDate.Text = "";
            this.FormClosing += NewNote_FormClosing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePalette();
        }
        private void SavePalette()
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            settings.Save();
        }
        
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RestorePalette();
        }
        private void RestorePalette()
        {
            var settings = Properties.Settings.Default;
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette))
                    UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName);
            }
        }

        /// <summary>
        /// all controls for the accordion control (left side of the app)
        /// </summary>
        private void AccordionControl()
        {            
            accordionCtlNotes.Elements.Clear();

            // Load Notebooks
            string notebookQuery = "SELECT notebookID, name FROM notebooks";

            using (IDbConnection cnn = new SQLiteConnection(SqliteDataAccess.LoadConnectionString()))
            {
                cnn.Open(); // Open the connection
                using (SQLiteCommand command = new SQLiteCommand(notebookQuery, (SQLiteConnection)cnn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int notebookId = reader.GetInt32(0);
                            string notebookName = reader.GetString(1);

                            // Create an AccordionControlElement for each notebook as a group
                            AccordionControlElement notebookGroup = new AccordionControlElement
                            {
                                Text = notebookName,
                                Style = ElementStyle.Group
                            };

                            notebookGroup.Click += (s, e) => OnNotebookSelected(notebookId);

                            // Add the notebook group to the accordion control
                            accordionCtlNotes.Elements.Add(notebookGroup);

                            // Load notes for this specific notebook
                            string notesQuery = "SELECT title, date, message FROM messages WHERE notebook_id = @notebookId";
                            using (SQLiteCommand notesCommand = new SQLiteCommand(notesQuery, (SQLiteConnection)cnn))
                            {
                                notesCommand.Parameters.AddWithValue("@notebookId", notebookId);

                                using (SQLiteDataReader notesReader = notesCommand.ExecuteReader())
                                {
                                    // Check if we have notes for this notebook
                                    Dictionary<string, List<DateTime>> noteEntries = new Dictionary<string, List<DateTime>>();

                                    while (notesReader.Read())
                                    {
                                        // Ensure there is a title and date
                                        if (!notesReader.IsDBNull(0) && !notesReader.IsDBNull(1))
                                        {
                                            string title = notesReader.GetString(0);
                                            DateTime date = notesReader.GetDateTime(1); // Adjust based on your column type
                                            string message = notesReader.GetString(2); // Retrieve message

                                            // Store the message along with the title and date in a separate dictionary
                                            noteMessages[(title, date)] = System.Text.Encoding.UTF8.GetBytes(message);

                                            // Ensure that the title is unique in the noteEntries
                                            if (!noteEntries.ContainsKey(title))
                                            {
                                                noteEntries[title] = new List<DateTime>();
                                            }
                                            noteEntries[title].Add(date);
                                        }
                                    }

                                    // Add entries to the accordion under the current notebook group
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

                                            // Add the title group to the notebook group
                                            notebookGroup.Elements.Add(titleGroup);

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
                                            notebookGroup.Elements.Add(uniqueItem);
                                        }
                                    }
                                }
                            }
                        }
                    }
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
        /// Used to select notebooks to insert notes into
        /// </summary>
        /// <param name="notebookId"></param>
        private void OnNotebookSelected(int notebookId)
        {
            selectedNotebook = notebookId; // Store the selected notebook ID
        }

        /// <summary>
        /// allows for the creation of new notes to be saved into the database and reloaded into the accordion control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                if (selectedNotebook == -1) // Check if a notebook has been selected
                {
                    MessageBox.Show("Please select a notebook before saving the note.");
                    return; // Exit early if no notebook is selected
                }

                NoteModel n = new NoteModel
                {
                    Title = txtTitle.Text
                };

                // Use the selected notebook ID to save the note
                SqliteDataAccess.SaveNote(n, txtMessage.RtfText, selectedNotebook);

                // Clear the UI fields after saving
                txtMessage.RtfText = "";
                txtTitle.Text = "";
                lblDate.Text = "";

                // Refresh the notes display
                SqliteDataAccess.LoadNotes();
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
                SqliteDataAccess.LoadNotes();
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

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(selectedNote.title)) // Ensure a note is selected
            {
                NoteModel updatedNote = new NoteModel
                {
                    Title = txtTitle.Text,
                };

                // Update the note in the database using title and date from the selectedNote
                SqliteDataAccess.UpdateNote(selectedNote.title, selectedNote.date, updatedNote.Title, txtMessage.RtfText);

                // Clear fields or reset state as needed
                txtMessage.RtfText = "";
                txtTitle.Text = "";
                lblDate.Text = "";

                // Refresh the notes display
                SqliteDataAccess.LoadNotes();
                AccordionControl();
                MessageBox.Show("Note updated successfully.");
            }
            else
            {
                MessageBox.Show("Please select a note to edit.");
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // save this to notebooks.db for later usage
            // make selection stay 
            if(e.KeyCode == Keys.Enter)
            {
                AccordionControlElement newGroup = accordionCtlNotes.Elements
                .FirstOrDefault(x => x.Text == "Notes");

                if (!string.IsNullOrWhiteSpace(toolStripTextBox1.Text))
                {
                    newGroup = new AccordionControlElement
                    {
                        Text = toolStripTextBox1.Text,
                        Style = ElementStyle.Group
                    };
                    SqliteDataAccess.SaveNotebook(toolStripTextBox1.Text);
                }
                accordionCtlNotes.Elements.Add(newGroup);

                toolStripTextBox1.Text = "";

                SqliteDataAccess.LoadNotebooks();
            }
        }

        private void accordionCtlNotes_FilterContent(object sender, FilterContentEventArgs e)
        {
            // create filter content for search bar
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtMessage.Text = "";
            txtTitle.Text = "";
            lblDate.Text = "";
        }
    }
}
