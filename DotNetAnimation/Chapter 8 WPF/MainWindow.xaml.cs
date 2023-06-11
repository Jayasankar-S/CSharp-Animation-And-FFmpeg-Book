using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Chapter_8_WPF
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

            Viewport3D myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            PerspectiveCamera myPCamera = CreateCamera();
            myViewport3D.Camera = myPCamera;

            DirectionalLight myDirectionalLight = CreateLightSource();
            myModel3DGroup.Children.Add(myDirectionalLight);

            MeshGeometry3D myMeshGeometry3D = CreateMeshGeometry();
            myGeometryModel.Geometry = myMeshGeometry3D;

            SolidColorBrush solidColorBrush =
                new SolidColorBrush(Colors.Yellow);

            DiffuseMaterial myMaterial =
                new DiffuseMaterial(solidColorBrush);

            myGeometryModel.Material = myMaterial;
            myGeometryModel.BackMaterial = myMaterial;

            Transform3DGroup myTransform3DGroup =
                new Transform3DGroup();

            RotateTransform3D myRotateTransform3DY =
                new RotateTransform3D();

            AxisAngleRotation3D yaxisRotation =
                new AxisAngleRotation3D();

            yaxisRotation.Axis = new Vector3D(0, 1, 0);
            yaxisRotation.Angle = 0;
            myRotateTransform3DY.Rotation = yaxisRotation;
            myTransform3DGroup.Children.Add(myRotateTransform3DY);


            myGeometryModel.Transform = myTransform3DGroup;
            myModel3DGroup.Children.Add(myGeometryModel);
            myModelVisual3D.Content = myModel3DGroup;
            myViewport3D.Children.Add(myModelVisual3D);
            myViewport3D.Arrange(new Rect(0, 0, 1920, 1080));

            for (int i = 0; i < 300; i++)
            {
                yaxisRotation.Angle = yaxisRotation.Angle + 2;

                string imageName = ("000000000" + i.ToString());

                imageName =
                    imageName.Substring(imageName.Length - 6, 6) +
                    ".png";

                RenderTargetBitmap renderTargetBitmap =
                    new RenderTargetBitmap(1920, 1080,
                    96, 96, PixelFormats.Pbgra32);

                Canvas canvas = new Canvas();
                canvas.Background = Brushes.Lavender;
                canvas.Arrange(new Rect(0, 0, 1920, 1080));
                renderTargetBitmap.Render(canvas);
                renderTargetBitmap.Render(myViewport3D);

                System.IO.FileStream fileStream =
                   new System.IO.FileStream("ImageOutput\\" +
                   imageName, System.IO.FileMode.Create);

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
            CreateVideoFromImages("ImageOutput\\",
                "VideoOutput\\3DTriangle.Mp4");
        }

        private static MeshGeometry3D CreateMeshGeometry()
        {
            MeshGeometry3D myMeshGeometry3D =
            new MeshGeometry3D();

            Point3DCollection myPositionCollection =
            new Point3DCollection();

            myPositionCollection.Add(
                new Point3D(-0.5, 0, -0.5));

            myPositionCollection.Add(
                new Point3D(0.5, 0, 0.5));

            myPositionCollection.Add(
                new Point3D(0, 1.5, 0));

            myMeshGeometry3D.Positions =
            myPositionCollection;

            Int32Collection myTriangleIndicesCollection =
                new Int32Collection(new int[] { 0, 1, 2 });

            myMeshGeometry3D.TriangleIndices =
                    myTriangleIndicesCollection;

            return myMeshGeometry3D;
        }

        private static DirectionalLight CreateLightSource()
        {
            DirectionalLight myDirectionalLight =
                new DirectionalLight();

            myDirectionalLight.Color = Colors.White;

            myDirectionalLight.Direction =
                new Vector3D(-1, -1, -1);

            return myDirectionalLight;
        }

        private static PerspectiveCamera CreateCamera()
        {
            PerspectiveCamera myPCamera = new PerspectiveCamera();
            myPCamera.Position = new Point3D(10, 0.3, 0);
            myPCamera.LookDirection = new Vector3D(-10, 0.3, 0);
            myPCamera.FieldOfView = 20;
            return myPCamera;
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
