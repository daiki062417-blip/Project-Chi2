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
        if (in_area = MoveToTarget(ThisTransform, Main.Playable().transform, 5f, 1f))
        {
            //Debug.Log("敵の範囲内に入りました");
        }

        //
    }

    bool MoveToTarget(Transform me, Transform target, float search_dis, float enough_dis)
    {
        //範囲は円形範囲で、半径はとりあえず仮で決めた。
        dis = Vector3.Distance(me.position, target.position);

        //敵が攻撃をするのは範囲内(search_dis は索敵範囲)
        if(dis < search_dis)
        {
            //敵が移動するのは範囲内であるときだが、一定まで近づけば移動しなくていい
            //enough_disは対象に移動するまでのノルマ
            if (dis > enough_dis)
            {
                //とりあえずスピードは１ｆにしている操作キャラに向かうベクトルを元に座標を代入
                //現時点では直線的、単調に向かっていくだけなのでご了承ください
                me.position =
                    Vector3.MoveTowards(me.position, target.position, 1f * Time.deltaTime);
            }
            return true;
        }

        return false;
    }
}
