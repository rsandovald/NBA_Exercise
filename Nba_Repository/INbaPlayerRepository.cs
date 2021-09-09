using NBA_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA_Repository
{
    public interface INbaPlayerRepository
    {
         Task<List<NBA_Player>>  getNbaPlayers(); 
    }
}
