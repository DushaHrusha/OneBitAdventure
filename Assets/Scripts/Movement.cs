using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]private IMovment _movment;
    public Movement(IMovment movmentUnit) => _movment = movmentUnit;


}
