using UnityEngine;
using System.Collections;

public class CannonSound : MonoBehaviour {

    public AudioClip fuse;
    public AudioClip boom;
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = fuse;
    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }
}
