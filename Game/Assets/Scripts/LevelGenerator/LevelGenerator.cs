using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Road prefabs")]
    [SerializeField] private GameObject straightRoad;
    [SerializeField] private GameObject turnLeftRoad;
    [SerializeField] private GameObject turnRightRoad;
    [SerializeField] private GameObject crossRoad;

    [Header("Settings")]
    [SerializeField] private int segmentsCount = 15;

    private Transform spawnPoint;

    void Start()
    {
        spawnPoint = transform;
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < segmentsCount; i++)
        {
            SpawnSegment();
        }
    }

    private void SpawnSegment()
    {
        GameObject prefab = GetRandomPrefab();

        GameObject segment = Instantiate(
            prefab,
            spawnPoint.position,
            spawnPoint.rotation,
            transform              // ← ВСЕ дороги будут дочерними
        );

        // Убираем "(Clone)" из имени
        segment.name = prefab.name;

        // Берём конечную точку дороги
        RoadSegment road = segment.GetComponent<RoadSegment>();
        spawnPoint = road.endPoint;
    }

    private GameObject GetRandomPrefab()
    {
        int choice = Random.Range(0, 4);

        return choice switch
        {
            0 => straightRoad,
            1 => turnLeftRoad,
            2 => turnRightRoad,
            _ => crossRoad
        };
    }
}