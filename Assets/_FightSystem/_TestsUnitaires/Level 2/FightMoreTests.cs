using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {


        [Test]
        public void TwoSpeedAreEquals()
        {
            Character pikachu = new Character(100, 50, 30, 200, TYPE.NORMAL);
            Character mewtwo = new Character(1000, 5000, 0, 200, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Punch p = new Punch();

            // if both pokemon have the same speed the second pokemon attack first so mewtwo attacks first,
            // oneshot pikachu, so pikachu doesn't attack
            f.ExecuteTurn(p, p);

            Assert.That(pikachu.IsAlive, Is.EqualTo(false));
            Assert.That(mewtwo.IsAlive, Is.EqualTo(true));
            Assert.That(mewtwo.CurrentHealth, Is.EqualTo(mewtwo.MaxHealth));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }
        [Test]
        public void NegativeAttack()
        {
            var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
            var punch = new Punch();
            var oldHealth = pikachu.CurrentHealth;

            Assert.Throws<ArgumentException>(() =>
            {
                pikachu.ReceiveAttack(punch, -50);
            });
        }
        public void NegativePower()
        {
            var pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
            var negativePowerSkill = new NegativePowerSkill();
            var oldHealth = pikachu.CurrentHealth;

            Assert.Throws<ArgumentException>(() =>
            {
                pikachu.ReceiveAttack(negativePowerSkill, 50);
            });
        }

        [Test]
        public void EquipementWithNegativeStats()
        {
            var pikachu = new Character(10, 50, 30, 20, TYPE.NORMAL);
            var shield = new Equipment(-20, 0, 10, 0);
            Assert.Throws<ArgumentException>(() =>
            {
                // Equip character
                pikachu.Equip(shield);
            });
        }
        [Test]
        public void CharacterConstructorWithNegativeStats()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var pikachu = new Character(-10, 50, 30, 20, TYPE.NORMAL);
            });
        }
        [Test]
        public void DmgWithTypePositiv()
        {
            Character pikachu = new Character(1000, 50, 0, 200, TYPE.WATER);
            Character mewtwo = new Character(1000, 10, 0, 200, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Punch p = new Punch();
            MagicalGrass grass = new MagicalGrass();
            // if both pokemon have the same speed the second pokemon attack first so mewtwo attacks first,
            // oneshot pikachu, so pikachu doesn't attack
            f.ExecuteTurn(p, grass);
            Assert.That(pikachu.CurrentHealth == 1000 - ((mewtwo.Attack + grass.Power) * 2));

        }

        [Test]
        public void DmgWithTypeNegativ()
        {
            Character pikachu = new Character(1000, 50, 0, 200, TYPE.FIRE);
            Character mewtwo = new Character(1000, 10, 0, 200, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Punch p = new Punch();
            MagicalGrass grass = new MagicalGrass();
            // if both pokemon have the same speed the second pokemon attack first so mewtwo attacks first,
            // oneshot pikachu, so pikachu doesn't attack
            f.ExecuteTurn(p, grass);
            Assert.That(pikachu.CurrentHealth == 1000 - ((mewtwo.Attack + grass.Power) * 0.5));

        }


        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer les TU sur le reste et de les implémenter

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type

    }
}
