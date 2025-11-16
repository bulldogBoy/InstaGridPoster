using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaGridPoster
{
    public class PathBuilder : AbstractPathBuilder
    {
        protected override void SetPathMessage()
        {
            Console.WriteLine("Enter the path to the photo");
        }

        protected override void SetPathSaveMessage()
        {
            Console.WriteLine("Specify the path to the folder where you want to save the poster.\r\n\r\n*Press Enter to save in the original photo's directory.*");
        }
    }
}
