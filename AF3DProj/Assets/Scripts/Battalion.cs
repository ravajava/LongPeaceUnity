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
    public string Name;
    public int BattalionCost;
    public int BattalionLightAttack;
    public int BattalionHeavyAttack;
    public int BattalionMaxHealth;
    public int BattalionCurrentHealth;
    public int BattalionArmour;
    public int BattalionSupply;
    public int BattalionSpeed;
    public int BattalionAwareness;

    public Battalion(string name, int cost, int lightAttack, int heavyAttack, int health, int armour, int supply, int speed, int awareness)
    {
        Name = name;
        BattalionCost = cost;
        BattalionLightAttack = lightAttack;
        BattalionHeavyAttack = heavyAttack;
        BattalionMaxHealth = health;
        BattalionCurrentHealth = health;
        BattalionArmour = armour;
        BattalionSupply = supply;
        BattalionSpeed = speed;
        BattalionAwareness = awareness;
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
