using UnityEngine;

public class PlayerTargetProvider : ITargetProvider
{
    private readonly Transform _target;

    public PlayerTargetProvider(Transform target)
    {
        _target = target;
    }

    public Transform GetTarget() => _target;
    public bool HasTarget() => _target != null;
}
