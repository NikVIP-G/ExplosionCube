using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColorToRandom(Material material)
    {
        material.color = PickRandomColor();
    }

    private Color PickRandomColor()
    {
        return Random.ColorHSV();
    }
}
