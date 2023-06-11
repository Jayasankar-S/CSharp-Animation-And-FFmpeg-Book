using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
namespace Chapter_2
{
    internal class Program
    {
        static void Main(string[] args)
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

            CreateVideoFromImages(
                Path.GetFullPath("ImageOutput\\"),
                Path.GetFullPath("VideoOutput\\CircleMovingRight2.mp4"));

            MergeVideo(
            "VideoOutput\\CircleMovingRight.mp4",
            "VideoOutput\\CircleMovingRight2.mp4",
            "VideoOutput\\CircleMovingRight_Merged.mp4");

            MergeAudio(
           "Dream_It.mp3",
           "Gully_Dreams.mp3",
           "VideoOutput\\merged.mp3");

            CutAudio(
            "Dream_It.mp3",
            "VideoOutput\\cut1.mp3",
            0, 5);

            CutAudio(
            "Gully_Dreams.mp3",
            "VideoOutput\\cut2.mp3",
            0, 5);

            MixAudioAndVideo(
            "00:00:00",
            "VideoOutput\\CircleMovingRight.mp4",
            "VideoOutput\\cut1.mp3",
            "VideoOutput\\CircleMovingRightWithAudio.mp4");

            MixAudioAndVideo(
           "00:00:00",
           "VideoOutput\\CircleMovingRight2.mp4",
           "VideoOutput\\cut2.mp3",
           "VideoOutput\\CircleMovingRightWithAudio2.mp4");

            MergeVideoWithAudio(
           "VideoOutput\\CircleMovingRightWithAudio.mp4",
           "VideoOutput\\CircleMovingRightWithAudio2.mp4",
           "VideoOutput\\CircleMovingRightWithAudioMerged.mp4");

            CutVideo(
             "VideoOutput\\CircleMovingRightWithAudioMerged.mp4",
             "VideoOutput\\CircleMovingRightWithAudioMergedAndCut.mp4",
            3, 5);

            ExtractAudioFromVideoFile(
            "VideoOutput\\CircleMovingRightWithAudioMergedAndCut.mp4",
            "VideoOutput\\ExtractedAudio.mp3");

            if (!Directory.Exists("ExtractedImages"))
                Directory.CreateDirectory("ExtractedImages");

            ConvertToImages(
           "VideoOutput\\CircleMovingRightWithAudioMergedAndCut.mp4",
           "ExtractedImages\\");

            ConvertFromMp4ToMpeg1(
            "VideoOutput\\CircleMovingRight.mp4",
            "VideoOutput\\CircleMovingRight.mpeg");


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

      

        public static void ConvertFromMp4ToMpeg1(
            string inputVideoFilePath, 
            string outputVideoFilePath)
        {

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg  -y -i " +
                inputVideoFilePath +
                " -f  mpeg1video -acodec copy  " +
                outputVideoFilePath;

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


        public static void MergeVideo(
            string inputVideoFilePath1, 
            string inputVideoFilePath2, 
            string outputVideoFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -i " +
                inputVideoFilePath1 + " -i " + inputVideoFilePath2 +
                " -filter_complex \"[0:v]  [1:v]  " +
                "concat=n=2:v=1 [v] \" -map \"[v]\"  \"" +
                outputVideoFilePath + "\" ";

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


        public static void MergeVideoWithAudio(
            string inputVideoFilePath1, 
            string inputVideoFilePath2, 
            string outputVideoFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -i " +
                inputVideoFilePath1 + " -i " + inputVideoFilePath2 +
                " -filter_complex \"[0:v] [0:a] [1:v] [1:a] " +
                "concat=n=2:v=1:a=1 " +
                "[v] [a]\" -map \"[v]\" -map \"[a]\" \"" +
                outputVideoFilePath + "\" ";
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


        public static void MergeAudio(
            string inputAudioFilePath1, 
            string inputAudioFilePath2, 
            string outputAudioFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -i " + 
                inputAudioFilePath1 +
                " -i " + inputAudioFilePath2 +
                " -filter_complex \"[0:a] [1:a] " +
                "concat=n=2:v=0:a=1 [a]\" -map \"[a]\" \"" +
                outputAudioFilePath + "\" ";

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



        public static void MixAudioAndVideo(
            string timestring, 
            string inputVideoFilePath,
            string inputAudioFilePath, 
            string outputVideoFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y  -i \"" + 
                inputVideoFilePath +
                "\" -itsoffset " + timestring + " -i \"" + 
                inputAudioFilePath +
                "\" -map 0:0 -map 1:0 -c:v copy  -async 1  \"" +
                outputVideoFilePath + "\" ";

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



        public static void CutAudio(
            string inputAudioFilePath, 
            string outputAudioFilePath, 
            int startPositionInSeconds, 
            int durationInSeconds)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -ss " + 
                startPositionInSeconds +
                " -t " + durationInSeconds + " -i \"" + 
                inputAudioFilePath +
                "\" -acodec copy \"" + outputAudioFilePath + "\"  ";

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



        public static void CutVideo(
            string inputVideoFilePath, 
            string outputVideoFilePath, 
            int startPositionInSeconds, 
            int durationInSeconds)
        {

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + 
                " ffmpeg -y -ss " + 
                startPositionInSeconds +
                " -t " + durationInSeconds + " -i \"" + 
                inputVideoFilePath +
                "\" \"" + outputVideoFilePath + "\"  ";

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

        public static void ConvertToImages(
            string inputVideoFilePath, 
            string outputFolder)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + 
                " ffmpeg -y -i " + 
                inputVideoFilePath +
                " -vcodec png  " + 
                outputFolder + "%06d.png ";

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
        public static void ExtractAudioFromVideoFile(
            string inputVideoFilePath, 
            string outputFilePath)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -i " + 
                inputVideoFilePath +
                " -filter_complex \"[0:a]  " +
                "concat=n=1:v=0:a=1 [a]\" -map \"[a]\" \"" +
                outputFilePath + "\" ";

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


        public static void CreateSilence(
            string filePath, 
            int seconds)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + " ffmpeg -y -f " +
                "lavfi -i anullsrc=r=24000:cl=mono -t " +
                seconds + " -b:a 32k " +
                "-ss 00:00:00 -acodec libmp3lame \"" +
                filePath + "\"  ";

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
