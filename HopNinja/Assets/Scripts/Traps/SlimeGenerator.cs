using Unity.VisualScripting;
using UnityEngine;

public class SlimeGenerator : MonoBehaviour
{
    public GameObject SlimeEnemy;
    public Transform killablesTransform; // Reference to the "Killables" empty object
    public int count;
    private float time = 0f;
    private float topTime;
    public int cap = 7; // Adjust the cap if needed

    void Start()
    {
        topTime = Random.Range(1f, 5f);

        // Assuming the "Killables" object is a child of this script's GameObject
        killablesTransform = transform.Find("Killables");

        // If "Killables" is not found as a child, try to find it in the scene
        if (killablesTransform == null)
        {
            killablesTransform = GameObject.Find("Killables").transform;
        }

        // Count existing "SlimeEnemy" children in "Killables"
        
    }

    void FixedUpdate()
    {
        count = CountSlimeEnemies();
        if (time >= topTime && count < cap)
        {
            SpawnSlime();
            time = 0f;
            topTime = Random.Range(1f, 5f);
            count++;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    void SpawnSlime()
    {

        if (killablesTransform != null)
        {
            Instantiate(SlimeEnemy, killablesTransform.position, Quaternion.identity, killablesTransform);
        }
    }

    int CountSlimeEnemies()
    {
        if (killablesTransform == null)
        {
            return 0; 
        }

        int slimeCount = 0;
        foreach (Transform child in killablesTransform)
        {
            if (child.name.StartsWith("SlimeEnemy"))
            {
                slimeCount++;
            }
        }
        return slimeCount;
    }
}
