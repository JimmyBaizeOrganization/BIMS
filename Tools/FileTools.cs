using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Tools
{
    public class FileTools
    {
    }
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
        public static Image getImage(String imagename, int sizeW, int sizeH)
        {
            Bitmap image = new Bitmap(getImage(imagename), sizeW, sizeH);
            return image;
        }
        public static Image MakeGrayscale(String imagename, int sizeW, int sizeH)
        {

            Bitmap image = new Bitmap(getImage(imagename), sizeW, sizeH);
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(image.Width, image.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
                  {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                  });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
               0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            attributes.Dispose();

            return newBitmap;
        }
    }
}
