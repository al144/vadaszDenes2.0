using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vadaszDenes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnMapUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog mapFile = new OpenFileDialog();
            if (mapFile.ShowDialog() != true)
            {
                tbMapFile.Content = "Select a file";
                return;
            }

            Map map = new Map(File.ReadAllLines(mapFile.FileName));
            tbMapFile.Content = $"Start Position: ({map.StartPosition[0]}, {map.StartPosition[1]})";



        }

    }
}