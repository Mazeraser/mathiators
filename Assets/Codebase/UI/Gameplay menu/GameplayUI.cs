using Assets.Codebase.Infrastructure.Fabrics;
using Assets.Codebase.Mechanics.ExpressionGenerator;
using Assets.Codebase.Mechanics.Character;
using Assets.Codebase.Mechanics.Timer;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using Assets.Codebase.Mechanics.EnemyScore;


namespace Assets.Codebase.UI.GameplayMenu
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private Sprite hp_full;
        [SerializeField]
        private Sprite hp_empty;

        [SerializeField]
        private Sprite ps;

        [SerializeField]
        private Sprite dp;

        private Player _player;
        private EnemyFactory _enemyFactory;
        private Timer _timer;
        private EnemyScore _score;

        [SerializeField]
        private TMP_Text _expressionText;

        [SerializeField]
        private TMP_Text _timerText;
        [SerializeField]
        private Image _timerImage;

        [SerializeField]
        private ContainerStorage _playerCharacteristicsContainer;

        [SerializeField]
        private ContainerStorage _enemyCharacteristicsContainer;

        [SerializeField]
        private TMP_InputField _answerInputField;

        [SerializeField]
        private TMP_Text _scoreField;

        [Inject]
        private void Construct(Player player, EnemyFactory enemyFactory, Timer timer, EnemyScore score)
        {
            _player = player;
            _timer = timer;
            _enemyFactory = enemyFactory;
            _score = score;
        }

        private void SetEnemy(Character_abstraction character, string team)
        {
            if (team == "Player")
            {
                SetCharacterInformation(_player, _playerCharacteristicsContainer);
            }
            else
            {
                SetCharacterInformation(_enemyFactory.CurrentEnemy, _enemyCharacteristicsContainer);
            }
        }

        private void SetExpression(string expression) => _expressionText.text = expression;
        private void SetTimer(float time) => _timerText.text = time.ToString();
        private void SetCharacterInformation(Character_abstraction character, ContainerStorage container)
        {
            ClearTransform(container.HP.transform);
            FillCharacteristicField(character.MaxHP, hp_full, container.HP.transform);

            ClearTransform(container.DP.transform);
            FillCharacteristicField(character.DP, dp, container.DP.transform);

            ClearTransform(container.PS.transform);
            FillCharacteristicField(character.PermanentShield, ps, container.PS.transform);
        }
        private void SetScore(int score) => _scoreField.text = "Killed enemy score: " + score.ToString();

        private void ClearTransform(Transform obj)
        {
            for (int i = 0; i < obj.childCount; i++)
                Destroy(obj.GetChild(i).gameObject);
        }

        private void FillCharacteristicField(int count, Sprite characteristic_sprite, Transform parent)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject heart = new GameObject();
                heart.transform.SetParent(parent);
                heart.AddComponent<Image>();
                heart.GetComponent<Image>().sprite = characteristic_sprite;
            }
        }
        private void UpdateCharacteristicField(Character_abstraction character, ContainerStorage container)
        {
            int characteristic_point_count = container.HP.transform.childCount;
            for(int i=0;i<characteristic_point_count;i++)
            {
                container.HP.transform.GetChild(i).GetComponent<Image>().sprite =
                                                                        character.CurrentHP > i ? hp_full : hp_empty;
            }
        }

        public void ClearField()
        {
            _answerInputField.text = "";
        }

        public void AddSymbol(string symbol) => _answerInputField.text += symbol;

        private void Awake()
        {
            GameplayExpressionGenerator.ExpressionGeneratedEvent += SetExpression;
            Character_abstraction.CharacteristicsUpdatedEvent += SetEnemy;
        }
        private void OnDestroy()
        {
            GameplayExpressionGenerator.ExpressionGeneratedEvent -= SetExpression;
            Character_abstraction.CharacteristicsUpdatedEvent -= SetEnemy;
        }

        private void Update()
        {
            SetTimer(_timer.TimeRemaining);
            SetScore(_score.Score);

            UpdateCharacteristicField(_player, _playerCharacteristicsContainer);
            UpdateCharacteristicField(_enemyFactory.CurrentEnemy, _enemyCharacteristicsContainer);

            if ("0123456789-".Contains(Input.inputString))
                AddSymbol(Input.inputString);
            else if (Input.GetKeyDown(KeyCode.Return))
                ClearField();
            else if(Input.GetKeyDown(KeyCode.Backspace))
                _answerInputField.text = _answerInputField.text.Substring(0, _answerInputField.text.Length - 1);
        }
    }
}