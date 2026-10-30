using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;

    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool isWaiting;

    void Start()
    {
        if (waypointParent == null)
        {
            Debug.LogError("Waypoint Parent is not assigned!");
            return;
        }

        waypoints = new Transform[waypointParent.childCount];

        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    void Update()
    {
        if (isWaiting)
        {
            return;
        }

        if (waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitForWaypoint());
        }
    }

    IEnumerator WaitForWaypoint()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        if (loopWaypoints)
        {
            currentWaypointIndex =
                (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            currentWaypointIndex =
                Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
        }

        isWaiting = false;
    }
}