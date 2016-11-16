using UnityEngine;
using System.Collections;

public class xbox : MonoBehaviour {

    public int Move_Speed;

    private int Old_Speed;

	// Use this for initialization
	void Start () {
        Old_Speed = Move_Speed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire3") > .2 || Input.GetAxis("Fire3") < -.2)
        {
            Move_Speed = Old_Speed / 2;
        }
        else
        {
            Move_Speed = Old_Speed;
        }
	}
}
