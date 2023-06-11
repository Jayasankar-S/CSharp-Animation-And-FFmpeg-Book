using System.Collections.Generic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Chapter_3
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

                g.DrawLine(Pens.Black, new Point(100, 150), new Point(200, 150));
                bmp.Save("SimpleLine.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                g.DrawLine(pen, new Point(100, 150), new Point(200, 150));
                bmp.Save("LineWithThickness.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                g.DrawRectangle(pen, 50, 50, 200, 200);
                bmp.Save("Rectangle.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                g.FillRectangle(Brushes.Black, 50, 50, 200, 200);
                bmp.Save("FillRectangle.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Color transparentGray = Color.FromArgb(125, 150, 150, 150);

                Brush transparentGrayBrush = new SolidBrush(transparentGray);

                g.FillRectangle(transparentGrayBrush, 50, 50, 150, 150);
                g.FillRectangle(transparentGrayBrush, 100, 100, 150, 150);

                bmp.Save("TransparentRectangle.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                g.DrawEllipse(pen, 50, 50, 200, 200);
                bmp.Save("Circle.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                g.DrawEllipse(pen, new RectangleF(50, 100, 200, 100));
                bmp.Save("Ellipse.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                RectangleF rect = new RectangleF(50, 50, 200, 200);
                g.DrawArc(pen, rect, 280, 70);
                bmp.Save("Arc.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Image image = Image.FromFile("flower.jpg");
                g.DrawImage(image, 50, 50, 200, 200);
                bmp.Save("OutputImage.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 10);
                g.DrawPie(pen, new RectangleF(50, 50, 200, 200), 225, 90);
                bmp.Save("Pie.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen p = new Pen(Color.Black, 10);

                Point origin = new Point(150, 150);
                double radius = 100;

                List<PointF> starPoints = new List<PointF>();
                for (int angle = -18; angle < 342; angle = angle + 72)
                {
                    double x = Math.Cos(angle * Math.PI / 180) * radius;
                    double y = Math.Sin(angle * Math.PI / 180) * radius;
                    starPoints.Add(new PointF((float)x + origin.X, (float)y + origin.Y));
                }

                g.DrawPolygon(p, starPoints.ToArray());
                bmp.Save("pentagon.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Pen p = new Pen(Color.Black, 10);

                Point origin = new Point(150, 150);
                double radius = 100;

                List<PointF> starPoints = new List<PointF>();
                for (int angle = -18; angle < 342; angle = angle + 72)
                {
                    double x = Math.Cos(angle * Math.PI / 180) * radius;
                    double y = Math.Sin(angle * Math.PI / 180) * radius;
                    starPoints.Add(new PointF((float)x + origin.X, (float)y + origin.Y));
                }

                PointF p1 = starPoints[0];
                PointF p2 = starPoints[1];
                PointF p3 = starPoints[2];
                PointF p4 = starPoints[3];
                PointF p5 = starPoints[4];

                GraphicsPath path = new GraphicsPath();

                path.StartFigure();
                path.AddLine(p1, p2);
                path.AddLine(p2, p3);
                path.AddLine(p3, p4);
                path.AddLine(p4, p5);
                path.AddLine(p5, p1);
                path.CloseFigure();

                g.DrawPath(p, path);
                bmp.Save("pentagonWithGrapicsPath.png");
            }

            {
                Bitmap bmp = new Bitmap(300, 200);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);

                Font font = new Font("Arial", 30);
                g.DrawString("Sample Text", font, Brushes.Black, new PointF(25, 25));
                bmp.Save("Text.png");
            }
        }
    }
}
