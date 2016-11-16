using UnityEngine;
using System.Collections;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;

[RequireComponent(typeof(VRInteractiveItem))]
public class Select_Lever : MonoBehaviour
{  
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

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            // rotate and wait until finished rotating then fire
            GameObject.Find("Cannon").GetComponent<CannonFire>().Fire();

            isSelected = false;
         
        }
        else
        {
            
        }
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
        
    }
}
