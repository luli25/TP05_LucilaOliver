using UnityEngine;

public class Utilities7 : MonoBehaviour
{
    public static bool CheckLayerInMask(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}