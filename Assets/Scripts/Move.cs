using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {
	public float maxSpeed;
	private float speed = 2;	
	private Rigidbody rb;
	
	void Start ()
	{
        UnityEngine.Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{		
		Vector3 movement = new Vector3 (0.0f, 0.0f, 1.0f);
		rb.AddForce (movement * speed);

		if(rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("menu");
        }

    }
}