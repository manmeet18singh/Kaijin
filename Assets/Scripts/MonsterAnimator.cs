using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAnimator : MonoBehaviour
{
    const float locoAnimationSmoothTime = .1f;
    Animator animator;
    NavMeshAgent agent;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }  

    void Update()
    {
        // float speedPercent = agent.velocity.magnitude / agent.speed;
        // animator.SetFloat("speedPercent", speedPercent, locoAnimationSmoothTime, Time.deltaTime);
    }
}
