using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CircleArea : MonoBehaviour
{
    [SerializeField, Range(10, 50)] private float _power;
    [Space(5)]

    [SerializeField, Range(0, 50)] private int _segments = 50;
    [SerializeField, Range(0, 10)] private float _radius = 4;
    [Space(3)]

    [SerializeField] private LayerMask _draggable;

    private float _xRadius;
    private float _yRadius;
    
    private LineRenderer line;

    private List<RaycastHit2D> _currentObjects = new ();

    private void Start()
    {
        _xRadius = _radius;
        _yRadius = _radius;

        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(_segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    private void Update()
    {
        RaycastHit2D[] objects = Physics2D.CircleCastAll(transform.position, _radius, new Vector2(0, 0), 0, _draggable);
        CompareLists(objects);

        foreach (var obj in objects)
        {
            if (obj.collider.gameObject.TryGetComponent(out DraggableObject draggableObject))
            {
                draggableObject.CanBeDragged = true;
                draggableObject.SetPlayerTransform(transform);
                _currentObjects.Add(obj);
            }
        }
    }

    // comparing current collisions with previous frame's ones
    private void CompareLists(RaycastHit2D[] objects)
    {
        List<RaycastHit2D> objectsList = new (objects);

        List<RaycastHit2D> tempList = new ();
        tempList.AddRange(_currentObjects.Except(objectsList).ToList());

        foreach (var obj in tempList)
        {
            if (obj.collider.gameObject.TryGetComponent(out DraggableObject draggableObject))
            {
                draggableObject.CanBeDragged = false;
            }
        }

        tempList.Clear();
        _currentObjects.Clear();
    }

    private void CreatePoints()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * _xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * _yRadius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / _segments);
        }
    }
}
