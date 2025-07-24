using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float M_moveSpeed = 2f;
    [SerializeField] private float M_destroyX = -10f;

    private bool M_scored = false;
    private float M_scorePosition = -1f;

    void Update()
    {
        transform.position += Vector3.left * M_moveSpeed * Time.deltaTime;

        if (!M_scored && transform.position.x < M_scorePosition)
        {
            M_scored = true;
            GameManager.S_Instance.IncreaseScore();
        }

        if (transform.position.x < M_destroyX)
        {
            Destroy(gameObject);
        }
    }
}
