namespace PairProgrammingsem3_REST
{
    public interface IMusicRecordRepository
    {
        public  List<MusicRecordModel> GetAll();

        public MusicRecordModel Add(MusicRecordModel musicRecord);
    }
}
