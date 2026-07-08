using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;

    public EggData tinyFishEgg;
    public EggData[] spawnableEggs;

    private bool firstSpawn = true;

    // Half-second delay between spawns
    public float spawnCooldown = 1.0f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if ((Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame) || (Mouse.current != null &&
             Mouse.current.leftButton.wasPressedThisFrame))
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            if (Mouse.current != null &&
             Mouse.current.leftButton.wasPressedThisFrame) {touchPos = Mouse.current.position.ReadValue();}

            Vector3 pos = Camera.main.ScreenToWorldPoint(
                new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane));

            pos.z = 0;

            // Don't spawn if outside tank
            if (pos.x < -3.45f || pos.x > 3.2f)
            {
                return;
            }

            GameObject eggObj = Instantiate(
                eggPrefab,
                new Vector3(pos.x, 1.6f, 0),
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