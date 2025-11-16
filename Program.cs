using System.Diagnostics;
using System.IO;

namespace InstaGridPoster
{
    class Program
    {
        static void Main(string[] args)
        {
           var pathBuilder = new PathBuilder();
           var ffmpegArgumentsBuilder = new FfmpegArgumentsBuilder(pathBuilder.PathToImage!,pathBuilder.PathToSave!);
           var ffmpegProcessSetup = new ProcessStartInfo()
            {
                FileName = "ffmpeg.exe",
                Arguments = ffmpegArgumentsBuilder.BuildArgs(),
                RedirectStandardError = true
            };
            Process.Start(ffmpegProcessSetup);
        }
    }
}
