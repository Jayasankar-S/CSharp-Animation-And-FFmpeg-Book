using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chapter_7_WPF
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
            Brush[] brushes = new Brush[]
            {
                Brushes.Violet,
                Brushes.Indigo,
                Brushes.Blue,
                Brushes.Green,
                Brushes.Yellow,
                Brushes.Orange,
                Brushes.Red,
            };

            int arcNumber = 0;
            Double currentArcPercentage = 0;
            int canvasWidth = 1920;
            int canvasHeight = 1080;

            if (!System.IO.Directory.Exists("ImageOutput"))
                System.IO.Directory.CreateDirectory("ImageOutput");

            if (!System.IO.Directory.Exists("VideoOutput"))
                System.IO.Directory.CreateDirectory("VideoOutput");

            int imageCount = 0;
            Canvas canvas = new Canvas();
            canvas.Measure(new Size(canvasWidth, canvasHeight));

            while (true)
            {
                canvas.Background = Brushes.White;

                if (currentArcPercentage > 100)
                {
                    currentArcPercentage = 0;
                    arcNumber++;

                    if (arcNumber >= 7)
                        break;
                }

                AddRainbow(canvas, brushes, arcNumber,
                    currentArcPercentage, 
                    canvasWidth, canvasHeight);

                SaveCanvasToImage(canvas, canvasWidth,
                    canvasHeight, imageCount, "ImageOutput\\");

                currentArcPercentage = 
                    currentArcPercentage + 0.5;
                imageCount++;
            }

            CreateVideoFromImages("ImageOutput\\", 
                "VideoOutput\\Rainbow.mp4");
        }
        private void AddRainbow(Canvas canvas, Brush[] brushes, 
            int arcNumber, double currentArcPercentage, 
            int canvasWidth, int canvasHeight)
        {
            Size arcSize;
            int initialXRadius = 300;
            int initialYRadius = 200;
            int arcThickness = 100;

            for (int j = 0; j < arcNumber; j++)
            {
                arcSize = new Size(
                    initialXRadius + (j * arcThickness),
                    initialYRadius + (j * arcThickness));

                AddArc(canvas, brushes[j], 
                    new Point(canvasWidth / 2, canvasHeight),
                    arcSize, arcThickness, arcThickness);
            }

            arcSize = new Size(
                initialXRadius + (arcNumber * arcThickness),
                initialYRadius + (arcNumber * arcThickness));

            AddArc(canvas, brushes[arcNumber], 
                new Point(canvasWidth / 2, canvasHeight),
                arcSize, arcThickness, currentArcPercentage);
        }
        private void AddArc(Canvas canvas, Brush brush, 
                        Point arcCentre, Size size, 
                        int arcThickness, Double percentage)
        {
            double xRadius = size.Width;
            double yRadius = size.Height;

            double angle = (180 * percentage / 100) - 180;

            double x = arcCentre.X + 
                Math.Cos(angle * Math.PI / 180) * xRadius;

            double y = arcCentre.Y + 
                Math.Sin(angle * Math.PI / 180) * yRadius;

            ArcSegment arcSegment =
                new ArcSegment(new Point(x, y), 
                size, 0, false, SweepDirection.Clockwise, 
                true);

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint =
                new Point(arcCentre.X - size.Width, arcCentre.Y);
            pathFigure.Segments.Add(arcSegment);

            Path path = new Path();
            path.Stroke = brush;
            path.StrokeThickness = arcThickness;

            path.Data = new PathGeometry(
                new PathFigure[] { pathFigure });

            canvas.Children.Add(path);
        }
        private static void SaveCanvasToImage(
            Canvas canvas, int canvasWidth, int canvasHeight, 
            int imageIndex, string outputFolder)
        {
            canvas.Arrange(
                new Rect(new Size(canvasWidth, canvasHeight)));

            string imageName = 
                ("000000000" + imageIndex.ToString());

            imageName = 
                imageName.Substring(imageName.Length - 6, 6) + 
                ".png";

            RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap(canvasWidth,
                canvasHeight, 96, 96, PixelFormats.Pbgra32);

            renderTargetBitmap.Render(canvas);

            System.IO.FileStream fileStream =
                new System.IO.FileStream(outputFolder + imageName, 
                System.IO.FileMode.Create);

            PngBitmapEncoder pngBitmapEncoder = 
                new PngBitmapEncoder();

            pngBitmapEncoder.Frames.Add(
                BitmapFrame.Create(renderTargetBitmap));

            pngBitmapEncoder.Save(fileStream);

            Console.WriteLine("Created image " + imageName);
            fileStream.Close();
            canvas.Children.Clear();
            renderTargetBitmap.Clear();
            pngBitmapEncoder = null;
            renderTargetBitmap = null;
            fileStream = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
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
