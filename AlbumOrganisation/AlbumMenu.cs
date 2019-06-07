/*
 * Program for keeping track of albums within collection 
 */

//Including appropriate libraries
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
    //Form to display information relating to albums/artists
    public partial class AlbumMenu : Form
    {

        //Initialises form for album 
        public AlbumMenu()
        {
            InitializeComponent();
            MenuDisplaySettings();
            LoadItems();
        }

        //Sets the size of the album menu form
        private void MenuDisplaySettings()
        {
            Size = new Size(600, 600);
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        //Loads items that will dynamically be displayed onto the screen
        private void LoadItems()
        {
            LoadTextBox();
        }

        //Settings to load a textbox to the screen which shall display information
        private void LoadTextBox()
        {
            TextBox textList = new TextBox();
            textList.SetBounds(280, 20, 300, 530);
            textList.ScrollBars = ScrollBars.Vertical;
            textList.BackColor = Color.White;
            textList.ReadOnly = true;
            textList.Multiline = true;
            Controls.Add(textList);
        }

        private void AlbumMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
