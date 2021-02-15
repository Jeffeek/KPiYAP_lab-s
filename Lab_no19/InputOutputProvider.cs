using System;

namespace Lab_no19
{
    public sealed class InputOutputProvider
    {
	    private Func<string> _input;
	    private Action<string> _output;

	    public InputOutputProvider(Func<string> input, Action<string> output)
	    {
		    _input = input ?? throw new ArgumentNullException(nameof(input));
		    _output = output ?? throw new ArgumentNullException(nameof(output));
	    }

	    public void Out(string text) => _output(text);

	    public string In() => _input();
    }
}
