using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class GridMovment : MonoBehaviour
{
    [SerializeField] private float _timeToMove = 0.2f;
    private bool _isMoving;
    private Vector3 _originPosition, targetPos;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;

    public LayerMask unit;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _isMoving = false;


    }
    private void Update()
    {
        if (_isMoving != Player.isMoveing)
        {
            
            Player.isMoveing = _isMoving;
        }

        if (Input.GetKey(KeyCode.W) && !_isMoving)
            StartCoroutine(MovePIayer(Vector3.up));
            
        if (Input.GetKey(KeyCode.S) && !_isMoving)
            StartCoroutine(MovePIayer(Vector3.down));
        if (Input.GetKey(KeyCode.A) && !_isMoving)
        {
            StartCoroutine(MovePIayer(Vector3.left));
             _spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) && !_isMoving)
        {
            _spriteRenderer.flipX = false;
            StartCoroutine(MovePIayer(Vector3.right));
        }
    }

    public IEnumerator MovePIayer(Vector3 direction)
    {
        if (!Occupied(direction))
        {
        
        Player.Ok();
        _isMoving = true;

        float elapsedTime = 0;
        _originPosition = transform.position;
        targetPos = _originPosition + direction;
        while (elapsedTime < _timeToMove) 
        {
            transform.position = Vector3.Lerp(_originPosition, targetPos, (elapsedTime/_timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
       _isMoving = false;
        }
    }
    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one , 0f, direction, 1f, unit);
        return hit.collider != null;
    }

}
