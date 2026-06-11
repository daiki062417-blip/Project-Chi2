using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// シナリオのフラグ監視、ロード、終了後の処理を行うクラス。
/// </summary>
public class ScenarioManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    /// <summary>
    /// シナリオ発生フラグの監視
    /// </summary>
    /// <param name="flag">シナリオ発生フラグ</param>
    /// <returns>発生するか</returns>
    public bool  ObserveFlag(Scenario.ScenarioFlag flag)    // テスト用にpublicにしている。
    {
        // 判定結果
        var result = true;

        // 指定位置到達時に発生するフラグ
        if(flag.posDetecter != null)
        {
            // 指定キャラと一致するか
            if (flag.detectedPlayer != null && flag.posDetecter.DetectPlayer() != flag.detectedPlayer)
                result = false;
        }

        // 前提シナリオをクリアしたか
        if(flag.premiseScenario != null)
        {
            if(!flag.premiseScenario.isFinished)
                result = false;
        }

        if(flag.premiseQuest != null)
        {
            if(flag.premiseQuest.isFinished)
                result = false;
        }

        if(flag.keyItems != null)
        {
            foreach(var pair in flag.keyItems)
                if (!inventory.HaveItem(pair.Key, pair.Value))
                {
                    result = false;
                    break;
                }
        }

        return false;
    }
}
