using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{

    [SerializeField] private GameObject groundPrefab=null;
    [SerializeField] private GameObject tree1Prefab = null;
    [SerializeField] private GameObject tree2Prefab = null;
    [SerializeField] private GameObject tree3Prefab = null;
    [SerializeField] private GameObject cloud1Prefab = null;
    [SerializeField] private GameObject cloud2Prefab = null;

    [SerializeField] private int groundsToSpawn = 5;
    [SerializeField] private int treesToSpawn = 5;
    [SerializeField] private int cloudsToSpawn = 5;


    [SerializeField] private float groundYPos = 0f;
    [SerializeField] private float tree1_YPos = 0f;
    [SerializeField] private float tree2_YPos = 0f;
    [SerializeField] private float tree3_YPos = 0f;
    [SerializeField] private float cloud1_YPos = 0f;
    [SerializeField] private float cloud2_YPos = 0f;


    [SerializeField] private float groundXDistance = 0f;
    [SerializeField] private float tree1_XDistance = 0f;
    [SerializeField] private float tree2_XDistance = 0f;
    [SerializeField] private float tree3_XDistance = 0f;
    [SerializeField] private float cloud1_XDistance = 0f;
    [SerializeField] private float cloud2_XDistance = 0f;


    private float lastGroundXPos;
    private float lastTree1_XPos;
    private float lastTree2_XPos;
    private float lastTree3_XPos;
    private float lastCloud1_XPos;
    private float lastCloud2_XPos;



    [SerializeField]
    private float generateLevelWaitTime = 3f;

    private float waitTimer;

    private void Start()
    {
        StartCoroutine(SpawnGrounds());
    }

    IEnumerator SpawnGrounds()
    {
        while (true)
        {
            GenerateGrounds();
            GenerateTrees();
            GenerateClouds();

            yield return new WaitForSeconds(generateLevelWaitTime);

        }
    }

    void GenerateGrounds()
    {

        Vector3 groundPosition = Vector3.zero;

        for (int i = 0; i < groundsToSpawn; i++)
        {

            groundPosition = new Vector3(lastGroundXPos, groundYPos, 0f);

            GameObject ground=PoolManager.Instance.ReuseGameObject(groundPrefab, groundPosition, Quaternion.identity);
            ground.SetActive(true);

            lastGroundXPos += groundXDistance;
        }
    }

    void GenerateTrees()
    {

        Vector3 tree1Position = Vector3.zero;
        Vector3 tree2Position = Vector3.zero;
        Vector3 tree3Position = Vector3.zero;


        for (int i = 0; i < treesToSpawn; i++)
        {

            tree1Position = new Vector3(lastTree1_XPos, tree1_YPos, 0f);
            tree2Position = new Vector3(lastTree2_XPos, tree2_YPos, 0f);
            tree3Position = new Vector3(lastTree3_XPos, tree3_YPos, 0f);

            GameObject tree1=PoolManager.Instance.ReuseGameObject(tree1Prefab, tree1Position, Quaternion.identity);
            tree1.SetActive(true);

            GameObject tree2=PoolManager.Instance.ReuseGameObject(tree2Prefab, tree2Position, Quaternion.identity);
            tree2.SetActive(true);

            GameObject tree3=PoolManager.Instance.ReuseGameObject(tree3Prefab, tree3Position, Quaternion.identity);
            tree3.SetActive(true);

            lastTree1_XPos += tree1_XDistance;
            lastTree2_XPos += tree2_XDistance;
            lastTree3_XPos += tree3_XDistance;
        }

    }

    private void GenerateClouds()
    {
        Vector3 cloud1Position=Vector3.zero;
        Vector3 cloud2Position=Vector3.zero;


        for (int i = 0; i < cloudsToSpawn; i++)
        {
            cloud1Position = new Vector3(lastCloud1_XPos, cloud1_YPos, 0f);
            cloud2Position = new Vector3(lastCloud2_XPos, cloud2_YPos, 0f);

            GameObject cloud1=PoolManager.Instance.ReuseGameObject(cloud1Prefab, cloud1Position, Quaternion.identity);
            cloud1.SetActive(true);

            GameObject cloud2=PoolManager.Instance.ReuseGameObject(cloud2Prefab, cloud2Position, Quaternion.identity);
            cloud2.SetActive(true);

            lastCloud1_XPos += cloud1_XDistance;
            lastCloud2_XPos += cloud2_XDistance;
        }

    }
}
