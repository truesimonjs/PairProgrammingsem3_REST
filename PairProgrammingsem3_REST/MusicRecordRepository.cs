namespace PairProgrammingsem3_REST
{
    public class MusicRecordRepository : IMusicRecordRepository
    {
        private List<MusicRecordModel> records = new();
        public void AddTestData()
        {
            records.Add(new MusicRecordModel("Test entry1", "testauthor1", 10, 2003));
            records.Add(new MusicRecordModel("Test entry2", "testauthor2", 10, 2004));
        }

        public List<MusicRecordModel> GetAll(string title = null, string artist = null)
        {
            List<MusicRecordModel> filteredMusicRecords = new List<MusicRecordModel>(records);
            if (title != null)
            {
                filteredMusicRecords = new List<MusicRecordModel>(filteredMusicRecords.Where(book => book.Title.ToLower().StartsWith(title.ToLower())));
            }
            if (artist != null)
            {
                filteredMusicRecords = new List<MusicRecordModel>(filteredMusicRecords.Where(book => book.Artist.ToLower().StartsWith(artist.ToLower())));
            }
            return filteredMusicRecords;
        }

        public MusicRecordModel Add(MusicRecordModel musicRecord)
        {
            records.Add(musicRecord);
            return musicRecord;

        }
    }
}
