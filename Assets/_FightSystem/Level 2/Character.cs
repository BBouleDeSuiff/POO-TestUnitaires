using System;
using System.Diagnostics;
using UnityEngine.Assertions;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            CurrentHealth = MaxHealth;
            if (_baseHealth < 0 || _baseAttack < 0 || _baseDefense < 0 || _baseSpeed < 0)
                throw new ArgumentException();
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get => _baseHealth;
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get =>_baseAttack;
            
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get => _baseDefense;
            
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get => _baseSpeed;
            
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive => CurrentHealth > 0;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s, int attack)
        {
            
            if (attack < 0 || s.Power <0)
                throw new ArgumentException();
            if ((s.Type == TYPE.FIRE && this.BaseType == TYPE.WATER) || (s.Type == TYPE.WATER && this.BaseType == TYPE.GRASS) || (s.Type == TYPE.GRASS && this.BaseType == TYPE.FIRE))
            {
                int damage = (int)((s.Power + attack) * 0.5f) - Defense;
                if (damage >= 0)
                    CurrentHealth -= damage;
            }
            else if ((s.Type == TYPE.FIRE && this.BaseType == TYPE.GRASS) || (s.Type == TYPE.WATER && this.BaseType == TYPE.FIRE) || (s.Type == TYPE.GRASS && this.BaseType == TYPE.WATER))
            {
                int damage = (s.Power + attack) * 2 - Defense;
                if (damage >= 0)
                    CurrentHealth -= damage;
            }
            else
            {
                int damage = (s.Power + attack) - Defense;
                if (damage >= 0)
                    CurrentHealth -= damage;
            }
            if(CurrentHealth < 0)
                CurrentHealth = 0;
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if(newEquipment!= null)
            {
                CurrentEquipment = newEquipment;
                _baseHealth += CurrentEquipment.BonusHealth;
                _baseAttack += CurrentEquipment.BonusAttack;
                _baseDefense += CurrentEquipment.BonusDefense;
                _baseSpeed += CurrentEquipment.BonusSpeed;
            }
            else
                throw new ArgumentNullException();
            if(_baseHealth <0 || _baseAttack < 0 || _baseDefense<0 || _baseSpeed <0)
                throw new ArgumentException();
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            _baseHealth -= CurrentEquipment.BonusHealth;
            _baseAttack -= CurrentEquipment.BonusAttack;
            _baseDefense -= CurrentEquipment.BonusDefense;
            _baseSpeed -= CurrentEquipment.BonusSpeed;
            _baseType = TYPE.NORMAL;

            CurrentEquipment = null;
        }

    }
}
