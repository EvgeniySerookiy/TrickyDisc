using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _rotationAngleZ;
    private bool _isMovingRotation = true;
    private float _currentTime;
    private Quaternion _quaternionMinAngleZ;
    private Quaternion _quaternionMaxAngleZ;

    private void Update()
    {
        Rotate();
    }
    
    public void Initialize()
    {
        _quaternionMaxAngleZ = Quaternion.Euler(0, 0, _rotationAngleZ);
        _quaternionMinAngleZ = Quaternion.Euler(0, 0, -_rotationAngleZ);
    }

    private void Rotate()
    {
        _currentTime += Time.deltaTime;
        var progress = _isMovingRotation? _currentTime / _duration : 1 - _currentTime / _duration;
        
        transform.rotation = Quaternion.Lerp(_quaternionMaxAngleZ, _quaternionMinAngleZ, progress);

        if (_currentTime > _duration)
        {
            _currentTime = 0f;
            _isMovingRotation = !_isMovingRotation;
        }
    }
}
