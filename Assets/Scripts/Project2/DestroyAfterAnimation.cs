using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public ParticleSystem snow;

    private void OnParticleSystemStopped()
    {
        Destroy(this.gameObject);
    }
}
