using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumOrganisation
{
    static class AlbumSorting
    {       
        static public void SearchArtistAccess()
        {
            SearchArtist();
        }

        static private void SearchArtist()
        {
            MessageBox.Show("Search Artist");
        }

        static public void SearchAlbumAccess()
        {
            SearchAlbum();
        }

        static private void SearchAlbum()
        {
            MessageBox.Show("Search Album");
        }

        static public void AddAccess()
        {
            AddAlbum();
        }

        static private void AddAlbum()
        {
            MessageBox.Show("Add Album");
        }

        static public void RemoveAccess()
        {
            RemoveAlbum();
        }

        static private void RemoveAlbum()
        {
            MessageBox.Show("Remove Album");
        }
    }
}
