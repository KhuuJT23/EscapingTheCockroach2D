using UnityEngine;
using System.Collections;

public class Cockroach : MonoBehaviour
{
    public float npcSpeed = 7f;
    public Transform player;
    public float dectRange;
    public Transform[] waypoints;
    public float patrolSpeed = 2f;
    enum State {Patrol, Chase}
    State state = State.Patrol;
    int current = 0;
    public float stopDistance = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, npcSpeed * Time.deltaTime);
        switch(state)
        {
            case State.Patrol:
                Patrol();
                if(PlayerInRange())
                {
                    state = State.Chase;
                    break;
                }
            case State.Chase:
                Chase();
                if(!PlayerInRange())
                {
                    state =  State.Patrol;
                    break;
                }
        }
    }
    bool PlayerInRange()
    {
        float dist = Vector2.Distance(transform.position, player.position);
        return dist < dectRange;
    }
    void Patrol()
    {
        Transform point = waypoints[current];
        transform.position = Vector2.MoveTowards(transform.position, point.position, patrolSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, point.position) < 0.1f)
        {
            current = (current + 1) % waypoints.Length;
        }
    }
    void Chase()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, npcSpeed*Time.deltaTime);


        }
        Filp(player.position.x);
    }
    void Flip()
    {
        float dir = targetX < transform.position.x ? -1f : 1f;
        transform.localScale = new Vector3(dir, 1f, 1f);

    }
}
