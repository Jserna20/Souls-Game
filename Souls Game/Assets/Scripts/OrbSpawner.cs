using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour {

    [Header("Set in Inspector")]
    public int numClouds = 10;
    public GameObject cloudPrefab;
    public Vector3 cloudPosMin = new Vector3(-2, -3, 0);
    public Vector3 cloudPosMax = new Vector3(6, -2, 0);
    public Vector3 cPos;
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 1;
    public float cloudSpeedMult = 0f;
    public int spawner;
    public GameObject cloud;
    public GameObject[] cloudInstances;

    void Awake()
    {
        cloudInstances = new GameObject[numClouds];
        GameObject anchor = GameObject.Find("ItemOrbAnchor");
        for (spawner = 0; spawner < numClouds; spawner++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);

            cPos = Vector3.zero;
            cPos.x = Random.Range(-2f, 6f);
            cPos.y = Random.Range(-3f, -1f);

            SpawnLocation();

            cloud.transform.position = cPos;
            cloud.transform.SetParent(anchor.transform);
            cloudInstances[spawner] = cloud;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach (GameObject cloud in cloudInstances)
        {
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;
            cPos.x = cPos.x + (scaleVal * Time.deltaTime * cloudSpeedMult);
            if (cPos.x <= cloudPosMin.x)
            {
                cPos.x = cloudPosMax.x;
            }
            cloud.transform.position = cPos;
        }*/
    }

    void SpawnLocation()
    {
        if (spawner != 0)
        {
            if (cPos == cloudInstances[spawner - 1].transform.position)
            {
                cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
                cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);
            }

            if(cPos == cloudInstances[spawner - 1].transform.position)
            {
                SpawnLocation();
            }
        }
    }
}
