using System.Collections;
using UnityEngine;
public class enemyMovment : MonoBehaviour
{
    [SerializeField] private float _timeToMove = 0.2f;
    private bool _isMoving;
    private Vector3 _originPosition, targetPos;
    Rigidbody2D _rigidbody;
    Vector3[] MoveEnemy = new Vector3[4]
        {
            Vector3.up,
            Vector3.right,
            Vector3.left,
            Vector3.down
        };

    public LayerMask unit;

    SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Player.moveUnit += moveEnemy;
    }
    void moveEnemy()
    {
        int vector = Random.Range(0, 3);
        StartCoroutine(MovePIayer(MoveEnemy[vector]));

    }

    public IEnumerator MovePIayer(Vector3 direction)
    {
        if (!Occupied(direction))
        {
            _isMoving = true;

            float elapsedTime = 0;
            _originPosition = transform.position;
            targetPos = _originPosition + direction;
            while (elapsedTime < _timeToMove)
            {
                transform.position = Vector3.Lerp(_originPosition, targetPos, (elapsedTime / _timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
            _isMoving = false;
        }
    }
    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0f, direction, 1f, unit);
        return hit.collider != null;
    }
}

