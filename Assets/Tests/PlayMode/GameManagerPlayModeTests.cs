using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Play mode tests validating basic GameManager behavior.
/// </summary>
public class GameManagerPlayModeTests
{
    [UnityTest]
    public IEnumerator GameManager_AddCoinsAndHeal_UpdatesValues()
    {
        // Create a temporary GameObject with GameManager attached
        var go = new GameObject();
        var gm = go.AddComponent<GameManager>();

        // Capture starting coin and life counts
        int initialCoins = gm.coins;
        int initialLives = gm.lives;

        // Apply changes
        gm.AddCoins(5);
        gm.Heal();

        // Wait a frame in case there is delayed processing
        yield return null;

        // Verify the values were updated correctly
        Assert.AreEqual(initialCoins + 5, gm.coins);
        Assert.AreEqual(initialLives + 1, gm.lives);

        // Clean up the test object
        Object.Destroy(go);
    }
}
