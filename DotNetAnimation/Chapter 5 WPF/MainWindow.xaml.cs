using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Chapter_4
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

                LineSegment line1 = new LineSegment(p4, true);
                pathFigure.Segments.Add(line1);

                LineSegment line2 = new LineSegment(p2, true);
                pathFigure.Segments.Add(line2);

                LineSegment line3 = new LineSegment(p5, true);
                pathFigure.Segments.Add(line3);

                LineSegment line4 = new LineSegment(p3, true);
                pathFigure.Segments.Add(line4);

                LineSegment line5 = new LineSegment(p1, true);
                pathFigure.Segments.Add(line5);

                Path path = new Path();

                path.Stroke = Brushes.Black;

                path.Data = new PathGeometry(new PathFigure[] { pathFigure });

                Canvas.SetLeft(path, 100);
                Canvas.SetTop(path, 100);

                canvas.Children.Add(path);
                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);

                System.IO.FileStream fileStream =
                new System.IO.FileStream("star1.png", System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                Size canvasSize = new Size(400, 400);
                canvas.Measure(canvasSize);
                canvas.Background = Brushes.White;


                System.Windows.FontStyle fontStyle = FontStyles.Normal;
                FontWeight fontWeight = FontWeights.Medium;

                Typeface typeface = new Typeface(new FontFamily("Comic Sans MS"),
                     fontStyle, fontWeight, FontStretches.Normal);

                FormattedText formattedText =
                    new FormattedText("Text", CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight, typeface, 100,
                    System.Windows.Media.Brushes.Black, 96);

                Geometry textGeometry =
                       formattedText.BuildGeometry(new System.Windows.Point(0, 0));

                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.Fill = Brushes.Gray;
                path.StrokeThickness = 5;
                path.Data = textGeometry;

                Canvas.SetLeft(path, 100);
                Canvas.SetTop(path, 100);

                canvas.Children.Add(path);
                canvas.Arrange(new Rect(canvasSize));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap((int)canvasSize.Width,
                    (int)canvasSize.Height, 96, 96, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream = 
                    new System.IO.FileStream("Text1.png", 
                    System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                Size canvasSize = new Size(400, 400);
                canvas.Measure(canvasSize);
                canvas.Background = Brushes.White;


                System.Windows.FontStyle fontStyle = FontStyles.Normal;
                FontWeight fontWeight = FontWeights.Medium;

                Typeface typeface = 
                    new Typeface(new FontFamily("Comic Sans MS"), 
                    fontStyle, fontWeight, FontStretches.Normal);

                FormattedText formattedText = 
                    new FormattedText("Text", CultureInfo.GetCultureInfo("en-us"), 
                    FlowDirection.LeftToRight, typeface, 100, 
                    System.Windows.Media.Brushes.Black, 90);

                Geometry textGeometry = formattedText.BuildGeometry(
                    new System.Windows.Point((canvasSize.Width - formattedText.Width) / 2, 
                    (canvasSize.Height - formattedText.Height) / 2));

                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.Fill = Brushes.Gray;
                path.StrokeThickness = 5;
                path.Data = textGeometry;

                canvas.Children.Add(path);
                canvas.Arrange(new Rect(canvasSize));

                RenderTargetBitmap renderTargetBitmap = 
                    new RenderTargetBitmap((int)canvasSize.Width, 
                    (int)canvasSize.Height, 96, 96, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream = 
                    new System.IO.FileStream("Text2.png", System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                Size canvasSize = new Size(400, 400);
                canvas.Measure(canvasSize);
                canvas.Background = Brushes.White;

                Point point1 = new Point(190, 280);
                Point point2 = new Point(350, 70);
                Point point3 = new Point(200, 60);
                Point point4 = new Point(50, 70);
                Point point5 = new Point(210, 280);

                PointCollection pointCollection =
                    new PointCollection { point2, point3, point4, point5 };
                PolyQuadraticBezierSegment polyQuadraticBezierSegment =
                    new PolyQuadraticBezierSegment(pointCollection, true);

                PathFigure pathFigure = new PathFigure();
                pathFigure.StartPoint = point1;
                pathFigure.Segments.Add(polyQuadraticBezierSegment);
                pathFigure.IsClosed = false;
                Path path = new Path();

                path.Stroke = Brushes.Black;
                path.StrokeThickness = 5;

                path.Data = new PathGeometry(new PathFigure[] { pathFigure });

                canvas.Children.Add(path);
                canvas.Arrange(new Rect(canvasSize));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap((int)canvasSize.Width,
                    (int)canvasSize.Height, 96, 96, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                    new System.IO.FileStream("Balloon.png", System.IO.FileMode.Create);
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
                rectangle.Height = 200;
                rectangle.Stroke = new SolidColorBrush(Colors.Black);
                rectangle.Fill = new SolidColorBrush(Colors.Gray);

                Canvas.SetLeft(rectangle, 100);
                Canvas.SetTop(rectangle, 100);
                canvas.Children.Add(rectangle);
                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                    new System.IO.FileStream("SolidBrush.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                LinearGradientBrush brush = new LinearGradientBrush();

                brush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
                brush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
                brush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 200;
                rectangle.Height = 200;
                rectangle.Fill = brush;

                Canvas.SetLeft(rectangle, 100);
                Canvas.SetTop(rectangle, 100);
                canvas.Children.Add(rectangle);
                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(400, 400, 96, 96, 
                    PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);

                System.IO.FileStream fileStream =
                    new System.IO.FileStream("LinearGradientBrush.png", 
                    System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder =
                    new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(400, 400));
                canvas.Background = Brushes.White;

                RadialGradientBrush brush = new RadialGradientBrush();

                brush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
                brush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
                brush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

                Rectangle rectangle = new Rectangle();
                rectangle.Width = 200;
                rectangle.Height = 200;
                rectangle.Fill = brush;

                Canvas.SetLeft(rectangle, 100);
                Canvas.SetTop(rectangle, 100);
                canvas.Children.Add(rectangle);
                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(400, 400, 96, 96, 
                    PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);

                System.IO.FileStream fileStream =
                    new System.IO.FileStream("RadialGradientBrush.png", 
                    System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder =
                    new PngBitmapEncoder();
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
                rectangle.Height = 200;
                rectangle.Fill =
                    new ImageBrush(new BitmapImage(new Uri(@"flower.jpg", UriKind.RelativeOrAbsolute)));

                Canvas.SetLeft(rectangle, 100);
                Canvas.SetTop(rectangle, 100);
                canvas.Children.Add(rectangle);
                canvas.Arrange(new Rect(new Size(400, 400)));

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                    new System.IO.FileStream("ImageBrush.png", System.IO.FileMode.Create);
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
                rectangle.Height = 200;

                System.Windows.FontStyle fontStyle = FontStyles.Normal;
                FontWeight fontWeight = FontWeights.Medium;

                Typeface typeface =
                    new Typeface(new FontFamily("Comic Sans MS"),
                    fontStyle, fontWeight, FontStretches.Normal);

                FormattedText formattedText =
                    new FormattedText("Text", CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight,
                    typeface, 100, System.Windows.Media.Brushes.Black, 90);

                Geometry textGeometry = 
                    formattedText.BuildGeometry(new System.Windows.Point(0, 0));

                GeometryDrawing geometryDrawing =
                    new GeometryDrawing(Brushes.Pink, new Pen(Brushes.Red, 5), textGeometry);

                rectangle.Fill = new DrawingBrush(geometryDrawing);

                Canvas.SetLeft(rectangle, 100);
                Canvas.SetTop(rectangle, 100);
                canvas.Children.Add(rectangle);
                canvas.Arrange(new Rect(new Size(400, 400)));


                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(400, 400, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);

                System.IO.FileStream fileStream =
                    new System.IO.FileStream("DrawingBrush.png", System.IO.FileMode.Create);
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

            {
                Canvas canvas = new Canvas();
                canvas.Measure(new Size(500, 500));
                canvas.Background = Brushes.Transparent;

                System.Windows.FontStyle fontStyle = FontStyles.Normal;
                FontWeight fontWeight = FontWeights.Medium;

                Typeface typeface =
                    new Typeface(new FontFamily("Comic Sans MS"),
                    fontStyle, fontWeight, FontStretches.Normal);

                FormattedText formattedText =
                    new FormattedText("Text", CultureInfo.GetCultureInfo("en-us"),
                    FlowDirection.LeftToRight, typeface, 160, System.Windows.Media.Brushes.Black, 90);

                Geometry textGeometry = formattedText.BuildGeometry(new System.Windows.Point(0, 0));

                Image image = new Image();
                image.Source = new BitmapImage(
                    new Uri(@"flower.jpg", UriKind.RelativeOrAbsolute)); ;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.Clip = textGeometry;

                Canvas.SetLeft(image, 50);
                Canvas.SetTop(image, 50);

                canvas.Children.Add(image);
                canvas.Arrange(new Rect(new Size(500, 500)));


                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(500, 500, 96, 96, PixelFormats.Pbgra32);

                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                    new System.IO.FileStream("imageclip.png", System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }

           

        }
    }
}
