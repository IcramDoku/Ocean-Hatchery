using UnityEngine;

public class MergeEgg : MonoBehaviour
{
    private Egg egg;
    private bool merged;

    private void Awake()
    {
        egg = GetComponent<Egg>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (merged) return;

        Egg other =
            collision.gameObject.GetComponent<Egg>();

        if (other == null) return;

        if (other.data == null || egg.data == null)
            return;

        MergeEgg otherMerge =
            other.GetComponent<MergeEgg>();

        if (otherMerge != null && otherMerge.merged)
            return;

        if (other.data.level == egg.data.level)
        {
            Merge(other);
        }
    }

    private void Merge(Egg other)
    {
        merged = true;

        MergeEgg otherMerge =
            other.GetComponent<MergeEgg>();

        if (otherMerge != null)
            otherMerge.merged = true;

        // Add score here
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(
                egg.data.scoreValue
            );
        }

        if (egg.data.nextEgg == null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        Vector3 spawnPos =
            (transform.position + other.transform.position) / 2f;

        GameObject newEgg =
            Instantiate(
                gameObject,
                spawnPos,
                Quaternion.identity
            );

        Egg newEggScript =
            newEgg.GetComponent<Egg>();

        newEggScript.data =
            egg.data.nextEgg;

        newEggScript.Refresh();

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
