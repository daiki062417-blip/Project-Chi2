using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Inventory : MonoBehaviour
{

    public struct InventoryElement
    {
        public Item item;
        public int num;
    }

    List<InventoryElement> itemList = new();
    Dictionary<GameObject, Item> showItemList = new(); // 表示しているアイテムを格納

    // ---------------------------------------------------------
    //                     アイテム管理  
    // ---------------------------------------------------------

    /// <summary>
    /// アイテムをインベントリに追加
    /// </summary>
    /// <param name="item">追加アイテム</param>
    /// <param name="num">個数</param>
    public void AddItem(Item item, int num)
    {
        
        var targetIndex = FindItemIndex(item);

        // まだ所有していなければ新規追加。
        if (targetIndex == -1)
        {
            var newElement = new InventoryElement() { item = item, num = num };
            itemList.Add(newElement);
        }
        // アイテムをすでに所有していれば、所持数を追加。
        else
        {
            var targetElement = itemList[targetIndex];
            targetElement.num += num;
            itemList[targetIndex] = targetElement;
        }

        // リストソート
        SortElement();

        // デバッグ（数確認）
        Debug_InventoryContent();
    }

    /// <summary>
    /// アイテムを使用する
    /// </summary>
    /// <param name="item">使用アイテム</param>
    /// <param name="player">使用するキャラ</param>
    public void UseItem(Item item, Player player)
    {
        var targetIndex = FindItemIndex(item);

        // まだ所有していなければエラー
        if (targetIndex == -1)
        {
            Debug.LogError("[Inventory] 未所持のアイテムを使用しました。");
            return;
        }

        // アイテム使用
        var targetElement = itemList[targetIndex];
        targetElement.item.Use(player);

        // アイテム消費処理
        if (targetElement.item.isConsumed)
        {
            // 残り１つならリストから削除
            if (targetElement.num <= 1)
            {
                itemList.Remove(targetElement);
            }
            // 複数個あれば、所持数を1減らす
            else
            {
                AddItem(targetElement.item, -1);
            }
        }

        // デバッグ（数確認）
        Debug_InventoryContent();
    }

    // ---------------------------------------------------------
    //                           探索 
    // ---------------------------------------------------------

    /// <summary>
    /// 指定アイテムのインデックスを返す
    /// </summary>
    /// <param name="item">アイテム</param>
    /// <returns>インデックス</returns>
    int FindItemIndex(Item item)
    {
        return itemList.FindIndex((target) => target.item == item);
    }


    /// <summary>
    /// インベントリをIDについて昇順に並べ替え
    /// </summary>
    void SortElement()
    {
        itemList.Sort((target1, target2) => target2.item.ID - target1.item.ID);
    }

    // ---------------------------------------------------------
    //                           表示用  
    // ---------------------------------------------------------

    /// <summary>
    /// アイテムを表示する。※未テスト。使いにくければ無視してくれ！
    /// </summary>
    /// <param name="item">表示するアイテム</param>
    /// <param name="pos"></param>
    GameObject ShowItem(Item item, Vector3 pos)
    {
        var itemObj = new GameObject();
        itemObj.name = item.name;
        itemObj.transform.position = pos;
        itemObj.AddComponent<SpriteRenderer>().sprite = item.icon;

        showItemList.Add(itemObj, item);
        return itemObj;
    }

    /// <summary>
    /// 表示用オブジェクトのアイテム情報を取得
    /// </summary>
    /// <param name="itemObj">表示用オブジェクト</param>
    /// <returns>そのオブジェクトに対応したアイテム</returns>
    Item ItemObj2Info(GameObject itemObj)
    {
        return showItemList[itemObj];
    }

    // ---------------------------------------------------------
    //                         デバッグ用 
    // ---------------------------------------------------------


    void Debug_InventoryContent()
    {
        string text = "[Inventory] インベントリ内のアイテム一覧 : \n";
        
        foreach(var element in itemList)
        {
            text += $"{element.item} : {element.num}";
        }

        Debug.Log(text);
    }


}

