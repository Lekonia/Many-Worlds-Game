using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jen_Motor))]
public class Jen_Controller : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    Jen_Motor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<Jen_Motor>();
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
               if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}
