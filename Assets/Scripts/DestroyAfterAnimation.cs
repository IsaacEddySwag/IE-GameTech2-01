using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        Destroy(this.gameObject);
    }
}
