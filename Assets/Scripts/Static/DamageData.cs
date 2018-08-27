using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData
{
    public static float GetGroundShooterDamage() => Random.Range(10f, 20f);

    public static float GetEnemyContactDamage() => Random.Range(5f, 10f);

	public static float GetWallShooterDamage() => Random.Range(20f, 30f);
}
