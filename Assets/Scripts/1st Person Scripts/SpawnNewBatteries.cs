using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnNewBatteries : MonoBehaviour
{
    public UnityEvent ActivateBatteries;

    //On trigger enter enables a group of new batteries for the player to collect
    public void OnTriggerEnter(Collider other)
    {
        ActivateBatteries.Invoke();
        Destroy(this.gameObject);
    }
}
