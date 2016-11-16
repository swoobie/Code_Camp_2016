using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class Start_Game : MonoBehaviour {

    private VRInteractiveItem interactor;                    // Used to handle the user clicking whilst looking at the target.

    private Rigidbody body;

    private bool isSelected;

    // Use this for initialization
    void Start()
    {
        isSelected = false;
        body = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        interactor = GetComponent<VRInteractiveItem>();
    }


    private void OnEnable()
    {
        interactor.OnDown += Select_Handler;
        interactor.OnOver += Over_Handler;
    }


    public bool IsOver
    {
        get { return interactor.IsOver; }              // Is the gaze currently over this object?
    }

    //Handle the Over event
    private void Over_Handler()
    {
        Debug.Log("Hovering over: " + name);

    }

    //Called when Fire1 is pressed
    private void Select_Handler()
    {
        print("Selected object: " + name);
        isSelected = !isSelected;

        Application.LoadLevel(1);

    }
}
