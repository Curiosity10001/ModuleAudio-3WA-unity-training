using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterraction : MonoBehaviour
{
    float maxDistance = 100f;
    IUsable target;
    public Image crossHair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
    }
    void FindTarget()
    {
        RaycastHit hit;
        Ray camRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward) ;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward*maxDistance);

        if(Physics.Raycast(camRay,out hit, maxDistance))
        {
            if (hit.collider.gameObject.GetComponent<IUsable>() != null) target = hit.collider.gameObject.GetComponent<IUsable>();

            else target = null;
          
        }
  
    }
    void UseTarget()
    {
        if (Input.GetButton("Use") && target != null)
        {
            target.use();
        }
    }
    void ChangeCrossHairState() 
    {
        if (target == null) crossHair.color = Color.yellow;
        else crossHair.color = Color.cyan;
    }
}
