using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move1 : MonoBehaviour {
	public float maxSpeed;
    private float maxSpeedTemp;
	private float speed = 2;	
	private Rigidbody rb;
	
	void Start ()
    {
        UnityEngine.Cursor.visible = false;
        maxSpeedTemp = maxSpeed;
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

        if (rb.position.z > 0.0f)
        {
            maxSpeed = maxSpeedTemp - rb.position.z;
        }

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("menu");
        }
    }
}