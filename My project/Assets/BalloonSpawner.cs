using UnityEngine;
using System.Collections.Generic; 

public class BalloonSpawner : MonoBehaviour
{
    public static BalloonSpawner Instance;

    public GameObject balloonPrefab; 
    public float baseSpawnRate = 2f; 
    public int maxBalloons = 10;     
    private List<GameObject> activeBalloons = new List<GameObject>(); 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

      void Start()
    {
        // currentSpawnRate = baseSpawnRate;
        InvokeRepeating(nameof(SpawnBalloon), baseSpawnRate, baseSpawnRate);
    }

    public void SetSpawnRateForLevel(int level)
    {
        // currentSpawnRate = baseSpawnRate / level; 
        CancelInvoke(nameof(SpawnBalloon));
        InvokeRepeating(nameof(SpawnBalloon), baseSpawnRate, baseSpawnRate);
    }

    void SpawnBalloon()
    {
        if (balloonPrefab != null)
        {
            Instantiate(balloonPrefab, Vector3.zero, Quaternion.identity);
            
        }


    }

} 




