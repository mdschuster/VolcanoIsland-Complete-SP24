using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int speed;
    public int maxHealth;
    private int health;
    private float input;
    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        Vector2 vel = new Vector2(input * speed, 0f);
        rb.velocity = vel;

        if (input != 0) //running
        {
            anim.SetBool("isRunning",true);
        }
        else //idle
        {
            anim.SetBool("isRunning",false);
        }

        if (input < 0) //moving to the left
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if(input > 0) //moving to the right
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        GameManager.instance().updateHealth(health);
        if (health <= 0)
        {
            //play a death effect (sound, vfx, ...)
            this.gameObject.SetActive(false);
            GameManager.instance().deathCanvasSwitch();
        }
    }
    
    public void reset()
    {
        health = maxHealth;
        Vector3 pos = new Vector3(0.0f, -4.0f, 0.0f);
        this.transform.position = pos;
        this.gameObject.SetActive(true);
        GameManager.instance().updateHealth(maxHealth);
        //ensure that all of the rotations for each part is correct
        //when resetting the game
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform t in children)
        {
            t.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}
