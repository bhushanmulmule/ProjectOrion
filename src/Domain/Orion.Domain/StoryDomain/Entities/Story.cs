using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Orion.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Domain.StoryDomain.Entities
{
    public class Story : Entity
    {
        public string Text { get; private set; }
        public string[] Images { get; private set; }

        public Story(string text, string[] images)
        {
            Text = DoesTextContainsBadWords(text) ? throw new BusinessRuleValidationException(ErrorMessages.DetectedBadWordsInText) : text;
            Images = images;
        }

        public void UpdateText(string text)
        {
            Text = DoesTextContainsBadWords(text) ? throw new BusinessRuleValidationException(ErrorMessages.DetectedBadWordsInText) : text;
        }

        private bool DoesTextContainsBadWords(string text)
        {
            //ToDO: use some third party api to detect bad words in text
            var badWords = new string[] { "badword1", "badword2", "badword3" };

            var textToLower = text.ToLower();

            foreach (var badWord in badWords)
            {
                if (textToLower.Contains(badWord))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
