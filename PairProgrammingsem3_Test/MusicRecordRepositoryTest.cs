using PairProgrammingsem3_REST;
using System.ComponentModel.DataAnnotations;

namespace PairProgrammingsem3_Test
{
    [TestClass]
    public sealed class MusicRecordRepositoryTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            MusicRecordRepository musicRecordRepository = new MusicRecordRepository();
            Assert.IsEmpty(musicRecordRepository.GetAll());
            const int Length = 5;

            for (int i = 0; i < Length; i++)
            {
                musicRecordRepository.Add(new MusicRecordModel());
            }
            Assert.HasCount(Length, musicRecordRepository.GetAll());
        }
    }
}
