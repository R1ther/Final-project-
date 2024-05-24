using System.Linq;
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

    public void Hit(Vector3 force, Vector3 hitPosition)
    {
        Rigidbody injuredRigidbody = _rb.OrderBy(rigidbody => Vector3.Distance(rigidbody.position, hitPosition)).First();

        injuredRigidbody.AddForceAtPosition(force, hitPosition, ForceMode.Impulse);
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
