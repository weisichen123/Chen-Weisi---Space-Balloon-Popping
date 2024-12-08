using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float moveSpeed = 3f; 
    private Vector2 screenBounds;
    private float moveDirection = 1f; 

    void Start()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
      
        transform.Translate(new Vector2(moveDirection, 0) * moveSpeed * Time.deltaTime);

        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x)
        {
            moveDirection = -moveDirection;
        }
    }


    public void OnHitByPin()
    {
        GameManager.Instance.GameOver(); 
        Destroy(gameObject); 
    }
}
