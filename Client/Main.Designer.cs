namespace Client
{
    partial class Main
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnGetId = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnPut = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstEntities = new System.Windows.Forms.ListBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.grpBoxEntity = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCredentials = new System.Windows.Forms.GroupBox();
            this.btnClearCredentials = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblCredentials = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.grpBoxEntity.SuspendLayout();
            this.grpCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Sitka Text", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(781, 104);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Client Web API Tester";
            // 
            // btnGetAll
            // 
            this.btnGetAll.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAll.Location = new System.Drawing.Point(30, 123);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(174, 72);
            this.btnGetAll.TabIndex = 3;
            this.btnGetAll.Text = "GET *";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnGetId
            // 
            this.btnGetId.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetId.Location = new System.Drawing.Point(30, 212);
            this.btnGetId.Name = "btnGetId";
            this.btnGetId.Size = new System.Drawing.Size(174, 72);
            this.btnGetId.TabIndex = 4;
            this.btnGetId.Text = "GET 1";
            this.btnGetId.UseVisualStyleBackColor = true;
            this.btnGetId.Click += new System.EventHandler(this.btnGetId_Click);
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.Location = new System.Drawing.Point(30, 304);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(174, 72);
            this.btnPost.TabIndex = 5;
            this.btnPost.Text = "POST";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnPut
            // 
            this.btnPut.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPut.Location = new System.Drawing.Point(30, 396);
            this.btnPut.Name = "btnPut";
            this.btnPut.Size = new System.Drawing.Size(174, 72);
            this.btnPut.TabIndex = 6;
            this.btnPut.Text = "PUT";
            this.btnPut.UseVisualStyleBackColor = true;
            this.btnPut.Click += new System.EventHandler(this.btnPut_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(30, 486);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(174, 72);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstEntities
            // 
            this.lstEntities.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEntities.FormattingEnabled = true;
            this.lstEntities.ItemHeight = 22;
            this.lstEntities.Location = new System.Drawing.Point(224, 126);
            this.lstEntities.Name = "lstEntities";
            this.lstEntities.Size = new System.Drawing.Size(293, 422);
            this.lstEntities.TabIndex = 8;
            this.lstEntities.SelectedValueChanged += new System.EventHandler(this.lstEntities_SelectedValueChanged);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntity.Location = new System.Drawing.Point(53, 11);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(167, 69);
            this.lblEntity.TabIndex = 7;
            this.lblEntity.Text = "Entity";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(100, 105);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(93, 52);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID*:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(55, 174);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(153, 53);
            this.txtId.TabIndex = 1;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(71, 270);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(128, 52);
            this.lblValue.TabIndex = 10;
            this.lblValue.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(25, 341);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(231, 53);
            this.txtValue.TabIndex = 2;
            // 
            // grpBoxEntity
            // 
            this.grpBoxEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grpBoxEntity.Controls.Add(this.btnClear);
            this.grpBoxEntity.Controls.Add(this.label1);
            this.grpBoxEntity.Controls.Add(this.txtValue);
            this.grpBoxEntity.Controls.Add(this.lblEntity);
            this.grpBoxEntity.Controls.Add(this.lblValue);
            this.grpBoxEntity.Controls.Add(this.txtId);
            this.grpBoxEntity.Controls.Add(this.lblId);
            this.grpBoxEntity.Location = new System.Drawing.Point(537, 107);
            this.grpBoxEntity.Name = "grpBoxEntity";
            this.grpBoxEntity.Size = new System.Drawing.Size(271, 451);
            this.grpBoxEntity.TabIndex = 12;
            this.grpBoxEntity.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::Client.Properties.Resources.clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Location = new System.Drawing.Point(215, 400);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(40, 41);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "* zero-based index";
            // 
            // grpCredentials
            // 
            this.grpCredentials.BackColor = System.Drawing.Color.LavenderBlush;
            this.grpCredentials.Controls.Add(this.btnClearCredentials);
            this.grpCredentials.Controls.Add(this.txtPassword);
            this.grpCredentials.Controls.Add(this.txtUsername);
            this.grpCredentials.Controls.Add(this.lblCredentials);
            this.grpCredentials.Controls.Add(this.lblPassword);
            this.grpCredentials.Controls.Add(this.lblUsername);
            this.grpCredentials.Location = new System.Drawing.Point(814, 107);
            this.grpCredentials.Name = "grpCredentials";
            this.grpCredentials.Size = new System.Drawing.Size(296, 451);
            this.grpCredentials.TabIndex = 13;
            this.grpCredentials.TabStop = false;
            // 
            // btnClearCredentials
            // 
            this.btnClearCredentials.BackgroundImage = global::Client.Properties.Resources.clear;
            this.btnClearCredentials.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearCredentials.Location = new System.Drawing.Point(238, 400);
            this.btnClearCredentials.Name = "btnClearCredentials";
            this.btnClearCredentials.Size = new System.Drawing.Size(40, 41);
            this.btnClearCredentials.TabIndex = 14;
            this.btnClearCredentials.UseVisualStyleBackColor = true;
            this.btnClearCredentials.Click += new System.EventHandler(this.btnClearCredentials_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(18, 341);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(231, 53);
            this.txtPassword.TabIndex = 13;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(18, 174);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 53);
            this.txtUsername.TabIndex = 12;
            // 
            // lblCredentials
            // 
            this.lblCredentials.AutoSize = true;
            this.lblCredentials.Font = new System.Drawing.Font("Sitka Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredentials.Location = new System.Drawing.Point(6, 11);
            this.lblCredentials.Name = "lblCredentials";
            this.lblCredentials.Size = new System.Drawing.Size(285, 69);
            this.lblCredentials.TabIndex = 11;
            this.lblCredentials.Text = "Credentials";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(48, 270);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(197, 52);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Sitka Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(48, 105);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(201, 52);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "username:";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Sitka Text", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(936, 29);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(174, 72);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1126, 572);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.grpCredentials);
            this.Controls.Add(this.grpBoxEntity);
            this.Controls.Add(this.lstEntities);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPut);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnGetId);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.lblTitle);
            this.Name = "Main";
            this.Text = "Client Web API Tester";
            this.grpBoxEntity.ResumeLayout(false);
            this.grpBoxEntity.PerformLayout();
            this.grpCredentials.ResumeLayout(false);
            this.grpCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnGetId;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnPut;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstEntities;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox grpBoxEntity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpCredentials;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblCredentials;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnClearCredentials;
        private System.Windows.Forms.Button btnRegister;
    }
}

