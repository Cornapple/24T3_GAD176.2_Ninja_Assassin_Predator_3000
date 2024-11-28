using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region Script LO's
///aims for this script: cover basic scripting needs: Pascal/camel case, conventions, 
///debugging, multiple functions, multiple classes, commenting, folder tructure,  <summary>
///serialized field, use of geometry and vector
///

///potentually can be used for: singe responcibility, inheritance, use of namespaces, protected keyword
#endregion
public class ProneController : ThirdPersonController
{
    public GameObject player;
    public int playerIsProne;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ProneController script has been called");
    }

    private void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.RightShift) && groundedPlayer)
        {
            // call the GoProne method
          
        }
    }

    // Update is called once per frame
    public void GoProne()
    {
        Debug.Log("GoProne method has been called from " + gameObject.name);
        // transform player to lower level from third person controller
        player.transform.localScale = new Vector3 (0, 0.5f, 0);

        //diactivates enemies ability to see the player (probably with another script called here)

        // slows player down
    }

}
