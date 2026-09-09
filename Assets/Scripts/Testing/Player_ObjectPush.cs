using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//RequireComponent(Rigidbody);

public class Player_ObjectPush : MonoBehaviour
{
    [SerializeField] private float forceMagnitude=1;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {


            //Opcion1-- Empuja pero choca contra los vertices de interseccion
            //Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            //forceDirection.y = 0;
            //forceDirection.Normalize();

            //-----------------
            //Opcion2 --
            Vector3 forceDirection = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }

    }


}
