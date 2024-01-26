using UnityEngine;
public class M_PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public float throwForce = 500f;
    public float pickUpRange = 5f; 
    private float rotationSensitivity = 1f; 
    private GameObject heldObj; 
    private Rigidbody heldObjRb; 
    private bool canDrop = true; 
    private int LayerNumber; 
    private M_PlayerMovement playerMovement;
    private Vector3 originalScale;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        playerMovement = player.GetComponent<M_PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            if (heldObj == null) 
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.tag == "canPickUp")
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if(canDrop == true)
                {
                    StopClipping();
                    DropObject();
                }
            }
        }
        if (heldObj != null) 
        {
            MoveObject(); 
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) 
            {
                StopClipping();
                ThrowObject();
            }
        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            originalScale = pickUpObj.transform.localScale;
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber; 
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            
        }
    }
    void DropObject()
    {
       
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null; 
    }
    void MoveObject()
    {
        //heldObj.transform.position = holdPos.transform.position;
        heldObj.transform.position = holdPos.position + holdPos.forward * 0.1f;
    }
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            canDrop = false; 
            playerMovement.allowMouseRotation = false;
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            playerMovement.allowMouseRotation = true;
            canDrop = true;
        }
    }
    void ThrowObject()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj.transform.localScale = originalScale;
        //heldObj.transform.localScale = Vector3.one;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping() 
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); 
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
       
        if (hits.Length > 1)
        {
            //heldObj.transform.position = transform.position + new Vector3(10f, 1f, 0f); 
            heldObj.transform.position = transform.position + transform.forward * 1.5f; 
        }
    }
   
}