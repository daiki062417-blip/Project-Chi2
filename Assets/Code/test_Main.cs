using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Main : MonoBehaviour
{
    
    [SerializeField] SkillSlotManager slotManager;

    // Start is called before the first frame update
    void Start()
    {
        slotManager.SetUp();
        GetComponent<Player>().SetUp();

        var skill = GetComponent<ISkill>();
        slotManager.SetSkill(skill, SkillSlotManager.Button.b1);

        GetComponent<Player>().ActivatedSkill(SkillSlotManager.Button.b1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
