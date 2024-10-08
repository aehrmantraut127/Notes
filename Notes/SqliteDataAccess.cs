﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    public class SqliteDataAccess
    {
        /// <summary>
        /// Loads all notebooks from the database.
        /// </summary>
        /// <returns>A list of notebook names.</returns>
        public static List<NotebookModel> LoadNotebooks()
        {
            var notebooks = new List<NotebookModel>();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (var command = new SQLiteCommand("SELECT notebookID, name FROM notebooks", (SQLiteConnection)cnn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var notebook = new NotebookModel
                            {
                                notebookID = reader.GetInt32(0), 
                                name = reader.GetString(1) 
                            };
                            notebooks.Add(notebook);
                        }
                    }
                }
            }

            return notebooks;
        }

        /// <summary>
        /// Saves a new notebook to the database.
        /// </summary>
        /// <param name="name">The name of the notebook.</param>
        public static void SaveNotebook(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (var command = new SQLiteCommand("INSERT INTO notebooks (name) VALUES (@name)", (SQLiteConnection)cnn))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a notebook from the database.
        /// </summary>
        /// <param name="name">The name of the notebook.</param>
        public static void DeleteNotebook(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "DELETE FROM notebooks WHERE name = @name";

                using (var cmd = new SQLiteCommand(query, (SQLiteConnection)cnn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Works with SQLite to load all records from the database
        /// </summary>
        /// <returns></returns>
        public static List<NoteModel> LoadNotes()
        {
            var notes = new List<NoteModel>();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (var command = new SQLiteCommand("SELECT title, date, message FROM messages", (SQLiteConnection)cnn))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var note = new NoteModel
                            {
                                Title = reader.GetString(0),
                                // Convert from byte array to string for RichTextBox
                                Message = System.Text.Encoding.UTF8.GetString((byte[])reader["message"]) // Convert byte array to RTF string
                            };
                            notes.Add(note);
                        }
                    }
                }
            }

            return notes;
        }

        /// <summary>
        /// works with SQLite to save all records to the database
        /// </summary>
        /// <param name="note"></param>
        /// <param name="rtfContent"></param>
        public static void SaveNote(NoteModel note, string rtfContent, int notebookId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                using (var command = new SQLiteCommand("INSERT INTO messages (title, date, message, notebook_id) VALUES (@title, @date, @message, @notebook_id)", (SQLiteConnection)cnn))
                {
                    command.Parameters.AddWithValue("@title", note.Title);
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@message", System.Text.Encoding.UTF8.GetBytes(rtfContent)); // Convert RTF string to byte array
                    command.Parameters.AddWithValue("@notebook_id", notebookId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// connection string creator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /// <summary>
        /// Allows for the deletion of records from the database (SQLite)
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        public static void DeleteNote(string title, DateTime date)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "DELETE FROM messages WHERE title = @title AND date = @date";

                using (var cmd = new SQLiteCommand(query, (SQLiteConnection)cnn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateNote(string oldTitle, DateTime oldDate, string newTitle, string rtfText)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string query = "UPDATE messages SET title = @NewTitle, message = @Message, date = @NewDate WHERE title = @OldTitle AND date = @OldDate";

                using (var cmd = new SQLiteCommand(query, (SQLiteConnection)cnn))
                {
                    cmd.Parameters.AddWithValue("@NewTitle", newTitle);
                    cmd.Parameters.AddWithValue("@Message", rtfText); // Assuming the RTF content is a string
                    cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@OldTitle", oldTitle); // Use the previously selected title
                    cmd.Parameters.AddWithValue("@OldDate", oldDate); // Use the previously selected date
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
