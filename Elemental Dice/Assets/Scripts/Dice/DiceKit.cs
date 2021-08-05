using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKit
{
    private List<Dice> diceTray = new List<Dice>();
    private List<Dice> dicePouch = new List<Dice>();
    private List<Dice> diceSummoned = new List<Dice>();
    //private Dictionary<TraitName, int> traitCount = new Dictionary<TraitName, int>();

    private int size = 8; // default, size = traySize, 2 * size = pouchSize

    public enum Section
    {
        Tray,
        Pouch,
        Summon,
        All,
        None
    }

    public DiceKit()
    {

    }

    public DiceKit(List<Dice> dTray, List<Dice> dPouch, int size)
    {
        foreach (Dice d in dTray)
        {
            AddDice(d, Section.Tray);
        }

        foreach (Dice d in dPouch)
        {
            AddDice(d, Section.Pouch);
        }

        this.size = size;
    }

    public List<Dice> GetDiceFrom(Section invType)
    {
        switch (invType)
        {
            case Section.Tray:
                return diceTray;
            case Section.Pouch:
                return dicePouch;
            case Section.Summon:
                return diceSummoned;
            case Section.All:
                List<Dice> allDice = new List<Dice>(diceTray);
                allDice.AddRange(dicePouch);
                allDice.AddRange(diceSummoned);
                return allDice;
        }

        Debug.LogWarning("Enum value not found!");

        throw new System.Exception();
    }

    public Dictionary<TraitName, int> GetTraitCount(Section invType)
    {
        Dictionary<TraitName, int> traitCount = new Dictionary<TraitName, int>();

        List<Dice> toSearch = GetDiceFrom(invType);
        foreach (Dice d in toSearch)
        {
            foreach (TraitName trait in d.diceTraits)
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

        return traitCount;
    }

    public bool AddDice(Dice dice, Section invType)
    {
        switch (invType)
        {
            case Section.Tray:
                diceTray.Add(dice);
                break;

            case Section.Pouch:
                dicePouch.Add(dice);
                break;

            case Section.Summon:
                diceSummoned.Add(dice);
                break;
                
            case Section.All:
                // defaults to adding to tray first, else pouch, else returns false
                if (diceTray.Count < size)
                {
                    AddDice(dice, Section.Tray);
                }
                else if (dicePouch.Count < 2 * size)
                {
                    AddDice(dice, Section.Pouch);
                }
                else
                {
                    return false;
                }
                break;

            default:
                Debug.LogWarning("Enum value not found!");

                throw new System.Exception();
        }

        return true;
    }

    public void RemoveDice(Dice dice, Section invType)
    {
        switch (invType)
        {
            case Section.Tray:
                diceTray.Remove(dice);
                break;

            case Section.Pouch:
                dicePouch.Remove(dice);
                break;

            case Section.Summon:
                diceSummoned.Remove(dice);
                break;

            case Section.All:
                diceTray.Remove(dice);
                dicePouch.Remove(dice);
                diceSummoned.Remove(dice);
                break;

            default:
                Debug.LogWarning("Enum value not found!");

                throw new System.Exception();
        }
    }

    public void CopyFrom(DiceKit other)
    {
        diceTray = new List<Dice>(other.diceTray);
        dicePouch = new List<Dice>(other.dicePouch);
        diceSummoned = new List<Dice>(other.diceSummoned);
    }

    public void ResetDice()
    {
        foreach (Dice d in diceTray)
        {
            d.ResetDiceValues();
        }
        foreach (Dice d in dicePouch)
        {
            d.ResetDiceValues();
        }
        foreach (Dice d in diceSummoned)
        {
            d.ResetDiceValues();
        }
    }
}
