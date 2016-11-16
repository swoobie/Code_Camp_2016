using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

    public bool canFire;
    public static bool isObjectSelected;
    public int Force;
    public Rigidbody Shot_Prefab;
    public Transform Cannon_Transform;

    public AudioClip fuse;
    public AudioClip boom;

    private bool fuseLit;

    // Use this for initialization
    void Start () {
        fuseLit = false;
        canFire = true;
        isObjectSelected = false;
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = fuse;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Fire2") > .2 && canFire && !isObjectSelected)
        {
            fuseLit = true;
            GetComponent<AudioSource>().clip = fuse;
            GetComponent<AudioSource>().Play();
        }
        else if(fuseLit && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = boom;
            GetComponent<AudioSource>().Play();
            Rigidbody shot;
            shot = Instantiate(Shot_Prefab, Cannon_Transform.position, Cannon_Transform.rotation) as Rigidbody;
            shot.AddForce(Cannon_Transform.forward * Force);
            canFire = false;
            fuseLit = false;
        }
    }

    public void Fire()
    {
        if (canFire && !isObjectSelected)
        {
            Rigidbody shot;
            shot = Instantiate(Shot_Prefab, Cannon_Transform.position, Cannon_Transform.rotation) as Rigidbody;
            shot.AddForce(Cannon_Transform.forward * Force);
            canFire = false;

        }
    }
}
