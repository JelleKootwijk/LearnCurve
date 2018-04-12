using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageToText
{
    public partial class Form1 : Form
    {
        Image sourceImage;
        Image sourceImage2;
        Bitmap image1;
        Bitmap image2;
        Image resizedImage1;
        Image resizedImage2;

        public Form1()
        {
            InitializeComponent();

            //Byte[] imageByteArray = CopyImageToByteArray(sourceImage);

            //string text = Encoding.ASCII.GetString(imageByteArray, 0, imageByteArray.Length);

            //System.IO.File.AppendAllText(saveLocation, text);

            //pictureBox1.Image = byteArrayToImage(imageByteArray);
        }

        private bool ImageCompareArray(Bitmap firstImage, Bitmap secondImage)
        {
            bool flag = true;
            string firstPixel;
            string secondPixel;


            if (firstImage.Width == secondImage.Width
            && firstImage.Height == secondImage.Height)
            {
                for (int x = 0; x < firstImage.Width; x++)
                {
                    for (int y = 0; y < firstImage.Height; y++)
                    {
                        firstPixel = firstImage.GetPixel(x, y).ToString();
                        secondPixel = secondImage.GetPixel(x, y).ToString();


                        if (radioButton1.Checked)
                        {
                            System.IO.File.AppendAllText(@"D:\ImageDetails.txt", firstPixel);
                        }
                        if (firstPixel != secondPixel)
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (!flag)
                {
                    ImageDetails(firstImage, secondImage);

                    label1.Text = "is not same";
                    return false;
                }
                else
                {
                    ImageDetails(firstImage, secondImage);

                    label1.Text = "is same";
                    return true;
                }
            }
            else
            {
                ImageDetails(firstImage, secondImage);

                label1.Text = "Width/Height Not the same";
                return false;
            }
        }

        private void ImageDetails(Bitmap image1, Bitmap image2)
        {
            lblImage1Height.Text = "" + image1.Height;
            lblImage1Width.Text = "" + image1.Width;

            lblImage2Heigth.Text = "" + image2.Height;
            lblImage2Width.Text = "" + image2.Width;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                sourceImage = new Bitmap(openfile.FileName);
                image1 = new Bitmap(sourceImage);
                resizedImage1 = resizeImage(image1, new Size(100, 100));
                pictureBox1.Image = resizedImage1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                sourceImage2 = new Bitmap(openfile.FileName);
                image2 = new Bitmap(sourceImage2);
                resizedImage2 = resizeImage(image2, new Size(100, 100));
                pictureBox2.Image = resizedImage2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImageCompareArray(image1, image2);
        }

        //public static byte[] CopyImageToByteArray(Image theImage)
        //{
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        theImage.Save(memoryStream, ImageFormat.Png);
        //        return memoryStream.ToArray();
        //    }
        //}

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
    }
}
