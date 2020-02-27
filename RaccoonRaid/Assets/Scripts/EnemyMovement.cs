using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemyMovement : MonoBehaviour
{
    public Transform[] pathPoint;
    public GameObject player;
    public float fieldOfViewAngle = 110f;
    public NavMeshAgent agent;

    private bool playerInSight;
    private int i;
    private Transform location;
    
    

    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, pathPoint.Length);
        playerInSight = false;
        location = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        walking();
        chasing();
    }

    void walking()
    {
        Vector3 point = pathPoint[i].position;
        if (!playerInSight)
        {
            agent.speed = 3.5f;
            agent.SetDestination(point);
            if (location.position == point)
            {
                if (i == pathPoint.Length - 1)
                    i = 0;
                else
                    i++;
            }
        }
    }

    void chasing()
    {
        Vector3 direction = player.transform.position - location.position;
        float angle = Vector3.Angle(direction, location.forward);

        if (angle < fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(location.position, direction.normalized, out hit, 10.0f))
            {
                if (hit.collider.gameObject == player)
                {
                    playerInSight = true;
                    agent.speed = 10f;
                    agent.SetDestination(player.transform.position);
                }
            }
        }
        playerInSight = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Object.Destroy(other.gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
