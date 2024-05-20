using UnityEngine;

public class WaypointAssignment : MonoBehaviour
{
    private Transform waypoint1, waypoint2;
    public GameObject  slime;

    void Start()
    {


        float[] validYPositions = { -5.7827f, -6.7453f, -8.0286f };

        int randomNumber = Random.Range(1, 4);

        slime.transform.position = new Vector3(4.9f, validYPositions[randomNumber-1], 0f);

        // Asignar las posiciones de los waypoints
        waypoint1 = gameObject.transform.GetChild(1);
        waypoint2 = gameObject.transform.GetChild(2);
        if (waypoint1 != null && waypoint2 != null)
        {
            waypoint1.transform.position = new Vector3(4, slime.transform.position.y, 0);
            waypoint2.transform.position = new Vector3(2.5f, slime.transform.position.y, 0);
        }
    }

    void Update()
    {

        if (transform.GetChild(0).name != "Slime")
        {
            Destroy(gameObject);
        }
    }
}
