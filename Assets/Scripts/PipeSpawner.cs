using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.3f;
    [SerializeField] private float _yPosRange = 0.7f;
    [SerializeField] private GameObject _pipe;

    private float _timer;
    private int _pipeCount = 0;   // 👈 track pipes

    void Start()
    {
        PipeSpawn();
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _maxTime)
        {
            PipeSpawn();
            _timer = 0f;
        }
    }

    void PipeSpawn()
    {
        Vector3 pipePos = transform.position +
            new Vector3(0, Random.Range(-_yPosRange, _yPosRange), 0);

        GameObject pipe = Instantiate(_pipe, pipePos, Quaternion.identity);

        _pipeCount++;

        // find coin inside prefab
        Transform coin = pipe.transform.Find("Coin");

        if (coin != null)
        {
            // enable coin every 4 pipes
            coin.gameObject.SetActive(_pipeCount % 4 == 0);
        }

        Destroy(pipe, 10f);
    }
}