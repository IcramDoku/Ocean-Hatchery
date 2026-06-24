using System.Collections;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    private bool checking;
    private int eggsInZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Egg>() != null)
        {
            eggsInZone++;

            Debug.Log("Egg entered. eggsInZone = " + eggsInZone);

            if (!checking)
            {
                StartCoroutine(CheckGameOver());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Egg>() != null)
        {
            eggsInZone--;

            Debug.Log("Egg exited. eggsInZone = " + eggsInZone);
        }
    }

    private IEnumerator CheckGameOver()
    {
        checking = true;

        Debug.Log("Checking game over...");

        yield return new WaitForSeconds(1f);

        Debug.Log("eggsInZone = " + eggsInZone);

        if (eggsInZone > 0)
        {
            Debug.Log("Calling GameOver()");
            GameManager.Instance.GameOver();
        }

        checking = false;
    }
}