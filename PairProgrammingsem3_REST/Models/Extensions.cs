using PairProgrammingsem3_REST.Interfaces;

namespace PairProgrammingsem3_REST.Models
{
    public partial class MusicRecord : IHasId
    {
       

        public MusicRecord(string title = "test_title", string artist = "test_artist", int? durationInSeconds = 10, int? publicationYear = 2000)
        {
            this.Title = title;
            this.Artist = artist;
            this.DurationInSeconds = durationInSeconds;
            this.PublicationYear = publicationYear;
        }



    }
}
