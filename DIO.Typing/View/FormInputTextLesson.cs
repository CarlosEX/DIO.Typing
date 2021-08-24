using System;
using System.Windows.Forms;

namespace DIO.Typing.View {
    public partial class FormInputTextLesson : Form {
        
        private bool _isConfirmed = false;
        private string _textInput = "";
        public bool Confirmed { get => _isConfirmed; }
        public string TextInput { get => _textInput; }
        
        public FormInputTextLesson() {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents() {
            this.buttonConfirmed.Click += new EventHandler(ButtonConfirmed_Click);
            this.buttonCancel.Click += new EventHandler(ButtonCancel_Click);
        }

        private void ButtonConfirmed_Click(object sender, EventArgs e) {

            if (!string.IsNullOrWhiteSpace(textBox1.Text)) {
                _isConfirmed = true;
                _textInput = textBox1.Text;
            }
            this.Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
