using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "temData", menuName = "ScriptableObjects/CreateItem")]
public class Item : ScriptableObject
{
    [Header("ƒAƒCƒeƒ€ID")]
    public int ID;
    public bool isConsumed;

    public void Use(Player player)
    {
        Debug.Log("[Item] use : " + ID);
    }
}
