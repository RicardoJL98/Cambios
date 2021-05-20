
namespace Cambios
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxOrigem = new System.Windows.Forms.ComboBox();
            this.ComboBoxDestino = new System.Windows.Forms.ComboBox();
            this.ButtonConverter = new System.Windows.Forms.Button();
            this.LabelResultado = new System.Windows.Forms.Label();
            this.LabelStatuts = new System.Windows.Forms.Label();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonTrocar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            // 
            // TextBoxValor
            // 
            this.TextBoxValor.Location = new System.Drawing.Point(73, 60);
            this.TextBoxValor.Name = "TextBoxValor";
            this.TextBoxValor.Size = new System.Drawing.Size(373, 23);
            this.TextBoxValor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Moeda de Origem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Moeda de Destino:";
            // 
            // ComboBoxOrigem
            // 
            this.ComboBoxOrigem.FormattingEnabled = true;
            this.ComboBoxOrigem.Location = new System.Drawing.Point(170, 130);
            this.ComboBoxOrigem.Name = "ComboBoxOrigem";
            this.ComboBoxOrigem.Size = new System.Drawing.Size(276, 23);
            this.ComboBoxOrigem.TabIndex = 4;
            // 
            // ComboBoxDestino
            // 
            this.ComboBoxDestino.FormattingEnabled = true;
            this.ComboBoxDestino.Location = new System.Drawing.Point(173, 200);
            this.ComboBoxDestino.Name = "ComboBoxDestino";
            this.ComboBoxDestino.Size = new System.Drawing.Size(276, 23);
            this.ComboBoxDestino.TabIndex = 5;
            // 
            // ButtonConverter
            // 
            this.ButtonConverter.Enabled = false;
            this.ButtonConverter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonConverter.Location = new System.Drawing.Point(527, 60);
            this.ButtonConverter.Name = "ButtonConverter";
            this.ButtonConverter.Size = new System.Drawing.Size(139, 57);
            this.ButtonConverter.TabIndex = 6;
            this.ButtonConverter.Text = "Converter";
            this.ButtonConverter.UseVisualStyleBackColor = true;
            this.ButtonConverter.Click += new System.EventHandler(this.ButtonConverter_Click);
            // 
            // LabelResultado
            // 
            this.LabelResultado.AutoSize = true;
            this.LabelResultado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelResultado.Location = new System.Drawing.Point(170, 268);
            this.LabelResultado.Name = "LabelResultado";
            this.LabelResultado.Size = new System.Drawing.Size(367, 18);
            this.LabelResultado.TabIndex = 7;
            this.LabelResultado.Text = "Escolha um valor, moeda de origem e destino";
            // 
            // LabelStatuts
            // 
            this.LabelStatuts.AutoSize = true;
            this.LabelStatuts.Location = new System.Drawing.Point(49, 398);
            this.LabelStatuts.Name = "LabelStatuts";
            this.LabelStatuts.Size = new System.Drawing.Size(39, 15);
            this.LabelStatuts.TabIndex = 8;
            this.LabelStatuts.Text = "Status";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(535, 390);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(159, 23);
            this.ProgressBar1.TabIndex = 9;
            // 
            // buttonTrocar
            // 
            this.buttonTrocar.Enabled = false;
            this.buttonTrocar.Image = ((System.Drawing.Image)(resources.GetObject("buttonTrocar.Image")));
            this.buttonTrocar.Location = new System.Drawing.Point(553, 153);
            this.buttonTrocar.Name = "buttonTrocar";
            this.buttonTrocar.Size = new System.Drawing.Size(83, 65);
            this.buttonTrocar.TabIndex = 10;
            this.buttonTrocar.UseVisualStyleBackColor = true;
            this.buttonTrocar.Click += new System.EventHandler(this.buttonTrocar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.buttonTrocar);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.LabelStatuts);
            this.Controls.Add(this.LabelResultado);
            this.Controls.Add(this.ButtonConverter);
            this.Controls.Add(this.ComboBoxDestino);
            this.Controls.Add(this.ComboBoxOrigem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxValor);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Câmbios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxOrigem;
        private System.Windows.Forms.ComboBox ComboBoxDestino;
        private System.Windows.Forms.Button ButtonConverter;
        private System.Windows.Forms.Label LabelResultado;
        private System.Windows.Forms.Label LabelStatuts;
        private System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.Button buttonTrocar;
    }
}

