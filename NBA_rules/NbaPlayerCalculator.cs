using NBA_Entities;
using NBA_Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NBA_BusinessRules
{
    public class NbaPlayerCalculator
    {       
        private INbaPlayerRepository _repository;       

        public NbaPlayerCalculator(INbaPlayerRepository repository)
        {
            this._repository = repository; 
        }     

        public async Task <List <Tuple<NBA_Player, NBA_Player>>>  getPairsOfPlayers(int targetHeight)
        {
            int heightToSeek;
            List <Tuple <NBA_Player, NBA_Player>> result= new List<Tuple<NBA_Player, NBA_Player>> ();
            List<NBA_Player> listNbaPlayers = await this._repository.getNbaPlayers (); 
            List<NBA_Player> auxiliarList = new List<NBA_Player> ();           
            
            if (targetHeight==  0 )
            {
                throw new System.Exception("Input parameter must be greather than 0"); 
            }

            while  (listNbaPlayers.Count > 0)
            {
                NBA_Player player1 = listNbaPlayers[0]; 
                listNbaPlayers.Remove(player1);
                if (player1.h_in >= targetHeight)
                {
                    continue;
                }
                heightToSeek = targetHeight - player1.h_in;
                auxiliarList.Clear();
                auxiliarList = listNbaPlayers.FindAll(p => p.h_in == heightToSeek);
                
                foreach (NBA_Player player2 in auxiliarList)
                {
                    result.Add(new Tuple <NBA_Player, NBA_Player> (player1, player2)) ; 
                }
            }                         
            return result; 
        }

    }
}
