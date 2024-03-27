using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    
    private Vector2 _startPosition;
    
    public void ChangeDirection()
    {
        _rigidbody.velocity *= -1;
    }
    
    public void Move()
    {
        _rigidbody.velocity = transform.up * _speed;
    }

    public void StopMove()
    {
        _rigidbody.velocity = Vector2.zero;
        transform.position = _startPosition;
    }

    public void Initialize()
    {
        _startPosition = transform.position;
    }
    
}
