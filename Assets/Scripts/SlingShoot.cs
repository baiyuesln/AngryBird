using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShoot : MonoBehaviour
{
    public static SlingShoot Instance { get; private set; }


    private LineRenderer leftLineRenderer;
    private LineRenderer rightLineRenderer;
    private Transform leftPoint;
    private Transform rightPoint;
    private Transform centerPoint;

    private Transform birdTransform;
    private bool isDrawing = false;

    private void Awake()
    {
        Instance = this;
        leftLineRenderer = transform.Find("LeftLineRenderer").GetComponent<LineRenderer>();
        rightLineRenderer = transform.Find("RightLineRenderer").GetComponent<LineRenderer>();
        leftPoint = transform.Find("LeftPoint");
        rightPoint = transform.Find("RightPoint");
        centerPoint = transform.Find("CenterPoint");
    }

    void Start()
    {
        

        HideLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrawing)
        {
            Draw();
        }
    }

    public void StartDraw(Transform birdTransform)
    {
        isDrawing = true;
        this.birdTransform = birdTransform;
        ShowLine();
    }

    public void EndDraw()
    {
        isDrawing = false;
        HideLine();

    }
      
    public void Draw()
    {
        Vector3 birdPosition = birdTransform.position;
        birdPosition +=  (birdPosition - centerPoint.position).normalized * 0.4f;

        leftLineRenderer.SetPosition(0, birdPosition);
        leftLineRenderer.SetPosition(1,leftPoint.position);

        rightLineRenderer.SetPosition(0, birdPosition);
        rightLineRenderer.SetPosition(1, rightPoint.position);

    }

    public Vector3 getCenterPosition()
    {
        return centerPoint.position;
    }

    private void HideLine()
    {
        rightLineRenderer.enabled = false;
        leftLineRenderer.enabled = false;  
    }
    private void ShowLine()
    {
        rightLineRenderer.enabled = true;
        leftLineRenderer.enabled = true;
    }
}
