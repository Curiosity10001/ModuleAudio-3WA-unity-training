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

        //L’ input xYmemory.y sert à pivoter le transform du GameObject Player sur son axe Y.
        //L’ input xYmemory.x sert à pivoter le transform du GameObject de la caméra sur son axe X.

        xYmemory += new Vector2((mouseDirection.x + padDirection.x), (mouseDirection.y + padDirection.y)); //De cette façon, on gère en même temps la souris et le stick.
                                                                                                            // On calcule les nouvelles rotations du GameObject Player et de la caméra.

        //ici on fait la rotation du joueur 
        //on utilise les angles en degrés, (ou angles d’Euler), mais il faut se souvenir qu’Unity utilise en coulisse des Quaternions

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xYmemory.x, transform.eulerAngles.z);

        //Au tour de la caméra
        xYmemory.y = Mathf.Clamp(xYmemory.y, mouseYLimits.x, mouseYLimits.y); // mouvements de tête puisqu'on est à la première personne on ne doit pas pouvoir faire une rotation 360 veritcal .
        Camera.main.transform.eulerAngles = new Vector3(xYmemory.y, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

    }
}
