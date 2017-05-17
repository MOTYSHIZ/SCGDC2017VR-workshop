using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPop : MonoBehaviour {

    ParticleSystem popParticles;
    GameObject model;

	// Use this for initialization
	void Start () {
        popParticles = GetComponent<ParticleSystem>();
        model = transform.Find("Model").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("bonk");
        if (collision.collider.tag == "Projectile")
        {
            Pop();
        }
    }

    private void Pop() {
        popParticles.Play();
        model.SetActive(false);
        Destroy(gameObject, popParticles.main.duration);
    }
}
