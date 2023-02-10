using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject cam;

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        if (Camera.main != null) cam = Camera.main.gameObject;
        Debug.Log(cam);
        cam.SetActive(true);
    }
}
