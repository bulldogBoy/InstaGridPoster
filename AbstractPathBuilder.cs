namespace InstaGridPoster
{
    public abstract class AbstractPathBuilder
    {
        public string? PathToImage { get; private set; }
        public string? PathToSave { get; private set; }
        protected abstract void SetPathMessage();
        protected abstract void SetPathSaveMessage();
        protected void SetPath()
        {
            SetPathMessage();
            string? pathToImage = Console.ReadLine()?.Trim('"');
            if (pathToImage is not null && ImagePathValidate(pathToImage))
            {
                PathToImage = pathToImage;
                SetSavePath();
            }
            else
            {
                SetPath();
            }
        }

        private void SetSavePath()
        {
            SetPathSaveMessage();
            string pathToSave = Console.ReadLine()!;
            if (!Path.Exists(pathToSave) && !string.IsNullOrEmpty(pathToSave)) Directory.CreateDirectory(pathToSave.Trim('"'));
            PathToSave = pathToSave;

        }
        private bool ImagePathValidate(string path)
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
