using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    public bool IsActive => _isActive;

    [SerializeField] private RectTransform _pointer;
    [SerializeField] private RectTransform _skillChecker;
    [SerializeField] private RectTransform _container;

    [Header("Settings")]
    [SerializeField] private float _minSkillCheckerWidth;
    [SerializeField] private float _maxSkillCheckerWidth;
    [SerializeField] private float _checkerSpeed = 5.5f;
    private static int tentativi = 1;
    [SerializeField] private bool _restartAfterInput;
    [SerializeField] private float _timeToWaitAfterInput;
    private Vector2 defaultArrowposition;


    [Header("Debug")]
    [SerializeField] private bool _changeSkillCheckPos;
    [SerializeField] private bool _canMove;

    public BoolEvent OnSkillCheckDone = new BoolEvent();

    private bool _isActive;
    private float _ySkillChecker;
    private float _maxPosition;
    private Pointer _pointerToCheck;

    private bool _isGoingToRight;
    private bool _isGoingToLeft;

    private void Start()
    {
        _pointerToCheck = _pointer.GetComponent<Pointer>();

        Active();
    }

    public void Active()
    {
        defaultArrowposition = _pointer.anchoredPosition;
        _canMove = true;
        _isActive = true;
        _ySkillChecker = _skillChecker.sizeDelta.y;
        gameObject.SetActive(_isActive);
        Debug.Log("Container width " + _container.sizeDelta);
        RandomizePositionAndWidth();
        StartCoroutine(MovePointer());
    }


    private void Update()
    {
        if (_changeSkillCheckPos)
        {
            _changeSkillCheckPos = false;
            RandomizePositionAndWidth();
        }
        if (Input.GetMouseButtonDown(0))
        {
            _canMove = false;

            var colls = _pointerToCheck.CheckIfFailed();

            if(colls == null || colls.Length == 0)
            {
                Debug.Log("Niente hai fallito");
            }

            bool giusto = colls.ToList().Exists(col => col.gameObject == _skillChecker.gameObject);
            OnSkillCheckDone?.Invoke(giusto);

            if (giusto)
                tentativi++;

            if (gameObject.activeInHierarchy == false)
                return;

            if (!_restartAfterInput) return;

            StopAllCoroutines();

            StartCoroutine(WaitAfterInput());
        }
    }

    IEnumerator MovePointer()
    {
        while (_canMove)
        {
            while (!IsReachedMax() && _canMove && !_isGoingToLeft)
            {
                _isGoingToLeft = false;
                _isGoingToRight = true;
                _pointer.Translate(new Vector3(_checkerSpeed * tentativi * Time.deltaTime, 0, 0));
                yield return null;
            }

            _isGoingToRight = false;

            while (!IsReachedMin() && _canMove && !_isGoingToRight)
            {
                _isGoingToLeft = true;
                _isGoingToRight = false;
                _pointer.Translate(new Vector3(-_checkerSpeed * tentativi * Time.deltaTime, 0, 0));
                yield return null;
            }

            _isGoingToLeft = false;

            yield return null;
        }
    }

    IEnumerator WaitAfterInput()
    {
        yield return new WaitForSeconds(_timeToWaitAfterInput);

        _canMove = true;

        StartCoroutine(MovePointer());
    }

    private bool IsReachedMax()
    {
        return _pointer.anchoredPosition.x >= _container.rect.width - _pointer.sizeDelta.x;
    }

    private bool IsReachedMin()
    {
        return _pointer.anchoredPosition.x <= 0;
    }

    public void RandomizePositionAndWidth()
    {
        _skillChecker.sizeDelta = new Vector2(Random.Range(_minSkillCheckerWidth, _maxSkillCheckerWidth), _ySkillChecker);
        _maxPosition = (_container.rect.width / 2) - (_skillChecker.sizeDelta.x / 2);
        _skillChecker.anchoredPosition = new Vector2(Random.Range(-_maxPosition + 10, _maxPosition), 0);

        var colliderToSkillChecker = _skillChecker.gameObject.GetComponent<BoxCollider2D>();

        if (colliderToSkillChecker == null) return;

        colliderToSkillChecker.size = _skillChecker.sizeDelta;
    }

    public void OnDisable()
    {
        StopAllCoroutines();
        _isActive = false;
            
    }
    public void OnEnable()
    {
        _pointer.anchoredPosition = defaultArrowposition;
        Active();

    }
}
