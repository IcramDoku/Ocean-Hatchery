using UnityEngine;

public class Egg : MonoBehaviour
{
    public EggData data;

    private void Awake()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (data == null) return;

        GetComponent<SpriteRenderer>().sprite =
            data.sprite;
    }
}