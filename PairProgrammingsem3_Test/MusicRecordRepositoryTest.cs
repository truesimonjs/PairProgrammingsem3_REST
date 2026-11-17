using PairProgrammingsem3_REST;
using PairProgrammingsem3_REST.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using PairProgrammingsem3_REST.Models;

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
            const int Length = 7;

            string title = "";
            string artist = "";

            for (int i = 0; i < Length; i++)
            {
                title += "a";
                artist += "b";
                musicRecordRepository.Add(new MusicRecord(title, artist));
            }
            Assert.HasCount(Length, musicRecordRepository.GetAll());

            var result = musicRecordRepository.GetAll("aaa", null);
            foreach (var record in result)
            {
                System.Diagnostics.Debug.WriteLine($"  -> Title: '{record.Title}', Artist: '{record.Artist}'");
            }
            Assert.HasCount(Length - 2, musicRecordRepository.GetAll("aaa"));
            Assert.HasCount(Length - 1, musicRecordRepository.GetAll(null, "bb"));
            Assert.HasCount(Length - 2, musicRecordRepository.GetAll("aa", "bbb"));
        }
    }
}
