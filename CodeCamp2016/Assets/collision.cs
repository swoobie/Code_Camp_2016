using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class collision : MonoBehaviour {


	public delegate void WhateverType(); // declare delegate type

	protected WhateverType callbackFct; // to store the function
	// Use this for initialization
	void Start () {
		//OnCollisionEnter ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		Camera.main.SendMessage ("fadeOut");
		SceneManager.LoadScene(0);
	}

		
		
}
