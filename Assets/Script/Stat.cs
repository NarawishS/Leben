using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private int health;
    private int wealth;
    private int education;
    private int relax;
    private int workHours;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Welth
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
