using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] RectTransform[] layers;
    [SerializeField] GameObject[] bgPrefabs;
    [SerializeField] float[] layersSpeeds;
    [SerializeField] float[] layersDistances;
	[SerializeField] float spawnInterval;

	float[] timers;
	int[] multipliers;

	void Start()
	{
		timers = new float[layers.Length];
		multipliers = new int[layers.Length];

		for (int i = 0; i < timers.Length; i++)
			timers[i] = spawnInterval - 0.1f;

		for (int i = 0; i < timers.Length; i++)
			multipliers[i] = 1;
	}

    void Update()
    {
		for (int i = 0; i < timers.Length; i++)
			timers[i] += Time.deltaTime;

        for (int i = 0; i < layers.Length; i++)
        {
            Vector2 position = layers[i].anchoredPosition;
            layers[i].anchoredPosition = new Vector2(position.x - layersSpeeds[i] * Time.deltaTime, position.y);

			if (timers[i] >= spawnInterval)
			{
				GameObject bg = Instantiate(bgPrefabs[i]);
				bg.transform.SetParent(layers[i]);
				bg.transform.localScale = new Vector2(4, 4);
				bg.transform.localPosition = new Vector2(layersDistances[i] * multipliers[i], 0);

				timers[i] = 0f;
				multipliers[i]++;				
			}
        }
    }
}
