using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] SkillSlotManager slotManager;
    Player player;
    float sp = 0;
    [SerializeField] float spSpeed;

    [Header("レベルアップ時の上昇量")]
    [SerializeField]
    List<StatusManager.LevelUpData> levelUpTable = new();

    bool almost;
    int level = 1;
    int current_level = 1;

    public Weapon weapon;


    public void SetUp()
    {
        player = GetComponent<Player>();

        status = StatusManager.CreateStatus(
            maxSP: 8
        );
        Debug.Log("maxSPは" + status.maxSP);
    }

    private void Start()
    {
        SetUp();

        StartCoroutine(SpRestoreCoroutine());
    }

    IEnumerator SpRestoreCoroutine()
    {
        while (true)
        {
            SpRestore();

            yield return new WaitForSeconds(3f);
        }
    }


    public void ActivatedSkill(SkillSlotManager.Button button)
    {
        ISkill skill = null;

        skill = slotManager.GetSkill(button);

        // モーション実行

        // 技発動
        StartCoroutine(skill.SkillProcess(player));
    }
    public void SpRestore()
    {
        if (sp < status.maxSP)
        {
            sp += spSpeed;
            Debug.Log("現在のspは" + sp);
            if (sp == status.maxSP)
            {
                almost = true;
            }
        }
        if (almost)
        {
            Debug.Log("sp上限に達しました");
            almost = false;
        }
    }

    public void GrowingCharacter()
    {
        while (current_level < level)
        {
            int tableIndex = current_level - 1;

            if (tableIndex < levelUpTable.Count)
            {
                var growth = levelUpTable[tableIndex];

                status = StatusManager.SumStatus(
                    status,
                    StatusManager.CreateStatus(
                        HP: growth.HP,
                        power: growth.power,
                        defense: growth.defense,
                        criticalRate: growth.criticalRate,
                        maxSP: growth.maxSP,
                        speed: growth.speed
                    )
                );
            }

            current_level++;
        }
    }
    public void LevelUp()
    {
        level++;

        GrowingCharacter();

        Debug.Log($"Lv.{level}になった！");
        StatusManager.ShowStatus(status);
    }
}