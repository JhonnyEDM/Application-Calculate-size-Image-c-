using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PesoImagen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(imagen);


                    int kilobyteOrmegaByte =  imageToByteArray(pictureBox1.Image).Length;

                    if (kilobyteOrmegaByte >= 1000000)
                    {
                        label2.Text = Convert.ToString(CalcularTamanoMegabyte(kilobyteOrmegaByte) + " MB");
                    }
                    else
                    {
                        label2.Text = Convert.ToString(CalcularTamanokilobyte(kilobyteOrmegaByte) + " KB");
                    }

                    label2.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }
        byte[] imageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        string  CalcularTamanokilobyte(int imagen)
        {
            double numero = 0;
            numero = (double)imagen/ 1024;
            return numero.ToString().Substring(0,4);
        }

        string CalcularTamanoMegabyte(int imagen)
        {
            double numero = 0.0;
            numero = (imagen / 1024);
            numero /= 1024;
            return numero.ToString().Substring(0,4);
        }

    }
}
