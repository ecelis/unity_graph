using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    [Range(10, 100)] public int resolution = 10;
    private Transform[] points;

    void Awake ()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        // f(x) = 0
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            // f(x) = x
            //position.y = position.x;
            // f(x) = x^2
            //position.y = position.x * position.x;
            // f(x) = x^3
            //position.y = position.x * position.x * position.x;
            // f(x) = sin(x)
            //position.y = Mathf.Sin(position.x);
            // f(x) = sin(pi*x)
            //position.y = Mathf.Sin(Mathf.PI * position.x);
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);  // false unbpunds position, scale and rotation of th parent
            points[i] = point;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            // f(x, t) = sin(pi*(x+t))
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
        }
    }
}
