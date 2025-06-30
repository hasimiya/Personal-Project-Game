using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    public void Initialize(Animator animatorComponent)
    {
        animator = animatorComponent;
    }
    public void PlayAnimation(Animator animator)
    {
        AnimationManager animationManager = gameObject.AddComponent<AnimationManager>();
        animationManager.Initialize(animator);
        animationManager.PlayDeathAnimation();
    }
    public void PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }
        else
        {
            Debug.LogWarning("Animator is not assigned or not found on the objectPrefab.");
        }
    }
}
