using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] public int ownerIndex = 0;
    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreboard.AddPoint(ownerIndex);
    }
}
