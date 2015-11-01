using UnityEngine;
using System.Collections;
using System;

namespace ItemSystem
{
    [Serializable]
    public class ISObject : IISObject
    {
        [SerializeField]
        string _name;

        [SerializeField]
        int _value;

        [SerializeField]
        Sprite _icon;

        [SerializeField]
        int _burden;

        [SerializeField]
        ISQuality _quality;

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

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
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

        public int Burden
        {
            get
            {
                return _burden;
            }

            set
            {
                _burden = value;
            }
        }

        public ISQuality Quality
        {
            get
            {
                return _quality;
            }

            set
            {
                _quality = value;
            }
        }

    }
}
