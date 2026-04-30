using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] SkillSlotManager slotManager;
    Player player;
  
    public void SetUp()
    {
        player = GetComponent<Player>();
    }

    public void ActivatedSkill(SkillSlotManager.Button button)
    {
        ISkill skill = null;
        
        skill = slotManager.GetSkill(button);

        // ƒ‚[ƒVƒ‡ƒ“Às

        // ‹Z”­“®
        StartCoroutine(skill.SkillProcess(player));
    }
}
