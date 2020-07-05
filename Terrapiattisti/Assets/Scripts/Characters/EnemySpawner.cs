using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySpawner : MonoBehaviour
{
    public GameObject astronauta;
    public GameObject terrapiattista;
    public int numeroNemici;
    private int countNemici = 0;
    public GameObject mondo;
    private Vector3 punto;
    public float timeToSpawn;
    private Vector3 direzione;
    public GameObject spawner;
    private Transform[] spawners;
    // Start is called before the first frame update
    private void Start()
    {
        spawners = spawner.GetComponentsInChildren<Transform>();
        StartCoroutine(EnemyDrop());
    }


    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator EnemyDrop()
    {
        while (countNemici < numeroNemici)
        {
            Transform spawnScelto = (Transform)spawners.GetValue(0);
            float modulo = 0;
            foreach (Transform spawn in spawners)
            {

                if ((astronauta.transform.position - spawn.position).magnitude > modulo)
                {
                    modulo = (astronauta.transform.position - spawn.position).magnitude;
                    spawnScelto = spawn;
                }
            }
            Debug.Log("Spawno nemico n°: " + countNemici + " in posizione : " + punto);
            Instantiate(terrapiattista, spawnScelto.position, Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
            countNemici++;

        }
    }

}