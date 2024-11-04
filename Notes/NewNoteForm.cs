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
        /// <summary>
        /// Creation of a NoteModel for easier storage and transportation of temp data
        /// dictionary to easily display the message with the notes title and date linking to the message
        /// tuple of our selected note for tracking what to update/delete
        /// your selected notebook id to know where to send a note
        /// </summary>
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
            this.FormClosing += NewNoteForm_FormClosing;
            this.Load += NewNoteForm_Load;
        }

        /// <summary>
        /// Theme selection and saving handlers
        /// override allows for the user saving their selected them on launch
        /// </summary>
        private void SavePalette() // saves the selected theme
        {
            var settings = Properties.Settings.Default;
            settings.SkinName = UserLookAndFeel.Default.SkinName;
            settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName;
            settings.Save();
        }
        protected override void OnShown(EventArgs e) // on launch, overrides default theme with user selected theme
        {
            base.OnShown(e);
            RestorePalette();
        }
        private void RestorePalette() // handles reskinning of app
        {
            var settings = Properties.Settings.Default;
            if (!string.IsNullOrEmpty(settings.SkinName))
            {
                if (!string.IsNullOrEmpty(settings.Palette))
                    UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette);
                else UserLookAndFeel.Default.SetSkinStyle(settings.SkinName);
            }
        }
        private void NewNoteForm_FormClosing(object sender, FormClosingEventArgs e) // saves note and palette before closing
        {
            SavePalette();
        }
        private void NewNoteForm_Load(object sender, EventArgs e)
        {
            NoteModel lastNote = SqliteDataAccess.GetLastNote();
            if (lastNote != null)
            {
                txtTitle.Text = lastNote.Title;
                txtMessage.RtfText = lastNote.Message; // Assuming this property exists
            }
        }



        /// <summary>
        /// Helper Methods
        /// </summary>
        private void ClearFields() // Clears all form fields
        {
            txtMessage.Text = "";
            txtTitle.Text = "";
            lblDate.Text = "";
            selectedNote = ("", DateTime.MinValue);
        } 
        private void Updater()
        {
            if (!string.IsNullOrWhiteSpace(selectedNote.title)) // Ensure a note is selected
            {
                if (!string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    NoteModel updatedNote = new NoteModel
                    {
                        Title = txtTitle.Text,
                    };

                    // Update the note in the database using title and date from the selectedNote
                    SqliteDataAccess.UpdateNote(selectedNote.title, selectedNote.date, updatedNote.Title, txtMessage.RtfText);

                    ClearFields();

                    // Refresh the notes display
                    SqliteDataAccess.LoadNotes();
                    AccordionControl();
                    MessageBox.Show("Note updated successfully.");
                }
                else
                {
                    MessageBox.Show("Please complete your note.");
                }
            }
            else
            {
                MessageBox.Show("Please select a note to edit.");
            }
        }
        /**
        * ADD FUNCTIONALITY:
        * 
        * auto update selected note
        * auto add new note
        * 
        * localize notes.db in appdata
        */



        /// <summary>
        /// All button functionality
        /// </summary>
        private void ACTLNewNote_ItemClick(object sender, EventArgs e) // new note selection, located on the accordion control section
        {
            ClearFields();
        }
        private void btnNewNote_ItemClick(object sender, ItemClickEventArgs e) // new note selection, located on the menu bar
        {
            ClearFields();
        }
        private void btnUpdateNote_ItemClick(object sender, ItemClickEventArgs e) // update current note selection, located on the menu bar
        {
            Updater();
        }
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e) // delete current note selection, located on the menu bar
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this notebook and all notes within?", "Delete Notebook?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (selectedNotebook != -1)
                {
                    // Call your data access method to delete the note
                    SqliteDataAccess.DeleteNotebook(selectedNotebook);

                    // Refresh the notes display
                    SqliteDataAccess.LoadNotebooks();
                    SqliteDataAccess.LoadNotes();
                    AccordionControl();

                    // Clear the selected note
                    selectedNotebook = -1;
                    ClearFields();
                    MessageBox.Show("Notebook deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a notebook to delete.");
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }
        }
        private void btnHelp_ItemClick(object sender, ItemClickEventArgs e) // displays help menu, located on the menu bar
        {
            try
            {
                // Assuming your RTF file is named "Help.rtf" and located in the root folder
                string filePath = @".\Help.rtf";

                // Load the RTF file into the RichTextBox with Help in the title TextBox
                txtTitle.Text = "Help";
                lblDate.Text = "";
                txtMessage.LoadDocument(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading help documentation: " + ex.Message);
            }
        }
        private void btnComplete_Click(object sender, EventArgs e) // saves the note to the database with selected notebook, located on the main form
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

                ClearFields();

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
        /// all controls for the accordion control
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
                                Style = ElementStyle.Group,
                                Expanded = true,
                                
                            };
                            
                            notebookGroup.Click += (s, e) =>
                            {
                                OnNotebookSelected(notebookId);
                                //mnuNotebook.Show(MousePosition);
                            };

                            // Add the notebook group to the accordion control
                            accordionCtlNotes.Elements.Add(notebookGroup);

                            // Load notes for this specific notebook
                            string notesQuery = "SELECT title, date, message FROM messages WHERE notebook_id = @notebookId AND archived = 0";
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
        private void OnNoteItemClick(string title, DateTime date) // handles the selection of notes from the accordion control
        {
            if (noteMessages.TryGetValue((title, date), out byte[] rtfData))
            {
                txtTitle.Text = title;
                lblDate.Text = date.ToString("yyyy-MM-dd");
                txtMessage.RtfText = System.Text.Encoding.UTF8.GetString(rtfData); 

                selectedNote = (title, date);
            }
            else
            {
                MessageBox.Show("No message found for the selected entry.");
            }
        }
        private void OnNotebookSelected(int notebookId) // handles the selection of notebooks from the accordion control *ERROR* saves infinetly 
        {
            selectedNotebook = notebookId; // Store the selected notebook ID
        }
        private void accordionCtlNotes_FilterContent(object sender, FilterContentEventArgs e) // Filter notes using metadata, search bar on accordion control
        {
            // create filter content for search bar
        }
        private void accordionCtlNotes_DragDrop(object sender, DragEventArgs e)
        {
            OnNotebookSelected(selectedNotebook);
            SqliteDataAccess.UpdateNoteInNotebook(selectedNotebook, selectedNote.title, selectedNote.date);
            // Refresh the notes display
            SqliteDataAccess.LoadNotes();
            AccordionControl();
        }



        /// <summary>
        /// Context menu for the accordion control
        /// </summary>
        private void txtNewNotebook_KeyDown(object sender, KeyEventArgs e) // context menu for new notebook creation in the accordion control
        {
            if (e.KeyCode == Keys.Enter)
            {
                AccordionControlElement newGroup = accordionCtlNotes.Elements
                .FirstOrDefault(x => x.Text == "Notes");

                if (!string.IsNullOrWhiteSpace(txtNewNotebook.Text))
                {
                    newGroup = new AccordionControlElement
                    {
                        Text = txtNewNotebook.Text,
                        Style = ElementStyle.Group
                    };
                    SqliteDataAccess.SaveNotebook(txtNewNotebook.Text);
                }
                accordionCtlNotes.Elements.Add(newGroup);
                OnNotebookSelected(accordionCtlNotes.Elements.IndexOf(newGroup));
                txtNewNotebook.Text = "";

                SqliteDataAccess.LoadNotebooks();
            }
        }
        private void mnuDeleteNotebook_Click(object sender, EventArgs e) // context menu for deleting a notebook
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this notebook and all notes within?", "Delete Notebook?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (selectedNotebook != -1)
                {
                    // Call your data access method to delete the note
                    SqliteDataAccess.DeleteNotebook(selectedNotebook);

                    // Refresh the notes display
                    SqliteDataAccess.LoadNotebooks();
                    SqliteDataAccess.LoadNotes();
                    AccordionControl();

                    // Clear the selected note
                    selectedNotebook = -1;
                    ClearFields();
                    MessageBox.Show("Notebook deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a notebook to delete.");
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }
        }
        private void txtUpdateNotebook_KeyDown(object sender, KeyEventArgs e) // context menu for updating a notebook
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (selectedNotebook != -1) // Ensure a notebook is selected
                {
                    if (!string.IsNullOrWhiteSpace(txtUpdateNotebook.Text))
                    {
                        NotebookModel updatedNotebook = new NotebookModel
                        {
                            name = txtUpdateNotebook.Text
                        };

                        // Update the note in the database using title and date from the selectedNote
                        SqliteDataAccess.UpdateNotebook(selectedNotebook, txtUpdateNotebook.Text);

                        txtUpdateNotebook.Text = "";

                        // Refresh the notes display
                        SqliteDataAccess.LoadNotes();
                        AccordionControl();
                        MessageBox.Show("Notebook updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Please fill in your notebook name.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a notebook to edit.");
                }
            }
        }
        private void mnuNewNote_Click(object sender, EventArgs e) // Clears fields for new note creation
        {
            ClearFields();
        }
        private void mnuDeleteNote_Click(object sender, EventArgs e) // context menu for deleting a note
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this note?", "Delete Note?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
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
                    ClearFields();
                    MessageBox.Show("Note deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a note to delete.");
                }
            }
            else
            {
                MessageBox.Show("Deletion Canceled.");
            }
        }
        private void mnuArchiveNote_Click(object sender, EventArgs e)
        {
            // Call your data access method to archive the note
            SqliteDataAccess.ArchiveNote(selectedNote.title, selectedNote.date);

            // Refresh the notes display
            SqliteDataAccess.LoadNotes();
            AccordionControl();

            // Clear the selected note
            selectedNote = (null, DateTime.MinValue);
            ClearFields();
            MessageBox.Show("Note archived successfully.");
        }
        private void accordionCtlNotes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!string.IsNullOrEmpty(selectedNote.title))
                {
                    mnuNote.Show(MousePosition);
                    ClearFields();
                }
                else 
                {
                    mnuNotebook.Show(MousePosition);
                }
            }
            Console.WriteLine(GetControlAtPoint(this,e.Location));
        }
        private Control GetControlAtPoint(Control parent, Point point)
        {
            // Convert the point to the parent control's client coordinates
            Point clientPoint = parent.PointToClient(point);

            // Get the immediate child control at the specified point
            Control child = parent.GetChildAtPoint(clientPoint);

            if (child == null)
            {
                // No control found directly, return the parent if it's a container control
                return parent;
            }

            // If the child is a container, recursively check for nested children
            if (child.HasChildren)
            {
                // Recursively search for the control under the cursor within the child container
                return GetControlAtPoint(child, point);
            }

            // If no children, return the child control found
            return child;
        }
    }
}
