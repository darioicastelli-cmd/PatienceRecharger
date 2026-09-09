using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 15f)] public float strength = 3f;
    //----------------------------------EJE X
    [SerializeField] public bool EjeX = false;
    private float EjeXTrue; // ahora float
    [SerializeField] float ValueX = 1f;

    private float ValueXAxis(ControllerColliderHit hit)
    {
        if (EjeX == true)
        {
            return ValueX;
        }
        else return hit.moveDirection.x;
    }

    //----------------------------------EJE Y
    [SerializeField] public bool EjeY = true;
    private float EjeYTrue;
    [SerializeField] float ValueY = 1f;

    private float ValueYAxis(ControllerColliderHit hit)
    {
        if (EjeY == true)
        {
            return ValueY;
        }
        else return hit.moveDirection.y;
    }

    //----------------------------------EJE Z
    [SerializeField] public bool EjeZ = false;
    private float EjeZTrue;
    [SerializeField] float ValueZ = 1f;

    private float ValueZAxis(ControllerColliderHit hit)
    {
        if (EjeZ == true)
        {
            return ValueZ;
        }
        else return hit.moveDirection.z;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
		

		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// make sure we only push desired layer(s)
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) return;

		// Calculate push direction from move direction, horizontal motion only
		Vector3 pushDir = new Vector3(
            (ValueXAxis(hit)),              //EjeX -Frente
            (ValueYAxis(hit)),              //EjeY - Arriba
			(ValueZAxis(hit))               //EjeZ -Costado
			);






		// Apply the push and take strength into account
		body.AddForce(pushDir * strength, 
			ForceMode.Impulse);	//Tipo de Fuerza


	}
}