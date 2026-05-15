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

    void TestFunction()
    {
        weapon.AddSubEffect(Weapon.Effect.enhanceCritical);
        weapon.ShowWeaponInfo();
        
    }
}
