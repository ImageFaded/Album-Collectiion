/*
 * Program for keeping track of albums within collection 
 */

//Including appropriate libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumOrganisation
{
    //Form to display information relating to albums/artists
    public partial class AlbumMenu : Form
    {
        TextBox textList;

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
            //LoadAllAlbums();
            LoadButtons();
        }

        //Settings to load a textbox to the screen which shall display information
        private void LoadTextBox()
        {
            textList = new TextBox();
            textList.SetBounds(280, 20, 300, 530);
            textList.ScrollBars = ScrollBars.Vertical;
            textList.BackColor = Color.White;
            textList.ReadOnly = true;
            textList.Multiline = true;
            Controls.Add(textList);
            LoadAlbumText();
        }

        //Displays Buttons with labels onto the screen
        private void LoadButtons()
        {
            //Create a list of buttons
            Button[] buttonList = new Button[5];
            int i = 0;
            for (i = 0; i < buttonList.Length; i++)
            {
                int arrayIndex = i;
                buttonList[i] = new Button();
                buttonList[i].SetBounds(80, 55 * (i+2) + 20, 100, 40);
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
                    case 4:
                        buttonList[i].Text = "Quit";
                        break;
                    default:
                        buttonList[i].Text = "Button"+i;
                        break;
                }
                buttonList[i].Tag = "Button"+i;
                buttonList[i].Click += (sender, args) => ButtonClick(sender, args, buttonList[arrayIndex], textList);
                Controls.Add(buttonList[i]);
            }
        }

        //Loads albums onto screen upon program startup/Creates new text file if deleted
        private void LoadAllAlbums()
        {
            var pathToList = Path.Combine(Directory.GetCurrentDirectory(), "\\AlbumList.txt");
            //MessageBox.Show(pathToList);
            if (!File.Exists(pathToList)){
                File.Create(pathToList);
            } else
            {
                textList.Text = File.ReadAllText(pathToList);
            }
        }

        private void ButtonClick(object sender, EventArgs e, Button buttonClicked, TextBox textList)
        {
            var pathToList = Path.Combine(Directory.GetCurrentDirectory(), "\\AlbumList.txt");
            switch (buttonClicked.Tag.ToString())
            {
                //Search Artists
                case "Button0":
                    textList.AppendText(AlbumSorting.SearchArtistAccess(textList));
                    SaveAlbumText(AlbumSorting.SearchArtistAccess(textList));
                    break;
                //Search Albums
                case "Button1":
                    textList.AppendText(AlbumSorting.SearchAlbumAccess(textList));
                    SaveAlbumText(AlbumSorting.SearchAlbumAccess(textList));
                    break;
                //Add Album
                case "Button2":
                    textList.AppendText(AlbumSorting.AddAccess(textList));
                    SaveAlbumText(AlbumSorting.AddAccess(textList));
                    break;
                //Remove Album
                case "Button3":
                    textList.AppendText(AlbumSorting.RemoveAccess(textList));
                    SaveAlbumText(AlbumSorting.RemoveAccess(textList));
                    break;
                case "Button4":
                    Application.Exit();
                    break;
                default:
                    MessageBox.Show("Functionality Not Found!");
                    break;
            }
        }

        private void LoadAlbumText()
        {
            var pathToList = Path.Combine(Directory.GetCurrentDirectory(), "\\AlbumList.txt");
            try
            {
                using (StreamReader streamRead = new StreamReader(pathToList))
                {
                    string line = streamRead.ReadToEnd();
                    textList.AppendText(line);
                }
            }
            catch (FileNotFoundException)
            {
                if (!File.Exists(pathToList))
                {
                    File.Create(pathToList);
                }
                else
                {
                    textList.Text = File.ReadAllText(pathToList);
                }
            }
        }

        private void SaveAlbumText(string inputText)
        {
            var pathToList = Path.Combine(Directory.GetCurrentDirectory(), "\\AlbumList.txt");
            //IOException Point
            using (StreamWriter streamWrite = File.AppendText(pathToList))
            {
                streamWrite.WriteLine(inputText);
            }

        }

        private void AlbumMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
