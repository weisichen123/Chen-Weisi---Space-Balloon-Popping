using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public static BalloonMovement Instance;

    public float moveSpeed = 5f;
    public float moveDirection = 1f;

    private Vector2 screenBounds;
    private AudioSource audioSource;
    public float growthRate = 0.1f;
    public float growthInterval = 1f;
    public float maxSize = 0.5f;
    public int baseScore = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(GrowBalloon), growthInterval, growthInterval);
    }

    void Update()
    {
        transform.Translate(new Vector2(moveDirection, 0) * moveSpeed * Time.deltaTime);

        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x)
        {
            moveDirection = -moveDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pin"))
        {
            if (transform.localScale.x >= maxSize)
            {
                Destroy(gameObject);
                return;
            }

            if (audioSource != null)
            {
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            }

            float sizeMultiplier = 1f / transform.localScale.x;
            int score = Mathf.RoundToInt(baseScore * sizeMultiplier);

            GameManager.Instance.AddScore(score);
            Destroy(gameObject);
        }
    }

    void GrowBalloon()
    {
        if (transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
            return;
        }

        transform.localScale += new Vector3(growthRate, growthRate, 0);
    }

    public void AdjustForLevel(int level)
    {
        
        moveSpeed += level; 
        growthRate += 0.05f * level; 
        maxSize -= 0.1f * level; 
    }

    public void OnPinHit()
    {
        Debug.Log("Balloon hit by Pin!");

        if (transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
            return;
        }

        if (audioSource != null)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        }

        float sizeMultiplier = 1f / transform.localScale.x;
        int score = Mathf.RoundToInt(baseScore * sizeMultiplier);

        GameManager.Instance.AddScore(score);
        Destroy(gameObject); 
    }
}





