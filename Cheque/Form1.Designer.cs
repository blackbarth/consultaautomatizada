namespace Cheque
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wb = new System.Windows.Forms.WebBrowser();
            this.status = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtcpf = new System.Windows.Forms.TextBox();
            this.txtd1 = new System.Windows.Forms.TextBox();
            this.txtd2 = new System.Windows.Forms.TextBox();
            this.txtd3 = new System.Windows.Forms.TextBox();
            this.txtcpfinteressado = new System.Windows.Forms.TextBox();
            this.txtcaptcha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.piccaptcha = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTeste = new System.Windows.Forms.Label();
            this.origem = new System.Windows.Forms.OpenFileDialog();
            this.destino = new System.Windows.Forms.OpenFileDialog();
            this.gridArquivos = new System.Windows.Forms.DataGridView();
            this.btnOrigem = new System.Windows.Forms.Button();
            this.btnDestino = new System.Windows.Forms.Button();
            this.lblDestino = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnIniciarConsulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccaptcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArquivos)).BeginInit();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(1310, 876);
            this.wb.TabIndex = 0;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 853);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1310, 23);
            this.status.TabIndex = 2;
            this.status.Text = "ultraStatusBar1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(503, 853);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // txtcpf
            // 
            this.txtcpf.Location = new System.Drawing.Point(25, 51);
            this.txtcpf.Name = "txtcpf";
            this.txtcpf.Size = new System.Drawing.Size(191, 20);
            this.txtcpf.TabIndex = 1;
            // 
            // txtd1
            // 
            this.txtd1.Location = new System.Drawing.Point(25, 97);
            this.txtd1.Name = "txtd1";
            this.txtd1.Size = new System.Drawing.Size(151, 20);
            this.txtd1.TabIndex = 2;
            // 
            // txtd2
            // 
            this.txtd2.Location = new System.Drawing.Point(182, 97);
            this.txtd2.Name = "txtd2";
            this.txtd2.Size = new System.Drawing.Size(134, 20);
            this.txtd2.TabIndex = 3;
            // 
            // txtd3
            // 
            this.txtd3.Location = new System.Drawing.Point(322, 97);
            this.txtd3.Name = "txtd3";
            this.txtd3.Size = new System.Drawing.Size(144, 20);
            this.txtd3.TabIndex = 4;
            // 
            // txtcpfinteressado
            // 
            this.txtcpfinteressado.Location = new System.Drawing.Point(18, 146);
            this.txtcpfinteressado.Name = "txtcpfinteressado";
            this.txtcpfinteressado.Size = new System.Drawing.Size(191, 20);
            this.txtcpfinteressado.TabIndex = 5;
            this.txtcpfinteressado.Text = "44003242068";
            // 
            // txtcaptcha
            // 
            this.txtcaptcha.Location = new System.Drawing.Point(238, 146);
            this.txtcaptcha.Name = "txtcaptcha";
            this.txtcaptcha.Size = new System.Drawing.Size(221, 20);
            this.txtcaptcha.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "CPF/CNPJ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "D1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "D2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "D3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "CPF/CNPJ do Interessado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Captcha";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(18, 258);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(155, 258);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // piccaptcha
            // 
            this.piccaptcha.Location = new System.Drawing.Point(18, 300);
            this.piccaptcha.Name = "piccaptcha";
            this.piccaptcha.Size = new System.Drawing.Size(221, 65);
            this.piccaptcha.TabIndex = 8;
            this.piccaptcha.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Atualiza Captcha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Testar Error";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Location = new System.Drawing.Point(65, 494);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(0, 13);
            this.lblTeste.TabIndex = 10;
            // 
            // origem
            // 
            this.origem.FileName = "Origem";
            // 
            // destino
            // 
            this.destino.FileName = "openFileDialog2";
            // 
            // gridArquivos
            // 
            this.gridArquivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridArquivos.Location = new System.Drawing.Point(25, 409);
            this.gridArquivos.Name = "gridArquivos";
            this.gridArquivos.Size = new System.Drawing.Size(441, 430);
            this.gridArquivos.TabIndex = 11;
            // 
            // btnOrigem
            // 
            this.btnOrigem.Location = new System.Drawing.Point(18, 380);
            this.btnOrigem.Name = "btnOrigem";
            this.btnOrigem.Size = new System.Drawing.Size(75, 23);
            this.btnOrigem.TabIndex = 12;
            this.btnOrigem.Text = "Ler Arquivo";
            this.btnOrigem.UseVisualStyleBackColor = true;
            this.btnOrigem.Click += new System.EventHandler(this.btnOrigem_Click);
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(99, 380);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(75, 23);
            this.btnDestino.TabIndex = 13;
            this.btnDestino.Text = "Destino";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(180, 385);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(0, 13);
            this.lblDestino.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(391, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Numero para consultar.:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(152, 230);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 17;
            // 
            // btnIniciarConsulta
            // 
            this.btnIniciarConsulta.Location = new System.Drawing.Point(308, 225);
            this.btnIniciarConsulta.Name = "btnIniciarConsulta";
            this.btnIniciarConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarConsulta.TabIndex = 18;
            this.btnIniciarConsulta.Text = "Iniciar Consulta";
            this.btnIniciarConsulta.UseVisualStyleBackColor = true;
            this.btnIniciarConsulta.Click += new System.EventHandler(this.btnIniciarConsulta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 876);
            this.Controls.Add(this.btnIniciarConsulta);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.btnDestino);
            this.Controls.Add(this.btnOrigem);
            this.Controls.Add(this.gridArquivos);
            this.Controls.Add(this.lblTeste);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.piccaptcha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcaptcha);
            this.Controls.Add(this.txtcpfinteressado);
            this.Controls.Add(this.txtd3);
            this.Controls.Add(this.txtd2);
            this.Controls.Add(this.txtd1);
            this.Controls.Add(this.txtcpf);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.wb);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccaptcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridArquivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar status;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox txtcpf;
        private System.Windows.Forms.TextBox txtd1;
        private System.Windows.Forms.TextBox txtd2;
        private System.Windows.Forms.TextBox txtd3;
        private System.Windows.Forms.TextBox txtcpfinteressado;
        private System.Windows.Forms.TextBox txtcaptcha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.PictureBox piccaptcha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.OpenFileDialog origem;
        private System.Windows.Forms.OpenFileDialog destino;
        private System.Windows.Forms.DataGridView gridArquivos;
        private System.Windows.Forms.Button btnOrigem;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnIniciarConsulta;
    }
}

