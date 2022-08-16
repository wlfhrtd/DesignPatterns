using AppOriginator.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AppOriginator
{
    public class HangmanGame
    {
        private readonly string secretWord;
        private const char maskChar = '_';
        protected const int INITIAL_GUESSES = 5;


        public HangmanGame(string secret = "secret")
        {
            secretWord = secret.ToLowerInvariant();
        }


        public GameResult Result { get; private set; }
        public bool IsOver => Result > GameResult.InProgress;
        public string CurrentMaskedWord
            => new string(secretWord
                .Select(c => PreviousGuesses.Contains(c) ? c : maskChar).ToArray());
        public List<char> PreviousGuesses { get; } = new();
        public int GuessesRemaining
            => INITIAL_GUESSES - PreviousGuesses.Count(c => !CurrentMaskedWord.Contains(c));

        public void Guess(char guessChar)
        {
            if (char.IsWhiteSpace(guessChar))
                throw new InvalidGuessException("Guess cannot be blank.");

            if (!Regex.IsMatch(guessChar.ToString(), "^[a-z]$"))
                throw new InvalidGuessException("Guess must be a letter in [a-z].");

            if (IsOver)
                throw new InvalidGuessException("Game over.");

            if (PreviousGuesses.Any(g => g == guessChar))
                throw new DuplicateGuessException();

            PreviousGuesses.Add(guessChar);

            if (secretWord.IndexOf(guessChar) >= 0)
            {
                if (!CurrentMaskedWord.Contains(maskChar))
                {
                    Result = GameResult.Won;
                }

                return;
            }

            if (GuessesRemaining <= 0)
            {
                Result = GameResult.Lost;
            }
        }
    }

    public enum GameResult
    {
        InProgress,
        Lost,
        Won
    }
}
