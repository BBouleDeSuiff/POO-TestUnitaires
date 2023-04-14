﻿
using System;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        public Fight(Character character1, Character character2)
        {
            if (character1 == null || character2 == null)
                throw new ArgumentNullException("character 1 ou 2 null");

            Character1 = character1;
            Character2 = character2;


            if(Character1.CurrentHealth == 0 )
                IsFightFinished = true;
            else if (Character2.CurrentHealth == 0)
                IsFightFinished = true;
            else
                IsFightFinished = false;



        }

        public Character Character1 { get; }
        public Character Character2 { get; }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished { get; protected set; }

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            if (skillFromCharacter1 == null || skillFromCharacter2 == null)
                throw new ArgumentNullException("un des deux skill est null");

            if(Character1.Speed > Character2.Speed)
            {

                if (skillFromCharacter1.Type == TYPE.HEAL)
                {
                    Character1.Heal(skillFromCharacter1.Power);
                }
                else
                    Character2.ReceiveAttack(skillFromCharacter1, Character1.Attack);

                if (Character2.IsAlive)
                {
                    if (skillFromCharacter2.Type == TYPE.HEAL)
                    {
                        Character1.Heal(skillFromCharacter2.Power);
                    }
                    else
                        Character1.ReceiveAttack(skillFromCharacter2, Character2.Attack);

                }
                else
                    IsFightFinished = true;
            }
            else
            {
                if (skillFromCharacter2.Type == TYPE.HEAL)
                {
                    Character1.Heal(skillFromCharacter2.Power);
                }
                else
                    Character1.ReceiveAttack(skillFromCharacter2, Character2.Attack);

                if (Character1.IsAlive)
                {
                    if (skillFromCharacter1.Type == TYPE.HEAL)
                    {
                        Character1.Heal(skillFromCharacter1.Power);
                    }
                    else
                        Character2.ReceiveAttack(skillFromCharacter1, Character1.Attack);

                }
                else
                    IsFightFinished = true;
            }
        }

    }
}
