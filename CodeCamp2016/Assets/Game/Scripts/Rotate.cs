using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    // Use this for initialization
    public int Rotate_Speed = 5;

    private Vector3 dir;

    void Start()
    {
        dir = new Vector3(1, 0, 0);
    }
	void Update()
    {
        transform.Rotate(dir, Rotate_Speed * Time.deltaTime);
    }
}