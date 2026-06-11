using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "temData", menuName = "ScriptableObjects/CreateItem")]
public class Item : ScriptableObject
{
    [Header("アイテムID")]
    public int ID;
    public string itemName;
    public List<string> tagList; // 商品のカテゴリ
    public bool isConsumed;
    public Sprite icon;

    public virtual void Use(Player player)
    {
        Debug.Log("[Item] use : " + ID);
    }
}
