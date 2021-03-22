using System;
using System.Collections.Generic;
using Cassettica.Models.Library;

namespace Cassettica.Library
{
    public interface IMusicLibrary
    {
        public IEnumerable<Song> Songs { get; }
        public IEnumerable<string> Artists { get; }
        public IEnumerable<string> Albums { get; }
    }
}