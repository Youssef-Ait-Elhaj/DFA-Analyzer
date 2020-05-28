using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;

namespace analyseur_afd
{
    public class AFD
    {
        public int startState { get; set; }
        public int noStates { get; set; }
        public string alphabet { get; set; }
        public Dictionary<Dictionary<int, char>, int> transitionMap;

        public AFD() {
        }
        public AFD(int startState, int noStates, string alphabet, Dictionary<Dictionary<int, char>, int> tMap, 
            int[] finalStates)
        {
            this.startState = startState;
            this.alphabet = alphabet;
            this.noStates = noStates;
            this.transitionMap = tMap;
        }
        
        public static AFD read(string fileName)
        {
            AFD afd;
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
                    
            Dictionary<Dictionary<int, char>, int> transitionTable = new Dictionary<Dictionary<int, char>, int>();

            for (int i = 5; i <= lines.Length -1; i++)
            {
                // State state = new State(Int32.Parse(lines[i].Split(' ')[0]), 
                //     finalStates.Contains(lines[i].Split(' ')[0]));
                int state = Int32.Parse(lines[i].Split(' ')[0]);
                        
                char symbol = Char.Parse(lines[i].Split(' ')[1]);

                // State nextState = new State(Int32.Parse(lines[i].Split(' ')[2]), 
                //     finalStates.Contains(lines[i].Split(' ')[2]));
                int nextState = Int32.Parse(lines[i].Split(' ')[2]);
                        
                Dictionary<int, char> dict = new Dictionary<int, char>();
                dict.Add(state, symbol);
                transitionTable.Add(dict, nextState);
            }

            // instanciate DFA class
            int noStates = Int32.Parse(lines[0]);
            string alphabet = lines[1];
            // State startState =  new State(Int32.Parse(lines[2]), finalStates.Contains(lines[2]));
            int startState = Int32.Parse(lines[2]);    // parse start state from file
            string[] finalStatesAsString = lines[4].Split(' ');
            int[] finalStates = Array.ConvertAll(finalStatesAsString, int.Parse);
            Console.WriteLine("num of final states {0}", finalStates.Length);

            afd = new AFD(startState, noStates, alphabet, transitionTable, finalStates);
            return afd;
            
                    // access map elements
                    // foreach (KeyValuePair<Dictionary<State,char>,State> keyValuePair in transitionTable)
                    // {
                    //     foreach (KeyValuePair<State,char> pair in keyValuePair.Key)
                    //     {
                    //         Console.WriteLine("{0} -> {1} -> {2}", pair.Key.num, pair.Value, keyValuePair.Value.num);
                    //     }
                    // }
        }

        public int δ(int stateNum, char symbol)
        {
            // initialize dict
            Dictionary<int, char> dictionary = new Dictionary<int, char> {{stateNum, symbol}};
            // if (transitionMap.ContainsKey(dictionary))
            return 0;
        }

        public static void print(AFD M)
        {
            List<int> states = new List<int>();
            foreach (KeyValuePair<Dictionary<int,char>,int> keyValuePair in M.transitionMap)
            {
                foreach (KeyValuePair<int,char> pair in keyValuePair.Key)
                {
                    if (states.IndexOf(pair.Key) == -1)
                        states.Add(pair.Key);
                    if (states.IndexOf(keyValuePair.Value) == -1)
                        states.Add(keyValuePair.Value);
                    Console.WriteLine("{0} -> {1} -> {2}", pair.Key, pair.Value, keyValuePair.Value);
                }
            }

            // print E
            int counter = 1;
            Console.Write("E = {");
            foreach (int state in states)
            {
                Console.Write(state);
                if (counter < states.Count)
                {
                    Console.Write(", ");
                    counter++;
                }
            }
            Console.Write("} ");

            // print alphabet A
            counter = 1;
            char[] alphabet = M.alphabet.ToCharArray();
            Console.Write("A = {");
            foreach (char c in alphabet)
            {
                Console.Write(c);
                if (counter < alphabet.Length)
                {
                    Console.Write(", ");
                    counter++;
                }
            }
            Console.WriteLine("}");
            
            // print transitions
            
        }
    }
}
    