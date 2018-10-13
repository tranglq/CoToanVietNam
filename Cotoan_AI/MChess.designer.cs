namespace MChess
{
    partial class MChess
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanCoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuSoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chonMauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doSauTimKiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Dokho6 = new System.Windows.Forms.ToolStripMenuItem();
            this.diemthoathuantoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muoitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muoinamtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haimuoitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hainhamtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bamuoitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banhamtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonmuoitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bonnhamtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vanMoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batDauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quaylaitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngungchoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dauhangtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatus});
            this.status.Location = new System.Drawing.Point(0, 699);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1117, 22);
            this.status.TabIndex = 35;
            this.toolTip.SetToolTip(this.status, "Thanh trạng thái");
            // 
            // lblstatus
            // 
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(53, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanCoToolStripMenuItem,
            this.chonMauToolStripMenuItem,
            this.doSauTimKiemToolStripMenuItem,
            this.diemthoathuantoolStripMenuItem,
            this.vanMoiToolStripMenuItem,
            this.batDauToolStripMenuItem,
            this.quaylaitoolStripMenuItem,
            this.ngungchoiToolStripMenuItem,
            this.dauhangtoolStripMenuItem,
            this.thoatToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // quanCoToolStripMenuItem
            // 
            this.quanCoToolStripMenuItem.AutoToolTip = true;
            this.quanCoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chamToolStripMenuItem,
            this.chuSoToolStripMenuItem});
            this.quanCoToolStripMenuItem.Name = "quanCoToolStripMenuItem";
            this.quanCoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quanCoToolStripMenuItem.Text = "Quân cờ";
            this.quanCoToolStripMenuItem.ToolTipText = "Chọn loại quân cờ";
            // 
            // chamToolStripMenuItem
            // 
            this.chamToolStripMenuItem.Checked = true;
            this.chamToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chamToolStripMenuItem.Name = "chamToolStripMenuItem";
            this.chamToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.chamToolStripMenuItem.Text = "Chấm";
            this.chamToolStripMenuItem.Click += new System.EventHandler(this.chamToolStripMenuItem_Click);
            // 
            // chuSoToolStripMenuItem
            // 
            this.chuSoToolStripMenuItem.Name = "chuSoToolStripMenuItem";
            this.chuSoToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.chuSoToolStripMenuItem.Text = "Chữ số";
            this.chuSoToolStripMenuItem.Click += new System.EventHandler(this.chuSoToolStripMenuItem_Click);
            // 
            // chonMauToolStripMenuItem
            // 
            this.chonMauToolStripMenuItem.AutoToolTip = true;
            this.chonMauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xanhToolStripMenuItem,
            this.doToolStripMenuItem});
            this.chonMauToolStripMenuItem.Name = "chonMauToolStripMenuItem";
            this.chonMauToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.chonMauToolStripMenuItem.Text = "Chọn màu";
            this.chonMauToolStripMenuItem.ToolTipText = " Chọn màu quân";
            // 
            // xanhToolStripMenuItem
            // 
            this.xanhToolStripMenuItem.Name = "xanhToolStripMenuItem";
            this.xanhToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.xanhToolStripMenuItem.Text = "Xanh";
            this.xanhToolStripMenuItem.Click += new System.EventHandler(this.xanhToolStripMenuItem_Click);
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Checked = true;
            this.doToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.doToolStripMenuItem.Text = "Đỏ";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // doSauTimKiemToolStripMenuItem
            // 
            this.doSauTimKiemToolStripMenuItem.AutoToolTip = true;
            this.doSauTimKiemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dokho1,
            this.Dokho2,
            this.Dokho3,
            this.Dokho4,
            this.Dokho5,
            this.Dokho6});
            this.doSauTimKiemToolStripMenuItem.Name = "doSauTimKiemToolStripMenuItem";
            this.doSauTimKiemToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.doSauTimKiemToolStripMenuItem.Text = "Độ khó";
            this.doSauTimKiemToolStripMenuItem.ToolTipText = "Chọn độ khó";
            // 
            // Dokho1
            // 
            this.Dokho1.Name = "Dokho1";
            this.Dokho1.Size = new System.Drawing.Size(91, 22);
            this.Dokho1.Text = "1";
            this.Dokho1.Click += new System.EventHandler(this.Dokho1_Click);
            // 
            // Dokho2
            // 
            this.Dokho2.Name = "Dokho2";
            this.Dokho2.Size = new System.Drawing.Size(91, 22);
            this.Dokho2.Text = "2";
            this.Dokho2.Click += new System.EventHandler(this.Dokho2_Click);
            // 
            // Dokho3
            // 
            this.Dokho3.Name = "Dokho3";
            this.Dokho3.Size = new System.Drawing.Size(91, 22);
            this.Dokho3.Text = "3";
            this.Dokho3.Click += new System.EventHandler(this.Dokho3_Click);
            // 
            // Dokho4
            // 
            this.Dokho4.Checked = true;
            this.Dokho4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Dokho4.Name = "Dokho4";
            this.Dokho4.Size = new System.Drawing.Size(91, 22);
            this.Dokho4.Text = "4";
            this.Dokho4.Click += new System.EventHandler(this.Dokho4_Click);
            // 
            // Dokho5
            // 
            this.Dokho5.Name = "Dokho5";
            this.Dokho5.Size = new System.Drawing.Size(91, 22);
            this.Dokho5.Text = "5";
            this.Dokho5.Click += new System.EventHandler(this.Dokho5_Click);
            // 
            // Dokho6
            // 
            this.Dokho6.Name = "Dokho6";
            this.Dokho6.Size = new System.Drawing.Size(91, 22);
            this.Dokho6.Text = "6";
            this.Dokho6.Click += new System.EventHandler(this.Dokho6_Click);
            // 
            // diemthoathuantoolStripMenuItem
            // 
            this.diemthoathuantoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.khongToolStripMenuItem,
            this.muoitoolStripMenuItem,
            this.muoinamtoolStripMenuItem,
            this.haimuoitoolStripMenuItem,
            this.hainhamtoolStripMenuItem,
            this.bamuoitoolStripMenuItem,
            this.banhamtoolStripMenuItem,
            this.bonmuoitoolStripMenuItem,
            this.bonnhamtoolStripMenuItem});
            this.diemthoathuantoolStripMenuItem.Name = "diemthoathuantoolStripMenuItem";
            this.diemthoathuantoolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.diemthoathuantoolStripMenuItem.Text = "Điểm thỏa thuận";
            // 
            // khongToolStripMenuItem
            // 
            this.khongToolStripMenuItem.Checked = true;
            this.khongToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.khongToolStripMenuItem.Name = "khongToolStripMenuItem";
            this.khongToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.khongToolStripMenuItem.Text = "Không giới hạn";
            this.khongToolStripMenuItem.Click += new System.EventHandler(this.khongToolStripMenuItem_Click);
            // 
            // muoitoolStripMenuItem
            // 
            this.muoitoolStripMenuItem.Name = "muoitoolStripMenuItem";
            this.muoitoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.muoitoolStripMenuItem.Text = "10";
            this.muoitoolStripMenuItem.Click += new System.EventHandler(this.muoitoolStripMenuItem_Click);
            // 
            // muoinamtoolStripMenuItem
            // 
            this.muoinamtoolStripMenuItem.Name = "muoinamtoolStripMenuItem";
            this.muoinamtoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.muoinamtoolStripMenuItem.Text = "15";
            this.muoinamtoolStripMenuItem.Click += new System.EventHandler(this.muoinamtoolStripMenuItem_Click);
            // 
            // haimuoitoolStripMenuItem
            // 
            this.haimuoitoolStripMenuItem.Name = "haimuoitoolStripMenuItem";
            this.haimuoitoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.haimuoitoolStripMenuItem.Text = "20";
            this.haimuoitoolStripMenuItem.Click += new System.EventHandler(this.haimuoitoolStripMenuItem_Click);
            // 
            // hainhamtoolStripMenuItem
            // 
            this.hainhamtoolStripMenuItem.Name = "hainhamtoolStripMenuItem";
            this.hainhamtoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.hainhamtoolStripMenuItem.Text = "25";
            this.hainhamtoolStripMenuItem.Click += new System.EventHandler(this.hainhamtoolStripMenuItem_Click);
            // 
            // bamuoitoolStripMenuItem
            // 
            this.bamuoitoolStripMenuItem.Name = "bamuoitoolStripMenuItem";
            this.bamuoitoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bamuoitoolStripMenuItem.Text = "30";
            this.bamuoitoolStripMenuItem.Click += new System.EventHandler(this.bamuoitoolStripMenuItem_Click);
            // 
            // banhamtoolStripMenuItem
            // 
            this.banhamtoolStripMenuItem.Name = "banhamtoolStripMenuItem";
            this.banhamtoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.banhamtoolStripMenuItem.Text = "35";
            this.banhamtoolStripMenuItem.Click += new System.EventHandler(this.banhamtoolStripMenuItem_Click);
            // 
            // bonmuoitoolStripMenuItem
            // 
            this.bonmuoitoolStripMenuItem.Name = "bonmuoitoolStripMenuItem";
            this.bonmuoitoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bonmuoitoolStripMenuItem.Text = "40";
            this.bonmuoitoolStripMenuItem.Click += new System.EventHandler(this.bonmuoitoolStripMenuItem_Click);
            // 
            // bonnhamtoolStripMenuItem
            // 
            this.bonnhamtoolStripMenuItem.Name = "bonnhamtoolStripMenuItem";
            this.bonnhamtoolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.bonnhamtoolStripMenuItem.Text = "45";
            this.bonnhamtoolStripMenuItem.Click += new System.EventHandler(this.bonnhamtoolStripMenuItem_Click);
            // 
            // vanMoiToolStripMenuItem
            // 
            this.vanMoiToolStripMenuItem.AutoToolTip = true;
            this.vanMoiToolStripMenuItem.Enabled = false;
            this.vanMoiToolStripMenuItem.Name = "vanMoiToolStripMenuItem";
            this.vanMoiToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.vanMoiToolStripMenuItem.Text = "Ván mới";
            this.vanMoiToolStripMenuItem.ToolTipText = "Chơi lại ván mới";
            this.vanMoiToolStripMenuItem.Click += new System.EventHandler(this.vanMoiToolStripMenuItem_Click);
            // 
            // batDauToolStripMenuItem
            // 
            this.batDauToolStripMenuItem.Name = "batDauToolStripMenuItem";
            this.batDauToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.batDauToolStripMenuItem.Text = "Bắt đầu";
            this.batDauToolStripMenuItem.Click += new System.EventHandler(this.batDauToolStripMenuItem_Click);
            // 
            // quaylaitoolStripMenuItem
            // 
            this.quaylaitoolStripMenuItem.Enabled = false;
            this.quaylaitoolStripMenuItem.Name = "quaylaitoolStripMenuItem";
            this.quaylaitoolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quaylaitoolStripMenuItem.Text = "Quay lại ";
            this.quaylaitoolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ngungchoiToolStripMenuItem
            // 
            this.ngungchoiToolStripMenuItem.AutoToolTip = true;
            this.ngungchoiToolStripMenuItem.Enabled = false;
            this.ngungchoiToolStripMenuItem.Name = "ngungchoiToolStripMenuItem";
            this.ngungchoiToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ngungchoiToolStripMenuItem.Text = "Ngừng chơi";
            this.ngungchoiToolStripMenuItem.ToolTipText = "Ngừng chơi , tính điểm để  quyết định bên thắng.";
            this.ngungchoiToolStripMenuItem.Click += new System.EventHandler(this.ngungchoiToolStripMenuItem_Click_1);
            // 
            // dauhangtoolStripMenuItem
            // 
            this.dauhangtoolStripMenuItem.Enabled = false;
            this.dauhangtoolStripMenuItem.Name = "dauhangtoolStripMenuItem";
            this.dauhangtoolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.dauhangtoolStripMenuItem.Text = "Đầu hàng ";
            this.dauhangtoolStripMenuItem.Click += new System.EventHandler(this.dauhangtoolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem1
            // 
            this.thoatToolStripMenuItem1.AutoToolTip = true;
            this.thoatToolStripMenuItem1.Name = "thoatToolStripMenuItem1";
            this.thoatToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.thoatToolStripMenuItem1.Text = "Thoát";
            this.thoatToolStripMenuItem1.ToolTipText = "Thoát game";
            this.thoatToolStripMenuItem1.Click += new System.EventHandler(this.thoatToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cotoan_AI.Properties.Resources.fonts_2;
            this.pictureBox2.Location = new System.Drawing.Point(83, 665);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(433, 31);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cotoan_AI.Properties.Resources.fonts_1_;
            this.pictureBox1.Location = new System.Drawing.Point(93, 605);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(412, 57);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Cotoan_AI.Properties.Resources.fonts_3;
            this.pictureBox3.Location = new System.Drawing.Point(94, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(402, 37);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            // 
            // MChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 721);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MChess";
            this.Text = "MChess";
            this.Load += new System.EventHandler(this.MChess_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanCoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuSoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chonMauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xanhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doSauTimKiemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dokho2;
        private System.Windows.Forms.ToolStripMenuItem Dokho3;
        private System.Windows.Forms.ToolStripMenuItem Dokho4;
        private System.Windows.Forms.ToolStripMenuItem vanMoiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batDauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngungchoiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quaylaitoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dokho1;
        private System.Windows.Forms.ToolStripMenuItem Dokho5;
        private System.Windows.Forms.ToolStripMenuItem Dokho6;
        private System.Windows.Forms.ToolStripMenuItem dauhangtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diemthoathuantoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muoitoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muoinamtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haimuoitoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hainhamtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bamuoitoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banhamtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bonmuoitoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bonnhamtoolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}