using UnityEngine;

[RequireComponent(typeof(Animator))]

public class MaleAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Heal()
    {
        _animator.SetTrigger(AnimatorMale.Params.Heal);
    }

    public void Damage()
    {
        _animator.SetTrigger(AnimatorMale.Params.Damage);
    }

    public void Die()
    {
        _animator.SetTrigger(AnimatorMale.Params.Die);
    }
}

public static class AnimatorMale
{
    public static class Params
    {
        public const string Damage = nameof(Damage);
        public const string Heal = nameof(Heal);
        public const string Die = nameof(Die);
    }

    public static class Male
    {
        public const string Idle = nameof(Idle);
        public const string Damage = nameof(Damage);
        public const string Heal = nameof(Heal);
        public const string Die = nameof(Die);
    }
}