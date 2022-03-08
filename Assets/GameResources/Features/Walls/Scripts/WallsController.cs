using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер стен
/// </summary>
[RequireComponent(typeof(Animation))]
public class WallsController : AbstractHealth
{
    /// <summary>
    /// Список точек, к которым должны идти зомби
    /// </summary>
    public IReadOnlyList<Transform> Points => points;

    /// <summary>
    /// Финальная точка
    /// </summary>
    public Transform FinalPoint => finalPoint;

    [SerializeField]
    private Transform finalPoint;
    [SerializeField]
    private List<Transform> points;

    private Animation anim;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animation>();
    }

    protected override void OnHealthChange(int value)
    {
        if (!isDead && value <= 0)
        {
            DeadAnim();
        }
    }

    private void DeadAnim()
    {
        anim.Play();
    }
}
