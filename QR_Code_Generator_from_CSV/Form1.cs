using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;


namespace QR_Code_Generator_from_CSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the CSV file
                //var csvFilePath = @"C:\test\hello.csv";
                //var csvContents = File.ReadAllText(csvFilePath);

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Title = "Select a CSV file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Read the selected CSV file

                    string filePath = openFileDialog.FileName;
                    label7.Text = "File selected: " + filePath;

                    var csvFilePath = openFileDialog.FileName;
                    var csvContents = File.ReadAllText(csvFilePath);


                    // Create a MultiFormatWriter instance
                    var barcodeWriter = new BarcodeWriter
                    {
                        Format = BarcodeFormat.QR_CODE,
                        Options = new EncodingOptions
                        {
                            Height = 300,
                            Width = 300,
                            Margin = 0
                        }
                    };

                    // Generate the QR code bitmap
                    var barcodeBitmap = barcodeWriter.Write(csvContents);

                    // Display the QR code in a picture box
                    pictureBox1.Image = barcodeBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the data from the textboxes
                string data = $"{textBox1.Text},{textBox2.Text},{textBox3.Text},{textBox4.Text}, {textBox5.Text}";

                // Create a MultiFormatWriter instance
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions
                    {
                        Height = 300,
                        Width = 300,
                        Margin = 0
                    }
                };

                // Generate the QR code bitmap
                var barcodeBitmap = barcodeWriter.Write(data);

                // Display the QR code in a picture box
                pictureBox1.Image = barcodeBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
