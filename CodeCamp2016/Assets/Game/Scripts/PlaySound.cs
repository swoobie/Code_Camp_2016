using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public AudioClip collision_sound;
	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = collision_sound;
    }

    void OnCollisionEnter(Collision col)  //Plays Sound Whenever collision detected
    {
        if(col.gameObject.name.ToLower().Contains("ball"))
           GetComponent<AudioSource>().Play();
    }
}
