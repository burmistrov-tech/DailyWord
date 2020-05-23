using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyWord.Services
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
