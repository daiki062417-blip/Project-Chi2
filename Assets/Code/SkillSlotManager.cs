using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class SkillSlotManager : MonoBehaviour
{
    Dictionary<Button, SkillSlot> skillSlots = new();

    public enum Button
    {
        b1,
        b2,
        b3,
        buttonCount,    // ボタン総数
    }

    // Start is called before the first frame update
    public void SetUp()
    {
        // スロット取得
        var childrenList = transform.GetComponentsInChildren<SkillSlot>();

        for(int i = 0; i < (int)Button.buttonCount; i++)
        {
            skillSlots.Add((Button)i, childrenList[i]);            
        }

    }

    /// <summary>
    /// 指定スロットへ技をセットする
    /// </summary>
    /// <param name="skill">セットする技</param>
    /// <param name="button">スロット位置</param>
    public void SetSkill(ISkill skill, Button button)
    {
        // 技セット
        var slot = skillSlots[button];
        slot.mySkill = skill;

        Debug.Log("[SkillSlotManager] SetSkill name : " + slot.mySkill.motionName);

        // アイコンセット処理
            //ここにアイコンセット処理を記述
    }

    /// <summary>
    /// 指定スロットの技を返す
    /// </summary>
    /// <param name="button">スロット位置</param>
    /// <returns>セットされた技</returns>
    public ISkill GetSkill(Button button)
    {
        return skillSlots[button].mySkill;
    }
}
