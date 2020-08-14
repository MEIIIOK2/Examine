using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileData data;
     
    private void Start()
    {
        
        GetComponent<SpriteRenderer>().sprite = data.sprite;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * data.speed);
        if (transform.position.y>20)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag !="Player")
        {
            Destroy(gameObject);
            Asteroid.AsteroidOutOfBounds(collision.collider.gameObject);

            Gamemanager.score += 1;
        }
        
    }

}
