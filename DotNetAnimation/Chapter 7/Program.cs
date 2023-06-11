using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Chapter_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!System.IO.Directory.Exists("ImageOutput"))
                System.IO.Directory.CreateDirectory("ImageOutput");

            if (!System.IO.Directory.Exists("VideoOutput"))
                System.IO.Directory.CreateDirectory("VideoOutput");

            int bitmapWidth = 1920;
            int bitmapheight = 1080;
            int arcThickness = 100;

            Pen[] pens = new Pen[]
            {
                new Pen(Color.Violet,arcThickness),
                new Pen(Color.Indigo,arcThickness),
                new Pen(Color.Blue,arcThickness),
                new Pen(Color.Green,arcThickness),
                new Pen(Color.Yellow,arcThickness),
                new Pen(Color.Orange,arcThickness),
                new Pen(Color.Red,arcThickness),
            };

            Bitmap bmp = 
                new Bitmap(bitmapWidth, bitmapheight);

            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.CompositingQuality = 
                CompositingQuality.HighQuality;

            g.InterpolationMode = 
                InterpolationMode.HighQualityBilinear;

            g.PageUnit = GraphicsUnit.Pixel;

            int arcNumber = 0;
            Double currentArcPercentage = 0;
            int imageCount = 0;

            while (true)
            {
                g.Clear(Color.White);

                AddRainbow(g, pens, bitmapWidth, bitmapheight,
                    arcThickness, arcNumber, currentArcPercentage);

                if (currentArcPercentage > 100)
                {
                    currentArcPercentage = 0;
                    arcNumber++;
                    if (arcNumber >= 7)
                        break;
                }

                string imageName = ("000000000" + 
                                imageCount.ToString());

                imageName = 
                    imageName.Substring(imageName.Length - 6, 6) + 
                    ".png";

                bmp.Save(Path.GetFullPath("ImageOutput\\" +
                                             imageName));

                Console.WriteLine("Created image " + 
                                            imageName);

                currentArcPercentage = 
                    currentArcPercentage + 0.5;

                imageCount++;
            }

            CreateVideoFromImages("ImageOutput\\", 
                "VideoOutput\\Rainbow.mp4");

        }
        private static void AddRainbow(
            Graphics g, Pen[] pens, int bitmapWidth,
            int bitmapHeight, int arcThickness, 
            int arcNumber, double currentArcPercentage)
        {
            Size arcSize;
            int initialXRadius = 300;
            int initialYRadius = 200;

            for (int j = 0; j < arcNumber; j++)
            {
                arcSize = new Size(initialXRadius + 
                    (j * arcThickness * 2),
                    initialYRadius + (j * arcThickness * 2));

                g.DrawArc(pens[j], 
                    new Rectangle(
                        new Point((bitmapWidth - arcSize.Width) / 2,
                    bitmapHeight - (arcSize.Height) / 2), 
                    arcSize), 180, 180);
            }

            arcSize = new Size(
                initialXRadius + (arcNumber * arcThickness * 2),
                initialYRadius + (arcNumber * arcThickness * 2));

            g.DrawArc(pens[arcNumber],
            new Rectangle(new Point((bitmapWidth - arcSize.Width) / 2,
                       bitmapHeight - (arcSize.Height) / 2), 
                       arcSize),
                       180, 
                       ((180 * (float)currentArcPercentage) / 100));
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
