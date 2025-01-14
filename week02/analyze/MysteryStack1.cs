public static class MysteryStack1 {
    public static string Run(string text) {
        // Stack: LIFO
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
        // if text = racecar then result = racecar
        // if text = stressed then result = desserts
        // if text = a nut for a jar of tuna then result = tuna of jat a for nut a
    }
}