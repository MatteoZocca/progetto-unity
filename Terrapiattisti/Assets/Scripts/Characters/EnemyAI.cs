using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    // Ogni AI possiede questa classe che contiene
    // gli stati da eseguire
    private AIBehaviuor brain;
    // L'oggetto da inseguire
    private Transform target;
    // Oggetto che impone il cammino
    private NavMeshAgent agent;
    // Posizione random corrente
    private Vector3 wanderPosition;

    private float wanderSpeed;
    private float wanderRadius;

    private void Start() {
        this.wanderRadius = 5;
        this.wanderSpeed = 5;
        this.wanderPosition = GetRandomPosition();
        this.brain = new AIBehaviuor();
        this.brain.PushState(Wander);
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        this.agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        brain.Update();
    }

    // Queste funzioni vengono invocate ogni frame
    private void Wander() {
        if (Vector3.Distance(transform.position, wanderPosition) < 0.5f)
            wanderPosition = GetRandomPosition();
        else
            agent.SetDestination(wanderPosition);   
    }

    private void Chase() {

    }

    private Vector3 GetRandomPosition() {
        Vector3 zone = Random.insideUnitSphere * wanderRadius + transform.position;
        zone.y = 0;
        NavMeshHit hit;
        NavMesh.SamplePosition(zone, out hit, wanderRadius, -1);
        return new Vector3(hit.position.x, 0, hit.position.z);
    }

    private bool WaitChance() {
        float chance = Random.Range(0, 1);
        return (chance > 0.5) ? true : false;
    }
}
