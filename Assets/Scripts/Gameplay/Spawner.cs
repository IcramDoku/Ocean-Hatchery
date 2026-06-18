using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;

    public EggData tinyFishEgg;
    public EggData[] spawnableEggs;

    private bool firstSpawn = true;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 pos =
                Camera.main.ScreenToWorldPoint(
                    Mouse.current.position.ReadValue());

            pos.z = 0;

            // Don't spawn if outside tank
            if (pos.x < -3.45f || pos.x > 3.2f)
            {
                return;
            }

            GameObject eggObj = Instantiate(
                eggPrefab,
                new Vector3(pos.x, 4f, 0),
                Quaternion.identity
            );

            Egg egg = eggObj.GetComponent<Egg>();

            if (firstSpawn)
            {
                egg.data = tinyFishEgg;
                firstSpawn = false;
            }
            else
            {
                egg.data =
                    spawnableEggs[
                        Random.Range(0, spawnableEggs.Length)
                    ];
            }

            egg.Refresh();
        }
    }
}