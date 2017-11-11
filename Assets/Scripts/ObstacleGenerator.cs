using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject stalactitePrefab;
    [SerializeField] float generationInterval;
    [SerializeField] float separation;
    [SerializeField] float speed;
    [SerializeField] float[] stalactiteYPositions;
    [SerializeField] Vector2[] stalactiteScales;


    float timer;
    Vector2 position;
    int prevX = 5;

    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= generationInterval)
        {
            GenerateStalactite();
            timer = 0;
        }

        Vector2 position = GetComponent<RectTransform>().anchoredPosition;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(position.x - speed * Time.deltaTime, position.y);
    }

    public void GenerateStalactite()
    {
        GameObject stalactite = Instantiate(stalactitePrefab);

        int random = Random.Range(0, 2);

        stalactite.transform.SetParent(gameObject.transform);
        stalactite.GetComponent<Transform>().localScale = stalactiteScales[random];
        stalactite.GetComponent<Transform>().localPosition = new Vector2(separation + prevX, stalactiteYPositions[random]);
        prevX = (int)stalactite.GetComponent<Transform>().localPosition.x;
    }

}
