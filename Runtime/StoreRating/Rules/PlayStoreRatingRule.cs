using System.Collections;
using RealbizGames.RulePattern;

namespace RealbizGames.Platform
{
    public class PlayStoreRatingRule : IRule<IEnumerator, string>
    {
        public const string TAG = "PlayStoreRatingRule";
        
        public IEnumerator Execute(string expression)
        {
            yield return null;
#if UNITY_ANDROID
            Google.Play.Review.ReviewManager _reviewManager = new Google.Play.Review.ReviewManager();
            var requestFlowOperation = _reviewManager.RequestReviewFlow();
            yield return requestFlowOperation;
            if (requestFlowOperation.Error != Google.Play.Review.ReviewErrorCode.NoError)
            {
                
                // Log error. For example, using requestFlowOperation.Error.ToString().
                UnityEngine.Debug.LogFormat("{0} - Log error. For example, using requestFlowOperation {1}", TAG, requestFlowOperation.Error.ToString());
                yield break;
            }
            Google.Play.Review.PlayReviewInfo playReviewInfo = requestFlowOperation.GetResult();
            var launchFlowOperation = _reviewManager.LaunchReviewFlow(playReviewInfo);
            yield return launchFlowOperation;

            if (launchFlowOperation.Error != Google.Play.Review.ReviewErrorCode.NoError)
            {
                // Log error. For example, using requestFlowOperation.Error.ToString().
                UnityEngine.Debug.LogFormat("{0} - Log error. For example, using launchFlowOperation {1}", TAG, launchFlowOperation.Error.ToString());
                yield break;
            }
#endif
        }

        public bool Valuate(string expression)
        {
            #if UNITY_ANDROID
            return true;
            #else
            return false;
            #endif
        }


    }
}