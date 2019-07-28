namespace OnlineRadioDataBaseEdited
{
    using Exceptions;
    public class Song
    {
        private string artistName;
        private string songName;
        private string songDuration;

        public Song(string artistName, string songName, string songDuration)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongDuration = songDuration;
        }

        public string ArtistName
        {
            get => artistName;

            private set
            {
                if(value.Length<3 | value.Length>20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artistName = value;
            }
        }
        public string SongName
        {
            get => songName;

            private set
            {
                if(value.Length<3 || value.Length>30)
                {
                    throw new InvalidSongNameException();
                }
            }
        }
        public string SongDuration
        {
            get => songDuration;

            private set
            {
                string[] songArgs = value.Split(":");

                if(songArgs.Length!=2)
                {
                    throw new InvalidSongLengthException();
                }
                if(!(int.TryParse(songArgs[0], out int minutes) && int.TryParse(songArgs[1], out int seconds)))
                {
                    throw new InvalidSongLengthException();
                }

                ValidateDuration(minutes, seconds);
            }

        }

        public int SongMinutes { get;private set; }
        public int SongSeconds { get;private set; }

        private void ValidateDuration(int minutes, int seconds)
        {
            if(minutes<0 || minutes>14)
            {
                throw new InvalidSongMinutesException();
            }

            if(seconds<0 || seconds>59)
            {
                throw new InvalidSongSecondsException();
            }

            this.SongMinutes = minutes;
            this.SongSeconds = seconds;
        }
    }
}
