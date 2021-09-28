
namespace TemperaaturasPOO.Windows
{
    partial class FrmTemperaturasEdit
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.TemperaturaTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.CancelarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Temperatura:";
            // 
            // TemperaturaTextBox
            // 
            this.TemperaturaTextBox.Location = new System.Drawing.Point(131, 54);
            this.TemperaturaTextBox.MaxLength = 5;
            this.TemperaturaTextBox.Name = "TemperaturaTextBox";
            this.TemperaturaTextBox.Size = new System.Drawing.Size(125, 20);
            this.TemperaturaTextBox.TabIndex = 1;
            // 
            // OkButton
            // 
            this.OkButton.Image = global::TemperaaturasPOO.Windows.Properties.Resources.Guardar;
            this.OkButton.Location = new System.Drawing.Point(35, 121);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 63);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Image = global::TemperaaturasPOO.Windows.Properties.Resources.Cancelar;
            this.CancelarButton.Location = new System.Drawing.Point(207, 121);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(100, 63);
            this.CancelarButton.TabIndex = 2;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // FrmTemperaturasEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 220);
            this.ControlBox = false;
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.TemperaturaTextBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(365, 259);
            this.MinimumSize = new System.Drawing.Size(365, 259);
            this.Name = "FrmTemperaturasEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTemperaturasEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TemperaturaTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}