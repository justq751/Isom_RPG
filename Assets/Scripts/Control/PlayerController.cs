using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover;

    void Start()
    {
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z));

        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            mover.MoveTo(hit.point);
        }
    }
}
