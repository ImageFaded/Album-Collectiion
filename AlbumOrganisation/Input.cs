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
        public Input(int appearance, AlbumMenu status)
        {
            InitializeComponent();
            LayoutBox(appearance,status);
        }

        private void LayoutBox(int numcase, AlbumMenu status)
        {
            Size = new Size(300, 300);
            switch (numcase)
            {
                case 0:
                    SearchArtistLayout(status);
                    break;
                case 1:
                    SearchAlbumLayout(status);
                    break;
                case 2:
                    AddAlbumLayout(status);
                    break;
                case 3:
                    RemoveAlbumLayout(status);
                    break;
                default:
                    //Nothing so far!
                    break;
            }
        }

        private void SearchArtistLayout(AlbumMenu status)
        {
            Text = "Search Artist";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Search Artist";
            button.Click += (sender,e) => React(status);
            Controls.Add(button);

            TextBox artistInput = new TextBox();
            artistInput.SetBounds(65, 100, 150, 20);
            //artistInput.Multiline = true;
            artistInput.Tag = "ArtistInput";
            Controls.Add(artistInput);
            MessageBox.Show("Search Artist!");       
        }

        private void SearchAlbumLayout(AlbumMenu status)
        {
            Text = "Search Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Search Album";
            button.Click += (sender, e) => React(status);
            Controls.Add(button);

            TextBox albumInput = new TextBox();
            albumInput.SetBounds(65, 100, 150, 20);
            //artistInput.Multiline = true;
            albumInput.Tag = "AlbumInput";
            Controls.Add(button);
            MessageBox.Show("Search Album!");
        }

        private void AddAlbumLayout(AlbumMenu status)
        {
            Text = "Search Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Search Album";
            button.Click += (sender, e) => React(status);
            Controls.Add(button);

            TextBox[] addAlbumInput = new TextBox[2];
            for(int i = 0; i < 2; i++)
            {
                addAlbumInput[i] = new TextBox();
                addAlbumInput[i].SetBounds(90, 45 * (i + 1), 100, 40);
                addAlbumInput[i].Tag = "AddAlbumInput" + i;
                Controls.Add(addAlbumInput[i]);
            }
            MessageBox.Show("Add Album!");
        }

        private void RemoveAlbumLayout(AlbumMenu status)
        {
            Text = "Remove Album";
            Button button = new Button();
            button.SetBounds(90, 180, 100, 40);
            button.Text = "Remove Album";
            button.Click += (sender, e) => React(status);
            Controls.Add(button);

            TextBox[] removeAlbumInput = new TextBox[2];
            for (int i = 0; i < 2; i++)
            {
                removeAlbumInput[i] = new TextBox();
                removeAlbumInput[i].SetBounds(90, 45 * (i + 1), 100, 40);
                removeAlbumInput[i].Tag = "RemoveAlbumInput" + i;
                Controls.Add(removeAlbumInput[i]);
            }
            MessageBox.Show("Remove Album!");
        }

        private bool React(AlbumMenu status)
        {
            Close();
            status.TopMost = true;
            return status.Enabled = true;
        }
    }
}
