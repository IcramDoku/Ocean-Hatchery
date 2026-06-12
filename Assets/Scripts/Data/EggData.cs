using UnityEngine;

[CreateAssetMenu(fileName = "EggData", menuName = "Ocean Hatchery/Egg Data")]
public class EggData : ScriptableObject
{
    public int level;
    public int scoreValue;
    public Sprite sprite;
    public EggData nextEgg;
}
