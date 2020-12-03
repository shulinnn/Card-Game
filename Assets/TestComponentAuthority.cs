using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestComponentAuthority : NetworkBehaviour
{
    public override void OnStartServer()
    {
        base.OnStartServer();
        GetComponent<NetworkIdentity>().RemoveClientAuthority();

    }
}
