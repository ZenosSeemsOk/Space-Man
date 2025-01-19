using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public Player player;

    private const string TAKEOFF = "Takeoff";
    private const string GROUNDED = "Grounded";
    private const string LANDING = "isLanding";
    private const string GLIDING = "isGliding";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(GROUNDED, player.IsOnGround());
        if (player.hasTakenOff)
        {
            animator.SetTrigger(TAKEOFF);
            player.hasTakenOff = false;
        }
    }

}
