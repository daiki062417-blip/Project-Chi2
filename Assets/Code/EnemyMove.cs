using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : Character
{
    //敵キャラの座標
    public Transform ThisTransform;

    //敵キャラの認知範囲にいるかどうか
    private bool in_area = false;

    //操作キャラは変動するのでMainで用いている操作キャラを示す変数を利用した。もっといい方法はありますか
    public PlayerManager Main;

    public float dis = 0;
    
    void Start()
    {
        //自身の座標情報
        ThisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (in_area = Player_In_Area(ThisTransform, Main.Playable().transform))
        {
            Debug.Log("敵の範囲内に入りました");
        }

        //
    }

    bool Player_In_Area(Transform enemy, Transform player)
    {
        //範囲は円形範囲で、半径はとりあえず仮で決めた。
        dis = Vector3.Distance(enemy.position, player.position);

        //敵が攻撃をするのは範囲内
        if(dis < 5f)
        {
            //敵が移動するのは範囲内であるときだが、一定まで近づけば移動しなくていい
            if (dis > 1f)
            {
                //とりあえずスピードは１ｆにしている操作キャラに向かうベクトルを元に座標を代入
                //現時点では直線的、単調に向かっていくだけなのでご了承ください
                enemy.position =
                    Vector3.MoveTowards(enemy.position, player.position, 1f * Time.deltaTime);
            }
            return true;
        }

        return false;
    }
}
