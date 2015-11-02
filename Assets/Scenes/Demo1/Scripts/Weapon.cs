using UnityEngine;
using System.Collections;
using ItemSystem;

[DisallowMultipleComponent]
public class Weapon : MonoBehaviour {

    public Sprite Icon;
    public int Value;
    public int Burden;
    public Sprite Quality;
    public int MinDamage;
    public int Durability;
    public int MaxDurability;
    public EquipmentSlot EquipmentSlot;
}
