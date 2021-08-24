
namespace DIO.Typing {
    public class Typing : ITyping {

        private int _wrong;
        private int _correct;
        private int _cursor;
        private char _charInput;
        private string _caractereWrong = "";

        public int Wrong => _wrong;
        public int Correct => _correct;
        public int Cursor => _cursor;
        public char CharInput => _charInput;

        public string CaracteresInputWrong => _caractereWrong;

        public int GetTotalKeysInput() {
            return _wrong + _correct;
        }
        public void SetWrong() {
            _wrong += 1;
        }
        public void SetCorrect() {
            _correct += 1;
        }
        public void SetCursor() {
            _cursor += 1;
        }
        public void SetCharInput(char charInput) {
            _charInput = charInput;
        }
        public void SetCaractereWrong(string caractere) {
            _caractereWrong += caractere;
        }
        public void Reset() {
            _wrong = 0;
            _correct = 0;
            _cursor = 0;
            _caractereWrong = string.Empty;
            _charInput = ' ';
        }
    }
}
