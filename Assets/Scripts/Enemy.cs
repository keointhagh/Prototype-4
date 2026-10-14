using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 2f;
    private Rigidbody enemyRb;
    private GameObject player;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        if (transform.position.y < -10) Destroy(gameObject);
    }
}
