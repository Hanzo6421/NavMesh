using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public float wanderRaduis = 10f;
    public float wanderTimer = 5f;

    private NavMeshAgent agent;
    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRaduis, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
        }
}
