
using Anticaptcha_example.Api;
using Anticaptcha_example.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Cheque
{
    public partial class Form1 : Form
    {
        string url = "https://www.chequelegal.com.br";
        string inicio = "i";

        string captcha { get; set; }

        int totalConsulta { get; set; }
        int totalconsultado { get; set; }

        List<Consulta> layout = new List<Consulta>();
        public Form1()
        {
            InitializeComponent();
            lblDestino.Text = Environment.CurrentDirectory;
            aguardar(url);


        }
        void aguardar(string url)
        {
            status.Text = " Iniciando...";
            wb.Navigate(url);

        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (inicio == "i")
            {
                wb.Document.GetElementById("bt3").InvokeMember("click");
                inicio = "p";

            }


            if (inicio == "f")
            {
                var links = wb.Document.GetElementsByTagName("a");
                foreach (HtmlElement link in links)
                {
                    if (link.GetAttribute("className") == "nova-consulta blue b")
                    {
                        link.InvokeMember("click");
                    }
                }


            }

            buscaerro();



        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {

            wb.Document.GetElementById("aceiteTermoUso").SetAttribute("checked", "true");

            if (!string.IsNullOrEmpty(txtcpf.Text))
                wb.Document.GetElementById("cpfCnpjEmitente").InnerText = txtcpf.Text.Trim();

            if (!string.IsNullOrEmpty(txtd1.Text))
                wb.Document.GetElementById("primeiroCampoCmc7").InnerText = txtd1.Text.Trim();

            if (!string.IsNullOrEmpty(txtd2.Text))
                wb.Document.GetElementById("segundoCampoCmc7").InnerText = txtd2.Text.Trim();

            if (!string.IsNullOrEmpty(txtd3.Text))
                wb.Document.GetElementById("terceiroCampoCmc7").InnerText = txtd3.Text.Trim();

            if (!string.IsNullOrEmpty(txtcpfinteressado.Text))
                wb.Document.GetElementById("cpfCnpjInteressado").InnerText = txtcpfinteressado.Text.Trim();


            var text = wb.Document.GetElementById("cipCaptchaImg");
            var html = String.Format("{0}{1}{2}", "<table cellpadding=\"0\" cellspacing=\"0\">", text.InnerHtml, "</table>");
            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            // htmlToImageConv.Height = 70;
            htmlToImageConv.Width = 200;
            var jpegBytes = htmlToImageConv.GenerateImage(html, "Png");
            piccaptcha.Image = ByteArrayToImage(jpegBytes);



            Bitmap bitmapImage = new Bitmap(piccaptcha.Image);
            var ms = new MemoryStream();

            Image image = piccaptcha.Image;

            image.Save(ms, ImageFormat.Png);
            var bytes = ms.ToArray();

            var imageMemoryStream = new MemoryStream(bytes);

            Image imgFromStream = Image.FromStream(imageMemoryStream);

            imgFromStream.Save("captcha.jpg", ImageFormat.Jpeg);



            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "ef85f1b1baa494a70b68cf1212727dcd",
                FilePath = "captcha.jpg"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
            {
                DebugHelper.Out("Result: " + api.GetTaskSolution().Text, DebugHelper.Type.Success);
                wb.Document.GetElementById("captcha").InnerText = api.GetTaskSolution().Text;
                txtcaptcha.Text = api.GetTaskSolution().Text;
            }

            if (!string.IsNullOrEmpty(txtcaptcha.Text))
                wb.Document.GetElementById("captcha").InnerText = txtcaptcha.Text.Trim();




            wb.Document.GetElementById("btEnviar").InvokeMember("click");


        }


        private async void button1_Click(object sender, EventArgs e)
        {

            BuscaCaptcha();

        }

        private async void BuscaCaptcha()
        {
            var text = wb.Document.GetElementById("cipCaptchaImg");
            var html = String.Format("{0}{1}{2}", "<table cellpadding=\"0\" cellspacing=\"0\">", text.InnerHtml, "</table>");
            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            // htmlToImageConv.Height = 70;
            htmlToImageConv.Width = 200;
            var jpegBytes = htmlToImageConv.GenerateImage(html, "Png");
            piccaptcha.Image = ByteArrayToImage(jpegBytes);



            Bitmap bitmapImage = new Bitmap(piccaptcha.Image);
            var ms = new MemoryStream();

            Image image = piccaptcha.Image;

            image.Save(ms, ImageFormat.Png);
            var bytes = ms.ToArray();

            var imageMemoryStream = new MemoryStream(bytes);

            Image imgFromStream = Image.FromStream(imageMemoryStream);

            imgFromStream.Save("captcha.jpg", ImageFormat.Jpeg);



            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "ef85f1b1baa494a70b68cf1212727dcd",
                FilePath = "captcha.jpg"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
            {
                DebugHelper.Out("Result: " + api.GetTaskSolution().Text, DebugHelper.Type.Success);
                //wb.Document.GetElementById("captcha").InnerText = api.GetTaskSolution().Text;
                txtcaptcha.Text = api.GetTaskSolution().Text;
            }

        }


        private void BuscaCaptchaString()
        {
            var text = wb.Document.GetElementById("cipCaptchaImg");
            var html = String.Format("{0}{1}{2}", "<table cellpadding=\"0\" cellspacing=\"0\">", text.InnerHtml, "</table>");
            var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
            // htmlToImageConv.Height = 70;
            htmlToImageConv.Width = 200;
            var jpegBytes = htmlToImageConv.GenerateImage(html, "Png");
            piccaptcha.Image = ByteArrayToImage(jpegBytes);



            Bitmap bitmapImage = new Bitmap(piccaptcha.Image);
            var ms = new MemoryStream();

            Image image = piccaptcha.Image;

            image.Save(ms, ImageFormat.Png);
            var bytes = ms.ToArray();

            var imageMemoryStream = new MemoryStream(bytes);

            Image imgFromStream = Image.FromStream(imageMemoryStream);

            imgFromStream.Save("captcha.jpg", ImageFormat.Jpeg);



            DebugHelper.VerboseMode = true;

            var api = new ImageToText
            {
                ClientKey = "ef85f1b1baa494a70b68cf1212727dcd",
                FilePath = "captcha.jpg"
            };

            if (!api.CreateTask())
                DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
            else if (!api.WaitForResult())
                DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
            else
            {
                DebugHelper.Out("Result: " + api.GetTaskSolution().Text, DebugHelper.Type.Success);
                captcha = api.GetTaskSolution().Text;
                txtcaptcha.Text = captcha;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = wb.Document.GetElementById("errors");
            if (item != null)
            {

                if (item.InnerText.Contains(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado"))
                {
                    MessageBox.Show(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado");
                }

                if (item.InnerText.Contains(@"CPF/CNPJ do Emissor é um campo obrigatório"))
                {
                    MessageBox.Show(@"CPF/CNPJ do Emissor é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                {
                    MessageBox.Show(@"1º Campo do Código CMC7 do Cheque é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"2º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                {
                    MessageBox.Show(@"2º Campo do Código CMC7 do Cheque é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"3º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                {
                    MessageBox.Show(@"3º Campo do Código CMC7 do Cheque é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"CPF/CNPJ do interessado é um campo obrigatório"))
                {
                    MessageBox.Show(@"CPF/CNPJ do interessado é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"Aceite do Termo de Uso é um campo obrigatório"))
                {
                    MessageBox.Show(@"Aceite do Termo de Uso é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"Código da Imagem é um campo obrigatório"))
                {
                    MessageBox.Show(@"Código da Imagem é um campo obrigatório");
                }
                if (item.InnerText.Contains(@"CPF/CNPJ do Emissor: CNPJ/CPF Emitente inválido"))
                {
                    MessageBox.Show(@"CPF/CNPJ do Emissor: CNPJ/CPF Emitente inválido");
                }
                if (item.InnerText.Contains(@"3º Campo do Código CMC7 do Cheque: Campo deve conter 12 dígitos"))
                {
                    MessageBox.Show(@"3º Campo do Código CMC7 do Cheque: Campo deve conter 12 dígitos");
                }

                if (item.InnerText.Contains(@"2º Campo do Código CMC7 do Cheque: Campo deve conter 10 dígitos"))
                {
                    MessageBox.Show(@"2º Campo do Código CMC7 do Cheque: Campo deve conter 10 dígitos");
                }
                if (item.InnerText.Contains(@"CPF/CNPJ do interessado: CPF/CNPJ Interessado inválido"))
                {
                    MessageBox.Show(@"CPF/CNPJ do interessado: CPF/CNPJ Interessado inválido");
                }
                if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos"))
                {
                    MessageBox.Show(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos");
                }
                if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos"))
                {
                    MessageBox.Show(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos");
                }


            }

        }


        public void buscaerro()
        {
            var item = wb.Document.GetElementById("errors");
            if (item != null)
            {


                if (item.InnerText != null)
                {

                    if (item.InnerText.Contains(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado"))
                    {
                        MessageBox.Show(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado");
                    }

                    if (item.InnerText.Contains(@"CPF/CNPJ do Emissor é um campo obrigatório"))
                    {
                        MessageBox.Show(@"CPF/CNPJ do Emissor é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                    {
                        MessageBox.Show(@"1º Campo do Código CMC7 do Cheque é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"2º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                    {
                        MessageBox.Show(@"2º Campo do Código CMC7 do Cheque é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"3º Campo do Código CMC7 do Cheque é um campo obrigatório"))
                    {
                        MessageBox.Show(@"3º Campo do Código CMC7 do Cheque é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"CPF/CNPJ do interessado é um campo obrigatório"))
                    {
                        MessageBox.Show(@"CPF/CNPJ do interessado é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"Aceite do Termo de Uso é um campo obrigatório"))
                    {
                        MessageBox.Show(@"Aceite do Termo de Uso é um campo obrigatório");
                    }
                    if (item.InnerText.Contains(@"Código da Imagem é um campo obrigatório"))
                    {
                        var links = wb.Document.GetElementsByTagName("a");
                        foreach (HtmlElement link in links)
                        {
                            if (link.GetAttribute("title") == "Recarregar Captcha")
                            {
                                MessageBox.Show(@"Código da Imagem é um campo obrigatório");//inicio = "i";
                                link.InvokeMember("click");
                                BuscaCaptcha();
                            }
                        }

                    }
                    if (item.InnerText.Contains(@"CPF/CNPJ do Emissor: CNPJ/CPF Emitente inválido"))
                    {
                        MessageBox.Show(@"CPF/CNPJ do Emissor: CNPJ/CPF Emitente inválido");
                    }
                    if (item.InnerText.Contains(@"3º Campo do Código CMC7 do Cheque: Campo deve conter 12 dígitos"))
                    {
                        MessageBox.Show(@"3º Campo do Código CMC7 do Cheque: Campo deve conter 12 dígitos");
                    }

                    if (item.InnerText.Contains(@"2º Campo do Código CMC7 do Cheque: Campo deve conter 10 dígitos"))
                    {
                        MessageBox.Show(@"2º Campo do Código CMC7 do Cheque: Campo deve conter 10 dígitos");
                    }
                    if (item.InnerText.Contains(@"CPF/CNPJ do interessado: CPF/CNPJ Interessado inválido"))
                    {
                        MessageBox.Show(@"CPF/CNPJ do interessado: CPF/CNPJ Interessado inválido");
                    }
                    if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos"))
                    {
                        MessageBox.Show(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos");
                    }
                    if (item.InnerText.Contains(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos"))
                    {
                        MessageBox.Show(@"1º Campo do Código CMC7 do Cheque: Campo deve conter 8 dígitos");
                    }


                }
            }
        }
        private void btnOrigem_Click(object sender, EventArgs e)
        {
            OpenFileDialog vAbreArq = new OpenFileDialog();

            vAbreArq.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm; *.xlsb; *.csv; *.txt";

            vAbreArq.Title = "Selecione o Arquivo";


            if (vAbreArq.ShowDialog() == DialogResult.OK)

            {
                layout.Clear();

                var fileName = vAbreArq.FileName;
                var rows = File.ReadAllLines(fileName, Encoding.GetEncoding("ISO-8859-1"));

                foreach (var item in rows)
                {

                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        string[] itens = item.Split(';');

                        layout.Add(new Consulta { CPFCNPJ = itens[4].ToString().Trim(), CM7D1 = itens[1].ToString().Trim(), CM7D2 = itens[2].ToString().Trim(), CM7D3 = itens[3].ToString().Trim(), CPFINTERESSADO = txtcpfinteressado.Text.Trim(), STATUS = "PENDENTE" });
                    }


                }
                gridArquivos.DataSource = layout;
                totalConsulta = layout.Count;
                totalconsultado = 0;
                lblTotal.Text = string.Format("{0}/{1}", totalconsultado, totalConsulta);

            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public Image LoadImage(string imagem64)
        {
            //data:image/gif;base64,
            //this image is a single pixel (black)
            byte[] bytes = Convert.FromBase64String(imagem64);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        public void ExportToBmp(PictureBox pictureBox, string path)
        {
            using (var bitmap = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                pictureBox.DrawToBitmap(bitmap, pictureBox.ClientRectangle);
                ImageFormat imageFormat = null;

                var extension = Path.GetExtension(path);
                switch (extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpeg":
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".gif":
                        imageFormat = ImageFormat.Gif;
                        break;
                    default:
                        throw new NotSupportedException("File extension is not supported");
                }

                bitmap.Save(path, imageFormat);
            }
        }
        private static Image CropImage(Image img, Rectangle cropArea)
        {
            try
            {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea /*your rectangle area*/, bmpImage.PixelFormat);
                return (Image)(bmpCrop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "CropImage()");
            }
            return null;
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, (long)quality);

            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
            {
                MessageBox.Show("Can't find JPEG encoder?", "saveJpeg()");
                return;
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];

            return null;
        }

        // Create a thumbnail in byte array format from the image encoded in the passed byte array.  
        // (RESIZE an image in a byte[] variable.)  
        public static byte[] CreateThumbnail(byte[] PassedImage, int LargestSide)
        {
            byte[] ReturnedThumbnail;

            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                double HW_ratio;
                if (startBitmap.Height > startBitmap.Width)
                {
                    newHeight = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Height);
                    newWidth = (int)(HW_ratio * (double)startBitmap.Width);
                }
                else
                {
                    newWidth = LargestSide;
                    HW_ratio = (double)((double)LargestSide / (double)startBitmap.Width);
                    newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                }

                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }

        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                returnImage = Image.FromStream(ms, true);//Exception occurs here

            }
            catch { }
            return returnImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var links = wb.Document.GetElementsByTagName("a");
            foreach (HtmlElement link in links)
            {
                if (link.GetAttribute("className") == "nova-consulta blue b")
                {
                    //inicio = "i";
                    link.InvokeMember("click");
                }
            }


            var aprovadoreprovado = wb.Document.GetElementsByTagName("div");
            foreach (HtmlElement link in aprovadoreprovado)
            {
                if (link.GetAttribute("className") == "box-left white-box reprovado")
                {
                    MessageBox.Show("Reprovado");
                }
            }
            foreach (HtmlElement link in aprovadoreprovado)
            {
                if (link.GetAttribute("className") == "box-left white-box aprovado")
                {
                    MessageBox.Show("Aprovado");
                }
            }


            var resultado = wb.Document.GetElementsByTagName("li");
            foreach (HtmlElement link in resultado)
            {
                if (link.GetAttribute("className") == "background-color: rgb(230, 229, 227)")
                {
                    MessageBox.Show("resultado");
                }
            }


        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog destDialog = new FolderBrowserDialog();
            if (destDialog.ShowDialog() == DialogResult.OK)
            {
                lblDestino.Text = destDialog.SelectedPath;
            }
        }

        public void SalvarArquivo(string destino, string linha1D, string nomeArquivo, string contaCredito, string contaDebito)
        {

            string path = @destino + @"\" + nomeArquivo.Trim() + ".txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {

                File.AppendAllText(path, linha1D + Environment.NewLine, Encoding.GetEncoding("ISO-8859-1"));

            }

        }

        private async void btnIniciarConsulta_Click(object sender, EventArgs e)
        {

            do
            {

                //foreach (var consul in layout)
                //{



                wb.Document.GetElementById("aceiteTermoUso").SetAttribute("checked", "true");

                if (!string.IsNullOrEmpty(layout[totalconsultado].CPFCNPJ))
                {
                    txtcpf.Text = layout[totalconsultado].CPFCNPJ;
                    wb.Document.GetElementById("cpfCnpjEmitente").InnerText = txtcpf.Text;

                }


                if (!string.IsNullOrEmpty(layout[totalconsultado].CM7D1))
                {
                    txtd1.Text = layout[totalconsultado].CM7D1;
                    wb.Document.GetElementById("primeiroCampoCmc7").InnerText = txtd1.Text;

                }


                if (!string.IsNullOrEmpty(layout[totalconsultado].CM7D2))
                {
                    txtd2.Text = layout[totalconsultado].CM7D2;
                    wb.Document.GetElementById("segundoCampoCmc7").InnerText = txtd2.Text;

                }


                if (!string.IsNullOrEmpty(layout[totalconsultado].CM7D3))
                {
                    txtd3.Text = layout[totalconsultado].CM7D3;
                    wb.Document.GetElementById("terceiroCampoCmc7").InnerText = txtd3.Text;

                }


                if (!string.IsNullOrEmpty(layout[totalconsultado].CPFINTERESSADO))
                {
                    txtcpfinteressado.Text = layout[totalconsultado].CPFINTERESSADO;
                    wb.Document.GetElementById("cpfCnpjInteressado").InnerText = txtcpfinteressado.Text;

                }



                var text = wb.Document.GetElementById("cipCaptchaImg");
                var html = String.Format("{0}{1}{2}", "<table cellpadding=\"0\" cellspacing=\"0\">", text.InnerHtml, "</table>");
                var htmlToImageConv = new NReco.ImageGenerator.HtmlToImageConverter();
                // htmlToImageConv.Height = 70;
                htmlToImageConv.Width = 200;
                var jpegBytes = htmlToImageConv.GenerateImage(html, "Png");
                piccaptcha.Image = ByteArrayToImage(jpegBytes);



                Bitmap bitmapImage = new Bitmap(piccaptcha.Image);
                var ms = new MemoryStream();

                Image image = piccaptcha.Image;

                image.Save(ms, ImageFormat.Png);
                var bytes = ms.ToArray();

                var imageMemoryStream = new MemoryStream(bytes);

                Image imgFromStream = Image.FromStream(imageMemoryStream);

                imgFromStream.Save("captcha.jpg", ImageFormat.Jpeg);



                DebugHelper.VerboseMode = true;

                var api = new ImageToText
                {
                    ClientKey = "ef85f1b1baa494a70b68cf1212727dcd",
                    FilePath = "captcha.jpg"
                };

                if (!api.CreateTask())
                    DebugHelper.Out("API v2 send failed. " + api.ErrorMessage, DebugHelper.Type.Error);
                else if (!api.WaitForResult())
                    DebugHelper.Out("Could not solve the captcha.", DebugHelper.Type.Error);
                else
                {
                    DebugHelper.Out("Result: " + api.GetTaskSolution().Text, DebugHelper.Type.Success);
                    captcha = api.GetTaskSolution().Text;
                    txtcaptcha.Text = captcha;
                }

                if (!string.IsNullOrEmpty(captcha))
                    wb.Document.GetElementById("captcha").InnerText = captcha;

                //status.Text = "Aguardar 3 segundos";
                //Thread.Sleep(3000);
                wb.Document.GetElementById("btEnviar").InvokeMember("click");

                //Thread.Sleep(5000);
                var item = wb.Document.GetElementById("errors");
                if (item.InnerHtml != null)
                {

                    if ((item.InnerText.Contains(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado")) || (item.InnerText.Contains(@"Código da Imagem é um campo obrigatório")))
                    {
                        //MessageBox.Show(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado");
                        status.Text = @"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado";
                        //goto repete;
                    }

                }


                atualizaConsultado();

            } while (totalconsultado < totalConsulta);

            //}
        }


        public void Consultar(Consulta consulta)
        {


            wb.Document.GetElementById("aceiteTermoUso").SetAttribute("checked", "true");

            if (!string.IsNullOrEmpty(consulta.CPFCNPJ))
                wb.Document.GetElementById("cpfCnpjEmitente").InnerText = consulta.CPFCNPJ;

            if (!string.IsNullOrEmpty(consulta.CM7D1))
                wb.Document.GetElementById("primeiroCampoCmc7").InnerText = consulta.CM7D1;

            if (!string.IsNullOrEmpty(consulta.CM7D2))
                wb.Document.GetElementById("segundoCampoCmc7").InnerText = consulta.CM7D2;

            if (!string.IsNullOrEmpty(consulta.CM7D3))
                wb.Document.GetElementById("terceiroCampoCmc7").InnerText = consulta.CM7D3;

            if (!string.IsNullOrEmpty(consulta.CPFINTERESSADO))
                wb.Document.GetElementById("cpfCnpjInteressado").InnerText = consulta.CPFINTERESSADO;


            //repete:
            //BuscaCaptchaString();

            if (!string.IsNullOrEmpty(captcha))
                wb.Document.GetElementById("captcha").InnerText = captcha;

            //status.Text = "Aguardar 3 segundos";
            //Thread.Sleep(3000);
            wb.Document.GetElementById("btEnviar").InvokeMember("click");

            Thread.Sleep(5000);
            var item = wb.Document.GetElementById("errors");
            if (item.InnerHtml != null)
            {

                if ((item.InnerText.Contains(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado")) || (item.InnerText.Contains(@"Código da Imagem é um campo obrigatório")))
                {
                    //MessageBox.Show(@"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado");
                    status.Text = @"Código da Imagem: Caracteres do captcha não foram preenchidos corretamente ou o tempo máximo para preenchimento foi ultrapassado";
                    //goto repete;
                }

            }

        }

        private void atualizaConsultado()
        {
            totalconsultado += 1;
            lblTotal.Text = string.Format("{0}/{1}", totalconsultado, totalConsulta);
        }
    }
}
