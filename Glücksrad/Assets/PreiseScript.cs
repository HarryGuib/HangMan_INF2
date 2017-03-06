using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreiseScript : MonoBehaviour {
    float result;
    float finalresult; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (DrehungCountScript.drehnum == -1)
        {
            //result = (Mathf.Abs(gameObject.transform.rotation.x)) / 15f;
           

            //finalresult = Mathf.Round(24-result);
            //Debug.Log("final " + finalresult);

        }
        if (DrehungCountScript.drehnum == 1)
        {
            //finalresult = (gameObject.transform.rotation.x) / 15f;
           // Debug.Log("X:" + gameObject.transform.rotation.x);
            //Debug.Log("final " + finalresult);
        }
    }
}
