using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Animator wizardAnimator;

    private void Start()
    {
        wizardAnimator = GetComponent<Animator>();
    }

    public void PlayJump()
    {
        if (wizardAnimator != null)
        {
            wizardAnimator.SetTrigger("Jump");
        }
    }

    public void PlayNo()
    {
        if (wizardAnimator != null)
        {
            wizardAnimator.SetTrigger("No");
        }
    }
}