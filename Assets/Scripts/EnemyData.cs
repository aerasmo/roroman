using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData", order = 0)]
public class EnemyData : ScriptableObject
{
    public new string name;
    public int health;
    public int bounty;
    public float speed;

    [SerializeField]
    public Transform[] routes;
}
