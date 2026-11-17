using PairProgrammingsem3_REST.Interfaces;
using PairProgrammingsem3_REST.Models;


namespace PairProgrammingsem3_REST.Repositories
{
    public class EFCMusicRecordRepository : EFCRepositoryBase<MusicRecord, simonjs_dk_db_PrimaryContext>, IMusicRecordRepository
    {
        public MusicRecord Add(MusicRecord musicRecord)
        {
            int id = Create(musicRecord);
            return Read(id);
        }

        public List<MusicRecord> GetAll(string title, string artist)
        {
            List<MusicRecord> filteredMusicRecords = new List<MusicRecord>(GetAll());
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
    }
}
