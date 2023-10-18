using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestruction : MonoBehaviour
{
    //Destroys the attached object when the functions is called
    public void DESTROY()
    {
        Destroy(this.gameObject); 
    }
}
