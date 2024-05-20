using UnityEngine;

public class ActivateRockHead : MonoBehaviour
{
    bool stoped = false;
    bool timerOn = false;
    float time = 0f;
    public BoxCollider2D boxCollider;
    public GameObject player;

    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma") && !timerOn)
        {
            timerOn = true;
            stoped = false;
        }

        if (collision.CompareTag("Breakable"))
        {
            stoped = true;
        }
    }

    private void FixedUpdate()
    {
        if (timerOn && !stoped)
        {
            time += Time.deltaTime;

            // Obtener la velocidad del jugador y mover el objeto en consecuencia
            float playerSpeed = player.GetComponent<PlayerMove>().runSpeed;
            Vector3 newPosition = transform.position + new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
            transform.position = newPosition;

            if (time >= 4f)
            {
                timerOn = false;
                time = 0;
                transform.position = initialPosition;
            }
        }

        if (stoped)
        {
            Debug.Log("stoped");

            time += Time.deltaTime;
            if (time >= 4f)
            {
                timerOn = false;
                time = 0;
                transform.position = initialPosition;
            }
        }
    }
}
