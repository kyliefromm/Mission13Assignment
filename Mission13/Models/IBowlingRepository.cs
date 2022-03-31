using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowl> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void SaveBowl(Bowl b);
        public void CreateBowl(Bowl b);
        public void DeleteBowl(Bowl b);
    }
}

