using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour
{

    public Sprite[] sprites;
    public Image scrollBar;

    public float[] points;
    [Tooltip("how many screens or pages are there within the content (steps)")]
    public int screens = 1;
    public float stepSize;

    ScrollRect scroll;
    public bool LerpH;
    public float targetH;
    public Sprite targetImage;
    [Tooltip("Snap horizontally")]
    public bool snapInH = true;

    bool LerpV;
    float targetV;
    [Tooltip("Snap vertically")]
    public bool snapInV = true;

    // Use this for initialization
    void Start()
    {
        scroll = gameObject.GetComponent<ScrollRect>();
        scroll.horizontalNormalizedPosition = 0f;
        //scroll.inertia = false;
        if (screens > 0)
        {
            points = new float[screens];
            stepSize = 1 / (float)(screens - 1);

            for (int i = 0; i < screens; i++)
            {
                points[i] = i * stepSize;
            }
        }
        else
        {
            points[0] = 0;
        }
    }

    void Update()
    {
        int index = FindNearest(scroll.horizontalNormalizedPosition, points);
        targetImage = sprites[index];
        scrollBar.sprite = targetImage;
        if (LerpH)
        {
            scroll.horizontalNormalizedPosition = Mathf.Lerp(scroll.horizontalNormalizedPosition, targetH, 10 * scroll.elasticity * Time.deltaTime);
            if (scroll.horizontalNormalizedPosition == targetH) LerpH = false;
        }
        if (LerpV)
        {
            scroll.verticalNormalizedPosition = Mathf.Lerp(scroll.verticalNormalizedPosition, targetV, 10 * scroll.elasticity * Time.deltaTime);
            if (Mathf.Approximately(scroll.verticalNormalizedPosition, targetV)) LerpV = false;
        }
    }

    public void DragEnd()
    {
        if (scroll.horizontal && snapInH)
        {
            Debug.Log("Scroll: " + scroll.horizontalNormalizedPosition);
            int index = FindNearest(scroll.horizontalNormalizedPosition, points);
            targetH = points[index];
            targetImage = sprites[index];
            LerpH = true;
        }
        if (scroll.vertical && snapInV)
        {
            targetH = points[FindNearest(scroll.verticalNormalizedPosition, points)];
            LerpH = true;
        }
    }

    public void OnDrag()
    {
        LerpH = false;
        LerpV = false;
    }

    int FindNearest(float f, float[] array)
    {
        float distance = Mathf.Infinity;
        int output = 0;
        for (int index = 0; index < array.Length; index++)
        {
            if (Mathf.Abs(array[index] - f) < distance)
            {     
                distance = Mathf.Abs(array[index] - f);
                Debug.Log(f);
                output = index;
            }
        }
        return output;
    }
}