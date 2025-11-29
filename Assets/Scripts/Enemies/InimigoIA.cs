using UnityEngine;

// Wrapper class to maintain backward compatibility with existing scenes
// that reference "InimigoIA".
[System.Obsolete("Use EnemyAI instead.")]
public class InimigoIA : EnemyAI
{
    // Inherits all logic from EnemyAI.
    // Unity Inspector values might be lost if not carefully migrated, 
    // but this prevents "Missing Script" errors on the GameObject itself.
}
