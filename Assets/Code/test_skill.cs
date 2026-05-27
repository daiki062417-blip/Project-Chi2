using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test_skill : MonoBehaviour, ISkill
{
    public string MotionName { get; } = "testSkill";
    public float SkillCoef { get; } = 1.0f;
    public float SPCost { get; } = 1.0f;
    public SpriteRenderer Icon { get; }
    public float Cooltime { get; } = 3f;


    public IEnumerator SkillProcess(Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("test Count : " + i);
            yield return null;

        }

        yield break;
    }
}
