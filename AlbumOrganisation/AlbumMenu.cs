using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumOrganisation
{
    public partial class AlbumMenu : Form
    {
        public AlbumMenu()
        {
            InitializeComponent();
            Settings();
        }

        private void Settings()
        {
            Size = new Size(600, 600);
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void AlbumMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
