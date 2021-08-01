using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInventory : MonoBehaviour
{
    public int inventorySize = 2;
    private const int STARTING_SIZE = 2; // move somewhere else
    private const int MAX_SIZE = 8; // move somewhere else

    public enum InvType
    {
        Inventory,
        Fight,
        Round,
    }

    private DiceKit inventoryDice = new DiceKit();
    private DiceKit fightDice = new DiceKit();
    private DiceKit roundDice = new DiceKit();

    //private List<Dice> inventoryDice = new List<Dice>();
    //private Dictionary<TraitName, int> inventoryTraitCount = new Dictionary<TraitName, int>();
    //private List<Dice> fightDice = new List<Dice>();
    //private Dictionary<TraitName, int> fightTraitCount = new Dictionary<TraitName, int>();
    //private List<Dice> roundDice = new List<Dice>();
    //private Dictionary<TraitName, int> roundTraitCount = new Dictionary<TraitName, int>();

    private void Awake()
    {
        // if instance == null
        // reset
    }

    public void AddDice(Dice dice, InvType inv)
    {
        DiceKit kit = null;

        switch (inv)
        {
            case InvType.Inventory:
                kit = inventoryDice;
                break;
            case InvType.Fight:
                kit = fightDice;
                break;
            case InvType.Round:
                kit = roundDice;
                break;

        }

        kit.AddDice(dice);
    }
    

    //public void AddInventoryDice(Dice dice)
    //{
    //    Debug.Log("Adding dice: " + dice.ToString());
    //    inventoryDice.Add(dice);
    //    AddTraits(inventoryTraitCount, dice.diceTraits);
    //}

    //public void RemoveInventoryDice(Dice dice)
    //{
    //    inventoryDice.Remove(dice);
    //    RemoveTraits(inventoryTraitCount, dice.diceTraits);
    //}

    //public void AddBattleDice(Dice dice)
    //{
    //    fightDice.Add(dice);
    //    AddTraits(inventoryTraitCount, dice.diceTraits);
    //}

    //public void RemoveBattleDice(Dice dice)
    //{
    //    fightDice.Remove(dice);
    //    RemoveTraits(inventoryTraitCount, dice.diceTraits);
    //}

    //private void AddTraits(Dictionary<TraitName, int> traitDict, List<TraitName> traits)
    //{
    //    foreach (TraitName trait in traits)
    //    {
    //        if (traitDict.ContainsKey(trait))
    //        {
    //            traitDict[trait] += 1;
    //        }
    //        else
    //        {
    //            traitDict.Add(trait, 1);
    //        }
    //    }
    //}

    //private void RemoveTraits(Dictionary<TraitName, int> traitDict, List<TraitName> traits)
    //{
    //    foreach (TraitName trait in traits)
    //    {
    //        if (!traitDict.ContainsKey(trait))
    //        {
    //            Debug.LogWarning("Tried removing trait [" + trait + "] when it wasn't present in dictionary!");
    //        }
    //        traitDict[trait] -= 1;
    //    }
    //}

    public void ResetFightDice()
    {
        fightDice.CopyFrom(inventoryDice);
    }

    public List<Dice> GetNewRoundDice()
    {
        roundDice.CopyFrom(fightDice);
        roundDice.ResetDice();
        return roundDice.GetDiceList();
    }

    public List<Dice> GetCurrentRoundDice()
    {
        return roundDice.GetDiceList();
    }

    public int GetBattleTraitCount(TraitName trait)
    {
        if (!fightDice.GetTraitCount().ContainsKey(trait))
            return 0;
        return fightDice.GetTraitCount()[trait];
    }



    public void PrintInventoryTraits()
    {
        string s = "--- Traits ---";

        foreach (TraitName trait in inventoryDice.GetTraitCount().Keys)
        {
            s += "\n" + trait + "\t" + inventoryDice.GetTraitCount()[trait];
        }

        Debug.Log(s);
    }
}
