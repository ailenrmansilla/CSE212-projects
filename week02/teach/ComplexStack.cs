public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        //it goes thorugh each element in the string line and evaluates if id a ( [ or { and add them to the stack
        // but if it is } ] ) and the stack.count is zero or th last element in a stack is not the corresponding
        // ( [ { then it returns fals
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
// 1. stack = true empty
// 2. stack = false
// 3. stack = false