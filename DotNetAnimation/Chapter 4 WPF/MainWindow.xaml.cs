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

namespace Chapter_3
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

        private void CreateImages_Click(object sender, RoutedEventArgs e)
        {
            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Line line = new Line();
                line.X1 = 100;
                line.Y1 = 100;
                line.X2 = 300;
                line.Y2 = 100;
                line.Stroke = Brushes.Black;
                canvas.Children.Add(line);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Line.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Line line = new Line();
                line.X1 = 100;
                line.Y1 = 100;
                line.X2 = 300;
                line.Y2 = 100;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 5;
                canvas.Children.Add(line);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Line2.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 200;
                rectangle.Height = 150;
                rectangle.Stroke = Brushes.Black;

                Canvas.SetLeft(rectangle, 50);
                Canvas.SetTop(rectangle, 50);
                canvas.Children.Add(rectangle);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Rectangle.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 200;
                rectangle.Height = 150;
                rectangle.Fill = Brushes.Gray;

                Canvas.SetLeft(rectangle, 50);
                Canvas.SetTop(rectangle, 50);
                canvas.Children.Add(rectangle);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Rectangle Fill.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 200;
                rectangle.Height = 150;
                rectangle.RadiusX = 50;
                rectangle.RadiusY = 50;
                rectangle.Stroke = Brushes.Black;

                Canvas.SetLeft(rectangle, 50);
                Canvas.SetTop(rectangle, 50);
                canvas.Children.Add(rectangle);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Rectangle With Radius.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                SolidColorBrush solidColorBrush =
                    new SolidColorBrush(Color.FromArgb(125, 100, 100, 100));

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 150;
                rectangle.Height = 150;
                rectangle.Fill = solidColorBrush;

                Canvas.SetLeft(rectangle, 50);
                Canvas.SetTop(rectangle, 50);
                canvas.Children.Add(rectangle);

                Rectangle rectangle2 = new Rectangle();
                rectangle2.Width = 150;
                rectangle2.Height = 150;
                rectangle2.Fill = solidColorBrush;

                Canvas.SetLeft(rectangle2, 100);
                Canvas.SetTop(rectangle2, 100);
                canvas.Children.Add(rectangle2);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Trasparent Rectangle.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Ellipse ellipse = new Ellipse();
                ellipse.Width = 200;
                ellipse.Height = 200;
                ellipse.StrokeThickness = 5;
                ellipse.Stroke = Brushes.Black;

                Canvas.SetLeft(ellipse, 50);
                Canvas.SetTop(ellipse, 50);

                canvas.Children.Add(ellipse);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Ellipse.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Point point = new Point(50, 250);
                Size size = new Size(100, 100);
                ArcSegment arc =
                                new ArcSegment(point, size, 0, true, SweepDirection.Clockwise, true);

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = new Point(50, 50);
                pathFigure.Segments.Add(arc);
                pathFigure.IsClosed = false;
                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.StrokeThickness = 2;
                path.Data = new PathGeometry(new PathFigure[] { pathFigure });

                Canvas.SetLeft(path, 0);
                Canvas.SetTop(path, 0);
                canvas.Children.Add(path);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("Arc.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                Image image = new Image();
                image.Source = new BitmapImage(
                                new Uri(@"flower.jpg", UriKind.RelativeOrAbsolute)); ;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.Width = 200;
                image.Height = 200;

                Canvas.SetLeft(image, 50);
                Canvas.SetTop(image, 50);
                canvas.Children.Add(image);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("imagedraw.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                int radius = 150;
                Point centrePoint = new Point(100, 250);
                Point arcStartPoint = new Point(centrePoint.X, centrePoint.Y - radius);
                Point arcEndPoint = new Point(centrePoint.X + radius, centrePoint.Y);

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = arcStartPoint;

                ArcSegment arc =
               new ArcSegment(arcEndPoint, new Size(radius, radius),
               0, false, SweepDirection.Clockwise, true);
                pathFigure.Segments.Add(arc);

                LineSegment line1 = new LineSegment(centrePoint, true);
                pathFigure.Segments.Add(line1);

                LineSegment line2 = new LineSegment(arcStartPoint, true);
                pathFigure.Segments.Add(line2);

                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.Fill = Brushes.LightGray;
                path.Data = new PathGeometry(new PathFigure[] { pathFigure });

                Canvas.SetLeft(path, 0);
                Canvas.SetTop(path, 0);

                canvas.Children.Add(path);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("pie.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                double y = 0;
                double radius = 100;

                double xStart = Math.Cos(0 * Math.PI / 180) * radius;

                List<Point> starPoints = new List<Point>();
                for (int angle = 0; angle < 360; angle = angle + 72)
                {
                    double x = Math.Cos(angle * Math.PI / 180) * radius;
                    y = Math.Sin(angle * Math.PI / 180) * radius;
                    starPoints.Add(new Point(x + 100, y + 100));
                }

                Point p1 = starPoints[0];
                Point p2 = starPoints[1];
                Point p3 = starPoints[2];
                Point p4 = starPoints[3];
                Point p5 = starPoints[4];

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = p1;

                LineSegment line1 = new LineSegment(p2, true);
                pathFigure.Segments.Add(line1);

                LineSegment line2 = new LineSegment(p3, true);
                pathFigure.Segments.Add(line2);

                LineSegment line3 = new LineSegment(p4, true);
                pathFigure.Segments.Add(line3);

                LineSegment line4 = new LineSegment(p5, true);
                pathFigure.Segments.Add(line4);

                LineSegment line5 = new LineSegment(p1, true);
                pathFigure.Segments.Add(line5);

                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.Fill = Brushes.LightGray;
                path.Data = new PathGeometry(new PathFigure[] { pathFigure });

                Canvas.SetLeft(path, 100);
                Canvas.SetTop(path, 100);

                canvas.Children.Add(path);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("pentagon.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "Sample text";
                textBlock.FontSize = 60;
                textBlock.Foreground = new SolidColorBrush(Colors.Gray);
                Canvas.SetLeft(textBlock, 50);
                Canvas.SetTop(textBlock, 50);
                canvas.Children.Add(textBlock);

                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                        new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                        new System.IO.FileStream("text.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

           

        }
    }
}
