using NBA_BusinessRules;
using NBA_Entities;
using NBA_Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA_NUnitTestProject
{
    public class Test_NBA_BusinessRules
    {
        NbaPlayerRepositoryMemory repository;
        NbaPlayerCalculator businessRules;

        [SetUp]
        public void Setup()
        {
            this.repository = new NbaPlayerRepositoryMemory();
            this.businessRules = new NbaPlayerCalculator(this.repository);
            this.repository.ListNbaPlayer = new List<NBA_Player>();            
            this.repository.ListNbaPlayer.Clear();
            this.repository.ListNbaPlayer.Add(new NBA_Player("A", 80));
            this.repository.ListNbaPlayer.Add(new NBA_Player("B", 80));
            this.repository.ListNbaPlayer.Add(new NBA_Player("C", 80));
            this.repository.ListNbaPlayer.Add(new NBA_Player("D", 65));
            this.repository.ListNbaPlayer.Add(new NBA_Player("E", 95));
        }               

        [Test]
        public async Task  TestFindPairs()
        {
            List<Tuple<NBA_Player, NBA_Player>> result;
            result = await this.businessRules.getPairsOfPlayers(160);
            Assert.IsTrue(result.Count == 4);            
        }

        [Test]
        public async Task TestNoFindPairs()
        {            
            List<Tuple<NBA_Player, NBA_Player>> result;
            result = await this.businessRules.getPairsOfPlayers(200);
            Assert.IsTrue(result.Count == 0 );
        }

    }
}