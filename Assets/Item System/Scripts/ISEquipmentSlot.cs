using UnityEngine;
using System.Collections;
using System;

namespace ItemSystem
{
    public class ISEquipmentSlot : IISEquipmentSlot
    {
        [SerializeField]
        string _name;

        [SerializeField]
        Sprite _icon;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Sprite Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
            }
        }
    }
}
