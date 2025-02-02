using UnityEngine;

public class StoneAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Player player;
    private const string STONEBREAK = "StoneBreak";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    private void Update()
    {
        if (anim != null)
        {
            if(!player.checkGameOver)
            {
                anim.enabled = true;
                anim.SetBool(STONEBREAK, !player.checkGameOver);
            }

        }
    }
}

