using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test_skill : MonoBehaviour, ISkill
{
    public string motionName { get; } = "testSkill";
    public float skillCoef { get; } = 1.0f;
    public float SPCost { get; } = 1.0f;
    public SpriteRenderer icon { get; }


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
