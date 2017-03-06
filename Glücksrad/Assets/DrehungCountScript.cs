using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrehungCountScript : MonoBehaviour {
    public static int drehnum = 1;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    

    void Update () {

       
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "sensor")
        {
            drehnum = 1;
            Debug.Log("hallo----> " + drehnum);
        }
        if (collision.transform.tag == "sensor2")
        {
            drehnum = 2;
            Debug.Log("hallo----> " + drehnum);
        }
        if (collision.transform.tag == "sensor3")
        {
            drehnum = 3;
            Debug.Log("hallo----> " + drehnum);
        }
    }
}
