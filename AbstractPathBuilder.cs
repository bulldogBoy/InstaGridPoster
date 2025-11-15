using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaGridPoster
{
    public abstract class AbstractPathBuilder
    {
        public string? PathToImage { get; private set; }
        protected abstract void SetPathMessage();
        protected void SetPath()
        {
            SetPathMessage();
            string? pathToImage = Console.ReadLine()?.Trim('"');
            if (pathToImage is not null && PathValidate(pathToImage))
            {
                PathToImage = pathToImage;
            }
            else
            {
                SetPath();
            }
        }
        private bool PathValidate(string path)
        {
            var format = path.Split(".");
            if (format.Length > 0 && Enum.TryParse<FormatsEnum>(format.Last<string>(), true, out _) && File.Exists(path)) 
            {
                return true;
            }
            return false;
        }

        protected AbstractPathBuilder()
        {
            SetPath();
        }
    }
}
