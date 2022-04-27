using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateActionButton(Action.ActionType.Slider, Action.GetSprite(Action.ActionType.Slider), "Slider",
            Action.GetCost(Action.ActionType.Slider), 0);
        CreateActionButton(Action.ActionType.Bench, Action.GetSprite(Action.ActionType.Bench), "Bench",
            Action.GetCost(Action.ActionType.Bench), 1);
        Hide();
        CreateActionButton(Action.ActionType.Work, Action.GetSprite(Action.ActionType.Work), "Work",
            Action.GetCost(Action.ActionType.Work), 2);
        Hide();
    }

    private void CreateActionButton(Action.ActionType actionType, Sprite actionSprite, string actionName,
        int actionCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);

        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 120f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(actionName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(actionCost.ToString());

        shopItemTransform.Find("actionImage").GetComponent<Image>().sprite = actionSprite;
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryDoAction(actionType));
        shopItemTransform.gameObject.SetActive(true);
    }

    public void TryDoAction(Action.ActionType actionType)
    {
        if (shopCustomer.TrySpendGoldAmount(Action.GetCost(actionType)))
        {
            shopCustomer.BoughtItem(actionType);
        }
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}