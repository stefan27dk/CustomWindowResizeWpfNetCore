using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomWindowResizeWpfNetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         // ::MainWindow::
        public MainWindow()
        {
            InitializeComponent();
        }


        // Close Button
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // Minimize Button
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        // Resize the Canvas Window :Thumbs:
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var str = (string)((Thumb)sender).Tag;

            if (str.Contains("T"))
            {
                Content.Height = Math.Min(Math.Max(Content.MinHeight, Content.ActualHeight - e.VerticalChange), Content.MaxHeight);
                Canvas.SetTop(Content, Canvas.GetTop(Content) - Content.Height + Content.ActualHeight);
            }
            if (str.Contains("L"))
            {
                Content.Width = Math.Min(Math.Max(Content.MinWidth, Content.ActualWidth - e.HorizontalChange), Content.MaxWidth);
                Canvas.SetLeft(Content, Canvas.GetLeft(Content) - Content.Width + Content.ActualWidth);
            }
            if (str.Contains("B"))
            {
                Content.Height = Math.Min(Math.Max(Content.MinHeight, Content.ActualHeight + e.VerticalChange), Content.MaxHeight);
            }
            if (str.Contains("R"))
            {
                Content.Width = Math.Min(Math.Max(Content.MinWidth, Content.ActualWidth + e.HorizontalChange), Content.MaxWidth);
            }
            if (str.Contains("M"))
            {
                Canvas.SetTop(Content, Canvas.GetTop(Content) + e.VerticalChange);
                Canvas.SetLeft(Content, Canvas.GetLeft(Content) + e.HorizontalChange);
            }

            e.Handled = true;
        }

    }
}
