using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorLauncherBox
{
    public partial class CloseBtn : UserControl
    {
        public CloseBtn()
        {
            InitializeComponent();
        }

        private void CloseBtn_Load(object sender, EventArgs e)
        {
            this.Height = label1.Height;
            this.Width = label1.Width;
            this.Left = Parent.Width - this.Width - 1;
            this.Top = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Parent.Dispose();
        }

        private void Parent_Disposed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.DarkRed;
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            label1.BackColor = Color.Red;
        }
    }
}
