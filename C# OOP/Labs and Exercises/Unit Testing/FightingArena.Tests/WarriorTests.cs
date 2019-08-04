using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 10, 20);
        }

        [Test]
        public void Constructor_Initialize_Properly()
        {
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void Poperties_Initalize_Correctly()
        {
            Assert.AreEqual("Pesho", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(20, warrior.HP);
        }

        [Test]
        public void Test_Name_Property_Exception()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("", 10, 20));
        }

        [Test]
        public void Test_Damage_Property_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", 0, 20));
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", -1, 20));
        }

        [Test]
        public void Test_HP_Property_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("Pesho", 10, -20));
        }

        [Test]
        public void Attack_Throws_Min_HP_Exception()
        {
            warrior = new Warrior("Pesho", 10, 20);
            Warrior otherWarrior = new Warrior("Ivan", 10, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(otherWarrior));
        }

        [Test]
        public void Attack_Throws_Min_HP_Exception_For_Other_Warrior()
        {
            warrior = new Warrior("Pesho", 10, 40);
            Warrior otherWarrior = new Warrior("Ivan", 10, 20);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(otherWarrior));
        }

        [Test]
        public void Attack_Throws_Min_HP_Exception_For_Other_Warrior_Damage()
        {
            warrior = new Warrior("Pesho", 10, 40);
            Warrior otherWarrior = new Warrior("Ivan", 100, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(otherWarrior));
        }

        [Test]
        public void Attack_Method_Reduces_HP_Properly()
        {
            warrior = new Warrior("Pesho", 10, 40);
            Warrior otherWarrior = new Warrior("Ivan", 10, 40);

            var expected = 30;
            warrior.Attack(otherWarrior);

            Assert.AreEqual(expected, warrior.HP);
            Assert.AreEqual(expected, otherWarrior.HP);
        }

        [Test]
        public void Attack_Method_Reduces_HP_Properly_When_Dead()
        {
            warrior = new Warrior("Pesho", 50, 40);
            Warrior otherWarrior = new Warrior("Ivan", 10, 40);

            warrior.Attack(otherWarrior);

            Assert.AreEqual(0, otherWarrior.HP);
        }
    }
}