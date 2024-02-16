using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    public int damage;
    public GameObject hitEffect;
   
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().takeDamage(damage);
            //play a sound
            //play a particle system
            Vector3 pos = this.transform.position;
            pos.y -= 0.5f;
            Instantiate(hitEffect, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.tag == "Ground")
        {
            //play a sound
            //play a particle system
            Vector3 pos = this.transform.position;
            pos.y -= 0.5f;
            Instantiate(hitEffect, pos, Quaternion.identity);
            //destroy the fireball
            Destroy(this.gameObject);
        }
    }
}
