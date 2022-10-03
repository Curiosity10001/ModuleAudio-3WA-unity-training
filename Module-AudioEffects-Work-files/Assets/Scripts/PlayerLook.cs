using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Vector2 mouseSensitivity = new Vector2(0.5f,0.25f);
    [SerializeField] Vector2 padSensitivity = new Vector2(0.1f, 0.1f);
    [SerializeField] Vector2 mouseYLimits = new Vector2 (-90f,90f);
    [SerializeField] Vector2 mouseDirection;
    [SerializeField] Vector2 padDirection;

    Vector2 xYmemory;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y")) * mouseSensitivity * Time.deltaTime;
       
        padDirection = new Vector2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical")) * padSensitivity * Time.deltaTime;

        //L� input xYmemory.y sert � pivoter le transform du GameObject Player sur son axe Y.
        //L� input xYmemory.x sert � pivoter le transform du GameObject de la cam�ra sur son axe X.

        xYmemory += new Vector2((mouseDirection.x + padDirection.x), (mouseDirection.y + padDirection.y)); //De cette fa�on, on g�re en m�me temps la souris et le stick.
                                                                                                            // On calcule les nouvelles rotations du GameObject Player et de la cam�ra.

        //ici on fait la rotation du joueur 
        //on utilise les angles en degr�s, (ou angles d�Euler), mais il faut se souvenir qu�Unity utilise en coulisse des Quaternions

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xYmemory.x, transform.eulerAngles.z);

        //Au tour de la cam�ra
        xYmemory.y = Mathf.Clamp(xYmemory.y, mouseYLimits.x, mouseYLimits.y); // mouvements de t�te puisqu'on est � la premi�re personne on ne doit pas pouvoir faire une rotation 360 veritcal .
        Camera.main.transform.eulerAngles = new Vector3(xYmemory.y, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

    }
}
