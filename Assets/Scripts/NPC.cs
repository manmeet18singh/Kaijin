using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // private NavMeshAgent = _agent;
    public GameObject player;
    public float npcRunDistance = 4.0f;

    void Start()
    {
        // _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        
        // Run away from the player
        if(dist < npcRunDistance) {
            Vector3 distToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + distToPlayer;
            // _agent.SetDestination(newPos);
        }
    }
}
