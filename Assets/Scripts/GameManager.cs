using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int Score { get; private set; }

    [Header("Box Controller")]
    public int boxSpawn;
    [SerializeField] Box boxPrefab;
    private List<Box> boxPool = new List<Box>();

    [Header("Game Area Constraint")]
    public float areaConstraintValue = 5f;

    [Header("UI")]
    public Text scoreText;

    private void Start()
    {
        for (int i = 0; i < boxSpawn; i++)
        {
            Box box = Instantiate(boxPrefab);
            box.Spawn();
        }
         scoreText.text = $"{Score}";
    }

    public Vector2 GetRandomPosition()
    {
        float xPosition = Random.Range(-areaConstraintValue, areaConstraintValue);
        float yPosition = Random.Range(-areaConstraintValue, areaConstraintValue);

        return new Vector2(xPosition, yPosition);
    }

    public void AddScore()
    {
        Score++;
        scoreText.text = $"{Score}";
    }

    public void RespawnBox() => StartCoroutine(ReSpawnBox());
    IEnumerator ReSpawnBox()
    {
        yield return new WaitForSeconds(3);
        Box box = GetBox();
        box.Spawn();
    }

    public Box GetBox()
    {
        for (int i = 0; i < boxPool.Count; i++)
        {
            if (!boxPool[i].gameObject.activeSelf)
            {
                boxPool[i].gameObject.SetActive(true);
                return boxPool[i];
            }
        }

        Box boxObject = Instantiate(boxPrefab, transform);
        boxPool.Add(boxObject);
        return boxObject;
    }
}