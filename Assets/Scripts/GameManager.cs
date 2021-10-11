using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null) Debug.LogError(" Game Manager Not Found!!!");
            }
            return _instance;
        }
    }
    #endregion

    [Header("Box Controller")]
    public int boxSpawn;
    [SerializeField] Box boxPrefabs;

    [Header("Game Area Constraint")]
    public float areaConstraintValue = 5f;

    private void Start()
    {
        for (int i = 0; i < boxSpawn; i++)
        {
            Box box = Instantiate(boxPrefabs);
            box.Spawn();
        }
    }

    public Vector2 GetRandomPosition()
    {
        float xPosition = Random.Range(-areaConstraintValue, areaConstraintValue);
        float yPosition = Random.Range(-areaConstraintValue, areaConstraintValue);

        return new Vector2(xPosition, yPosition);
    }
}