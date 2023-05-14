using UnityEngine;

// Used to store wave important stats
[System.Serializable]
public class Wave
{
    public WaveGroup[] enemies;
    public float spawnRate;

    [System.Serializable]
    public class WaveGroup
    {
        public GameObject enemy;
        public int count;
    }

}
