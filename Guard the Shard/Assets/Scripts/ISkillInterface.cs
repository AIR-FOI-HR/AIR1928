using UnityEngine;
public interface ISkillInterface
{
    void PrepareForUse();
    void SpawnObject(Vector3 vector3);
    bool DeductCost(int cost);
}
