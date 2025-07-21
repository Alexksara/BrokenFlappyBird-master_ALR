using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -10f;

    private bool M_scored = false;
    private float M_scorePosition = -1f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (!M_scored && transform.position.x < M_scorePosition)
        {
            M_scored = true;
            GameManager.S_Instance.IncreaseScore();
        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
