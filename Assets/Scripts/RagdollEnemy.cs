using UnityEngine;

public class RagdollEnemy : MonoBehaviour
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private RagdollHandler _ragdollHandler;

    private void Start()
    {
        _view.Initialize();
        _ragdollHandler.Initialize();
    }
    public void Kill()
    {
        _view.AnimatorDisable();
        _ragdollHandler.Enable();
        EnemyController.EnemyCollider.enabled = false;
    }
}
