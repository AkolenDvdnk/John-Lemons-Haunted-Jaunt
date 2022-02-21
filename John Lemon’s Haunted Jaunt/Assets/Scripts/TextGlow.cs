using UnityEngine;
using TMPro;

public class TextGlow : MonoBehaviour
{
    private TextMeshProUGUI text;

    private float dilateValue = -1;

    private bool lessThanOne = true;
    private bool animationPlayed = false;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (animationPlayed)
            return;

        text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilateValue);

        if (dilateValue <= 1f && lessThanOne)
        {
            dilateValue += 0.02f;
            
            if (dilateValue >= 1)
            {
                lessThanOne = false;
                dilateValue = 1f;
            }
        }
        if (!lessThanOne)
        {
            dilateValue -= 0.01f;

            if (dilateValue <= 0f)
            {
                dilateValue = 0f;
                animationPlayed = true;
            }
        }
    }
}
