namespace ColorLauncherBox
{
    partial class Loginfrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginfrm));
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.SavepassCheck = new System.Windows.Forms.CheckBox();
            this.AutoLoginCheck = new System.Windows.Forms.CheckBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RegChgBtn = new System.Windows.Forms.Button();
            this.verL = new System.Windows.Forms.Label();
            this.Atimer = new System.Windows.Forms.Timer(this.components);
            this.autologintimer = new System.Windows.Forms.Timer(this.components);
            this.VedioPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.L_M1 = new System.Windows.Forms.Label();
            this.L_M2 = new System.Windows.Forms.Label();
            this.LoginTitle = new System.Windows.Forms.Label();
            this.LoginTitlePic = new System.Windows.Forms.PictureBox();
            this.UserList = new System.Windows.Forms.ListBox();
            this.DelectSelUser = new System.Windows.Forms.Label();
            this.closeBtn1 = new ColorLauncherBox.CloseBtn();
            ((System.ComponentModel.ISupportInitialize)(this.VedioPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTitlePic)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(57)))));
            this.UsernameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameTxt.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UsernameTxt.ForeColor = System.Drawing.Color.White;
            this.UsernameTxt.Location = new System.Drawing.Point(656, 210);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(182, 33);
            this.UsernameTxt.TabIndex = 0;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(57)))));
            this.PasswordTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTxt.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordTxt.ForeColor = System.Drawing.Color.White;
            this.PasswordTxt.Location = new System.Drawing.Point(656, 275);
            this.PasswordTxt.MaxLength = 16;
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '^';
            this.PasswordTxt.Size = new System.Drawing.Size(182, 33);
            this.PasswordTxt.TabIndex = 1;
            // 
            // SavepassCheck
            // 
            this.SavepassCheck.AutoSize = true;
            this.SavepassCheck.BackColor = System.Drawing.Color.Transparent;
            this.SavepassCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SavepassCheck.ForeColor = System.Drawing.Color.White;
            this.SavepassCheck.Location = new System.Drawing.Point(656, 320);
            this.SavepassCheck.Name = "SavepassCheck";
            this.SavepassCheck.Size = new System.Drawing.Size(84, 24);
            this.SavepassCheck.TabIndex = 2;
            this.SavepassCheck.Text = "记住密码";
            this.SavepassCheck.UseVisualStyleBackColor = false;
            this.SavepassCheck.CheckedChanged += new System.EventHandler(this.SavepassCheck_CheckedChanged);
            // 
            // AutoLoginCheck
            // 
            this.AutoLoginCheck.AutoSize = true;
            this.AutoLoginCheck.BackColor = System.Drawing.Color.Transparent;
            this.AutoLoginCheck.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AutoLoginCheck.ForeColor = System.Drawing.Color.White;
            this.AutoLoginCheck.Location = new System.Drawing.Point(754, 320);
            this.AutoLoginCheck.Name = "AutoLoginCheck";
            this.AutoLoginCheck.Size = new System.Drawing.Size(84, 24);
            this.AutoLoginCheck.TabIndex = 3;
            this.AutoLoginCheck.Text = "自动登录";
            this.AutoLoginCheck.UseVisualStyleBackColor = false;
            this.AutoLoginCheck.CheckedChanged += new System.EventHandler(this.AutoLoginCheck_CheckedChanged);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(155)))), ((int)(((byte)(12)))));
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginBtn.Location = new System.Drawing.Point(656, 352);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(182, 34);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "登  录";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // RegChgBtn
            // 
            this.RegChgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(57)))));
            this.RegChgBtn.FlatAppearance.BorderSize = 0;
            this.RegChgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegChgBtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RegChgBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.RegChgBtn.Location = new System.Drawing.Point(656, 395);
            this.RegChgBtn.Name = "RegChgBtn";
            this.RegChgBtn.Size = new System.Drawing.Size(182, 34);
            this.RegChgBtn.TabIndex = 5;
            this.RegChgBtn.Text = "注 册 / 找 回 密 码";
            this.RegChgBtn.UseVisualStyleBackColor = false;
            this.RegChgBtn.Click += new System.EventHandler(this.RegChgBtn_Click);
            // 
            // verL
            // 
            this.verL.BackColor = System.Drawing.Color.Transparent;
            this.verL.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.verL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.verL.Location = new System.Drawing.Point(667, 432);
            this.verL.Name = "verL";
            this.verL.Size = new System.Drawing.Size(160, 45);
            this.verL.TabIndex = 6;
            this.verL.Text = "客户端版本：$$$";
            this.verL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Atimer
            // 
            this.Atimer.Enabled = true;
            this.Atimer.Interval = 20;
            this.Atimer.Tick += new System.EventHandler(this.Atimer_Tick);
            // 
            // autologintimer
            // 
            this.autologintimer.Interval = 2000;
            this.autologintimer.Tick += new System.EventHandler(this.autologintimer_Tick);
            // 
            // VedioPlayer
            // 
            this.VedioPlayer.Enabled = true;
            this.VedioPlayer.Location = new System.Drawing.Point(1, 1);
            this.VedioPlayer.Name = "VedioPlayer";
            this.VedioPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VedioPlayer.OcxState")));
            this.VedioPlayer.Size = new System.Drawing.Size(633, 484);
            this.VedioPlayer.TabIndex = 8;
            this.VedioPlayer.Visible = false;
            this.VedioPlayer.StatusChange += new System.EventHandler(this.VedioPlayer_StatusChange);
            // 
            // L_M1
            // 
            this.L_M1.AutoSize = true;
            this.L_M1.BackColor = System.Drawing.Color.Transparent;
            this.L_M1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L_M1.ForeColor = System.Drawing.Color.White;
            this.L_M1.Location = new System.Drawing.Point(651, 182);
            this.L_M1.Name = "L_M1";
            this.L_M1.Size = new System.Drawing.Size(69, 25);
            this.L_M1.TabIndex = 9;
            this.L_M1.Text = "账号：";
            // 
            // L_M2
            // 
            this.L_M2.AutoSize = true;
            this.L_M2.BackColor = System.Drawing.Color.Transparent;
            this.L_M2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L_M2.ForeColor = System.Drawing.Color.White;
            this.L_M2.Location = new System.Drawing.Point(651, 247);
            this.L_M2.Name = "L_M2";
            this.L_M2.Size = new System.Drawing.Size(69, 25);
            this.L_M2.TabIndex = 10;
            this.L_M2.Text = "密码：";
            // 
            // LoginTitle
            // 
            this.LoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.LoginTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginTitle.ForeColor = System.Drawing.Color.White;
            this.LoginTitle.Location = new System.Drawing.Point(656, 131);
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Size = new System.Drawing.Size(182, 42);
            this.LoginTitle.TabIndex = 11;
            this.LoginTitle.Text = "Title";
            this.LoginTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginTitlePic
            // 
            this.LoginTitlePic.BackColor = System.Drawing.Color.Transparent;
            this.LoginTitlePic.Location = new System.Drawing.Point(720, 68);
            this.LoginTitlePic.Name = "LoginTitlePic";
            this.LoginTitlePic.Size = new System.Drawing.Size(60, 60);
            this.LoginTitlePic.TabIndex = 12;
            this.LoginTitlePic.TabStop = false;
            // 
            // UserList
            // 
            this.UserList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserList.ForeColor = System.Drawing.Color.White;
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 21;
            this.UserList.Location = new System.Drawing.Point(656, 210);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(182, 128);
            this.UserList.TabIndex = 13;
            this.UserList.Visible = false;
            // 
            // DelectSelUser
            // 
            this.DelectSelUser.AutoSize = true;
            this.DelectSelUser.BackColor = System.Drawing.Color.Transparent;
            this.DelectSelUser.ForeColor = System.Drawing.Color.Gray;
            this.DelectSelUser.Location = new System.Drawing.Point(782, 189);
            this.DelectSelUser.Name = "DelectSelUser";
            this.DelectSelUser.Size = new System.Drawing.Size(56, 17);
            this.DelectSelUser.TabIndex = 14;
            this.DelectSelUser.Text = "删除选中";
            this.DelectSelUser.Visible = false;
            this.DelectSelUser.Click += new System.EventHandler(this.DelectSelUser_Click);
            // 
            // closeBtn1
            // 
            this.closeBtn1.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn1.Location = new System.Drawing.Point(851, 1);
            this.closeBtn1.Margin = new System.Windows.Forms.Padding(3, 9360113, 3, 9360113);
            this.closeBtn1.Name = "closeBtn1";
            this.closeBtn1.Size = new System.Drawing.Size(26, 25);
            this.closeBtn1.TabIndex = 7;
            // 
            // Loginfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(862, 486);
            this.Controls.Add(this.DelectSelUser);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.LoginTitlePic);
            this.Controls.Add(this.LoginTitle);
            this.Controls.Add(this.L_M2);
            this.Controls.Add(this.L_M1);
            this.Controls.Add(this.VedioPlayer);
            this.Controls.Add(this.closeBtn1);
            this.Controls.Add(this.verL);
            this.Controls.Add(this.RegChgBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.AutoLoginCheck);
            this.Controls.Add(this.SavepassCheck);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameTxt);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Loginfrm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorLogin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Loginfrm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Loginfrm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.VedioPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTitlePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.CheckBox SavepassCheck;
        private System.Windows.Forms.CheckBox AutoLoginCheck;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button RegChgBtn;
        private System.Windows.Forms.Label verL;
        private CloseBtn closeBtn1;
        private System.Windows.Forms.Timer Atimer;
        private System.Windows.Forms.Timer autologintimer;
        private AxWMPLib.AxWindowsMediaPlayer VedioPlayer;
        private System.Windows.Forms.Label L_M1;
        private System.Windows.Forms.Label L_M2;
        private System.Windows.Forms.Label LoginTitle;
        private System.Windows.Forms.PictureBox LoginTitlePic;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Label DelectSelUser;
    }
}

