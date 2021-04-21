namespace c_sharp_thread
{
    partial class FormTPL
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
            this.buttonRequestPost = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRequestUser = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.buttonCancelUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRequestPost
            // 
            this.buttonRequestPost.Location = new System.Drawing.Point(292, 12);
            this.buttonRequestPost.Name = "buttonRequestPost";
            this.buttonRequestPost.Size = new System.Drawing.Size(96, 23);
            this.buttonRequestPost.TabIndex = 1;
            this.buttonRequestPost.Text = "Request POST";
            this.buttonRequestPost.UseVisualStyleBackColor = true;
            this.buttonRequestPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonRequestUser
            // 
            this.buttonRequestUser.Location = new System.Drawing.Point(27, 12);
            this.buttonRequestUser.Name = "buttonRequestUser";
            this.buttonRequestUser.Size = new System.Drawing.Size(104, 23);
            this.buttonRequestUser.TabIndex = 3;
            this.buttonRequestUser.Text = "Request USER";
            this.buttonRequestUser.UseVisualStyleBackColor = true;
            this.buttonRequestUser.Click += new System.EventHandler(this.buttonUser_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(27, 55);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(35, 13);
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "label1";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(292, 55);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(35, 13);
            this.labelPost.TabIndex = 5;
            this.labelPost.Text = "label2";
            // 
            // buttonCancelUser
            // 
            this.buttonCancelUser.Location = new System.Drawing.Point(138, 12);
            this.buttonCancelUser.Name = "buttonCancelUser";
            this.buttonCancelUser.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelUser.TabIndex = 6;
            this.buttonCancelUser.Text = "Cancel";
            this.buttonCancelUser.UseVisualStyleBackColor = true;
            this.buttonCancelUser.Click += new System.EventHandler(this.buttonCancelUser_Click);
            // 
            // FormTPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 497);
            this.Controls.Add(this.buttonCancelUser);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonRequestUser);
            this.Controls.Add(this.buttonRequestPost);
            this.Name = "FormTPL";
            this.Text = "FormTPL";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRequestPost;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonRequestUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Button buttonCancelUser;
    }
}