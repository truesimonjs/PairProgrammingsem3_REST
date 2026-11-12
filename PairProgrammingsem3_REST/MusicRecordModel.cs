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

        public MusicRecordModel (string title = "test_title", string artist = "test_artist",int durationInSeconds = 10,int publicationYear = 2000)
        {
            this.Title = title;
            this.Artist = artist;
            this.DurationInSeconds = durationInSeconds;
            this.PublicationYear = publicationYear;
        }



    }
}
