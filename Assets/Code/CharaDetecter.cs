using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// コライダー範囲内にある特定オブジェクトを検出する。
/// </summary>
public class CharaDetecter : MonoBehaviour
{

    List<GameObject> collisionObjList = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!collisionObjList.Contains(other.gameObject))
           collisionObjList.Add(other.gameObject); 
    }

    private void OnTriggerExit(Collider other)
    {
        if (collisionObjList.Contains(other.gameObject))
            collisionObjList.Remove(other.gameObject);
    }

    /// <summary>
    /// 範囲内のプレイヤーを返す。
    /// </summary>
    /// <returns>検出したプレイヤー（いなければnull）。</returns>
    public Player DetectPlayer()
    {
        foreach(var obj in collisionObjList)
        {
            var player = obj.GetComponent<Player>();
            if (player != null)
                return player;
        }

        return null;
    }
}
