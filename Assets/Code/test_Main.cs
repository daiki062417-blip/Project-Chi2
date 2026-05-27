using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Main : MonoBehaviour
{
    
    [SerializeField] SkillSlotManager slotManager;


    // Start is called before the first frame update
    void Start()
    {
        // セットアップ
        slotManager.SetUp();
       
        
        //// プレイアブルキャラの初期化 ( PlayerManager に移動予定)
        //foreach(var p in playerDic.Values)
        //{
        //    p.SetUp();
        //}

        // デバッグ用
        TestFunction();

    }

    /// <summary>
    /// デバッグ用関数。コンフリクトしたら、自分の編集で上書きしていいよ
    /// </summary>
    public Weapon weapon;
    public Player player;

    void TestFunction()
    {
        if (weapon == null || player == null) { Debug.LogError("[test_Main] テスト用の変数が未定義"); return; }

        weapon.AddSubEffect(Weapon.Effect.enhanceCritical);
        weapon.ShowWeaponInfo();

        weapon.Use(player); //装備
        
        StatusManager.ShowStatus(StatusManager.PlayerTotalStatus(player));
    }
}
