namespace sistema_de_agenda
{
    partial class form_detalles_contacto
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_numberphone = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(197, 102);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(61, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "label_name";
            this.label_name.Click += new System.EventHandler(this.label_name_Click);
            // 
            // label_numberphone
            // 
            this.label_numberphone.AutoSize = true;
            this.label_numberphone.Location = new System.Drawing.Point(320, 102);
            this.label_numberphone.Name = "label_numberphone";
            this.label_numberphone.Size = new System.Drawing.Size(65, 13);
            this.label_numberphone.TabIndex = 1;
            this.label_numberphone.Text = "label_phone";
            this.label_numberphone.Click += new System.EventHandler(this.label_numberphone_Click);
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(200, 167);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(59, 13);
            this.label_email.TabIndex = 2;
            this.label_email.Text = "label_email";
            this.label_email.Click += new System.EventHandler(this.label_email_Click);
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(323, 167);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(56, 13);
            this.label_date.TabIndex = 3;
            this.label_date.Text = "label_date";
            this.label_date.Click += new System.EventHandler(this.label_date_Click);
            // 
            // form_detalles_contacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_numberphone);
            this.Controls.Add(this.label_name);
            this.Name = "form_detalles_contacto";
            this.Text = "form_detalles_contacto";
            this.Load += new System.EventHandler(this.form_detalles_contacto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_numberphone;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.Label label_date;
    }
}