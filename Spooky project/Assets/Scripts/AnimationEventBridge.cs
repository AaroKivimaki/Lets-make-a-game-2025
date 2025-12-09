using UnityEngine;

public class AnimationEventBridge : MonoBehaviour
{
    private MonsterAI monsterAI;

    void Start()
    {
        monsterAI = GetComponentInParent<MonsterAI>();

        if (monsterAI == null)
        {
            Debug.LogError("MonsterAI component not found on parent object!");
        }
    }

    public void FinishDyingFromAnim()
    {
        if (monsterAI != null)
        {
            monsterAI.FinishDying();
        }
        else
        {
            Debug.LogError("Bridge failed: MonsterAI reference is missing.");
        }
    }
}
