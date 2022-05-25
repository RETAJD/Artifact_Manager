namespace App
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.probab_Admin = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(329, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // probab_Admin
            // 
            this.probab_Admin.AutoSize = true;
            this.probab_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.probab_Admin.Location = new System.Drawing.Point(34, 15);
            this.probab_Admin.Name = "probab_Admin";
            this.probab_Admin.Size = new System.Drawing.Size(30, 31);
            this.probab_Admin.TabIndex = 1;
            this.probab_Admin.Text = "a";
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_User.Location = new System.Drawing.Point(575, 15);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(30, 24);
            this.label_User.TabIndex = 2;
            this.label_User.Text = "aa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 59);
            this.button1.TabIndex = 3;
            this.button1.Text = "Zarządzanie Użytkownikami";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 66);
            this.button2.TabIndex = 4;
            this.button2.Text = "Zarządzanie artefaktami";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(297, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 65);
            this.button3.TabIndex = 5;
            this.button3.Text = "TOP 5 i Lista nowości";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.probab_Admin);
            this.Controls.Add(this.label1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label probab_Admin;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}