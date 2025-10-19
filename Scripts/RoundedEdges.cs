using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class RoundedPanel : MonoBehaviour
{
    [Range(0f, 1f)] public float cornerRadius = 0.1f;
    private Material runtimeMaterial;
    private Image image;

    void OnEnable()
    {
        image = GetComponent<Image>();
        UpdateMaterial();
    }

    void OnValidate()
    {
        if (image != null)
            UpdateMaterial();
    }

    void UpdateMaterial()
    {
        if (runtimeMaterial == null)
        {
            runtimeMaterial = new Material(Shader.Find("UI/RoundedPanel"));
            image.material = runtimeMaterial;
        }

        runtimeMaterial.SetFloat("_Radius", cornerRadius);
    }

    void OnDestroy()
    {
        if (Application.isPlaying && runtimeMaterial != null)
            Destroy(runtimeMaterial);
    }
}
