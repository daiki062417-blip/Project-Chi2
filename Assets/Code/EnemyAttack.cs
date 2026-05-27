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
    Player enemy;

    //技はとりあえず3種類は使えるようにした。個数の変更検討。
    private const int nubmer_of_skills = 3;

    //技の範囲はそれぞれ異なるため変更可能にする。
    [SerializeField] float [] skill_area = new float[nubmer_of_skills]
        {1, 3, 10};

    //技の範囲が狭い順にスキルを入れるようにしてほしい。
    //[SerializeField] ISkill[] skills = new ISkill[nubmer_of_skills]

    [SerializeField] test_skill[] skills = new test_skill [nubmer_of_skills];

    float dis;

    bool can_use_skill;

    void Start()
    {
        can_use_skill = true;
    }
    void Update()
    {
        dis = GetComponent<EnemyMove>().dis;

        if(can_use_skill)
        ChoiseSkill(dis, nubmer_of_skills);
    }

    void ChoiseSkill(float dis, int n_skill)
    {
        for (int i = 0; i < n_skill; i++)
        {
            if (skill_area[i] > dis)
            {
                //実際のスキルプロセスができるまでコメントアウト
                //StartCoroutine(skills[i].SkillProcess(enemy));

                Debug.Log("敵スキル" + i +
                    "発動。クールタイム ： " + 3f);
                StartCoroutine(CoolTimeCoroutine(3f));

                break;
            }
        }
        return;
    }

    IEnumerator CoolTimeCoroutine(float cooltime)
    {
        can_use_skill = false;

        yield return new WaitForSeconds(cooltime);

        can_use_skill = true;
    }
}
