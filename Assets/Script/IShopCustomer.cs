using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(Action.ActionType actionType);
    bool TrySpendGoldAmount(int goldAmount);
}