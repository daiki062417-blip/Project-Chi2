using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMyChara : MonoBehaviour
{
    //スペル分からない！
    public GameObject Chi;
    public GameObject Miu;
    public GameObject Virna;

    private int current_chara;
    private GameObject[] players;
    public Transform chara_transform;


    void Start()
    {
        //名前でGameObjectを指定、後で正式な名称に修正する
        //Chi = GameObject.Find("TempChi");
        //Miu = GameObject.Find("TempMiu");
        //Virna = GameObject.Find("TempVirna");

        players = new GameObject[] { Chi, Miu, Virna };

        // 最初はカイだけ操作可能
        current_chara = 0;
        players[0].SetActive(true);
        players[1].SetActive(false);
        players[2].SetActive(false);

    }
    void Update()
    {    
        //とりあえずシフトキーを押して交代する。キーの場所は要相談。
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //交代前のキャラの座標情報を保存
            chara_transform = players[current_chara].transform;
            //現在キャラを非アクティブ化する
            players[current_chara].SetActive(false);

            //次のキャラをアクティブ化する
            current_chara = (current_chara + 1) % players.Length;

            players[current_chara].transform.position = chara_transform.position;
            players[current_chara].transform.rotation = chara_transform.rotation;
            
            players[current_chara].SetActive(true);

        }
    }


}
