using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スロット使わなくてよい

public class EnemyAttack : MonoBehaviour
{
    //敵キャラも操作キャラと同じスキル管理で攻撃技を設計する
    //SkillSlotManagerとPlayerのコード参考

    //statusはどこで設定する？
    public StatusManager.Status status;

    //技はとりあえず3種類は使えるようにした。個数の変更検討。
    private const int nubmer_of_skills = 3;

    //技の範囲はそれぞれ異なるため変更可能にする。
    [SerializeField] float [] skill_area = new float[nubmer_of_skills];
    //技のクールタイム
    [SerializeField] float [] cooltime = new float[nubmer_of_skills];
    //技
    [SerializeField] ISkill[] skills = new ISkill[nubmer_of_skills];

    float dis;

    void Start()
    {
        //enemy = GetComponent<Player>();
    }
    void Update()
    {
        dis = GetComponent<EnemyMove>().dis;

        //スキル及びスキルの範囲は小さい順に設定してくれたらありがたい。
        if (dis < skill_area[0])
        {
            StartCoroutine(Enemy_Attack(0));
        }
        else if (dis < skill_area[1])
            { StartCoroutine(Enemy_Attack(1)); }
        else
        {
            StartCoroutine(Enemy_Attack(2));
        }
    }

    //クールタイムごとに技を繰り出す
    IEnumerator Enemy_Attack
        (int what_skill)
    {
        Debug.Log("Enemy Attacked" +  what_skill);

        yield return new WaitForSeconds(cooltime[what_skill]);
        
    }
}
