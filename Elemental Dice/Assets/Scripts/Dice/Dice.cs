using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    // d4, d6, d8, d10, d12, d20
    public int diceNumberType;
    // tribe
    public List<TraitName> diceTraits = new List<TraitName>();

    private int rawValue;
    private int attackBonus;

    public bool hasHealth = true; // when you lose a dice, can this be lost?

    private DiceGameObject diceGO;
    public GameObject gameObject { get { return diceGO.gameObject; } }

    public Dice(int numberType, TraitName[] traits, DiceGameObject diceGO)
    {
        diceNumberType = numberType;
        diceTraits = new List<TraitName>(traits);
        this.diceGO = diceGO;
    }

    public Dice(int numberType, TraitName[] traits, DiceGameObject diceGO, bool hasHealth) : this(numberType, traits, diceGO)
    {
        this.hasHealth = hasHealth;
    }



    public bool HasTrait(TraitName diceTrait)
    {
        return diceTraits.Contains(diceTrait);
    }

    // Values

    public void RollRawValue()
    {
        rawValue = Random.Range(0, diceNumberType) + 1;
        // update stuff
    }

    public void SetRawValue(int value)
    {
        rawValue = value;
        // update stuff
    }

    public int GetRawValue()
    {
        return rawValue;
    }

    public int GetAttackBonus()
    {
        return attackBonus;
    }

    public void AddAttackBonus(int amount)
    {
        attackBonus += amount;
    }

    public int GetAttackValue()
    {
        // do crits here
        return rawValue + attackBonus;
    }

    public void ResetDiceValues()
    {
        rawValue = 0;
        attackBonus = 0;
    }

    // Game Object stuff

    public DiceGameObject GetDiceGameObject()
    {
        return diceGO;
    }

    public GameObject GetGameObject()
    {
        return diceGO.gameObject;
    }



    // C# object stuff

    public override int GetHashCode()
    {
        return System.Tuple.Create(diceNumberType, diceTraits).GetHashCode();
    }

    public override bool Equals(object obj)
    {
        Dice other = (Dice)obj;
        if (diceNumberType != other.diceNumberType)
            return false;

        if (!new HashSet<TraitName>(diceTraits).SetEquals(other.diceTraits))
            return false;

        return true;
    }

    public override string ToString()
    {
        string s = "d" + diceNumberType + " ";
        foreach (TraitName dt in diceTraits)
        {
            s += dt + ", ";
        }
        return s;
    }
}
