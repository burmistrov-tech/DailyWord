using DailyWord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyWord.Services
{
    public interface IWordDataService<T> where T : IWordModel
    {
        public void Insert(T model);
        public Tuple<string, long> GetMostPopularWord();
        public Tuple<string, long> GetUserWord(string word);
        public Dictionary<string, long> GetSimilarWords(string word);
    }
}
