using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //スペル分からない！
    [SerializeField] GameObject Chi;
    [SerializeField] GameObject Miu;
    [SerializeField] GameObject Virna;

    private int current_chara;
    private int before_chara;
    private GameObject[] players;

    void Start()
    {
        players = new GameObject[] { Chi, Miu, Virna };

        // 最初はカイだけ操作可能
        current_chara = 0;
        before_chara = 2;
        players[0].SetActive(true);
        players[1].SetActive(false);
        players[2].SetActive(false);

    }
    void Update()
    {
        //とりあえずシフトキーを押して交代する。キーの場所は要相談。
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //現在キャラを非アクティブ化する
            players[current_chara].SetActive(false);

            //次のキャラが何番目か、前キャラが何番目か
            current_chara = (current_chara + 1) % players.Length;//次キャラ
            before_chara = (before_chara + 1) % players.Length;//前キャラ

            //前キャラの座標情報を現在キャラに代入
            players[current_chara].transform.position = players[before_chara].transform.position;
            players[current_chara].transform.rotation = players[before_chara].transform.rotation;

            //現在キャラをアクティブ化
            players[current_chara].SetActive(true);

        }
    }

    //現在の操作キャラが何かを返す関数
    public GameObject Playable()
    {
        return players[current_chara];
    }


}
