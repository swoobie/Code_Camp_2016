using UnityEngine;
using System.Collections;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;


public class SelectObject : MonoBehaviour
{
    public Shader Outline_Shader;
    public Shader Standard_Shader;

    
    public bool Use_Gravity;

    private GameObject xboxController;
    private VRInteractiveItem interactor;                    // Used to handle the user clicking whilst looking at the target.

    private Rigidbody body;

    private bool isSelected;
    private bool canBeDeselected;

    // Use this for initialization
    void Start()
    {
        isSelected = false;
        body = GetComponent<Rigidbody>();

        xboxController = GameObject.Find("xboxController");
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
            GetComponent<Rigidbody>().useGravity = false;

            if(GetComponent<Renderer>().material.shader.name != "Outlined/Silhouetted Diffuse")
            {
                GetComponent<Renderer>().material.shader = Outline_Shader; 
            }
            Vector3 moveDir = Vector3.zero;
            moveDir.x = Input.GetAxis("Horizontal"); // get result of AD keys in X
            moveDir.y = Input.GetAxis("Vertical");  // get result of WS keys in Z
            // move this object at frame rate independent speed:
            transform.position += moveDir * Time.deltaTime * xboxController.GetComponent<xbox>().Move_Speed;
            

            if(Input.GetButtonUp("Fire1") && !canBeDeselected)
            {
                canBeDeselected = true;
                //CannonFire.isObjectSelected = true; //Not quite working
            }

            if(Input.GetButtonDown("Fire1") && canBeDeselected)
            {
                isSelected = false;
                CannonFire.isObjectSelected = false;
            }
        }
        else
        {
            GetComponent<Renderer>().material.shader = Standard_Shader;
            GetComponent<Rigidbody>().useGravity = true && Use_Gravity;
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
       // m_Renderer.material = m_OverMaterial;
    }

    //Called when Fire1 is pressed
    private void Select_Handler()
    {
        print("Selected object: " + name);
        isSelected = !isSelected;
        
        canBeDeselected = false;
    }
}
