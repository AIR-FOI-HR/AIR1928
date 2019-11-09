using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndDetection : MonoBehaviour
{
    private MovementOfTurret script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Turret").GetComponent<MovementOfTurret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("tap");
            //script.Teleport();
            
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            script.Teleport(hit);
            /*
            if (hit.collider != null)
            {
                Debug.Log("Hit Collider: " + hit.transform.name);
            }
            else
            {
                Debug.Log("No colliders hit from tap");
            }
            /*
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
            /*
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "Turret")
                {
                    Debug.Log("Soccer Ball clicked");
                }

                //OR with Tag

                if (raycastHit.collider.CompareTag("SoccerTag"))
                {
                    Debug.Log("Soccer Ball clicked");
                }
            }
            */
        }
    }
}
