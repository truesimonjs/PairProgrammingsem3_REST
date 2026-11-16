namespace PairProgrammingsem3_REST
{
    public interface IMusicRecordRepository
    {
        public  List<MusicRecordModel> GetAll(string title, string artist);

        public MusicRecordModel Add(MusicRecordModel musicRecord);
    }
}
