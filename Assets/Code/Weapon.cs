using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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

    // 武器のステータス
    [SerializeField] StatusManager.Status status;

    // サブ効果の付与上限
    [SerializeField] int effectLimit;
    public List<Effect> effectList;
    public List<Effect> subEffectList;


    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="effect"></param>
    public void AddSubEffect(List<Effect> subEffectList, Effect effect)
    {
        // 空きスロット確認

        // 判定
        if(true)
        {
            subEffectList.Add(effect);

            // 表示変更
        }
    }
    
}
