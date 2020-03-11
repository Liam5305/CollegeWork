using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileExtensionsStarter;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileExtensionsStarter
{   [Serializable]
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// dbentries database
        /// </summary>
        DefaultProgDatabase dbentries;
        public const string FILE_NAME = "datafile.dat";
        
        public MainWindow()
        {
            InitializeComponent();
            dbentries = DefaultProgDatabase.Instance;

            //create  dbentries 
            //should then read in entries from file or use populate
            //you might want to use populate before adding persistence
            //dbentries = new DefaultProgDatabase();

            if (!File.Exists("datafile.dat"))
            {
                dbentries.populate(); // Testing purposes
            }
            else
            {
                IFormatter nformatter = new BinaryFormatter();
                Stream nstream = new FileStream("datafile.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
                dbentries = (DefaultProgDatabase)nformatter.Deserialize(nstream);
                nstream.Close();
            }
        }

        private void btnListAll_Click(object sender, RoutedEventArgs e)
        {
            textDisplay.Clear();
            try
            {
                textDisplay.Text = dbentries.getAll();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error dialog:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dbentries.isEmpty() == false)
            {
                if (MessageBox.Show("Are you sure you wish to delete all entries?", "Clear dialog: ", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dbentries.clearAll();
                    textDisplay.Clear();

                    MessageBox.Show("All entries deleted successfully.", "Clear dialog: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBox.Show("No entries were deleted!", "Clear dialog: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("There is no entries stored that will be deleted", "Clear dialog: ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAddEntry_Click(object sender, RoutedEventArgs e)
        {
                string extension = txtExtension.Text;
                string program = txtProgram.Text;

                if (extension == "" || program == "")
                {
                    MessageBox.Show("Incorrect information", "Add extension dialog: ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (dbentries.addEntry(extension, program) == true)
                    {
                        MessageBox.Show("File extension added successfully.", "Add extension dialog", MessageBoxButton.OK, MessageBoxImage.Information);
                        btnListAll.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    else
                    {
                        MessageBox.Show("File extension " + extension + " already exists. No extension added", "Add extension dialog: ", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                txtExtension.Clear();
                txtProgram.Clear();
                textDisplay.Clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string value = txtDelExtension.Text;

            if (dbentries.deleteEntry(value) == true)
            {
                MessageBox.Show("File extension " + value + " deleted successfully.", "Delete Dialog:", MessageBoxButton.OK, MessageBoxImage.Information);
                textDisplay.Clear();
                if (dbentries.isEmpty() != true)
                    btnListAll.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                MessageBox.Show("File extension " + value + " not found. No extension deleted.", "Delete Dialog:", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            txtDelExtension.Clear();
        }

        private void btnFindDefault_Click(object sender, RoutedEventArgs e)
        {
            string value = txtFindDefault.Text;
            string defaultProgram = "";

            try
            {
                defaultProgram = dbentries.findDefaultProgram(value);
                MessageBox.Show(defaultProgram, " Default Program Dialog: ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, " Error Dialog ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtFindDefault.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("datafile.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, dbentries);
            if (MessageBox.Show("Do you wish to save any changes made before quitting?", "Save Dialog:", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            if (MessageBox.Show("Do you wish to quit?", "Quit Dialog:", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;

            stream.Close();
        }
    }
}
