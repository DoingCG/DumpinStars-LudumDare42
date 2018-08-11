using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

    public Rigidbody p1;
    public Rigidbody p2;
    public float a;
    public float ta;
    public float maxvel;
    //public float maxtorgue;

    float v1;
    float v2;
    float t1;
    float t2;
    private float refv1=0.0f;
    private float refv2 = 0.0f;
    private float reft1 = 0.0f;
    private float reft2 = 0.0f;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveAndRotate(p1, P1inputs());
        MoveAndRotate(p2, P2inputs());
    }

    Vector2 P1inputs()
    {

        if (Input.GetKey(KeyCode.W))
        {
            v1 += Time.deltaTime * a;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v1 -= Time.deltaTime * a;
        }
        else v1 =Mathf.SmoothDamp(v1,0,ref refv1,0.3f);
        v1 = Mathf.Clamp(v1, -maxvel, maxvel);

        if (Input.GetKey(KeyCode.D))
        {
            t1 += Time.deltaTime * ta;
        }
        if (Input.GetKey(KeyCode.A))
        {
            t1 -= Time.deltaTime * ta;
        }
       // t1 = Mathf.Clamp(t1, -maxtorgue, maxtorgue);

        return new Vector2(v1, t1);

    }

    Vector2 P2inputs()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v2 += Time.deltaTime * a;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            v2 -= Time.deltaTime * a;
        }
        else v2 = Mathf.SmoothDamp(v2, 0, ref refv2, 0.3f);
        v2 = Mathf.Clamp(v2, -maxvel, maxvel);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            t2 += Time.deltaTime * ta;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            t2 -= Time.deltaTime * ta;
        }
        //else t2 = Mathf.SmoothDamp(t2, 0, ref reft2, 0.3f);
        // t2 = Mathf.Clamp(t2, -maxtorgue, maxtorgue);
       // t2 = Mathf.Floor(t2 / 360)*360;
        return new Vector2(v2, t2);

    }

    void MoveAndRotate(Rigidbody rbd, Vector2 input)
    { 
        //rbd.velocity += transform.forward * input.x;
        //rbd.MovePosition(transform.forward * input.x);
        rbd.AddForce(rbd.transform.forward * input.x-rbd.velocity, ForceMode.VelocityChange);
        //rbd.AddRelativeForce(Vector3.forward * input.x, ForceMode.Force);
        //rbd.AddTorque(transform.up * input.y,ForceMode.VelocityChange);
       // Quaternion rot = Quaternion.Euler(rbd.transform.up * input.y);
        Quaternion rot = Quaternion.Euler(Vector3.up * input.y);
        rbd.MoveRotation(rot);
    }

}
