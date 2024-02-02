using Unity.VisualScripting;
using UnityEngine;
public class KeyboardControlMovment : MonoBehaviour
{    GridMovment gridMovment;

    private void Start()
    {
        gridMovment = GetComponent<GridMovment>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            StartCoroutine(gridMovment.MovePIayer(Vector3.up));
        if (Input.GetKey(KeyCode.S))
            StartCoroutine(gridMovment.MovePIayer(Vector3.down));
        if (Input.GetKey(KeyCode.A))
            StartCoroutine(gridMovment.MovePIayer(Vector3.left));
        if (Input.GetKey(KeyCode.D))
            StartCoroutine(gridMovment.MovePIayer(Vector3.right));
    }
}
