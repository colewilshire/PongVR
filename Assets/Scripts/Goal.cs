using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] public int ownerIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Scoreboard.Instance.AddPoint(ownerIndex);
    }
}
