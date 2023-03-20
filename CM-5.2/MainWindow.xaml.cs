using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CM_5._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Inkanvas Format(*.sandy)|*.sandy|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var fs = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                drawing.Strokes = strokes;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter= "Inkanvas Format(*.sandy)|*.sandy|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog()== true)
            {
                FileStream fs = File.Open(saveFileDialog.FileName, FileMode.Create);
                drawing.Strokes.Save(fs);
                fs.Flush();
                fs.Close();
            }    
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (drawing!=null)
            {
                drawing.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (drawing != null)
            {
                drawing.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

       
    }
}
