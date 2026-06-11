using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu]
public class Scenario : ScriptableObject
{

    /// <summary>
    /// シナリオ開始フラグ。設定したすべての条件が合致すればシナリオをロード 
    /// </summary>
    [Serializable] public struct SenarioFlag
    {
        Collider PosColliderName;   // プレイヤー位置。コライダーを設置し、それがプレイヤーを検知したか判定する。
        Scenario premiseScenario;   // 前提シナリオ
        Quest premiseQuest;         // 前提クエスト
        SerializedDictionary<Item, int> keyItem;    // キーアイテム。これを持っているとシナリオ実行（消費しない）
    }

    [SerializeField] SenarioFlag flag;


    /// <summary>
    /// シナリオの形式。設定したものを実行する
    /// </summary>
    [Serializable] public struct Format
    {
        VideoPlayer movie;      // ムービーを再生
        string scenarioScene;   // シナリオを別シーンで再生
        string csv;     // 吹き出し型の会話。会話データをcsvで管理したいが、形式や導入するか未定のため保留。
    }

    [SerializeField] Format format;


    /// <summary>
    /// シナリオ終了後に起きること
    /// </summary>
    [Serializable] struct FinishEvent
    {
        SerializedDictionary<Enemy, Vector3> appearEnemyDic;
        Dictionary<Item, int> getItemDic;
        Quest clearQuest;
    }

    [SerializeField] FinishEvent finishEvent;
}
