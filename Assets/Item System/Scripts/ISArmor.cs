using UnityEngine;
using System.Collections;
using System;

namespace ItemSystem
{
    [Serializable]
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject 
    {
        [SerializeField]
        int _curArmor;

        [SerializeField]
        int _maxArmor;

        [SerializeField]
        Vector2 _armor;

        [SerializeField]
        int _durability;

        [SerializeField]
        int _maxDurability;

        [SerializeField]
        GameObject _prefab;

        public EquipmentSlot equipmentSlot;

        public ISArmor()
        {
            _curArmor = 0;
            _maxArmor = 100;
            _durability = 1;
            _maxDurability = 100;
            _prefab = new GameObject();
            equipmentSlot = EquipmentSlot.Torso;
        }

        public Vector2 Armor
        {
            get
            {
                return _armor;
            }

            set
            {
                _armor = value;
            }
        }

        public int Durability
        {
            get
            {
                return _durability;
            }
        }

        public int MaxDurability
        {
            get
            {
                return _maxDurability;
            }
        }

        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }
        }

        public void Break()
        {
            _durability = 0;
        }

        public void Repair()
        {
            // TODO add more complexity later
            _maxDurability--;

            if (_maxDurability > 0)
            {
                _durability = _maxDurability;
            }
        }

        public void TakeDamage(int amount)
        {
            _durability -= amount;

            if (_durability <= 0)
            {
                Break();
            }
        }
    }
}
