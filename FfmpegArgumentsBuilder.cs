using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaGridPoster
{
    public class FfmpegArgumentsBuilder
    {
        private string _input;
        private string Input 
        {
            get => $"-i {_input}";
        }
        public string PathToSaveResult { get; set; }
        private const string FirstStream = "[0:v]";
        private const string FilterComplex = "-filter_complex";
        private const string Crop = "crop";
        private const string Map = "-map";
        private List<string> ImageMatrixRender = new List<string> { "iw/3:ih/3:0:0", "iw/3:ih/3:iw/3:0", "iw/3:ih/3:2*iw/3:0", "iw/3:ih/3:0:ih/3",
            "iw/3:ih/3:iw/3:ih/3","iw/3:ih/3:2*iw/3:ih/3","iw/3:ih/3:0:2*ih/3","iw/3:ih/3:iw/3:2*ih/3","iw/3:ih/3:2*iw/3:2*ih/3" };
        private string GetFilterComplexArgs()
        {
            string result = "";
            for (int i = 0; i < ImageMatrixRender.Count; i++)
            {
                var temp = $@"{FirstStream}{Crop}={ImageMatrixRender[i]};";
                result += temp;
            }
            return result;
        }
        private string GetMapArgs()
        {
            string result = "";
            for (int i = 0; i < ImageMatrixRender.Count; i++)
            {
                result += $@"{Map} ""[out{i}]"" {PathToSaveResult}\PosterChunk{i}.png ";
            }
            return result;
        }

        public string BuildArgs() 
        {
            var filterArgs = GetFilterComplexArgs();
            var mapArgs = GetMapArgs();
            var argsJoin = $@"{Input} {FilterComplex} ""{filterArgs}"" {mapArgs}";
            return argsJoin;
        }
        public FfmpegArgumentsBuilder(string input, string pathToSaveResult)
        {
            _input = input;
            if (string.IsNullOrEmpty(pathToSaveResult)) pathToSaveResult = Path.GetDirectoryName(input)!;
                PathToSaveResult = pathToSaveResult;
        } 
    }
}
