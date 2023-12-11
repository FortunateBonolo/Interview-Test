using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHero
    {
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats { get; set; }
        void evolve(int statIncrease);
    }

    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }

        public void evolve(int statIncrease = 5)
        {
            foreach (var stat in stats)
            {
                int originalValue = stat.Value;
                int increaseValue = originalValue / 2 * statIncrease;
                stat.Value += increaseValue;
            }
        }
    }
}


