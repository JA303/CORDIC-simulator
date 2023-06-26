using UnityEngine;

public class CordicInputs : MonoBehaviour
{
    [SerializeField] public double x;
    [SerializeField] public double y;
    [SerializeField] public double z;

    [SerializeField] public CordicBlock.Mode mode;
    [SerializeField] public int mu;

    [SerializeField] public int itrationCount = 3;
}
