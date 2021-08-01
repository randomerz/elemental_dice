using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKit
{
    private List<Dice> diceList = new List<Dice>();
    private Dictionary<TraitName, int> traitCount = new Dictionary<TraitName, int>();

    public DiceKit()
    {

    }

    public DiceKit(List<Dice> dice)
    {
        foreach (Dice d in dice)
        {
            AddDice(d);
        }
    }

    public List<Dice> GetDiceList()
    {
        return diceList;
    }

    public Dictionary<TraitName, int> GetTraitCount()
    {
        return traitCount;
    }

    public void AddDice(Dice dice)
    {
        diceList.Add(dice);

        foreach (TraitName trait in dice.diceTraits)
        {
            if (traitCount.ContainsKey(trait))
            {
                traitCount[trait] += 1;
            }
            else
            {
                traitCount.Add(trait, 1);
            }
        }
    }

    public void RemoveDice(Dice dice)
    {
        diceList.Remove(dice);

        foreach (TraitName trait in dice.diceTraits)
        {
            if (!traitCount.ContainsKey(trait))
            {
                Debug.LogWarning("Tried removing trait [" + trait + "] when it wasn't present in dictionary!");
            }
            traitCount[trait] -= 1;
        }
    }

    public void CopyFrom(DiceKit other)
    {
        diceList = new List<Dice>(other.diceList);
        traitCount = new Dictionary<TraitName, int>(other.traitCount);
    }

    public void ResetDice()
    {
        foreach (Dice d in diceList)
        {
            d.ResetDiceValues();
        }
    }
}
