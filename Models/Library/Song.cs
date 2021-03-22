using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cassettica.Models.Library
{
    [DataContract]
    public class Song
    {
        [DataMember]
        public string Guid { get; set; }

        public string Path { get; set;}
        [DataMember]
        public uint Track { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public string ArtistFriendlyName => getFriendlyName(Artist);

        [DataMember]
        public string Album { get; set; }

        [DataMember]
        public string AlbumFriendlyName => getFriendlyName(Album);

        [DataMember]
        public string AlbumArtist { get; set; }

        [DataMember]
        public string AlbumArtistFriendlyName => getFriendlyName(AlbumArtist);

        [DataMember]
        public uint ReleaseYear { get; set; }
        public string Genre { get; set; }

        [DataMember]
        public string GenreFriendlyName => getFriendlyName(Genre);
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        private string getFriendlyName(string name)
        {
            if (name == null)
                return string.Empty;
            return string.Join('-', name.ToLower().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
