using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    public string typeName;
    public int health;
    public float speed;
    public int damage;
    public int scoregiven;
    public int moneyDropped;
}
