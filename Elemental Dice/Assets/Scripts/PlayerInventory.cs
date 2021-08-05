using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int inventorySize = 2;
    private const int STARTING_SIZE = 2; // move somewhere else
    private const int MAX_SIZE = 8; // move somewhere else

    private DiceKit inventory = new DiceKit(); 

    private void Awake()
    {
        // if instance == null
        // reset
    }

    public void SetInitValues(DiceKit initInventory)
    {
        inventory = initInventory;
    }



    public void AddDice(Dice dice)
    {
        AddDice(dice, DiceKit.Section.All);
    }

    public void AddDice(Dice dice, DiceKit.Section dkSection)
    {
        inventory.AddDice(dice, dkSection);
    }
    

    public List<Dice> GetDice()
    {
        return inventory.GetDiceFrom(DiceKit.Section.All);
    }

    public int GetBattleTraitCount(TraitName trait)
    {
        Dictionary<TraitName, int> traitCount = inventory.GetTraitCount(DiceKit.Section.All);
        if (!traitCount.ContainsKey(trait))
            return 0;
        return traitCount[trait];
    }



    public void PrintInventoryTraits()
    {
        Dictionary<TraitName, int> traitCount = inventory.GetTraitCount(DiceKit.Section.All);
        string s = "--- Traits ---";

        foreach (TraitName trait in traitCount.Keys)
        {
            s += "\n" + trait + "\t" + traitCount[trait];
        }

        Debug.Log(s);
    }
}
