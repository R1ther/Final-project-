using UnityEngine;

public class RagdollEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private RagdollHandler _ragdollHandler;

    private void Start()
    {
        _view.Initialize();
        _ragdollHandler.Initialize();
    }

    public void TakeDamage(Vector3 force, Vector3 hitPoint)
    {
        EnableRagdollBehaviour();
        _ragdollHandler.Hit(force, hitPoint);
    }
    private void EnableRagdollBehaviour()
    {
        _view.AnimatorDisable();
        _ragdollHandler.Enable();
    }
}
