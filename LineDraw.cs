using UnityEngine;
using System.Collections;

public class LineDraw : MonoBehaviour
{

    public Vector3 Origin = new Vector3();
    public Vector3 EndPoint = new Vector3();
    public GameObject Player;

    private float dist;
    private float counter;

    LineRenderer Lrender;

    // Use this for initialization
    void Start()
    {


        Lrender = gameObject.GetComponent<LineRenderer>();

        Lrender.useWorldSpace = true;
        Lrender.SetColors(Color.red, Color.red);
        Lrender.SetPosition(0, Origin);

        Lrender.SetWidth(0.2f, 0.2f);

        dist = Vector3.Distance(Origin, EndPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < dist)
        {
            counter += 0.1f / 4.0f;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointAlongLine = x * Vector3.Normalize(EndPoint - Origin) + Origin;
            Lrender.SetPosition(1, pointAlongLine);

        }
    }
}