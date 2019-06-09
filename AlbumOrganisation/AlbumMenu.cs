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
            LoadButtons();
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

        //Displays Buttons with labels onto the screen
        private void LoadButtons()
        {
            Button[] buttonList = new Button[5];
            int i = 0;
            for (i = 0; i < buttonList.Length-1; i++)
            {
                int arrayIndex = i;
                buttonList[i] = new Button();
                buttonList[i].SetBounds(80, 60 * (i+2) + 20, 100, 40);
                switch (i)
                {
                    case 0:
                        buttonList[i].Text = "Search Artist";
                        break;
                    case 1:
                        buttonList[i].Text = "Search Album";
                        break;
                    case 2:
                        buttonList[i].Text = "Add Album";
                        break;
                    case 3:
                        buttonList[i].Text = "Remove Album";
                        break;
                    default:
                        buttonList[i].Text = "Button"+i;
                        break;
                }
                buttonList[i].Tag = "Button"+i;
                buttonList[i].Click += (sender, args) => ButtonClick(sender, args, buttonList[arrayIndex]);
                Controls.Add(buttonList[i]);
            }
        }

        private void ButtonClick(object sender, EventArgs e, Button buttonClicked)
        {
            //MessageBox.Show(buttonClicked.Tag.ToString());
            switch (buttonClicked.Tag.ToString())
            {
                //Search Artissts
                case "Button0":
                    break;
                //Search Albums
                case "Button1":
                    break;
                //Add Album
                case "Button2":
                    break;
                //Remove Album
                case "Button3":
                    break;
                default:
                    MessageBox.Show("Functionality Not Found!");
                    break;
            }
        }

        private void AlbumMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
