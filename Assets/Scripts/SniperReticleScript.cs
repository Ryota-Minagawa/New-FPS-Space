using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperReticleScript : MonoBehaviour
{

    [SerializeField] GameObject sniperReticle;
    [SerializeField] Camera firstPersonCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (sniperReticle.activeSelf)
            {
                sniperReticle.SetActive(false);
                firstPersonCamera.fieldOfView = 60;
            }
            else
            {
                sniperReticle.SetActive(true);
                firstPersonCamera.fieldOfView = 20;
            }
        }
    }
}

