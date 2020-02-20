using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animate;
    void Start()
    {
	    rb2d = GetComponent<Rigidbody2D>();
	    animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
	    if (isDead == false)
	    {
		    if (Input.GetMouseButtonDown(0))
		    {
			    rb2d.velocity = UnityEngine.Vector2.zero;
                rb2d.AddForce(new UnityEngine.Vector2(0, upForce));
                animate.SetTrigger("Flap");
		    }
	    }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = new UnityEngine.Vector2(0, 0);
	    isDead = true;
        animate.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
