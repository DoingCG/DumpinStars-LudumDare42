using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    public float a;
    public float ta;
    public float maxvel;
    public float maxtorgue;

    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;


    private Rigidbody rbd;
    float v;
    float t;
    private float refv = 0.0f;
    private float reft = 0.0f;


    // Use this for initialization
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotate(Inputs());
    }

    Vector2 Inputs()
    {

        if (Input.GetKey(forward))
        {
            v += Time.deltaTime * a;
        }
        else if (Input.GetKey(back))
        {
            v -= Time.deltaTime * a;
        }
        else v = Mathf.SmoothDamp(v, 0, ref refv, 0.3f);
        v = Mathf.Clamp(v, -maxvel, maxvel);

        if (Input.GetKey(left))
        {
            t += Time.deltaTime * ta;
        }
        else if (Input.GetKey(right))
        {
            t -= Time.deltaTime * ta;
        }
        else t = Mathf.SmoothDamp(t, 0, ref reft, 0.3f);
        t = Mathf.Clamp(t, -maxtorgue, maxtorgue);
        // t = ((t / (3.1416f *2)) - Mathf.Floor(t)) * (3.1416f * 2);
        //Debug.Log(t);
        return new Vector2(v, t);
        
    }

  
    void MoveAndRotate( Vector2 input)
    {
        //rbd.velocity += transform.forward * input.x;
        //rbd.MovePosition(transform.forward * input.x);
        rbd.AddForce(rbd.transform.forward * input.x - rbd.velocity, ForceMode.VelocityChange);
        //rbd.AddRelativeForce(Vector3.forward * input.x, ForceMode.Force);
        //rbd.AddTorque(transform.up * input.y,ForceMode.VelocityChange);
        // Quaternion rot = Quaternion.Euler(rbd.transform.up * input.y);
        Quaternion rot = Quaternion.Euler(Vector3.up * input.y*Time.deltaTime);
        //rbd.MoveRotation(rot);
        rbd.MoveRotation(rbd.rotation*rot);
    }

}

