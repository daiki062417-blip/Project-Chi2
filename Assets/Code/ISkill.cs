using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    /// <summary>
    /// モーション名（形式変更の可能性あり）
    /// </summary>
    public string motionName { get; }

    /// <summary>
    /// 技係数。ダメージ計算時に参照
    /// </summary>
    public float skillCoef { get; }

    /// <summary>
    /// 消費SP
    /// </summary>
    public float SPCost { get; }

    /// <summary>
    /// 技アイコン
    /// </summary>
    SpriteRenderer icon { get; }

    public IEnumerator SkillProcess(Player player);
}
