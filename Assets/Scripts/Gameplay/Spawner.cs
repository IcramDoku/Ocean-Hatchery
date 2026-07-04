using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;

    public EggData tinyFishEgg;
    public EggData[] spawnableEggs;

    private bool firstSpawn = true;

    // Half-second delay between spawns
    public float spawnCooldown = 0.5f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Don't allow spawning too quickly
            if (Time.time < nextSpawnTime)
                return;

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
                new Vector3(pos.x, 3f, 0),
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

            // Start cooldown
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }
}