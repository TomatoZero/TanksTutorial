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
        
        private GameData _game;

        public void SetData(GameData gameData)
        {
            _game = gameData;
            SetData();
        }
        
        private void SetData()
        {
            foreach (var example in _game.GameExamples)
            {
                var instant = Instantiate(_gameExample, _content);
                var mask = instant.GetComponent<Image>();
                var image = GetChildrenImage(instant);
                image.sprite = example;
                
                var newImageSize = DefineSizeAccordingToObjectHeight(example);
                ResizeImage(mask, newImageSize);
            }
        }

        private Image GetChildrenImage(GameObject gameObject)
        {
            return gameObject.transform.GetChild(0).GetComponent<Image>();
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