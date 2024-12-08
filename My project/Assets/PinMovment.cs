using UnityEngine;
using System.Collections;

public class PinMovement : MonoBehaviour
{
    public float speed = 10f; 
    private bool isMoving = false; 

    public float spawnInterval = 2f; 
    public GameObject pinPrefab; 
    public Transform spawnPoint; 

    private void Start()
    {
        
        StartCoroutine(SpawnPinCoroutine());
    }

    private void Update()
    {
        if (isMoving)
        {
          
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("碰撞物体名称: " + collision.gameObject.name + ", 标签: " + collision.gameObject.tag);

        if (collision.CompareTag("Bird"))
        {
            Debug.Log("Pin 碰到飞鸟，游戏结束！");
            GameManager.Instance.GameOver(); 
            Destroy(gameObject); 
        }
        else if (collision.CompareTag("Balloon"))
        {
            Debug.Log("Pin 碰到气球");
            BalloonMovement balloon = collision.GetComponent<BalloonMovement>();
            if (balloon != null)
            {
                balloon.OnPinHit(); 
            }
            Destroy(gameObject); 
        }
    }

    
    IEnumerator SpawnPinCoroutine()
    {
        while (true) 
        {
            Instantiate(pinPrefab, spawnPoint.position, Quaternion.identity);

          
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

