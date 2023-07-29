using System;
using TankTutorial.Scripts.ScriptableObject.PlayMarket;
using UnityEngine;
using UnityEngine.UI;

namespace TankTutorial.Scripts.UI.PlayMarket
{
    public class GameExampleController : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Transform _content;
        [SerializeField] private GameObject _gameExample;
        [SerializeField] private GameData _game;

        private void Start()
        {
            SetData();
        }

        public void SetData()
        {
            foreach (var example in _game.GameExamples)
            {
                var image = Instantiate(_gameExample, _content).GetComponent<Image>();
                image.sprite = example;


                var newImageSize = DefineSizeAccordingToObjectHeight(example);
                ResizeImage(image, newImageSize);
            }
        }

        private void ResizeImage(Image image, Vector2 size)
        {
            image.rectTransform.sizeDelta = size;
        }

        private Vector2 DefineSizeAccordingToObjectHeight(Sprite sprite)
        {
            var defaultHeight = sprite.rect.height;
            var defaultWidth = sprite.rect.width;

            var ratio = defaultHeight / defaultWidth;
            
            var newHeight = _rectTransform.rect.height;
            var newWidth = newHeight / ratio;

            return new Vector2(newWidth, newHeight);
        }
    }
}