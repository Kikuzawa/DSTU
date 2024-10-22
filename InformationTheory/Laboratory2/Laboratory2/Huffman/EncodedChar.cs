namespace Laboratory2
{
    public class EncodedChar
    {
        private string character;
        private string binary;

        public string Character
        {
            get { return character; }
            set { character = value; }
        }
        public string Binary
        {
            get { return binary; }
            set { binary = value; }
        }

        public EncodedChar()
        {
            this.Character = "";
            this.Binary = "";
        }
    }
}
