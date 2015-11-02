﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

namespace ItemSystem
{
    [Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISGameObject
    {
        [SerializeField]
        int _minDamage;

        [SerializeField]
        int _durability;

        [SerializeField]
        int _maxDurability;

        [SerializeField]
        GameObject _prefab;

        public EquipmentSlot equipmentSlot;


        public ISWeapon()
        {
        }

        public ISWeapon(ISWeapon weapon)
        {
            Clone(weapon);
        }

        public void Clone(ISWeapon weapon)
        {
            base.Clone(weapon);

            _durability = weapon.Durability;
            _maxDurability = weapon.MaxDurability;
            equipmentSlot = weapon.equipmentSlot;
            _prefab = weapon.Prefab;
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

        public int MinDamage
        {
            get
            {
                return _minDamage;
            }

            set
            {
                _minDamage = value;
            }
        }

        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }
        }

        public int Attack()
        {
            throw new NotImplementedException();
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

        // This code will be placed in a new class later

        public override void OnGUI()
        {
            base.OnGUI();

            _minDamage = Convert.ToInt32(EditorGUILayout.TextField("Min Damage: ", _minDamage.ToString()));
            _durability = Convert.ToInt32(EditorGUILayout.TextField("Durability: ", _durability.ToString()));
            _maxDurability = Convert.ToInt32(EditorGUILayout.TextField("Max Durability: ", _maxDurability.ToString()));

            DisplayEquipmentSlot();
            DisplayPrefab();
        }

        public void DisplayEquipmentSlot()
        {
            equipmentSlot = (EquipmentSlot) EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
        }

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }
    }
}
