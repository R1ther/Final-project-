using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollHandler : MonoBehaviour
{
    private List<Rigidbody> _rb;
    public void Initialize()
    {
        _rb = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        Disable();
    }
    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rb)
            rigidbody.isKinematic = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rb)
            rigidbody.isKinematic = true;
    }
}
