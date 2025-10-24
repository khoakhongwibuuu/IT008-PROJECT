using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WordleClient.libraries.lowlevel;
using WordleClient.libraries.ingame;


namespace WordleClient.tests
{
    public static class TestGameInstance
    {
        public static void Exec()
        {
            Debug.WriteLine("GameInstance quick tests\n");

            RunTest("Exact match",
                target: "APPLE",
                guess: "APPLE",
                expected: new[] { TriState.MATCH, TriState.MATCH, TriState.MATCH, TriState.MATCH, TriState.MATCH });

            RunTest("One letter not exist",
                target: "APPLE",
                guess: "APPLY",
                expected: new[] { TriState.MATCH, TriState.MATCH, TriState.MATCH, TriState.MATCH, TriState.NOT_EXIST });

            RunTest("Letters in wrong positions (invalid order)",
                target: "APPLE",
                guess: "PALES",
                expected: new[] { TriState.INVALID_ORDER, TriState.INVALID_ORDER, TriState.INVALID_ORDER, TriState.INVALID_ORDER, TriState.NOT_EXIST });

            RunTest("Extra repeated guesses beyond target occurrences",
                target: "BANAL",
                guess: "AAAAA",
                expected: new[] { TriState.NOT_EXIST, TriState.MATCH, TriState.NOT_EXIST, TriState.MATCH, TriState.NOT_EXIST });

            // Test: length mismatch should throw
            Debug.WriteLine("\nTest: Guess length mismatch -> expecting ArgumentException");
            try
            {
                var gi = new GameInstance("SHORT", 6);
                gi.EvaluateGuess("TOO_LONG");
                Debug.WriteLine("  FAIL: no exception thrown for length mismatch");
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine($"  PASS: caught expected exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"  FAIL: unexpected exception type: {ex.GetType().Name} : {ex.Message}");
            }

            Debug.WriteLine("\nAll tests finished.");
        }

        private static void RunTest(string name, string target, string guess, TriState[] expected)
        {
            Debug.WriteLine($"Test: {name}");
            Debug.WriteLine($"  Target: \"{target}\", Guess: \"{guess}\"");

            var gi = new GameInstance(target, maxAttempts: 6);
            StateArray result;
            try
            {
                result = gi.EvaluateGuess(guess);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"  FAIL: EvaluateGuess threw an exception: {ex.GetType().Name} - {ex.Message}");
                return;
            }

            var actual = result.ToArray();

            Debug.WriteLine($"  Result : {FormatState(result)}");
            Debug.WriteLine($"  Expected: {FormatState(expected)}");

            bool pass = expected.Length == actual.Length && expected.SequenceEqual(actual);
            Debug.WriteLine(pass ? "  PASS" : "  FAIL");
            Debug.WriteLine("");
        }

        private static string FormatState(StateArray states)
        {
            return string.Join(" ", states.Select(ToSymbol));
        }

        private static string FormatState(TriState[] states)
        {
            return string.Join(" ", states.Select(ToSymbol));
        }

        private static string ToSymbol(TriState s) => s switch
        {
            TriState.MATCH => "0x538d4e",          // Green / match
            TriState.INVALID_ORDER => "0xb59f3b",  // Yellow / wrong position
            TriState.NOT_EXIST => "0x3a3a3c",      // Dot for not exist
            _ => "?"
        };

        private static TriState[] ToArray(this StateArray states)
        {
            var arr = new TriState[states.Length];
            for (int i = 0; i < states.Length; i++) arr[i] = states.Get(i);
            return arr;
        }
    }

}
