using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

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

        public ISObject(ISObject item)
        {
            Clone(item);
        }

        public void Clone(ISObject item)
        {
            _name = item.Name;
            _value = item.Value;
            _icon = item.Icon;
            _burden = item.Burden;
            _quality = item.Quality;
        }

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

        // This code is going to be placed in a new class later

        ISQualityDatabase _qualityDatabase;
        int _selectedQualityIndex = 0;
        string[] option;

        public virtual void OnGUI()
        {
            _name = EditorGUILayout.TextField("Name: ", _name);
            _value = EditorGUILayout.IntField("Value: ", _value);
            _burden = EditorGUILayout.IntField("Burden: ", _burden);

            DisplayIcon();
            DisplayQuality();
        }

        public void DisplayIcon()
        {
            _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }

        public int SelectedQualityId
        {
            get
            {
                return _selectedQualityIndex;
            }
        }

        public ISObject()
        {
            string DATABASE_NAME = @"ItemSystemQualityDatabase.asset";
            string DATABASE_PATH = @"Database";

            _qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);

            option = new string[_qualityDatabase.Count];
            for (int cnt = 0; cnt < _qualityDatabase.Count; cnt++)
            {
                option[cnt] = _qualityDatabase.Get(cnt).Name;
            }
        }

        public void DisplayQuality()
        {
            int itemIndex = 0;

            if (_quality != null)
            {
                itemIndex = _qualityDatabase.GetIndex(_quality.Name);
            }

            if (itemIndex == -1)
            {
                itemIndex = 0;
            }

            _selectedQualityIndex = EditorGUILayout.Popup("Quality", itemIndex, option);
            _quality = _qualityDatabase.Get(_selectedQualityIndex);
        }
    }
}
