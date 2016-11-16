using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
    public int Force = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        //add if thing here
        if(col.gameObject.name.ToLower().Contains("ball"))
        {
            Vector3 angle2 = col.contacts[0].normal * -1;
            col.gameObject.GetComponent<Rigidbody>().velocity = angle2 * Force;
        }
        
    }
}
