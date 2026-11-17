namespace PairProgrammingsem3_REST.Interfaces
{
    public interface IRepository<T> where T : IHasId
    {
        List<T> GetAll();
        int Create(T entity);

        T Read(int id);

        /// <summary>
        /// Return true if element was deleted
        /// </summary>

        bool Delete(int id);
    }
    public interface IMusicRecordRepository : IRepository<MusicRecordModel>
    {
        public List<MusicRecordModel> GetAll(string title, string artist);

        public MusicRecordModel Add(MusicRecordModel musicRecord);
    }
}
