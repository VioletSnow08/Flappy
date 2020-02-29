using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColumnPool : MonoBehaviour
{
    // Start is called before the first frame update
    public int ColumnPoolSize = 5;
    private GameObject[] _columns;
    public float SpawnRate = 4f;
    public float ColumnMinY = -1f;
    public float ColumnMaxY = 3.5f;
    public GameObject ColumnPrefab;
    private float _spawnXPosition = 10f;
    private readonly Vector2 _objectPoolPosition = new Vector2(-15f, -25f);
    private float _timeSinceLastSpawned;
    private int _currentColumn = 0;

    void Start()
    {
	    _columns = new GameObject[ColumnPoolSize];
	    for (int i = 0; i < ColumnPoolSize; i++)
	    {
		    _columns[i] = (GameObject) Instantiate(ColumnPrefab, _objectPoolPosition, Quaternion.identity);
	    }
    }

    // Update is called once per frame
    void Update()
    {
	    _timeSinceLastSpawned += Time.deltaTime;
	    if (GameControl.instance.gameOver == false && _timeSinceLastSpawned >= SpawnRate)
	    {
		    _timeSinceLastSpawned = 0;
		    float _spawnYPosition = Random.Range(ColumnMinY, ColumnMaxY);
		    _columns[_currentColumn].transform.position = new Vector2(_spawnXPosition, _spawnYPosition);
		    _currentColumn++;
		    if (_currentColumn >= ColumnPoolSize)
		    {
			    _currentColumn = 0;
		    }
	    }
    }
}
