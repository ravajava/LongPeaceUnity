using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Title: Battalion
 * Author: Kristian Mckesey & Josue Lopes
 * Date: October 3rd, 2018
 * Description: Battalions are the building blocks for brigades
 */

[System.Serializable]
public class Battalion
{
    public int battalionCost;
    public int battalionLightAttack;
    public int battalionHeavyAttack;
    public int battalionMaxHealth;
    public int battalionCurrentHealth;
    public int battalionArmour;
    public int battalionSupply;
    public int battalionSpeed;
    public int battalionAwareness;

    public Battalion(int cost, int lightAttack, int heavyAttack, int health, int armour, int supply, int speed, int awareness)
    {
        battalionCost = cost;
        battalionLightAttack = lightAttack;
        battalionHeavyAttack = heavyAttack;
        battalionMaxHealth = health;
        battalionCurrentHealth = health;
        battalionArmour = armour;
        battalionSupply = supply;
        battalionSpeed = speed;
        battalionAwareness = awareness;
    }

    void GetBrigadeLightAttack()
    {

    }

    void SetBrigadeLightAttack()
    {

    }

    void GetBrigadeHeavyAttack()
    {

    }

    void SetBrigadeHeavyAttack()
    {

    }

    void GetBrigadeHealth()
    {

    }

    void SetBrigadeHealth()
    {

    }

    void GetBrigadeArmour()
    {

    }

    void SetBrigadeArmour()
    {

    }

    void GetBrigadeSupply()
    {

    }

    void SetBrigadeSupply()
    {

    }

    void GetBrigadeSpeed()
    {

    }

    void SetBrigadeSpeed()
    {

    }

    void GetBrigadeAwareness()
    {

    }

    void SetBrigadeAwareness()
    {

    }
}
