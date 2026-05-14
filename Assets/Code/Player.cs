using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] SkillSlotManager slotManager;
    Player player;
    float sp = 0;
    [SerializeField]float spSpeed;
    public StatusManager.Status status;
    bool almost;
  

    public void SetUp()
    {
        player = GetComponent<Player>();

        status = StatusManager.CreateStatus(
            maxSP:8
        );
        Debug.Log("maxSP��" + status.maxSP);
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
     }

    public void ActivatedSkill(SkillSlotManager.Button button)
    {
        ISkill skill = null;

        skill = slotManager.GetSkill(button);

        // ���[�V�������s

        // �Z����
        StartCoroutine(skill.SkillProcess(player));
    }
    public void SpRestore()
    {
        if (sp < status.maxSP)
        {
            sp += spSpeed;
            Debug.Log("���݂�sp��" + sp);
            if (sp == status.maxSP)
            {
                almost = true;
            }
        }
        if(almost)
        {
            Debug.Log("sp����ɒB���܂���");
            almost = false;
        }
    }
}
