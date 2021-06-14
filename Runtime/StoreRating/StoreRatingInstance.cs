using System.Collections;
using UnityEngine;
using RealbizGames.RulePattern;

namespace RealbizGames.Platform
{
    public class StoreRatingInstance
    {
        private static StoreRatingInstance _defaultInstance;

        public static StoreRatingInstance DefaultInstance {
            get {
                if (_defaultInstance == null) {
                    _defaultInstance = new StoreRatingInstance();
                }
                return _defaultInstance;
            }
        }
        
        private IRuleEngine<IEnumerator, string> _ruleEngine;
        private StoreRatingInstance () {
            InitRuleEngine();
        }

        private void InitRuleEngine() {
            _ruleEngine = new GenericRuleEngine<IEnumerator, string>();
            _ruleEngine.AddRule(new AppStoreRatingRule());
            _ruleEngine.AddRule(new PlayStoreRatingRule());
        }

        public void AddRule(IRule<IEnumerator, string> rule) {
            _ruleEngine.AddRule(rule);
        }

        public void Rate(MonoBehaviour behaviour, string expression = "") {
            behaviour.StartCoroutine(_ruleEngine.Execute(expression: expression));
        }


    }

}
