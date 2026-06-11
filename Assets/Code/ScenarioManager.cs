using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �V�i���I�̃t���O�Ď��A���[�h�A�I����̏������s���N���X�B
/// </summary>
public class ScenarioManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    /// <summary>
    /// �V�i���I�����t���O�̊Ď�
    /// </summary>
    /// <param name="flag">�V�i���I�����t���O</param>
    /// <returns>�������邩</returns>
    public bool  ObserveFlag(Scenario.ScenarioFlag flag)    // �e�X�g�p��public�ɂ��Ă���B
    {
        // ���茋��
        var result = true;

        // �w��ʒu���B���ɔ�������t���O
        if(flag.posDetecter != null)
        {
            // �w��L�����ƈ�v���邩
            if (flag.detectedPlayer != null && flag.posDetecter.DetectPlayer() != flag.detectedPlayer)
                result = false;
        }

        // �O��V�i���I���N���A������
        if(flag.premiseScenario != null)
        {
            if(!flag.premiseScenario.isFinished)
                result = false;
        }

        if(flag.premiseQuest != null)
        {
            if(flag.premiseQuest.isFinished)
                result = false;
        }

        if(flag.keyItems != null)
        {
            foreach(var pair in flag.keyItems)
                if (!inventory.HaveItem(pair.Key, pair.Value))
                {
                    result = false;
                    break;
                }
        }

        return false;
    }
}
