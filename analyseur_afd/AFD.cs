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
        public State startState { get; set; }
        public int noStates { get; set; }
        public string alphabet { get; set; }
        public Dictionary<Dictionary<int, char>, int> transitionMap;

        public AFD() {
        }
        public AFD(State startState, int noStates, string alphabet, Dictionary<Dictionary<int, char>, int> tMap, 
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
                    
            string[] finalStates = lines[4].Split(' ');
            Dictionary<Dictionary<int, char>, int> transitionTable = new Dictionary<Dictionary<int, char>, int>();

            for (int i = 5; i <= lines.Length -1; i++)
            {
                State state = new State(Int32.Parse(lines[i].Split(' ')[0]), 
                    finalStates.Contains(lines[i].Split(' ')[0]));
                        
                char symbol = Char.Parse(lines[i].Split(' ')[1]);

                State nextState = new State(Int32.Parse(lines[i].Split(' ')[2]), 
                    finalStates.Contains(lines[i].Split(' ')[2]));
                        
                Dictionary<State, char> dict = new Dictionary<State, char>();
                dict.Add(state, symbol);
                transitionTable.Add(dict, nextState);
            }

            // instanciate DFA class
            int noStates = Int32.Parse(lines[0]);
            string alphabet = lines[1];
            State startState =  new State(Int32.Parse(lines[2]), finalStates.Contains(lines[2]));

            afd = new AFD(startState, noStates, alphabet, transitionTable);
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
            if (transitionMap.ContainsKey(dictionary))
        }

        public static void print(AFD M)
        {
            List<int> states = new List<int>();
            foreach (KeyValuePair<Dictionary<State,char>,State> keyValuePair in M.transitionMap)
            {
                foreach (KeyValuePair<State,char> pair in keyValuePair.Key)
                {
                    if (states.IndexOf(pair.Key.num) == -1)
                        states.Add(pair.Key.num);
                    if (states.IndexOf(keyValuePair.Value.num) == -1)
                        states.Add(keyValuePair.Value.num);
                    // Console.WriteLine("{0} -> {1} -> {2}", pair.Key.num, pair.Value, keyValuePair.Value.num);
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
    