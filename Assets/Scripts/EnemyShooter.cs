using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;

	// Use this for initialization
	void Start () {
        StartCoroutine(Attack());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        print("shoot");
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
}
