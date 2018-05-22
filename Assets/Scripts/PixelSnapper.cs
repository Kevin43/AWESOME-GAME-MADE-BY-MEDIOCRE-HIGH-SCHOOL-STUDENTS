using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelSnapper : MonoBehaviour {

    public Transform player;
    public Transform parent;
    Vector2 playerPos;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void LateUpdate() {
        //Vector2 playerPos = player.position; 
        
        playerPos.x = (Mathf.Round(parent.position.y * 100) / 100) - parent.position.x;
        playerPos.y = (Mathf.Round(parent.position.y * 100) / 100) - parent.position.y;
        player.position = new Vector2(playerPos.x, playerPos.y);
        //player.position.y = (Mathf.Round(parent.position.y * 100) / 100) - parent.position.y;
    }
}
