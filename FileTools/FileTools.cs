using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace FileTools
{
    public class FileURL
    {
      public static String ResourceDirRoot = @"../../..";
    }
    public class ImageTools
    {
         
        public static Image getImage(String imagename)
        {
            return Image.FromFile(@FileURL.ResourceDirRoot + "/Image/" + imagename);
        }
        public static Image getImage(String imagename,int sizeW,int sizeH)
        {
            Bitmap image = new Bitmap(getImage(imagename), sizeW, sizeH);
            
           
            return image;
        }
    }
}
