using UnityEngine;

public class WizardController : MonoBehaviour
{
    private Animator wizardAnimator;

    void Start()
    {
        // Get the Animator component from this GameObject
        wizardAnimator = GetComponent<Animator>();
    }

    public void PlayJump()
    {
        // Play the Jump animation (Trigger parameter)
        wizardAnimator.SetTrigger("Jump");
    }

    public void PlayNo()
    {
        // Play the No animation (Trigger parameter)
        wizardAnimator.SetTrigger("No");
    }
}
