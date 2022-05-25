using System.Windows;

namespace WpfTest
{
    public static class MertHelper
    {
        public enum Position {Left,Top,Right,Bottom,Center };
        //Finder center punktet i et ui element i forhold til et andet
        public static Point CenterOfElement(FrameworkElement element, FrameworkElement elementRelativeTo)
        {
            //For fat i top/left punktet i elementet
            Point point = element.TranslatePoint(new Point(0, 0), elementRelativeTo);
            
            //Udregner centrum
            point.X += element.Width / 2;
            point.Y += element.Height / 2;
            return point;
        }

        public static Point FindPosition(FrameworkElement element, FrameworkElement elementRelativeTo, Position position = Position.Center)
        {
            //For fat i top/left punktet i elementet
            Point point = element.TranslatePoint(new Point(0, 0), elementRelativeTo);

            switch (position)
            {
                case Position.Left:
                    point.Y += element.Height / 2;
                    return point;
                case Position.Top:
                    point.X += element.Width / 2;
                    return point;
                case Position.Right:
                    point.X += element.Width;
                    point.Y += element.Height / 2;
                    return point;
                case Position.Bottom:
                    point.X += element.Width / 2;
                    point.Y += element.Height;
                    return point;   
                case Position.Center:
                    point.X += element.Width / 2;
                    point.Y += element.Height / 2;
                    return point;
                default:
                    return point;
            }
        }
    }
}
