using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInventory : MonoBehaviour
{
    private DiceKit battleDice = new DiceKit();
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

    public void SetInitValues(DiceKit battleDice)
    {
        this.battleDice = battleDice;
    }



    public void AddBattleDice(Dice dice)
    {
        AddBattleDice(dice, DiceKit.Section.All);
    }

    public void AddBattleDice(Dice dice, DiceKit.Section dkSection)
    {
        battleDice.AddDice(dice, dkSection);
    }

    public void AddRoundDice(Dice dice)
    {
        AddRoundDice(dice, DiceKit.Section.All);
    }

    public void AddRoundDice(Dice dice, DiceKit.Section dkSection)
    {
        roundDice.AddDice(dice, dkSection);
    }


    

    public List<Dice> GetNewRoundDice()
    {
        roundDice.CopyFrom(battleDice);
        roundDice.ResetDice();
        return roundDice.GetDiceFrom(DiceKit.Section.All);
    }

    public List<Dice> GetCurrentRoundDice()
    {
        return roundDice.GetDiceFrom(DiceKit.Section.All);
    }

    public int GetBattleTraitCount(TraitName trait)
    {
        Dictionary<TraitName, int> traitCount = battleDice.GetTraitCount(DiceKit.Section.All);
        if (!traitCount.ContainsKey(trait))
            return 0;
        return traitCount[trait];
    }



    public void PrintInventoryTraits()
    {
        Dictionary<TraitName, int> traitCount = battleDice.GetTraitCount(DiceKit.Section.All);
        string s = "--- Traits ---";

        foreach (TraitName trait in traitCount.Keys)
        {
            s += "\n" + trait + "\t" + traitCount[trait];
        }

        Debug.Log(s);
    }
}
