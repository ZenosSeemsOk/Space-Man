using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public Player player;

    private const string TAKEOFF = "Takeoff";
    private const string GROUNDED = "Grounded";
    private const string LANDING = "isLanding";
    private const string GLIDING = "isGliding";
    private const string FALLING = "GameOver";
    private const string BLAST = "gameEnd";
    private bool wasGliding = false; // To track state changes
    private bool wasLanding = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Update grounded state
        animator.SetBool(GROUNDED, player.IsOnGround());

        // Handle takeoff animation
        if (player.hasTakenOff)
        {
            animator.SetTrigger(TAKEOFF);
            player.hasTakenOff = false; // Reset the takeoff state after triggering animation
        }

        // Handle gliding animation
        if (player.isGliding && !wasGliding)
        {
            animator.SetBool(GLIDING, true);
            wasGliding = true;
        }
        else if (!player.isGliding && wasGliding)
        {
            animator.SetBool(GLIDING, false);
            wasGliding = false;
        }

        // Handle landing animation
        if (player.isLanding && !wasLanding)
        {
            animator.SetTrigger(LANDING);
            wasLanding = true;
        }
        else if (!player.isLanding && wasLanding)
        {
            wasLanding = false; // Reset state when landing is complete
        }
        else if (!player.checkGameOver)
        {
            animator.SetBool(FALLING, true);
        }

        // Handle Blast animation
        if(!player.checkGameOver)
        {
            animator.SetBool(BLAST, true);
        }
    }
}
