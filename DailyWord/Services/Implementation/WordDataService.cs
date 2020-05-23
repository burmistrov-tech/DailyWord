using DailyWord.Models;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyWord.Services
{
    public class WordDataService<T> : IWordDataService<T> where T : IWordModel
    {
        public WordDataService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            collection = database.GetCollection<T>(settings.CollectionName);
        }
        private readonly IMongoCollection<T> collection;
        public void Insert(T model) =>
            collection.InsertOne(model);

        public Tuple<string, long> GetMostPopularWord()
        {
            // Not implementation yet
            return new Tuple<string, long>("child", 237);
        }

        public Tuple<string, long> GetUserWord(string word) =>
            new Tuple<string, long>(word, 
                collection.CountDocuments(Builders<T>.Filter.Where(m => m.Value == word)));

        public Dictionary<string, long> GetSimilarWords(string word)
        {
            var similarWords = collection.Find(m => m.Value.Length == word.Length 
            && m.Value != word 
            && CheckMathes(word, m.Value)).Limit(3);
            var result = new Dictionary<string, long>();
            similarWords.ForEachAsync(m => result.Add(m.Value, collection.CountDocuments(x => x.Value == m.Value)));
            return result;
        }
        protected bool CheckMathes(string x, string y)
        {
            for (int i = 0, notMatch = 0; i < x.Length; i++)
                if (x[i] != y[i])
                    if (notMatch > 0)
                        return false;
                    else
                        notMatch++;                    
            
            return true;
        }
    }
}
