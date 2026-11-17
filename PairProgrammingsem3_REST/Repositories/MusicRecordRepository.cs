using PairProgrammingsem3_REST.Interfaces;
using PairProgrammingsem3_REST.Models;
namespace PairProgrammingsem3_REST.Repositories
{
    public class MusicRecordRepository : IMusicRecordRepository
    {
        private List<MusicRecord> records = new();
        public void AddTestData()
        {
            records.Add(new MusicRecord("Test entry1", "testauthor1", 10, 2003));
            records.Add(new MusicRecord("Test entry2", "testauthor2", 10, 2004));
        }
        public List<MusicRecord> GetAll()
        {
            return new List<MusicRecord>(records);
        }

        public List<MusicRecord> GetAll(string title = null, string artist = null)
        {
            List<MusicRecord> filteredMusicRecords = new List<MusicRecord>(records); 
           if (title != null)
            {
                filteredMusicRecords = new List<MusicRecord>(filteredMusicRecords.Where(entry => entry.Title.ToLower().StartsWith(title.ToLower())));
            }
            if (artist != null)
            {
                filteredMusicRecords = new List<MusicRecord>(filteredMusicRecords.Where(entry => entry.Artist.ToLower().StartsWith(artist.ToLower())));
            }
            return filteredMusicRecords;
        }

        public MusicRecord Add(MusicRecord musicRecord)
        {
            musicRecord.Id = GetNextId();
            records.Add(musicRecord);
            return musicRecord;

        }
        public int Create (MusicRecord musicRecord)
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

      

        public MusicRecord Read(int id)
        {
            return records.Where(entry => entry.Id == id).FirstOrDefault();
        }

        public bool Delete(int id)
        {
           return records.Remove(Read(id));
        }
    }
}
