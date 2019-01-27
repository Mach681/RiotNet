﻿using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class LeagueTests : TestBase
    {
        string encryptedSummonerId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("Abou222");
            encryptedSummonerId = summoner.Id;
        }

        [Test]
        public async Task GetLeagueByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetLeagueByIdAsync("a681d5d0-430e-11e8-a82d-c81f66cf2333");

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeaguePositionsBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            List<LeaguePosition> leaguePositions = await client.GetLeaguePositionsBySummonerIdAsync(encryptedSummonerId);

            Assert.That(leaguePositions, Is.Not.Null);
            var leaguePosition = leaguePositions.First();
            Assert.That(leaguePosition.Position, Is.Not.Null.And.Not.Empty);
            Assert.That(leaguePosition.LeagueName, Is.Not.Null.And.Not.Empty);
            Assert.That(leaguePosition.Tier, Is.Not.EqualTo(Tier.CHALLENGER));
        }

        [Test]
        public async Task GetChallengerLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetChallengerLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.CHALLENGER));
        }

        [Test]
        public async Task GetGrandmasterLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetGrandmasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.GRANDMASTER));
        }

        [Test]
        public async Task GetMasterLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.MASTER));
        }

        [Test]
        public void DeserializeLeagueTest()
        {
            var league = JsonConvert.DeserializeObject<LeagueList>(Resources.SampleLeague, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(league);
        }
    }
}
