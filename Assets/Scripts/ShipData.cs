using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Ship")]
public class ShipData : ScriptableObject
{
 
    public int health;
    public float speed;
    public float fireRate;
    public Vector2 initialPosition;
    public Sprite mainsprite;
    public GameObject projectilePrefab;
}
