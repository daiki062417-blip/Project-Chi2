using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static StatusManager;

[CreateAssetMenu(fileName = "weaponData", menuName = "ScriptableObjects/CreateWeapon")]
public class Weapon : Item
{

    /// <summary>
    /// 効果指定用の定数
    /// </summary>
    public enum Effect
    {
        enhancePower,
        enhanceCritical,
    }

    // 効果と効果名の対応表
    static Dictionary<Effect, string> effectName = new()
    {
        [Effect.enhancePower] = "enhancePower",
        [Effect.enhanceCritical] = "enhanceCritical"
    };

    // 武器のステータス
    [SerializeField] Status status;

    // サブ効果の付与上限
    [SerializeField] int effectLimit;

    // メイン効果リスト
    [SerializeField] List<Effect> effectList;

    // サブ効果リスト
    List<Effect> subEffectList;


    //--------------------------------
    //       　 コンフィグ
    //--------------------------------

    // 攻撃力の強化倍率
    // -メモ 増加量の記載。実際は「1 + 値」で計算される。
    float enhancePowerRate = 0.05f;
    float enhanceCriticalRate = 0.05f;


    //--------------------------------
    //        セットアップ処理
    //--------------------------------


    public void SetUp()
    {
        isConsumed = false;
    }


    //--------------------------------
    //             API
    //--------------------------------
    

    /// <summary>
    /// サブ効果の追加
    /// </summary>
    /// <param name="effect">付与する効果</param>
    /// <param name="subEffectL">サブ効果リスト</param>
    public void AddSubEffect(Effect effect)
    {
        // 空きスロット判定
        if(CheckEmptySlot(subEffectList, effectLimit))
        {
            subEffectList.Add(effect);

            // 表示変更
        }
        else
        {
            // 削除効果選択要求
        }
    }

    /// <summary>
    /// メイン効果をすべて取得
    /// </summary>
    /// <returns>効果名リスト</returns>
    public List<string> GetEffectsName()
    {
        var nameList = new List<string>();

        foreach (Effect eff in effectList)
        {
            nameList.Add(GetEffectName(eff));
        }

        return nameList;
    }

    /// <summary>
    /// サブ効果をすべて取得
    /// </summary>
    /// <returns>サブ効果名リスト</returns>
    public List<string> GetSubEffectsName()
    {
        var nameList = new List<string>();

        foreach (Effect eff in subEffectList)
        {
            nameList.Add(GetEffectName(eff)); 
        }

        return nameList;
    }

    /// <summary>
    /// 武器のステータス（効果込）を返す。
    /// </summary>
    /// <returns>武器ステータス</returns>
    public Status GetStatus()
    {
        return CalcEffect(status);
    }
   

    //--------------------------------
    //           内部処理
    //--------------------------------

    /// <summary>
    /// サブ効果に空きスロットがあるか判定
    /// </summary>
    /// <param name="subEffectList">サブ効果リスト</param>
    /// <param name="effectLimit">サブ効果上限数</param>
    /// <returns>判定</returns>
    bool CheckEmptySlot(List<Effect> subEffectList, int effectLimit)
    {
        return subEffectList.Count < effectLimit;
    }


    /// <summary>
    /// 武器の効果を適用する
    /// </summary>
    /// <param name="status">武器ステータス</param>
    /// <returns>効果適用後のステータス</returns>
    Status CalcEffect(Status status)
    {
        // デバッグ用
        Debug.Log("[Weapon] 効果適用");

        // 全ての効果リストを作成
        var allEffList = new List<Effect>(effectList);
        allEffList.AddRange(subEffectList);

        // 全効果を適用
        foreach (var eff in allEffList)
        {
            switch (eff)
            {
                case Effect.enhancePower:
                    status.power = Mathf.CeilToInt(status.power * (1 + enhancePowerRate) );
                    break;

                case Effect.enhanceCritical:
                    // 100分率。小数切り上げ。
                    status.criticalRate *= 1 + enhanceCriticalRate;
                    Debug.Log("[Weapon] criticalRate（効果適用後）: " +  status.criticalRate);
                    status.criticalRate = Mathf.Ceil(status.criticalRate * 100) / 100;
                    break;
            }

        }

        return status;
    }


    //--------------------------------
    //              表示
    //--------------------------------


    /// <summary>
    /// デバッグ用。ステータスと効果を表示。
    /// </summary>
    public void ShowWeaponInfo()
    {
        // 効果表示
        var text = $"=== 武器：{itemName}===\n【効果】 ";

        if (effectList.Count == 0) text += "\n\t(なし)";

        foreach (var eff in effectList)
        {
            text += $"\n\t・{GetEffectName(eff)}";
        }

        text += "\n\n【サブ効果】";

        if (subEffectList.Count == 0) text += "\n\t(なし)";

        foreach (var eff in subEffectList)
        {
            text += $"\n\t・{GetEffectName(eff)}";
        }

        text += "\n武器の基礎ステータスは以下。";

        Debug.Log(text);

        // 武器ステータス表示
        ShowStatus(status);

    }

    public string GetEffectName(Effect effect)
    {
        return effectName[effect];
    }

}
