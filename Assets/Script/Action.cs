using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public enum ActionType
    {
        Slider,
        Bench,
        Home
    }

    public static int GetCost(ActionType actionType)
    {
        switch (actionType)
        {
            default:
            case ActionType.Slider: return 0;
            case ActionType.Bench: return 0;
            case ActionType.Home: return 0;
        }
    }

    public static Sprite GetSprite(ActionType actionType)
    {
        switch (actionType)
        {
            default:
            case ActionType.Slider: return GameAssets.i.Slider;
            case ActionType.Bench: return GameAssets.i.Bench;
            case ActionType.Home: return GameAssets.i.Home;
        }
    }
}
