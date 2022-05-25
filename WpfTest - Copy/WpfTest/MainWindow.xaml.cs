using System;
using System.Diagnostics;
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
using WpfTest.Commands;
using WpfTest.Converters;
using WpfTest.ViewModels;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Level l = new Level(3, 3);
        public MainWindow()
        {
            InitializeComponent();
            CreateLevel(l);
            ContentRendered += DrawAllLines;


            Et.Click += ClickTest;
            

        }

        void ClickTest(object sender, RoutedEventArgs e)
        {
            l.Reset();
        }

        void CreateLevel(Level level)
        {

            Et.Content = level.startNumber;
            To.Content = level.finalNumber;

            double mainWidth = LevelGrid.Width;
            double mainHeight = LevelGrid.Height;
            double buttonSize = 50;

            double buttonCollumMargin = (mainWidth - (buttonSize * level.Collums)) / (level.Collums * 2);
            double rCount = level.Rows * 2 - 1;
            double rowMargin = (mainHeight - (buttonSize * rCount)) / (rCount * 2);

            //Rows
            for (int i = 0; i < level.Rows; i++)
            {
                StackPanel rowPanel = new StackPanel();

                rowPanel.Width = mainWidth;
                rowPanel.Height = buttonSize;
                rowPanel.Orientation = Orientation.Horizontal;
                rowPanel.Margin = new Thickness(0, rowMargin, 0, rowMargin);

                Binding colorBinding = new Binding("Used");
                colorBinding.Source = level.operatorRows[i];
                colorBinding.Converter = new BoolToColorConverter(Brushes.LightGray, Brushes.DarkGray);
                rowPanel.SetBinding(StackPanel.BackgroundProperty, colorBinding);

                //Collums
                for (int ii = 0; ii < level.Collums; ii++)
                {
                    Button b = new Button();
                    b.Command = new FieldClickCommand(level,i, ii);
                    b.Width = buttonSize;
                    b.Height = buttonSize;
                    b.Content = level.operatorRows[i].fields[ii].ToString();
                    b.Margin = new Thickness(buttonCollumMargin, 0, buttonCollumMargin, 0);
                    rowPanel.Children.Add(b);
                }

                LevelGrid.Children.Insert(0, rowPanel);

                //MidButton
                if (i < level.Rows - 1)
                {
                    Button button = new Button();
                    button.Width = 50;
                    button.Height = 50;

                    //Binding Test
                    Binding binding = new Binding("DisplayField");
                    binding.Source = level.operatorRows[i];
                    button.SetBinding(Button.ContentProperty, binding);
                    //----

                    button.Margin = new Thickness(0, rowMargin, 0, rowMargin);
                    LevelGrid.Children.Insert(0, button);
                }
            }
        }

        void DrawAllLines(object? sender, EventArgs e)
        {
            for(int i = 0; i < LevelGrid.Children.Count; i++)
            {
                if(i == 0)
                {
                    var row = LevelGrid.Children[i] as StackPanel;
                    foreach (FrameworkElement element in row.Children)
                    {
                        DrawLine(element, 225, 0,MertHelper.Position.Top);
                        var nextField = LevelGrid.Children[i + 1] as FrameworkElement;
                        DrawLine(element, nextField, MertHelper.Position.Bottom, MertHelper.Position.Top);
                    }
                }
                else if(i == LevelGrid.Children.Count -1)
                {
                    var row = LevelGrid.Children[i] as StackPanel;
                    foreach (FrameworkElement element in row.Children)
                    {
                        DrawLine(element, 225, 500, MertHelper.Position.Bottom);
                        var previousField = LevelGrid.Children[i - 1] as FrameworkElement;
                        DrawLine(element, previousField, MertHelper.Position.Top, MertHelper.Position.Bottom);
                    }
                }
                else
                {
                    if(LevelGrid.Children[i] is StackPanel)
                    {
                        var row = LevelGrid.Children[i] as StackPanel;
                        foreach (FrameworkElement element in row.Children)
                        {
                            var previousField = LevelGrid.Children[i - 1] as FrameworkElement;
                            DrawLine(element, previousField, MertHelper.Position.Top, MertHelper.Position.Bottom);
                            var nextField = LevelGrid.Children[i + 1] as FrameworkElement;
                            DrawLine(element, nextField, MertHelper.Position.Bottom, MertHelper.Position.Top);
                        }
                    }
                }
            }
        }
        
        void DrawLine(FrameworkElement element1, FrameworkElement element2, MertHelper.Position position1 = MertHelper.Position.Center,MertHelper.Position position2 = MertHelper.Position.Center)
        {
            Line myLine = new Line();

            Point p1 = MertHelper.FindPosition(element1, LevelCanvas,position1);
            Point p2 = MertHelper.FindPosition(element2, LevelCanvas,position2);

            DrawLine(p1.X, p1.Y, p2.X, p2.Y);
        }

        void DrawLine(FrameworkElement element1, double x, double y, MertHelper.Position position = MertHelper.Position.Center)
        {
            Line myLine = new Line();

            Point p1 = MertHelper.FindPosition(element1, LevelCanvas,position);
            Point p2 = new Point(x,y);

            DrawLine(p1.X, p1.Y, p2.X, p2.Y);
        }

        void DrawLine(double x1, double y1, double x2, double y2)
        {
            Line myLine = new Line();

            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);


            myLine.Stroke = Brushes.Black;
            myLine.X1 = p1.X;
            myLine.Y1 = p1.Y;
            myLine.X2 = p2.X;
            myLine.Y2 = p2.Y;
            myLine.StrokeThickness = 3;
            LevelCanvas.Children.Add(myLine);
        }


        void TestLine2(object? sender, EventArgs e)
        {

        }

        Button CreateButton(int id, int rowPlacement, int collumPlacement)
        {
            Button b = new Button();
            b.Content = id.ToString();
            Grid.SetRow(b, rowPlacement);
            Grid.SetColumn(b, collumPlacement);
            b.Margin = new Thickness(20, 20, 20, 20);
            return b;
        }
    }
}
