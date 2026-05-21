using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Transform parent;

    List<string> itemNames = new List<string>()
    {
        "É|Å[ÉVÉáÉì",
        "åï",
        "èÇ"
    };

    void Start()
    {
        CreateButtons();
    }

    void CreateButtons()
    {
        foreach (string item in itemNames)
        {
            GameObject buttonObj =
                Instantiate(buttonPrefab, parent);

            Text text =
                buttonObj.GetComponentInChildren<Text>();

            text.text = item;

            Button button =
                buttonObj.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                BuyItem(item);
            });
        }
    }

    void BuyItem(string itemName)
    {
        Debug.Log(itemName + " Ççwì¸");
    }
}