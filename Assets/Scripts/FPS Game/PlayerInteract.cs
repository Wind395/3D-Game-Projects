using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private Camera cam;
    
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject door;
    private bool isOpened = false;
    private Ray ray;
    
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    private void Interact() {
        playerUI.UpdateText(string.Empty);
        ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask)) 
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null) 
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(!isOpened) {
                        isOpened = true;
                        door.GetComponent<Animator>().SetBool("isOpen", true);
                    } else {
                        isOpened = false;
                        door.GetComponent<Animator>().SetBool("isOpen", false);
                    }
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * distance);
    }
}
