using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase
{
    public virtual void Fire(MyShooter shooter) { }
    public virtual void Discard(MyShooter shooter) { }
}
