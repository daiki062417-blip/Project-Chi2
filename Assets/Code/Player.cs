using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] SkillSlotManager slotManager;
    Player player;
    float sp = 0;
    [SerializeField] float spSpeed;
    public StatusManager.Status status;
    bool almost;

    public Weapon weapon;


    public void SetUp()
    {
        player = GetComponent<Player>();

        status = StatusManager.CreateStatus(
            power: 3,
            criticalRate: 0.1f,
            maxSP: 8
        );
        Debug.Log("maxSPは" + status.maxSP);
    }

    private void Start()
    {
        SetUp();

        StartCoroutine(SpRestoreCoroutine());
    }

    //--------------------------------
    //          スキル発動
    //--------------------------------


    public void ActivatedSkill(SkillSlotManager.Button button)
    {
        ISkill skill = null;

        skill = slotManager.GetSkill(button);

        // モーション実行

        // 技発動
        StartCoroutine(skill.SkillProcess(player));
    }

    //--------------------------------
    //           SP回復
    //--------------------------------

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

    IEnumerator SpRestoreCoroutine()
    {
        while (true)
        {
            SpRestore();

            yield return new WaitForSeconds(3f);
        }
    }
}