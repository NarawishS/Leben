using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerStat
{
    private string playerName;
    private BaseStat playerStat;
    private int health;
    private int wealth;
    private int education;
    private int relax;
    private int workHours;

    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    public BaseStat PlayerStat
    {
        get { return playerStat; }
        set { playerStat = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Wealth
    {
        get { return wealth; }
        set { wealth = value; }
    }

    public int Education
    {
        get { return education; }
        set { education = value; }
    }
    public int Relax
    {
        get { return relax; }
        set { relax = value; }
    }
    public int WorkHours
    {
        get { return workHours; }
        set { workHours = value; }
    }
}
