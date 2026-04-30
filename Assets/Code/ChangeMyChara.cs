using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMyChara : MonoBehaviour
{
    //とりあえずシフトキーを押して交代する。キーの場所は要相談。
    //スペル分からない！
    public GameObject Chi;
    public GameObject Miu;
    public GameObject Virna;

    private int current_chara;
    private GameObject[] players;

    void Start()
    {
        players = new GameObject[] { Chi, Miu, Virna };

        // 最初はplayer1だけ操作可能
        current_chara = 0;
        players[current_chara].SetActive(true);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //次のキャラをアクティブ化する
            current_chara = (current_chara + 1) % players.Length;
            SetActivePlayer(current_chara);

            //他キャラを非アクティブ化する。
            for (int i = 0; i < players.Length; i++)
            {
                if (i != current_chara)
                {
                    players[i].SetActive(false);
                }
            }

        }
    }

    void SetActivePlayer(int index)
    {
        //for (int i = 0; i < players.Length; i++)
        //{
        // PlayerControllerの有効/無効を切り替える(AI製)
        //players[i].GetComponent<PlayerController>().enabled = (i == index);
        //}

        //控えのキャラはSetActiveで非表示にする
    }

}
