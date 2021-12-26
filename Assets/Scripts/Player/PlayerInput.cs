using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    private bool _canScanSwipe;
    private PlayerMover _mover;

    private void Start() => _mover = GetComponent<PlayerMover>();

    private void Update()
    {
        if (_canScanSwipe)
            ScanSwipe();
    }

    public void BeginToScanSwipe() => _canScanSwipe = true;

    private void FinishToScanSwipe() => _canScanSwipe = false;

    private void ScanSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            _startTouchPosition = Input.GetTouch(0).position;

        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _endTouchPosition = Input.GetTouch(0).position;

            if (_endTouchPosition.x < _startTouchPosition.x)
                OnLeftSwipe();

            else if (_endTouchPosition.x > _startTouchPosition.x)
                OnRightSwipe();
        }
    }

    private void OnLeftSwipe()
    {
        Debug.Log("OnLeftSwipe");
        FinishToScanSwipe();
        _mover.MoveLeft();
    }

    private void OnRightSwipe()
    {
        _mover.MoveRight();
        Debug.Log("OnRightSwipe");
        FinishToScanSwipe();
    }
}