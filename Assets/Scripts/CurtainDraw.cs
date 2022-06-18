using UnityEngine;

public class CurtainDraw : MonoBehaviour
{
    private float startPosx = 2;
    private float startScalex = 1.6f;
    
    private float endPosx = -0.7598f;
    private float endScalex = 0.22016f;



    public void updateCurtain (float progress)
    {
        if (progress >= 0 && progress <= 1)
        {
            transform.position = new Vector3(- progress * (endPosx - startPosx) + endPosx, transform.position.y, transform.position.z);
            transform.localScale = new Vector3(progress * (endScalex - startScalex) - endScalex, transform.localScale.y, transform.localScale.z);
        }
    }
}
