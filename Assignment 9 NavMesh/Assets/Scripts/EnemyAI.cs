/*
 * Gerard Lamoureux
 * Assignment 9
 * Handles Enemy AI Movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public GameObject player;
    public float chaseDistance;
    private void Start()
    {
        character = GetComponent<ThirdPersonCharacter>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        player = GameObject.FindGameObjectWithTag("Player");
        chaseDistance = 8.0f;
    }
    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);
        if(distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}
