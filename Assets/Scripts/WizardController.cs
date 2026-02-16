using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Animator wizardAnimator;

    private void Start()
    {
        // Get Animator component attached to this object
        wizardAnimator = GetComponent<Animator>();
    }

    public void PlayJump()
    {
        // Trigger Jump animation
        if (wizardAnimator != null)
        {
            wizardAnimator.SetTrigger("Jump");
        }
    }

    public void PlayNo()
    {
        // Trigger No animation
        if (wizardAnimator != null)
        {
            wizardAnimator.SetTrigger("No");
        }
    }
}
