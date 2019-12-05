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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EpicRandomArena.Views
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();
            DrawCanvas();
            DoubleAnimation a = new DoubleAnimation();
            a.From = 0;
            a.To = 360;
            a.RepeatBehavior = RepeatBehavior.Forever;
            a.SpeedRatio = 2;

            Spin.BeginAnimation(RotateTransform.AngleProperty, a);
        }

        void DrawCanvas()
        {
            for (int i = 0; i < 12; i++)
            {
                Line line = new Line()
                {
                    X1 = 50,
                    X2 = 50,
                    Y1 = 0,
                    Y2 = 20,
                    StrokeThickness = 7,
                    Stroke = Brushes.White,
                    Width = 100,
                    Height = 200
                };
                line.VerticalAlignment = VerticalAlignment.Center;
                line.HorizontalAlignment = HorizontalAlignment.Center;
                line.RenderTransformOrigin = new Point(.5, .5);
                line.RenderTransform = new RotateTransform(i * 30);
                line.Opacity = (double)i / 12;

                SpinnerCanvas.Children.Add(line);

            }
        }
    }
}
