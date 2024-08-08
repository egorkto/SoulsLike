using UnityEngine;

public class FootIK : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;
    [SerializeField] [Range(0, 1)] private float _weight = 1f;
    [SerializeField] [Range(0, 1)] private float _hipsWeight = 0.75f;
    [SerializeField] [Range(0, 1)] private float _footPositionWeight = 1f;
    [SerializeField] [Range(0, 1)] private float _footRotationWeight = 1f; 
    [SerializeField] private float _maxStep = 0.5f;
    [SerializeField] private float _offset = 0f;
    [SerializeField] private float _hipsPositionSpeed = 1f;
    [SerializeField] private float _feetPositionSpeed = 2f;
    [SerializeField] private float _feetRotationSpeed = 90;
    [SerializeField] private LayerMask _ground = 1;

    private Vector3 _lIKPosition, _rIKPosition, _lNormal, _rNormal;
    private Quaternion _lIKRotation, _rIKRotation, _lastLRotation, _lastRRotation;
    private float _lastRFootHeight, _lastLFootHeight;
    private float _falloffWeight;
    private float _lastHeight;
    private bool _lGrounded, _rGrounded;

    private void OnAnimatorIK(int layerIndex)
    {
        _falloffWeight = _lGrounded || _rGrounded ? _weight : 0;
        if (_controller.isGrounded)
        {
            FootSolver(HumanBodyBones.LeftFoot, ref _lIKPosition, ref _lNormal, ref _lIKRotation, ref _lGrounded);
            FootSolver(HumanBodyBones.RightFoot, ref _rIKPosition, ref _rNormal, ref _rIKRotation, ref _rGrounded);
            MovePelvisHeight();
            MoveIK(AvatarIKGoal.LeftFoot, _lIKPosition, _lNormal, _lIKRotation, ref _lastLFootHeight, ref _lastLRotation);
            MoveIK(AvatarIKGoal.RightFoot, _rIKPosition, _rNormal, _rIKRotation, ref _lastRFootHeight, ref _lastRRotation);
        }
    }

    private void MovePelvisHeight()
    {
        float leftOffset = _lIKPosition.y - _animator.transform.position.y;
        float rightOffset = _rIKPosition.y - _animator.transform.position.y;
        float TotalOffset = (leftOffset < rightOffset) ? leftOffset : rightOffset;
        Vector3 NewPosition = _animator.bodyPosition;
        float NewHeight = TotalOffset * (_hipsWeight * _falloffWeight);
        _lastHeight = Mathf.MoveTowards(_lastHeight, NewHeight, _hipsPositionSpeed * Time.deltaTime);
        NewPosition.y += _lastHeight + _offset;
        _animator.bodyPosition = NewPosition;
    }

    void MoveIK(AvatarIKGoal foot, Vector3 IKPosition, Vector3 normal, Quaternion IKRotation, ref float lastHeight, ref Quaternion lastRotation)
    {
        Vector3 position = _animator.GetIKPosition(foot);
        Quaternion rotation = _animator.GetIKRotation(foot);
        position = _animator.transform.InverseTransformPoint(position);
        IKPosition = _animator.transform.InverseTransformPoint(IKPosition);
        lastHeight = Mathf.MoveTowards(lastHeight, IKPosition.y, _feetPositionSpeed * Time.deltaTime);
        position.y += lastHeight;
        position = _animator.transform.TransformPoint(position);
        position += normal * _offset;
        Quaternion Relative = Quaternion.Inverse(IKRotation * rotation) * rotation;
        lastRotation = Quaternion.RotateTowards(lastRotation, Quaternion.Inverse(Relative), _feetRotationSpeed * Time.deltaTime);
        rotation *= lastRotation;
        _animator.SetIKPosition(foot, position);
        _animator.SetIKPositionWeight(foot, _footPositionWeight * _falloffWeight);
        _animator.SetIKRotation(foot, rotation);
        _animator.SetIKRotationWeight(foot, _footRotationWeight * _falloffWeight);
    }

    private void FootSolver(HumanBodyBones foot, ref Vector3 IKPosition, ref Vector3 normal, ref Quaternion IKRotation, ref bool grounded)
    {
        var position = _animator.GetBoneTransform(foot).position;
        position.y = _animator.transform.position.y + _maxStep;
        position -= normal * _offset;
        grounded = true;
        RaycastHit hit;

        if (Physics.Raycast(position, Vector3.down, out hit, _maxStep * 2, _ground))
        {
            grounded = _animator.transform.position.y - hit.point.y < _maxStep;
            IKPosition = hit.point;
            normal = hit.normal;
            Vector3 Axis = Vector3.Cross(Vector3.up, hit.normal);
            float Angle = Vector3.Angle(Vector3.up, hit.normal);
            IKRotation = Quaternion.AngleAxis(Angle, Axis);
            if((_animator.transform.position.y - hit.point.y) >= _maxStep)
            {
                IKPosition.y = _animator.transform.position.y - _maxStep;
                IKRotation = Quaternion.identity;
            }
        }
    }
}
