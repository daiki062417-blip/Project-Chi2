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
    [Serializable] public struct ScenarioFlag
    {
        public CharaDetecter posDetecter;   // プレイヤー位置。コライダーを設置し、それがプレイヤーを検知したか判定する。
        public Player detectedPlayer;   //上コライダーにおいて、検出するキャラを制限する。（指定なしなら全員対象）
        public Scenario premiseScenario;   // 前提シナリオ
        public Quest premiseQuest;         // 前提クエスト
        public SerializedDictionary<Item, int> keyItems;    // キーアイテム。これを持っているとシナリオ実行（消費しない）
    }

    [SerializeField] ScenarioFlag flag;


    /// <summary>
    /// シナリオの形式。設定したものを実行する
    /// </summary>
    [Serializable] public struct Format
    {
        public VideoPlayer movie;      // ムービーを再生
        public string scenarioScene;   // シナリオを別シーンで再生
        public string csv;     // 吹き出し型の会話。会話データをcsvで管理したいが、形式や導入するか未定のため保留。
    }

    [SerializeField] Format format;


    /// <summary>
    /// シナリオ終了後に起きること
    /// </summary>
    [Serializable] struct FinishEvent
    {
        public SerializedDictionary<Enemy, Vector3> appearEnemyDic;
        public Dictionary<Item, int> getItemDic;
        public Quest clearQuest;
    }

    [SerializeField] FinishEvent finishEvent;

    public bool isFinished = false;
}
