namespace Laboratory2
{
    public class HuffmanNode
    {
        private string str;
        private int freq;
        private HuffmanNode left;
        private HuffmanNode right;

        public string NodeString
        {
            get { return str; }
            set { str = value; }
        }
        public int Frequency
        {
            get { return freq; }
            set { freq = value; }
        }
        public HuffmanNode Left
        {
            get { return left; }
            set { left = value; }
        }
        public HuffmanNode Right
        {
            get { return right; }
            set { right = value; }
        }

        public HuffmanNode()
        {
            this.NodeString = "";
            this.Frequency = 0;
            this.Left = null;
            this.Right = null;
        }
    }
}
