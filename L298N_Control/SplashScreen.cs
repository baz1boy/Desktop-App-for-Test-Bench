using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L298N_Control
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            panelProgressBar.Width += 5;
            if(panelProgressBar.Width >= 700)
            {
                timerProgressbar.Stop();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            labelLoading.BackColor = Color.Transparent;
            labelLoading.Parent = pictureBoxBackground;
            iconButtonExitProgress.BackColor = Color.Transparent;
            iconButtonExitProgress.Parent = pictureBoxBackground;
        }

        private void iconButtonExitProgress_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
