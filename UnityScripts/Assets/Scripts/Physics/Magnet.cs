using UnityEngine;

public class Magnet : MonoBehaviour
{
    private LineRenderer beamRenderer;
    private GameObject magnetObject;
    private GameObject player;

    public float forceFactor = 10;
    private bool active;

    private void Start()
    {
        beamRenderer = GetComponent<LineRenderer>();
        magnetObject = transform.parent.gameObject;

        beamRenderer.positionCount = 0;
    }

    void Update()
    {
        if (active)
        {
            var force = forceFactor;

            var playerRigidBody = player.GetComponent<Rigidbody2D>();
            //reduce applied force
            if (player.GetComponent<PlayerStatsController>().HasShield)
            {
                force = force * 0.6f;
            }

            //Attract towards magnet
            playerRigidBody.AddForce((magnetObject.transform.position - player.transform.position) * force * Time.smoothDeltaTime);
            beamRenderer.SetPosition(1, player.GetComponent<Transform>().position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //render line between player and desired object
            player = collision.gameObject;
            beamRenderer.positionCount = 2;
            beamRenderer.SetPosition(0, GetComponent<Transform>().position);
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = false;
            beamRenderer.positionCount = 0;
        }
    }
}
