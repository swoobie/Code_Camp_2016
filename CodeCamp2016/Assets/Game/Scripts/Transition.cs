using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {
    public AudioClip backgroundMusic;

    void Awake()
    {
        DontDestroyOnLoad(this);
        GetComponent<AudioSource>().clip = backgroundMusic;
    }
    
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Credits")
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
