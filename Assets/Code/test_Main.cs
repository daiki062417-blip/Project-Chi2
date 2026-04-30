using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Main : MonoBehaviour
{
    
    [SerializeField] SkillSlotManager slotManager;
    public SerializedDictionary<string, Player> playerDic = new();


    // Start is called before the first frame update
    void Start()
    {
        // セットアップ
        slotManager.SetUp();
       
        // プレイアブルキャラの初期化
        foreach(var p in playerDic.Values)
        {
            p.SetUp();
        }

        // デバッグ用
        TestFunction();

    }

    /// <summary>
    /// デバッグ用関数。コンフリクトしたら、自分の編集で上書きしていいよ
    /// </summary>
    public Item item;

    void TestFunction()
    {
        var inventory = GetComponent<Inventory>();

        inventory.AddItem(item, 1);
        inventory.AddItem(item, 1);

        inventory.UseItem(item, playerDic["Kai"]);
        inventory.UseItem(item, playerDic["Kai"]);

    }
}
