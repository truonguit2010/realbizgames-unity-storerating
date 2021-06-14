using System.Collections;
using RealbizGames.RulePattern;

namespace RealbizGames.Platform
{
    public class AppStoreRatingRule : IRule<IEnumerator, string>
    {
        public IEnumerator Execute(string expression)
        {
            yield return null;
            #if UNITY_IOS
            UnityEngine.iOS.Device.RequestStoreReview();
            #endif
        }

        public bool Valuate(string expression)
        {
            #if UNITY_IOS 
            return true;
            #else
            return false;
            #endif
        }
    }
}