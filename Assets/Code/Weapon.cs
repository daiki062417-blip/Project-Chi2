using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : Item
{

    /// <summary>
    /// 効果指定用の定数
    /// </summary>
    enum Effect
    {
        enhancePower,
        enhanceCritical,
    }

    // 武器のステータス
    [SerializeField] StatusManager.Status status;

    // サブ効果の付与上限
    [SerializeField] int effectLimit;


    

    public void AddSubEffect()
    {

    }
    
}
