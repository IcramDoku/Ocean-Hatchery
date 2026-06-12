using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 pos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            pos.z = 0;

            Instantiate(
                eggPrefab,
                new Vector3(pos.x, 5f, 0),
                Quaternion.identity
            );
        }
    }
}