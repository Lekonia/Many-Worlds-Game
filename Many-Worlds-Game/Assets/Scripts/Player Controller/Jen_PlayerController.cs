using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jen_PlayerMotor))]
public class Jen_PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    Jen_PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<Jen_PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                // Stop focusing any objects
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Check if we hit an interactable
                // If we did set it as our focus
            }
        }
    }
}
