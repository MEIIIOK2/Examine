using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Text scoretext;
    [SerializeField]
    private ShipData data;
    [SerializeField] private int health;
    [SerializeField] private Joystick joystick;
    
    private Vector3 movevector = new Vector3();

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
        health = data.health;
        text.text = $"HP: {health}";
        GetComponent<SpriteRenderer>().sprite = data.mainsprite;

        transform.position = data.initialPosition;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var _firerate = data.fireRate;
        if (_firerate==0)
        {
            _firerate = 1;
        }
        while (true)
        {
            Instantiate(data.projectilePrefab, transform.position + Vector3.up/2, Quaternion.identity);
            yield return new WaitForSeconds(_firerate);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
#if UNITY_ANDROID
        movevector.x = joystick.Horizontal;
        movevector.y = joystick.Vertical;
#endif

#if UNITY_EDITOR
        movevector.x = Input.GetAxis("Horizontal");
        movevector.y = Input.GetAxis("Vertical");
#endif
        transform.position += movevector * data.speed;
        Vector3 clPos = transform.position;
        clPos.x = Mathf.Clamp(clPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        clPos.y = Mathf.Clamp(clPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = clPos;
        scoretext.text = $"Score: {Gamemanager.score}";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        health -= 1;
        text.text = $"HP: {health}";
        Asteroid.AsteroidOutOfBounds(collision.collider.gameObject);
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }

}
