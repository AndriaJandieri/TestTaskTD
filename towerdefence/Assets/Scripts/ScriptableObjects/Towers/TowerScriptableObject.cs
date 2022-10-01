using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Tower_Color", menuName = "Tower")]
public class TowerScriptableObject : ScriptableObject
{
    public int towerPrice;
    public float towerAttackRange;
    public float towerShootInterval;
    public float towerDamage;    
}
