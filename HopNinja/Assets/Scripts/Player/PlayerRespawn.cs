using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{

    private float checkPointPositionx;
    private float checkPointPositiony;
    public float checkCP = 0;
    public Text timer;
    public Animator animator;

    void Start()
    {

        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetFloat("checkPointPositionx", 0);
        PlayerPrefs.SetFloat("checkPointPositiony", 0);




    }

    public void PlayerDamaged()
    {
        if (PlayerPrefs.GetInt("SpR") == 1)
        {
            timer.GetComponent<Timer>().end();
        }
        animator.Play("HitAnimation");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("checkPointPositionx", 0);
        PlayerPrefs.SetFloat("checkPointPositiony", 0); 
    }

}
