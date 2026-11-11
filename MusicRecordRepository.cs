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

        public List<MusicRecordModel> GetAll()
        {
            return new List<MusicRecordModel>(records);
        }
    }
}
