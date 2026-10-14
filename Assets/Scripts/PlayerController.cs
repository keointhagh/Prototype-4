using UnityEngine;
using Unity.Collections;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private InputSystem_Actions controls;
    public float playerSpeed = 150f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup = false;
    public float powerupStrength = 15f;
    public GameObject powerupIndicator;

    private void Awake()
    {
        controls = new InputSystem_Actions();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        //transform.Rotate(Vector3.up, moveInput.y * rotationSpeed * Time.deltaTime);
        playerRb.AddForce(focalPoint.transform.forward * moveInput.y * playerSpeed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position;
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRg = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRg.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            //Debug.Log("Collided with enemy");
        }
    }
}
