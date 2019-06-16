/*
 * Main functionality of program held here, including actions such as searches/adding/removing albums from the collection
 */ 

//Including appropriate libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumOrganisation
{
    //Functions such as Adding/Removing/Searching held here
    static class AlbumSorting
    {       
        static public string SearchArtistAccess(TextBox textList)
        {
            return SearchArtist(textList);
        }

        static private string SearchArtist(TextBox textList)
        {
            return "Search Artist!\n";
        }

        static public string SearchAlbumAccess(TextBox textList)
        {
            return SearchAlbum(textList);
        }

        static private string SearchAlbum(TextBox textList)
        {
            return "Search Album!\n";
        }

        static public string AddAccess(TextBox textList)
        {
            return AddAlbum(textList);
        }

        static private string AddAlbum(TextBox textList)
        {
            return "Add Album!\n";
        }

        static public string RemoveAccess(TextBox textList)
        {
            return RemoveAlbum(textList);
        }

        static private string RemoveAlbum(TextBox textList)
        {
            return "Remove Album!\n";
        }
    }
}
