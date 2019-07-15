using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera _cam;

    public LayerMask _groundLayer;
    public NavMeshAgent _playerAgent;

    // Start is called before the first frame update
    void Awake()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RightClick();
        }
    }


    public void RightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            switch (hit.collider.tag)
            {
                case "Ground":
                    _playerAgent.destination = hit.point;
                    break;
                case "Enemy":
                    Debug.Log("hi");
                    Debug.Log(hit.distance);
                    break;
                default:
                    break;
            }
        }
    }


    public void GetClickType()
    {
        if (true)
        {

        }
    }
}
