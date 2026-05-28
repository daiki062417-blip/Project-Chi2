using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform parent;

    int money = 100;

    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public int price;
        public Button button;

        public ItemData(string name, int price)
        {
            itemName = name;
            this.price = price;
        }
    }

    List<ItemData> items = new List<ItemData>()
    {
        new ItemData("ポーション", 30),
        new ItemData("剣", 120),
        new ItemData("盾", 80),
        new ItemData("薬草", 10),
        new ItemData("エリクサー", 200),
        new ItemData("弓", 90),
        new ItemData("斧", 150),
        new ItemData("ハンマー", 180),
    };

    void Start()
    {
        CreateButtons();
        UpdateButtonState();
    }

    void CreateButtons()
    {
        foreach (ItemData item in items)
        {
            GameObject buttonObj =
                Instantiate(buttonPrefab, parent);

            TMP_Text text =
                buttonObj.GetComponentInChildren<TMP_Text>();

            text.text =
                item.itemName + " : " + item.price + "G";

            Button button =
                buttonObj.GetComponent<Button>();

            item.button = button;

            button.onClick.AddListener(() =>
            {
                BuyItem(item);
            });
        }
    }

    void BuyItem(ItemData item)
    {
        if (money < item.price)
        {
            return;
        }

        money -= item.price;

        Debug.Log(item.itemName + " を購入");
        Debug.Log("残金 : " + money + "G");

        UpdateButtonState();
    }

    void UpdateButtonState()
    {
        foreach (ItemData item in items)
        {
            item.button.interactable =
                money >= item.price;
        }
    }
}