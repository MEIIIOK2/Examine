using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroidspawner : MonoBehaviour
{
    public Asteroid asteroid;
    [SerializeField] private List<AsteroidData> asteroidSettings;

    [SerializeField] private int poolLength;

    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private float spawnRate;
    
    public  Dictionary<GameObject, Asteroid> Asteroids;
    private Queue<GameObject> currentAsteroids;
    private float scrborder;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        
        scrborder = Camera.main.aspect * Camera.main.orthographicSize;
        Asteroids = new Dictionary<GameObject, Asteroid>();
        currentAsteroids = new Queue<GameObject>();
        for (int i = 0; i < poolLength; i++)
        {
            var prefab = Instantiate(asteroidPrefab);
            var script = prefab.GetComponent<Asteroid>();
            prefab.SetActive(false);
            Asteroids.Add(prefab, script);
            currentAsteroids.Enqueue(prefab);
        }
        Asteroid.AsteroidOutOfBounds += ReturnAsteroid;

        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        if (spawnRate==0)
        {
            Debug.Log("Spawn Rate not set");
            spawnRate = 1;
        }
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            if (currentAsteroids.Count>0)
            {
                var asteroid = currentAsteroids.Dequeue();
                var script = Asteroids[asteroid];
                asteroid.SetActive(true);
                int rand = Random.Range(0, asteroidSettings.Count);
                script.Init(asteroidSettings[rand]);
                float xpos = Random.Range(-scrborder, scrborder);
                asteroid.transform.position = new Vector2(xpos, transform.position.y);
            }
        }
    }
    public void ReturnAsteroid(GameObject aster)
    {
        aster.transform.position = transform.position;
        aster.SetActive(false);
        currentAsteroids.Enqueue(aster);
    }
}
