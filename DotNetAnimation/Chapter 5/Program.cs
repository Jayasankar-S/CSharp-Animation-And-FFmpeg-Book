using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Chapter_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen p = new Pen(Color.Black, 10);

                double y = 0;
                double radius = 100;

                Point origin = new Point(150, 150);

                List<PointF> starPoints = new List<PointF>();
                for (int angle = -55; angle < 305; angle = angle + 72)
                {
                    double x = Math.Cos(angle * Math.PI / 180) * radius;
                    y = Math.Sin(angle * Math.PI / 180) * radius;
                    starPoints.Add(new PointF((float)x + origin.X, (float)y + origin.Y));
                }

                PointF p1 = starPoints[0];
                PointF p2 = starPoints[1];
                PointF p3 = starPoints[2];
                PointF p4 = starPoints[3];
                PointF p5 = starPoints[4];

                g.DrawPolygon(p, new PointF[] { p1, p4, p2, p5, p3, p1 });
                bmp.Save("star.png");

            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen p = new Pen(Color.Black, 10);

                double y = 0;
                double radius = 100;
                Point origin = new Point(150, 150);

                List<PointF> starPoints = new List<PointF>();
                for (int angle = -55; angle < 305; angle = angle + 72)
                {
                    double x = Math.Cos(angle * Math.PI / 180) * radius;
                    y = Math.Sin(angle * Math.PI / 180) * radius;
                    starPoints.Add(new PointF((float)x + origin.X, (float)y + origin.Y));
                }

                PointF p1 = starPoints[0];
                PointF p2 = starPoints[1];
                PointF p3 = starPoints[2];
                PointF p4 = starPoints[3];
                PointF p5 = starPoints[4];

                GraphicsPath path = new GraphicsPath();

                path.AddLine(p1, p4);
                path.AddLine(p4, p2);
                path.AddLine(p2, p5);
                path.AddLine(p5, p3);
                path.AddLine(p3, p1);

                path.CloseFigure();

                g.DrawPath(p, path);
                bmp.Save("star2.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 200);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                pen.LineJoin = LineJoin.Round;

                GraphicsPath graphicsPath = new GraphicsPath();

                graphicsPath.AddString("Sample Text",
                                FontFamily.GenericSansSerif, (int)FontStyle.Regular,
                                40, new Point(50, 50), new StringFormat());

                g.FillPath(Brushes.Gray, graphicsPath);
                g.DrawPath(Pens.Black, graphicsPath);

                bmp.Save("TextOutline1.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);


                int textEmSize = 70;
                Font font = new System.Drawing.Font(FontFamily.GenericSansSerif, textEmSize,
                                (int)FontStyle.Regular, GraphicsUnit.Pixel);
                SizeF size = g.MeasureString("Text", font);

                int textX = (bmp.Width - (int)size.Width) / 2;
                int textY = (bmp.Height - (int)size.Height) / 2;

                GraphicsPath path = new GraphicsPath();
                path.AddString("Text", FontFamily.GenericSansSerif, (int)FontStyle.Regular, textEmSize,
                                new Point(textX, textY), new StringFormat());

                g.FillPath(Brushes.LightGray, path);

                Pen p = new Pen(Color.Black, 3);
                p.LineJoin = LineJoin.Round;
                g.DrawPath(p, path);

                bmp.Save("text.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Point point = new Point(150, 150);

                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddBezier(
                                new Point(147, 152), new Point(290, 30), new Point(10, 30), new Point(152, 152));
                graphicsPath.CloseFigure();

                Pen pen = new Pen(Color.Black, 5);
                g.DrawPath(pen, graphicsPath);

                bmp.Save("Balloon.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                SolidBrush solidBush = new SolidBrush(Color.LightGray);
                g.FillRectangle(solidBush, new Rectangle(50, 50, 100, 100));
                bmp.Save("solidBush.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                HatchBrush hatchBrush = new HatchBrush(HatchStyle.Cross, Color.Black, Color.LightGray);
                g.FillRectangle(hatchBrush, new Rectangle(50, 50, 100, 100));
                bmp.Save("hatchBrush.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);


                Image img = new Bitmap("flower.jpg");
                TextureBrush textureBrush = new TextureBrush(img);
                g.FillRectangle(textureBrush, new Rectangle(50, 50, 200, 200));
                bmp.Save("textureBrush.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                LinearGradientBrush linearGradientBrush =
                        new LinearGradientBrush(new Point(0, 0), new Point(200, 200), Color.Black, Color.LightGray);
                g.FillRectangle(linearGradientBrush, new Rectangle(25, 25, 150, 150));
                bmp.Save("linearGradientBrush.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddRectangle(new Rectangle(0, 0, 200, 200));
                PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                pathGradientBrush.CenterColor = Color.Black;
                pathGradientBrush.SurroundColors = new Color[] { Color.LightGray };

                g.FillRectangle(pathGradientBrush, new Rectangle(25, 25, 150, 150));
                bmp.Save("pathGradientBrush.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddBezier(new Point(147, 152), new Point(290, 30), new Point(10, 30), new Point(152, 152));
                graphicsPath.CloseFigure();

                PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
                pathGradientBrush.CenterColor = Color.Black;
                pathGradientBrush.SurroundColors = new Color[] { Color.LightGray };

                g.FillRectangle(pathGradientBrush, new Rectangle(0, 0, 300, 200));
                Pen p = new Pen(Color.Black, 4);
                g.DrawPath(p, graphicsPath);

                bmp.Save("pathGradientBalloon.png");
            }

            {

                Point point = new Point(150, 150);

                Bitmap balloonBmp = new Bitmap(300, 200);
                Graphics balloonBmpGraphics = 
                    Graphics.FromImage(balloonBmp);

                balloonBmpGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                balloonBmpGraphics.InterpolationMode = 
                                    InterpolationMode.HighQualityBicubic;
                balloonBmpGraphics.Clear(Color.Transparent);

                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddBezier(
                   new Point(147, 152), new Point(290, 30),
                   new Point(10, 30), new Point(152, 152));

                graphicsPath.CloseFigure();

                PathGradientBrush pathGradientBrush = 
                    new PathGradientBrush(graphicsPath);

                pathGradientBrush.CenterColor = Color.Black;
                pathGradientBrush.SurroundColors = 
                    new Color[] { Color.LightGray };

                balloonBmpGraphics.FillRectangle(pathGradientBrush, 
                                    new RectangleF(0, 0, 300, 200));

                Pen pen = new Pen(Color.Black, 4);
                balloonBmpGraphics.DrawPath(pen, graphicsPath);


                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.Clear(Color.Transparent);
                g.DrawImage(balloonBmp, new Point(0, 0));
                g.DrawImage(balloonBmp, new Point(50, 50));
                g.DrawImage(balloonBmp, new Point(-50, +50));
                g.DrawImage(balloonBmp, new Point(0, 100));

                bmp.Save("Balloons.png");
            }

            {

                Bitmap sourcebmp = new Bitmap("flower.jpg");
                Rectangle sourceRectangle = new Rectangle(100, 100, 100, 100);
                Rectangle targetRectangle = new Rectangle(0, 0, 100, 100);
                Bitmap outputbmp = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(outputbmp);

                g.DrawImage(sourcebmp, targetRectangle, sourceRectangle, GraphicsUnit.Pixel);
                outputbmp.Save("cropedimage.png");
            }

            {
                Bitmap bmp = new Bitmap("flower.jpg");
                
                Rectangle rect = 
                    new Rectangle(0, 0, bmp.Width, bmp.Height);

                System.Drawing.Imaging.BitmapData bitmapData =
                    bmp.LockBits(rect, 
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                IntPtr ptr = bitmapData.Scan0;

                int bytes = Math.Abs(bitmapData.Stride) * bmp.Height;
                byte[] rgbValues = new byte[bytes];

                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bitmapData.Stride; j=j+3)
                    {
                        if (j + 2 < bitmapData.Stride)
                        {
                            int red = rgbValues[(i * bitmapData.Stride) + j];
                            int green = rgbValues[(i * bitmapData.Stride) + j + 1];
                            int blue = rgbValues[(i * bitmapData.Stride) + j + 2];

                            rgbValues[(i * bitmapData.Stride) + j] = 255;
                            rgbValues[(i * bitmapData.Stride) + j + 1] = 0;
                            rgbValues[(i * bitmapData.Stride) + j + 2] = 0;
                        }
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(
                                   rgbValues, 0, ptr, bytes);

                bmp.UnlockBits(bitmapData);
                bmp.Save("fullRedColorImage.png");

            }

        }
    }
}
