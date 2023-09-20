using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnNewBatteries : MonoBehaviour
{
    public UnityEvent ActivateBatteries;

    public void OnTriggerEnter(Collider other)
    {
        ActivateBatteries.Invoke();
        Destroy(this.gameObject);
    }
}
