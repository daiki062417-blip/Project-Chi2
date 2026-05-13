using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : Character
{
    public Transform ThisTransform;
    private bool movable = false;
    //操作キャラは変動するのでMainで用いている操作キャラを示す変数を利用した。もっといい方法はありますか
    GameObject Main;

    
    void Start()
    {
        //自身の座標情報
        ThisTransform = GetComponent<Transform>();

        Main = GameObject.Find("Main");

    }

    void Update()
    {
        if (movable = Player_In_Area())
        {
            Debug.Log("敵の範囲内に入りました");
        }
    }

    bool Player_In_Area()
    {        
        //範囲は円形範囲で、半径はとりあえず仮で決めた。
        if(Vector3.Distance(ThisTransform.position, Main.GetComponent<ChangeMyChara>().Playable().transform.position) < 5f)
        {
            return true;
        }

        return false;
    }
}
