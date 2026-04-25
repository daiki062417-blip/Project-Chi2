using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤークラスを作ったら抽象クラスにする 
public class Character : MonoBehaviour
{
    [SerializeField] string name;
    StatusManager.Status status;
}
