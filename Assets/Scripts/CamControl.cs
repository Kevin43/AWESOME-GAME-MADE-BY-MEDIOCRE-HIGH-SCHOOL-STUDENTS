using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    private Transform playerLoc;
    private float waitTime = 0f;
    private Transform camPosition;


	// Use this for initialization
	void Start () {
        playerLoc = GameObject.Find("Player").GetComponent<Transform>();
        waitTime += Time.time;
        camPosition = Camera.main.GetComponent<Transform>();
        Screen.SetResolution(800, 600, false);
    }
	
	// Update is called once per frame
	void Update () {

        if (waitTime > Time.time)
            return;

        try
        {
            if (playerLoc.transform.position.x >= 0f)
            {
                camPosition.position = new Vector3(playerLoc.position.x, camPosition.position.y, camPosition.position.z);
            }
        }
        catch
        {
            playerLoc = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        }

	}
