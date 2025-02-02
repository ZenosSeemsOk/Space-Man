using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform moveToLocation;

    private void Update()
    {
        if(player.checkGameCompletion)
        {
            Invoke("Tween",1.5f);
        }
    }

    private void Tween()
    {
        LeanTween.move(gameObject, moveToLocation.position, 1.25f);
    }
}
