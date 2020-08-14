using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private AsteroidData data;
    public void Init(AsteroidData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.mainSprite;
    }
    public static Action<GameObject> AsteroidOutOfBounds;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * data.speed);
        if (transform.position.y<=-10 && AsteroidOutOfBounds !=null)
        {
            AsteroidOutOfBounds(gameObject);
        }
    }
}
