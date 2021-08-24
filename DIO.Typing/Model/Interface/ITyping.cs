namespace DIO.Typing {
    public interface ITyping {
        int Correct { get; }
        int Cursor { get; }
        int Wrong { get; }
        char CharInput { get; }
        string CaracteresInputWrong { get; }

        int GetTotalKeysInput();
        void SetCaractereWrong(string caractere);
        void SetCorrect();
        void SetCursor();
        void SetWrong();
        void SetCharInput(char charInpu);
        void Reset();
    }
}