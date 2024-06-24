using Assets.Codebase.Infrastructure.Fabrics;
using Assets.Codebase.Mechanics.ExpressionGenerator;
using Assets.Codebase.Mechanics.Character;
using Assets.Codebase.Mechanics.Timer;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;


namespace Assets.Codebase.UI
{
    public class GameplayUI : MonoBehaviour
    {
        private Player _player;
        private EnemyFactory _enemyFactory;
        private Timer _timer;

        [SerializeField]
        private TMP_Text _expressionText;

        [SerializeField]
        private TMP_Text _timerText;
        [SerializeField]
        private Image _timerImage;

        [SerializeField]
        private TMP_Text _playerCharacterText;

        [SerializeField]
        private TMP_Text _enemyCharacterText;

        [SerializeField]
        private TMP_InputField _answerInputField;

        [Inject]
        private void Construct(Player player, EnemyFactory enemyFactory, Timer timer)
        {
            _player = player;
            _enemyFactory = enemyFactory;
            _timer = timer;
        }

        private void SetExpression(string expression) => _expressionText.text = expression;
        private void SetTimer(float time) => _timerText.text = time.ToString();
        private void SetCharacterInformation(Character_abstraction character, TMP_Text field) => field.text =
                                                                                                 "HP: " + character.CurrentHP + "/" + character.MaxHP + "\n" +
                                                                                                 "DP: " + character.DP + "\n" +
                                                                                                 "Armor: " + character.PermanentShield;
        public void ClearField()
        {
            _answerInputField.text = "";
        }
        public void AddSymbol(string symbol) => _answerInputField.text += symbol;

        private void Awake()
        {
            GameplayExpressionGenerator.ExpressionGeneratedEvent += SetExpression;
        }
        private void Update()
        {
            SetTimer(_timer.TimeRemaining);
            SetCharacterInformation(_player, _playerCharacterText);
            SetCharacterInformation(_enemyFactory.CurrentEnemy, _enemyCharacterText);
            _timerImage.fillAmount = _timer.ProcentFilling;

            if ("0123456789-".Contains(Input.inputString))
                AddSymbol(Input.inputString);
            else if (Input.GetKeyDown(KeyCode.Return))
                ClearField();
            else if(Input.GetKeyDown(KeyCode.Backspace))
                _answerInputField.text = _answerInputField.text.Substring(0, _answerInputField.text.Length - 1);
        }
    }
}