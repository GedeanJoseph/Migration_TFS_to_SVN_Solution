namespace MigracaoSVN
{
    partial class frmConfigSln
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigSln));
            this.btnExecutar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnGetPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExecutar
            // 
            this.btnExecutar.Location = new System.Drawing.Point(193, 56);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(145, 34);
            this.btnExecutar.TabIndex = 0;
            this.btnExecutar.Text = "Executa tratamento";
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caminho da solution";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 28);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(461, 20);
            this.txtPath.TabIndex = 2;
            // 
            // btnGetPath
            // 
            this.btnGetPath.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPath.Image = ((System.Drawing.Image)(resources.GetObject("btnGetPath.Image")));
            this.btnGetPath.Location = new System.Drawing.Point(475, 26);
            this.btnGetPath.Name = "btnGetPath";
            this.btnGetPath.Size = new System.Drawing.Size(27, 23);
            this.btnGetPath.TabIndex = 5;
            this.btnGetPath.UseVisualStyleBackColor = false;
            this.btnGetPath.Click += new System.EventHandler(this.btnGetPath_Click);
            // 
            // frmConfigSln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(507, 102);
            this.Controls.Add(this.btnGetPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecutar);
            this.MaximizeBox = false;
            this.Name = "frmConfigSln";
            this.Text = "Projeto CI/CD - Configuração";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnGetPath;
    }
}