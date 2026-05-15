using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    [SerializeField] StatusManager.Status status;

    // サブ効果の付与上限
    [SerializeField] int effectLimit;

    // メイン効果リスト
    List<Effect> effectList;

    // サブ効果リスト
    List<Effect> subEffectList;


    //--------------------------------
    //       　 コンフィグ
    //--------------------------------

    // 攻撃力の強化倍率
    float powerRate = 0.05f;
    float criticalRate = 0.05f;


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

        text += "\n武器ステータスは以下。";

        Debug.Log(text);

        // 武器ステータス表示
        StatusManager.ShowStatus(status);

    }

    public string GetEffectName(Effect effect)
    {
        return effectName[effect];
    }

}
