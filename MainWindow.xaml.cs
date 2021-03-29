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
using Microsoft.Win32;

namespace EX2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Example for injecting 15 buttons into the stackPanel
            int num = 15;
            for (int i = 0; i < num; i++)
            {
                System.Windows.Controls.Button button = new Button();
                {
                    button.Content = i.ToString();
                    button.Name = "Button" + i.ToString();
                    button.Click += new RoutedEventHandler(stackButton_Click); // set the click button to stackButton_Click
                }
                sp.Children.Add(button);
            }
        }
        // default function to handle all stackPanel button clicks.
        private void stackButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Console.WriteLine(b.Content.ToString());
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(e.Source.ToString());
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;
            openDialog.Filter = "Log Files|* .log|Textfiles|.txt|All files|.*";
            openDialog.DefaultExt = ".log";
            Nullable<bool> dialogOK = openDialog.ShowDialog();
            if (dialogOK == true)
            {
                string fileNames = "";
                foreach (string fileName in openDialog.FileNames)
                {
                    fileNames += ";" + fileName;
                }
                fileNames = fileNames.Substring(1);
                Console.WriteLine(fileNames);
            }
        }
    }
}