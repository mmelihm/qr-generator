using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace qweqweqw
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20, "#00082E", "#FFFBD9");
            pictureBox1.Image = qrCodeImage;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Dosyası|*.png|JPEG Dosyası|*.jpg|BMP Dosyası|*.bmp";
            saveFileDialog.Title = "Qr Kodunu Kaydet";
            saveFileDialog.FileName = "QR";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                qrCodeImage.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
