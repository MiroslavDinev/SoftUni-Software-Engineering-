using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Pesho", 10, 40);
        }

        [Test]
        public void Constructor_Initialize_Properly()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void Test_Count_Works_Properly()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Warrior_Property_Works_Correctly()
        {
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Warriors.Count);
        }

        [Test]
        public void Test_Enroll_Works_Properly()
        {
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_Enroll_Throws_Exception()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Test_Fight_Method_Works_Properly()
        {
            arena.Enroll(warrior);

            Warrior otherWarrior = new Warrior("Ivan", 20, 40);

            arena.Enroll(otherWarrior);

            arena.Fight(warrior.Name, otherWarrior.Name);

            Assert.AreEqual(20, warrior.HP);
            Assert.AreEqual(30, otherWarrior.HP);
        }

        [Test]
        public void Test_Fight_Method_Throws_Exception_For_Attacker()
        {
            arena.Enroll(warrior);

            Warrior otherWarrior = new Warrior("Ivan", 20, 40);

            arena.Enroll(otherWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gosho", "Ivan"));
        }

        [Test]
        public void Test_Fight_Method_Throws_Exception_For_Defender()
        {
            arena.Enroll(warrior);

            Warrior otherWarrior = new Warrior("Ivan", 20, 40);

            arena.Enroll(otherWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Gosho"));
        }
    }
}
