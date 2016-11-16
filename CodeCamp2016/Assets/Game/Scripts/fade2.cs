using UnityEngine;
using System.Collections;

public class fade2 : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.05f;

	public int drawDepth = -1000;

	private float alpha = 1.0f; 

	private float fadeDir = 1f;

	void OnGUI(){

		alpha += fadeDir * fadeSpeed * Time.deltaTime;	
		alpha = Mathf.Clamp01(alpha);	

		Color thisColor = GUI.color;
		thisColor.a = alpha;
		GUI.color = thisColor;

		GUI.depth = drawDepth;

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

        print("Alpha: " + alpha);
	}

	//--------------------------------------------------------------------

	public void fadeIn(){
		fadeDir = -1;	
	}

	//--------------------------------------------------------------------

	public void fadeOut(){
		fadeDir = 1;	
	}

	void Start(){
		alpha=1;
		fadeIn();

	}


}

