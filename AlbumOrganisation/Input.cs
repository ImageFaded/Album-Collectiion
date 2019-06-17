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
    public partial class Input : Form
    {
        public Input(int appearance, AlbumMenu status, string pathToList)
        {
            InitializeComponent();
            LayoutBox(appearance,status, pathToList);
        }

        private void LayoutBox(int numcase, AlbumMenu status, string pathToList)
        {
            Size = new Size(300, 300);
            switch (numcase)
            {
                case 0:
                    SearchArtistLayout(status,pathToList);
                    break;
                case 1:
                    SearchAlbumLayout(status, pathToList);
                    break;
                case 2:
                    AddAlbumLayout(status, pathToList);
                    break;
                case 3:
                    RemoveAlbumLayout(status, pathToList);
                    break;
                default:
                    //Nothing so far!
                    break;
            }
        }

        private void SearchArtistLayout(AlbumMenu status, string pathToList)
        {
            TextBox artistInput = new TextBox();
            artistInput.SetBounds(65, 100, 150, 20);
            //artistInput.Multiline = true;
            artistInput.Tag = "ArtistInput";
            Controls.Add(artistInput);

            Text = "Search Artist";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Search Artist";
            button.Click += (sender, e) => React(status, artistInput, null, 0, pathToList);
            Controls.Add(button);

            MessageBox.Show("Search Artist!");       
        }

        private void SearchAlbumLayout(AlbumMenu status, string pathToList)
        {
            TextBox albumInput = new TextBox();
            albumInput.SetBounds(65, 100, 150, 20);
            //artistInput.Multiline = true;
            albumInput.Tag = "AlbumInput";
            Controls.Add(albumInput);

            Text = "Search Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Search Album";
            button.Click += (sender, e) => React(status, albumInput, null, 0, pathToList);
            Controls.Add(button);
            MessageBox.Show("Search Album!");
        }

        private void AddAlbumLayout(AlbumMenu status, string pathToList)
        {
            TextBox[] addAlbumInput = new TextBox[2];
            for(int i = 0; i < 2; i++)
            {
                addAlbumInput[i] = new TextBox();
                addAlbumInput[i].SetBounds(90, 45 * (i + 1), 100, 40);
                addAlbumInput[i].Tag = "AddAlbumInput" + i;
                Controls.Add(addAlbumInput[i]);
            }

            Text = "Add Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Add Album";
            button.Click += (sender, e) => React(status,addAlbumInput[0],addAlbumInput[1],1,pathToList);
            Controls.Add(button);

            //MessageBox.Show("Add Album!");
        }

        private void RemoveAlbumLayout(AlbumMenu status, string pathToList)
        {
            TextBox[] removeAlbumInput = new TextBox[2];
            for (int i = 0; i < 2; i++)
            {
                removeAlbumInput[i] = new TextBox();
                removeAlbumInput[i].SetBounds(90, 45 * (i + 1), 100, 40);
                removeAlbumInput[i].Tag = "RemoveAlbumInput" + i;
                Controls.Add(removeAlbumInput[i]);
            }

            Text = "Remove Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Remove Album";
            button.Click += (sender, e) => React(status,removeAlbumInput[0],removeAlbumInput[1],1,pathToList);
            Controls.Add(button);

            MessageBox.Show("Remove Album!");
        }

        private bool React(AlbumMenu status, TextBox inputOne, TextBox inputTwo, int type, string pathToList)
        {
            switch (type)
            {
                case 0:
                    break;
                case 1:
                    //Add Album
                    if(inputOne.Text.ToString() == "" || inputTwo.Text.ToString() == "")
                    {
                        MessageBox.Show("Incomplete Parameter!");                      
                        break;
                    }
                    else
                    {
                        //Do Thing
                        AlbumMenu.SaveTextAccess(inputOne.Text.ToString(), inputTwo.Text.ToString(), pathToList);
                        Close();
                        status.TopMost = true;
                        return status.Enabled = true;
                    }
                default:
                    break;
            }
            return false;
        }
    }
}
