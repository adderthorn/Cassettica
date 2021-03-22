using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Cassettica.Models.Library;

namespace Cassettica.Library
{
    public class MusicLibrary : IMusicLibrary
    {
        private static readonly string[] AudioExtensions = 
            {".3gp",".aa",".aac",".aax",".act",".aiff",".alac",
            ".amr",".ape",".au",".awb",".dct",".dss",".dvf",".flac",
            ".gsm",".iklax",".ivs",".m4a",".m4b",".m4p",".mmf",
            ".mp3",".mpc",".msv",".nmf",".ogg",".oga",".mogg",
            ".opus",".ra",".rm",".raw",".rf64",".sln",".tta",
            ".voc",".vox",".wav",".wma",".wv",".webm",".8svx",".cda"};

        public IEnumerable<Song> Songs { get; private set; }
        public IEnumerable<string> Artists { get; private set; }
        public IEnumerable<string> Albums { get; private set; }

        public MusicLibrary()
        {
            const string PathToSongs = @"D:\Music\LSD\LABRINTH, SIA & DIPLO PRESENT... LSD\MP3";
            var songList = new List<Song>();
            for (int i = 0; i < AudioExtensions.Length; i++)
            {
                string[] files = Directory.GetFiles(PathToSongs, "*" + AudioExtensions[i], SearchOption.AllDirectories);
                for (int j = 0; j < files.Length; j++)
                {
                    var tFile = TagLib.File.Create(files[j]);
                    string title = tFile.Tag.Title;
                    string artistName = tFile.Tag.FirstPerformer;
                    string album = tFile.Tag.Album;
                    string albumArtist = tFile.Tag.FirstAlbumArtist;
                    uint track = tFile.Tag.Track;
                    string genre = tFile.Tag.FirstGenre;
                    uint releaseYear = tFile.Tag.Year;

                    Song song = new Song()
                    {
                        Track = track,
                        Title = title,
                        Artist = artistName,
                        Album = album,
                        AlbumArtist = albumArtist,
                        Genre = genre,
                        ReleaseYear = releaseYear,
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                        Path = files[j],
                        Guid = j.ToString()
                    };
                    songList.Add(song);
                }
            }
            setSongs(songList);
        }

        private void setSongs(IEnumerable<Song> songs)
        {
            Songs = songs;
            Artists = songs.Select(s => s.Artist).Distinct();
            Albums = songs.Select(s => s.Album).Distinct();
        }
    }
}