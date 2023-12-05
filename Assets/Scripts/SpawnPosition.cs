using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    private GameObject player;
    public GameObject refToPlayer;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //refToPlayer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
