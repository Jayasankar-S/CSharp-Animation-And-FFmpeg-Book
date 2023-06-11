using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chapter_6_WPF
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

        private void CreateVideo_Click(object sender, RoutedEventArgs e)
        {
            if (!System.IO.Directory.Exists("ImageOutput"))
                System.IO.Directory.CreateDirectory("ImageOutput");

            if (!System.IO.Directory.Exists("VideoOutput"))
                System.IO.Directory.CreateDirectory("VideoOutput");

            Brush[] brushes = new Brush[]
            {
                Brushes.DarkMagenta,
                Brushes.DarkSalmon,
                Brushes.DarkOliveGreen,
                Brushes.Gray,
                Brushes.Lime,
                Brushes.LightCoral,
                Brushes.SpringGreen,
                Brushes.Yellow,
                Brushes.Pink,
                Brushes.GreenYellow
            };

            int angleIncrement = 1;

            for (int i = 0; i < 1000; i++)
            {

                Canvas canvas = new Canvas();
                canvas.Measure(new Size(1920, 1080));
                canvas.Background = Brushes.White;

                for (int j = 0; j < 9; j++)
                {

                    Path flowerPetal =
                        GetFlowerPetalPath(
                            new Point(0, 0),
                            new Point(-200, 450),
                            new Point(0, 440),
                            new Point(200, 450), brushes[j]);

                    flowerPetal.RenderTransform =
                            new RotateTransform(angleIncrement + (40 * j), 0, 0);

                    Canvas.SetLeft(flowerPetal, 900);
                    Canvas.SetTop(flowerPetal, 500);
                    // Adding petals to canvas
                    canvas.Children.Add(flowerPetal);
                }

                // Arranging the children in Canvas.
                canvas.Arrange(new Rect(new Size(1920, 1080)));

                string imageName = ("000000000" + i.ToString());
                imageName = imageName.Substring(imageName.Length - 6, 6) + ".png";

                // Following lines of code, save canvas as a png image file to disk.  
                RenderTargetBitmap renderTargetBitmap =
                                new RenderTargetBitmap(1920, 1080, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(canvas);
                System.IO.FileStream fileStream =
                    new System.IO.FileStream(
                    System.IO.Path.GetFullPath("ImageOutput\\" + imageName),
                            System.IO.FileMode.Create);

                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                pngBitmapEncoder.Save(fileStream);// saving the image
                Console.WriteLine("Created image " + imageName);
                fileStream.Close();
                canvas.Children.Clear();
                renderTargetBitmap.Clear();
                pngBitmapEncoder = null;
                renderTargetBitmap = null; 
                fileStream = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //angleIncrement increases by one after each image creation. 
                angleIncrement++;
            }

            // All images are created. Using the FFmpeg command with appropriate arguments, 
            CreateVideoFromImages(System.IO.Path.GetFullPath("ImageOutput\\"),
                        System.IO.Path.GetFullPath("VideoOutput\\Rotating Flower.mp4"));
        }

        private Path GetFlowerPetalPath(Point point1, Point point2,
                            Point point3, Point point4, Brush brush)
        {
            // Creating a Bezier curve using points given.
            PointCollection pointCollection =
                        new PointCollection { point2, point3, point4, point1 };
            PolyQuadraticBezierSegment polyQuadraticBezierSegment =
                        new PolyQuadraticBezierSegment(pointCollection, false);

            // PathFigure is created, and adding PolyQuadraticBezierSegment to it.
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = point1;
            pathFigure.Segments.Add(polyQuadraticBezierSegment);
            pathFigure.IsClosed = true;
            Path path = new Path();

            //Brush to fill color.
            path.Fill = brush;

            // Adding PathFigure to Path 
            path.Data = new PathGeometry(new PathFigure[] { pathFigure });
            return path;
        }

        public static void CreateVideoFromImages(
                        string inputImagesfolder,
                        string videoOutputFile)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -i  \"" +
                inputImagesfolder +
                 "%06d.png\" -y -pix_fmt yuv420p  \""
                 + videoOutputFile + "\" "; ;

            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();

            int exitCode = process.ExitCode;
            if (exitCode == 0)
            {
                Console.WriteLine("Creating Video From" +
                    " Images completed successfully!");
            }
            else
            {
                Console.WriteLine($"FFmpeg processing " +
                    $"failed with exit code: {exitCode}");
            }
        }
    }
}
