using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public Image icon;
    public Image iconOff;
    public Animator animator;
    public GameObject player;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb2D;
    BoxCollider2D boxCollider;
    public bool isTaken = false;
    private float slightOffset = 0.3f;
    float wait;
    float time = 0f;
    float timeA = 0f;
    bool timerOn = false;
    bool right = false;
    public Text text;
    bool alert = false;
    private float playerYPosition;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        icon.gameObject.SetActive(false);
        iconOff.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject.transform.GetChild(0).gameObject, 0.5f);
            icon.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            isTaken = true;
            boxCollider.isTrigger = false;
            boxCollider.enabled = false;
            if (text != null)
            {
                text.gameObject.SetActive(true);
            }
            alert = true;
        }
    }

    private void FixedUpdate()
    {
        if (alert && text != null)
        {
            if (timeA >= 2)
            {
                alert = false;
                text.gameObject.SetActive(false);
            }
            else
            {
                timeA += Time.deltaTime;
            }
        }

        if (isTaken && Input.GetKey("g"))
        {
            icon.gameObject.SetActive(true);
            timerOn = true;
            GetComponent<SpriteRenderer>().enabled = true;
            boxCollider.enabled = true;
            animator.Play("AbilityAnimation");
            isTaken = false;
            playerYPosition = player.transform.position.y;
            if (player.GetComponent<PlayerMove>().flipx)
            {
                transform.position = player.transform.position + new Vector3(-slightOffset, 0f, 0f);
                right = false;
            }
            else
            {
                transform.position = player.transform.position + new Vector3(slightOffset, 0f, 0f);
                right = true;
            }
        }

        if (timerOn)
        {
            icon.gameObject.SetActive(false);
            iconOff.gameObject.SetActive(true);
            Vector3 newPosition = transform.position;
            newPosition.y = playerYPosition;
            transform.position = newPosition;
            time += Time.deltaTime;
            if (!right)
            {
                rb2D.velocity = new Vector2(-player.GetComponent<PlayerMove>().runSpeed, player.GetComponent<PlayerMove>().rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(player.GetComponent<PlayerMove>().runSpeed, player.GetComponent<PlayerMove>().rb2D.velocity.y);
            }

            if (time >= 3)
            {
                timerOn = false;
                isTaken = true;
                GetComponent<SpriteRenderer>().enabled = false;
                boxCollider.enabled = false;
                time = 0f;
            }
        }
        else if (!timerOn && isTaken)
        {
            icon.gameObject.SetActive(true);
            iconOff.gameObject.SetActive(false);
            
        }   
    }
}
