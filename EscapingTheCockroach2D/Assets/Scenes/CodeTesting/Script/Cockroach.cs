using UnityEngine;
using System.Collections;

public class Cockroach : MonoBehaviour
{
    public float npcSpeed = 7f; // The speed
    public Transform player; // For tracking the player
    public float dectRange; // The range needed to detect the player
    public Transform[] waypoints; // An array for the npc to walk around and patrol while not in view of the player
    public float patrolSpeed = 2f; // Its pratrol speed when the player isn't detected
    enum State {Patrol, Chase} // The two state the npc can be in
    State state = State.Patrol;// Default chase to be on patrol 
    int current = 0; //index for the waypoint
    public float stopDistance = 1f;
    public bool playerEaten;
    public bool playerEatenHiding;
    public GameObject Player;
    public GameObject Hiding;
    public GameObject Closet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, npcSpeed * Time.deltaTime);
        switch(state)
        {
            case State.Patrol:
                Patrol();
                if(PlayerInRange() && !Hiding.activeInHierarchy)
                {
                    state = State.Chase;
                    
                }
                break;
            case State.Chase:
                Chase();
                if(!PlayerInRange())
                {
                    state =  State.Patrol;
                    
                }
                break;
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
        if (playerEaten)
        {
            Destroy(Player);
        }else if ((playerEatenHiding && Hiding.activeInHierarchy && (state == State.Chase)))
        {
            Hiding.SetActive(false);
            Closet.SetActive(true);
            Player.SetActive(true);

            
        }
        //Flip(player.position.x);
    }
   /** void Flip(float targetX)
    {
        float dir = targetX < transform.position.x ? -1f : 1f;
        transform.localScale = new Vector3(dir, 1f, 1f);
   **/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEaten = true;
        }
        if(collision.CompareTag("HidingPlayer"))
        {
            playerEatenHiding = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEaten = false;
        }
    }
}
