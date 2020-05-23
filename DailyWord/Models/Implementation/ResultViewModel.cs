using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyWord.Models
{
    public class ResultViewModel
    {
        public Tuple<string, long> MostPopularWord { get; set; }
        public Tuple<string, long>? UserWord { get; set; }
        public Dictionary<string, long> SimilarWords { get; set; }

    }
}
