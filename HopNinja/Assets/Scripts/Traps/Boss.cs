using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject toDestroy;

    private float disableTime;
    private float enableTime;
    private bool isObject1Active = true;
    private bool isObject2Active = true;
    public Animator animator;

    private int health = 10;

    void Start()
    {
        disableTime = Random.Range(2f, 5f);
        enableTime = Random.Range(2f, 5f);

        StartCoroutine(ManageObjectStates());
    }

    IEnumerator ManageObjectStates()
    {
        while (true)
        {
            GameObject objectToDisable = Random.Range(0, 2) == 0 ? object1 : object2;

            if (objectToDisable == object1)
            {
                isObject1Active = false;
                object1.SetActive(false);
            }
            else
            {
                isObject2Active = false;
                object2.SetActive(false);
            }

            yield return new WaitForSeconds(disableTime);

            if (!isObject1Active)
            {
                isObject1Active = true;
                object1.SetActive(true);
            }
            else
            {
                isObject2Active = true;
                object2.SetActive(true);
            }

            yield return new WaitForSeconds(enableTime);

            disableTime = Random.Range(2f, 5f);
            enableTime = Random.Range(2f, 5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            health--;
            animator.Play("HitAnimation");

            if (health <= 0)
            {
                animator.Play("HitAnimation");
                Destroy(transform.parent.gameObject);
                Destroy(toDestroy);
            }
        }
    }
}
