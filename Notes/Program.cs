using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Notes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NewNoteForm());


            /**
             * 
            string dbPath = "notes.db"; // Specify your database file name

            // Create a new database file
            using (var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database connection opened.");

                    // Create a new table (example)
                    string createTableQuery = @"CREATE TABLE IF NOT EXISTS Messages (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Title TEXT NOT NULL,
                                                Message TEXT NOT NULL,
                                                Date DATETIME DEFAULT CURRENT_TIMESTAMP
                                              );";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Table 'Messages' created or already exists.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("Database connection closed.");
                }
            }
             */
        }
    }
}
