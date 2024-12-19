namespace std
{
    internal class Song
    {
        public string name { get; private set; }
        public string author { get; private set; }
        public Song? prev { get; private set; }

        public Song()
        {
            this.name = "";
            this.author = "";
            this.prev = null;
        }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = null;
        }

        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Song otherSong)
            {
                return (name == otherSong.name && author == otherSong.author);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }
    }
}