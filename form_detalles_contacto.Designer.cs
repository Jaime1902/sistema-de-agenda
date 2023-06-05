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
            this.button_back = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_view = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
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
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 29);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 4;
            this.button_back.Text = "Atras";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(123, 251);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 5;
            this.button_edit.Text = "Editar";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_view
            // 
            this.button_view.Location = new System.Drawing.Point(270, 251);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(75, 23);
            this.button_view.TabIndex = 6;
            this.button_view.Text = "Ver";
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(411, 251);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 7;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // form_detalles_contacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 302);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label_numberphone);
            this.Controls.Add(this.label_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_detalles_contacto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.Button button_eliminar;
    }
}