namespace LinkedListAndStack
{
    class Balanced
    {
        private Dictionary<char, char> Pairs = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}'}
        };
        public bool IsBalanced(string input)
        {

            MyStack<char> stack = new MyStack<char>();

            foreach (char c in input)
            {
                if (Pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (Pairs.ContainsValue(c))
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if (Pairs[top] != c) return false;
                }
            }
            return stack.Count == 0;
        }
    }
}