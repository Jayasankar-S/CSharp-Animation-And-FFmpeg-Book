using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Chapter_6
{
    internal class Program
    {
        static Brush[] brushes = new Brush[]
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
        static void Main(string[] args)
        {
            if (!System.IO.Directory.Exists("ImageOutput"))
                System.IO.Directory.CreateDirectory("ImageOutput");

            if (!System.IO.Directory.Exists("VideoOutput"))
                System.IO.Directory.CreateDirectory("VideoOutput");


            int angleIncrement = 1;
            for (int i = 0; i < 1000; i++)
            {
                Bitmap bmp = new Bitmap(1920, 1080);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.PageUnit = GraphicsUnit.Pixel;

                g.Clear(Color.White);
                g.TranslateTransform(1920 / 2, 1080 / 2);
                g.RotateTransform(angleIncrement);
                GraphicsPath flowerPetal = GetFlowerPetalPath();
                for (int j = 0; j < 9; j++)
                {
                    g.FillPath(brushes[j], flowerPetal);
                    g.RotateTransform(40);

                }

                string imageName = ("000000000" + i.ToString());
                imageName = imageName.Substring(imageName.Length - 6, 6) + ".png";

                bmp.Save(Path.GetFullPath("ImageOutput\\" + imageName));
                Console.WriteLine("Created image " + imageName);
                angleIncrement++;
            }

            CreateVideoFromImages(System.IO.Path.GetFullPath("ImageOutput\\"),
             System.IO.Path.GetFullPath("VideoOutput\\Rotating Flower.mp4"));
        }

        static private GraphicsPath GetFlowerPetalPath()
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddBezier(
                            new Point(0, 0),
                            new Point(-200, 450),
                            new Point(200, 450),
                            new Point(0, 0));
            graphicsPath.CloseFigure();
            return graphicsPath;
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
