using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NBA_Entities;


namespace NBA_Repository
{
    public class NbaPlayerRepositoryMemory : INbaPlayerRepository
    {
        List<NBA_Player> _listNbaPlayer;
        public NbaPlayerRepositoryMemory()
        {

        }
        public NbaPlayerRepositoryMemory(List<NBA_Player> listNbaPlayer)
        {
            this.ListNbaPlayer = listNbaPlayer; 
        }

        public List<NBA_Player> ListNbaPlayer { get => _listNbaPlayer; set => _listNbaPlayer = value; }

        public async Task <List<NBA_Player>> getNbaPlayers()
        {
            return this.ListNbaPlayer; 
        }
    }
}
