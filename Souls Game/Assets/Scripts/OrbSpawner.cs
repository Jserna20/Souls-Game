using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour {

    [Header("Set in Inspector")]
    public int numitemOrbs = 10;
    public GameObject itemOrbPrefab;
    public Vector3 ioPos;
    public float itemOrbScaleMin = 1;
    public float itemOrbScaleMax = 1;
    public float itemOrbSpeedMult = 0f;
    public int spawner;
    public GameObject itemOrb;
    public GameObject[] itemOrbInstances;

    void Awake()
    {
        itemOrbInstances = new GameObject[numitemOrbs];
        GameObject anchor = GameObject.Find("ItemOrbAnchor");
        for (spawner = 0; spawner < numitemOrbs; spawner++)
        {
            itemOrb = Instantiate<GameObject>(itemOrbPrefab);

            ioPos = Vector3.zero;
            ioPos.x = Random.Range(-2f, 6f);
            ioPos.y = Random.Range(-3f, -1f);

            SpawnLocation();

            itemOrb.transform.position = ioPos;
            itemOrb.transform.SetParent(anchor.transform);
            itemOrbInstances[spawner] = itemOrb;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    void SpawnLocation()
    {
        if (spawner != 0)
        {
            if (ioPos == itemOrbInstances[spawner - 1].transform.position)
            {
                ioPos.x = Random.Range(-2f, 6f);
                ioPos.y = Random.Range(-3f, -1f);
            }

            if(ioPos == itemOrbInstances[spawner - 1].transform.position)
            {
                SpawnLocation();
            }
        }
    }
}
