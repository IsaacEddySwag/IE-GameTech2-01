using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeThrowSpeed : MonoBehaviour
{
    private Animator animator;
    float throwSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        throwSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            UpgradeThrow(0.1f);
        }
    }

    public void UpgradeThrow(float upgrade)
    {
        throwSpeed += upgrade;

        animator.SetFloat("Speed", throwSpeed);
    }
}
