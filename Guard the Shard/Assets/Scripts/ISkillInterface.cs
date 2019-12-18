using UnityEngine;
public interface ISkillInterface
{
    void SendParameters(float range,int damage,float slow,float duration);
    void PrepareForUse();
    void SpawnObject(Vector3 vector3);
    bool DeductCost(int cost);
}
