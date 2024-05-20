using System.Collections;
using UnityEngine;

public class AIBasic : MonoBehaviour
{

    //public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float waitTime;
    public Transform[] moveSpots;   
    public float startWaitTime = 2;
    private int i = 0;
    private Vector2 actualPos;
    private bool hit = false;


    void Start()
    {
        waitTime = startWaitTime;
    }


    void Update()
    {
        StartCoroutine(CheckEnemyMoving());
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f || hit == true)
        {
            if (waitTime <= 0 || hit == true)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                hit = false;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x >  actualPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else if(transform.position.x < actualPos.x) 
        {
            spriteRenderer.flipX=false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Breakable"))
        {
            hit = true;
        }
    }
}
