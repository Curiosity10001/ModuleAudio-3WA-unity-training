using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    Vector3 move;
   CharacterController playerController;

    private void Awake()
    {
        playerController = this.GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       move = (transform.right * (Input.GetAxisRaw("Horizontal") )+( transform.forward * (Input.GetAxisRaw("Vertical")))) * playerSpeed * Time.deltaTime;
        playerController.Move(move);
    }
}

//Dans la méthode Update, récupérer les inputs de déplacements, puis se servir des propriétés right et forward du transform en les multipliant par les inputs correspondants, additionner les deux vecteurs pour obtenir un vecteur de direction.


//Comment transformer les deux float en vecteur de direction ?
//Pour “Vertical”, on sait qu’on veut aller vers l’avant quand on pousse le stick vers le haut



//Multiplier ce vecteur de direction par la vitesse _speed et par le deltaTime  pour obtenir un vecteur de mouvement.
//Vector3 move = direction * _speed * Time.deltaTime;
//Créer une variable _characterController et lui assigner la valeur GetComponent<CharacterController>() dans la méthode Awake

//Dans Update appeler la fonction _characterController.Move() avec la variable move comme paramètre.

