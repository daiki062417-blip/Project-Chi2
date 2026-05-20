using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //敵キャラも操作キャラと同じスキル管理で攻撃技を設計する
    //SkillSlotManagerとPlayerのコード参考
    [SerializeField] SkillSlotManager slotManager;
    Player enemy;
    //statusはどこで設定する？
    public StatusManager.Status status;

    //技はとりあえず3種類は使えるようにした。変更検討。
    private const int nubmer_of_skills = 3;

    //技の範囲はそれぞれ異なるため変更可能にする。
    [SerializeField] float [] skill_area = new float[nubmer_of_skills];
    //技のクールタイム
    [SerializeField] float [] skill_cooltime = new float[nubmer_of_skills];
    //技
    [SerializeField] ISkill[] skills = new ISkill[nubmer_of_skills];

    //private SkillSlotManager.Button button;

    float dis;

    void Start()
    {
        //enemy = GetComponent<Player>();
        dis = GetComponent<EnemyMove>().dis;

        //敵に技をセット
        for (int i = 0; i < nubmer_of_skills; i++)
        {
            slotManager.SetSkill(skills[i], (SkillSlotManager.Button)i);
        }

        StartCoroutine(Enemy_Attack((SkillSlotManager.Button)0, skill_cooltime[0], skill_area[0]));

    }
    void Update()
    {
        dis = GetComponent<EnemyMove>().dis;
    }

    //数秒ごとに技を繰り出す
    IEnumerator Enemy_Attack
        (SkillSlotManager.Button what_skill, float cooltime, float area)
    {
        Debug.Log("Enemy_Attack");

        //敵の技範囲内に操作キャラがいれば
        while (true)
        {

            if (area > dis)
            {
                Attack(what_skill);
                yield return new WaitForSeconds(cooltime);
            }

            yield return null;
        }
    }
    

    public void Attack(SkillSlotManager.Button what_skill)
    {
        Debug.Log("Enemey Attacked" +  what_skill);

        //スキル実装するまでコメントアウト
        //ISkill skill = slotManager.GetSkill(what_skill);

        //モーション実行

        //技発動
        //StartCoroutine(skill.SkillProcess(enemy));
    }
}
