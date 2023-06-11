using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
namespace Chapter_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Bitmap bmp = new Bitmap(1920, 1080);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = 
                    InterpolationMode.HighQualityBicubic;

                int startX = 0;
                int startY = 340;
                int xIncrement = 10;

                if (!Directory.Exists("ImageOutput"))
                    Directory.CreateDirectory("ImageOutput");

                if (!Directory.Exists("VideoOutput"))
                    Directory.CreateDirectory("VideoOutput");

                for (int i = 0; i < 125; i++)
                {
                    g.Clear(Color.White);
                    g.FillEllipse(Brushes.Gray,
                        new Rectangle(startX, startY, 400, 400));
                    string imageName = "000000000" + i;

                    imageName = 
                        imageName.Substring(imageName.Length - 6, 6);

                    bmp.Save("ImageOutput\\" + imageName + ".png");
                    Console.WriteLine("Created image " + imageName);
                    startX = startX + xIncrement;
                }
                CreateVideoFromImages(
                    Path.GetFullPath("ImageOutput\\"),
                    Path.GetFullPath("VideoOutput\\CircleMovingRight.mp4"));
            }

            {
                Bitmap bmp = new Bitmap(1920, 1080);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

                int startX = 760;
                int startY = 0;
                int yIncrement = 10;

                if (!Directory.Exists("ImageOutput"))
                    Directory.CreateDirectory("ImageOutput");

                if (!Directory.Exists("VideoOutput"))
                    Directory.CreateDirectory("VideoOutput");

                for (int i = 0; i < 125; i++)
                {
                    g.Clear(Color.White);
                    g.FillEllipse(Brushes.Gray,
                        new Rectangle(startX, startY, 400, 400));

                    string imageName = "000000000" + i;
                    imageName = 
                        imageName.Substring(imageName.Length - 6, 6);

                    bmp.Save("ImageOutput\\" + imageName + ".png");
                    Console.WriteLine("Created image " + imageName);
                    startY = startY + yIncrement;
                }
                CreateVideoFromImages(
                    Path.GetFullPath("ImageOutput\\"),
                    Path.GetFullPath("VideoOutput\\CircleMovingDown.mp4"));
            }

            {
                Bitmap bmp = new Bitmap(1920, 1080);
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = 
                    InterpolationMode.HighQualityBicubic;

                int sweepAngle = 3;

                if (!Directory.Exists("ImageOutput"))
                    Directory.CreateDirectory("ImageOutput");

                if (!Directory.Exists("VideoOutput"))
                    Directory.CreateDirectory("VideoOutput");

                for (int i = 0; i < 125; i++)
                {
                    g.Clear(Color.White);
                    g.FillPie(Brushes.Gray,
                     new Rectangle(760, 340, 400, 400), 0, sweepAngle);
                    string imageName = "000000000" + i;
                    imageName = 
                        imageName.Substring(imageName.Length - 6, 6);

                    bmp.Save("ImageOutput\\" + imageName + ".png");
                    Console.WriteLine("Created image " + imageName);
                    sweepAngle = sweepAngle + 3;
                }
                CreateVideoFromImages(
                    Path.GetFullPath("ImageOutput\\"),
                    Path.GetFullPath("VideoOutput\\CircleCompletion.mp4"));
            }

            Process.Start("explorer.exe", "VideoOutput\\");

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
                Console.WriteLine("Creating Video " +
                    "From Images completed successfully!");
            }
            else
            {
                Console.WriteLine($"FFmpeg processing " +
                    $"failed with exit code: {exitCode}");
            }
        }

    
    }
}
