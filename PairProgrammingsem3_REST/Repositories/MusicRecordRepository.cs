using PairProgrammingsem3_REST.Interfaces;

namespace PairProgrammingsem3_REST.Repositories
{
    public class MusicRecordRepository : IMusicRecordRepository
    {
        private List<MusicRecordModel> records = new();
        public void AddTestData()
        {
            records.Add(new MusicRecordModel("Test entry1", "testauthor1", 10, 2003));
            records.Add(new MusicRecordModel("Test entry2", "testauthor2", 10, 2004));
        }
        public List<MusicRecordModel> GetAll()
        {
            return new List<MusicRecordModel>(records);
        }

        public List<MusicRecordModel> GetAll(string title = null, string artist = null)
        {
            List<MusicRecordModel> filteredMusicRecords = new List<MusicRecordModel>(records); 
           if (title != null)
            {
                filteredMusicRecords = new List<MusicRecordModel>(filteredMusicRecords.Where(entry => entry.Title.ToLower().StartsWith(title.ToLower())));
            }
            if (artist != null)
            {
                filteredMusicRecords = new List<MusicRecordModel>(filteredMusicRecords.Where(entry => entry.Artist.ToLower().StartsWith(artist.ToLower())));
            }
            return filteredMusicRecords;
        }

        public MusicRecordModel Add(MusicRecordModel musicRecord)
        {
            musicRecord.Id = GetNextId();
            records.Add(musicRecord);
            return musicRecord;

        }
        public int Create (MusicRecordModel musicRecord)
        {
            musicRecord.Id = GetNextId();
            records.Add(musicRecord);
            return 1;
        }
        private int nextId = 0;
        private int GetNextId()
        {
            int returnedId = nextId;
            nextId++;
            return returnedId;
        }

      

        public MusicRecordModel Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
