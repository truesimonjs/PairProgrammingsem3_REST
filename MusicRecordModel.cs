using System.Reflection;

namespace PairProgrammingsem3_REST
{
    public class MusicRecordModel
    {
        public int id { get; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int DurationInSeconds { get; set; }

        public int PublicationYear { get; set; }

        public MusicRecordModel (string title, string artist,int durationInSeconds,int publicationYear)
        {
            this.Title = title;
            this.Artist = artist;
            this.DurationInSeconds = durationInSeconds;
            this.PublicationYear = publicationYear;
        }



    }
}
