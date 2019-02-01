using UnityEngine;

public class Fan : MonoBehaviour
{
    private GameObject fanObject;
    private Rigidbody2D playerRigidBody;

    public float forceFactor = 1;
    private bool isActive;

    private void Start()
    {
        fanObject = transform.parent.gameObject;
    }

    void Update()
    {
        if (isActive)
        {
            playerRigidBody.AddForce(-forceFactor * playerRigidBody.velocity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = false;
        }
    }
}
