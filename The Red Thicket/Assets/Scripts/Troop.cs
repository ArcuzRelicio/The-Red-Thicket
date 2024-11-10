using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTroop", menuName = "The Red Thicket/Troops", order = 1)]
public class Troop : ScriptableObject
{
    public enum typeOfTroop
    {
        soliderClass,
        mageClass,
        bruteClass
    }

    public enum faction
    {
        elven,
        kraudrasi,
        archivist
    }
    public int troopHealth;
    public typeOfTroop troopType;
    public faction troopFaction;
    public Sprite troopSprite;
    public Sprite troopDamagedSprite;

    public void DealDamage(int damage)
    {
        troopHealth =- damage;
    }

    public void HealDamage(int HealNo)
    {
        troopHealth =+ HealNo;
    }

    

}
