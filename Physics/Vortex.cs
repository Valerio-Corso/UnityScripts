using UnityEngine;

public class Vortex : MonoBehaviour
{

    public float force = 0.5f;

    Rigidbody2D playerRigidBody;
    bool isActive;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            var vortexForce = force;

            //Reduce force
            if (playerRigidBody.GetComponent<playerStats>().vortexShield)
            {
                vortexForce = vortexForce * 0.6f;
            }

            Vector2 dir = gameObject.transform.position - playerRigidBody.transform.position;

            playerRigidBody.AddForce(dir.normalized * vortexForce, ForceMode2D.Force);
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
