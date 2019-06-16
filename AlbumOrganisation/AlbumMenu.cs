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
        //Textbox is used to list information to the user regarding the albums in their collection
        TextBox textList;
        Input input;
        public static bool formOpen = false;

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
            var pathToList = Path.Combine(Directory.GetCurrentDirectory(), "\\AlbumList.txt");
            LoadTextBox(pathToList);
            LoadButtons(pathToList);
        }

        //Settings to load a textbox to the screen which shall display information
        private void LoadTextBox(string pathToList)
        {
            textList = new TextBox();
            textList.SetBounds(280, 20, 300, 530);
            textList.ScrollBars = ScrollBars.Vertical;
            textList.BackColor = Color.White;
            textList.ReadOnly = true;
            textList.Multiline = true;
            Controls.Add(textList);
            LoadAlbumText(pathToList);
        }

        //Displays Buttons with labels onto the screen
        private void LoadButtons(string pathToList)
        {
            //Create a list of buttons which contain main functionality of program
            Button[] buttonList = new Button[5];
            int buttonPosition = 0;
            for (buttonPosition = 0; buttonPosition < buttonList.Length; buttonPosition++)
            {
                int arrayIndex = buttonPosition;
                buttonList[buttonPosition] = new Button();
                buttonList[buttonPosition].SetBounds(80, 55 * (buttonPosition + 2) + 20, 100, 40);
                switch (buttonPosition)
                {
                    case 0:
                        buttonList[buttonPosition].Text = "Search Artist";
                        break;
                    case 1:
                        buttonList[buttonPosition].Text = "Search Album";
                        break;
                    case 2:
                        buttonList[buttonPosition].Text = "Add Album";
                        break;
                    case 3:
                        buttonList[buttonPosition].Text = "Remove Album";
                        break;
                    case 4:
                        buttonList[buttonPosition].Text = "Quit";
                        break;
                    default:
                        buttonList[buttonPosition].Text = "Button"+ buttonPosition;
                        break;
                }
                buttonList[buttonPosition].Tag = "Button"+ buttonPosition;
                buttonList[buttonPosition].Click += (sender, args) => ButtonClick(sender, args, buttonList[arrayIndex], textList, pathToList);
                Controls.Add(buttonList[buttonPosition]);
            }
        }

        //Checks if the file where album information is stored exists
        private bool FileExists(string pathToList)
        {
            //If the album storage file doesnt exist, create a file
            if (!File.Exists(pathToList))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //A function occurs depending on the tag of the button clicked
        private void ButtonClick(object sender, EventArgs e, Button buttonClicked, TextBox textList, string pathToList)
        {
            var albumMenuStatus = this;
            switch (buttonClicked.Tag.ToString())
            {
                //Searches For Artists
                case "Button0":
                    textList.AppendText(AlbumSorting.SearchArtistAccess(textList));
                    SaveAlbumText(AlbumSorting.SearchArtistAccess(textList), pathToList);
                    input = new Input(0,albumMenuStatus);
                    input.Show();
                    break;
                //Search For Albums
                case "Button1":
                    textList.AppendText(AlbumSorting.SearchAlbumAccess(textList));
                    SaveAlbumText(AlbumSorting.SearchAlbumAccess(textList), pathToList);
                    input = new Input(1, albumMenuStatus);
                    input.Show();                  
                    break;
                //Adds A New Album Into The Collection
                case "Button2":
                    textList.AppendText(AlbumSorting.AddAccess(textList));
                    SaveAlbumText(AlbumSorting.AddAccess(textList), pathToList);
                    input = new Input(2, albumMenuStatus);
                    input.Show();
                    break;
                //Remove An Album From The Collection
                case "Button3":
                    textList.AppendText(AlbumSorting.RemoveAccess(textList));
                    SaveAlbumText(AlbumSorting.RemoveAccess(textList), pathToList);
                    input = new Input(3, albumMenuStatus);
                    input.Show();
                    break;
                //Exits Program
                case "Button4":
                    Application.Exit();
                    break;
                //If the tag of the button doesn't match the above, show user there is no functionality
                default:
                    MessageBox.Show("Functionality Not Found!");
                    break;
            }
            this.Enabled = false;
        }

        //Loads the album text from within the stored file if it exists into the textbox on-screen
        private void LoadAlbumText(string pathToList)
        {
            try
            {
                //Open up a StreamReader to read through each line of the text file
                using (StreamReader streamRead = new StreamReader(pathToList))
                {
                    string line = streamRead.ReadToEnd();
                    textList.AppendText(line);
                }
            }
            catch (FileNotFoundException)
            {
                //If no file is found, create a new file and dispose of the stream               
                if (!File.Exists(pathToList))
                {
                    //Disposing the stream is needed since without doing so this causes conflicts when text is being written to the file after being created
                    File.Create(pathToList).Dispose();
                }
                else
                {
                    //Set the text within the file to be the text present within the textbox
                    textList.Text = File.ReadAllText(pathToList);
                }
            }
        }

        //Save the text within the textbox to the file storing album information
        private void SaveAlbumText(string inputText, string pathToList)
        {
            //If the file storing album information exists
            if (FileExists(pathToList))
            {
                //Write the information of the button clicked into the file
                //True is used to indicate appending to a file instead of overwriting
                using (StreamWriter streamWrite = new StreamWriter(pathToList, true))
                {
                    //Write line into album information file
                    streamWrite.WriteLine(inputText);
                }
            }
        }

        private void AlbumMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
