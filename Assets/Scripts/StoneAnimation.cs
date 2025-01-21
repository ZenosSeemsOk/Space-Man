using UnityEngine;

public class StoneAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Player player;
    private const string STONEBREAK = "StoneBreak";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (anim != null)
        {
            anim.SetBool(STONEBREAK, !player.checkGameOver);
        }
    }
}

