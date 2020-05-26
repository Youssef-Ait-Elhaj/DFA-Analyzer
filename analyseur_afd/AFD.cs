using System;
using System.Collections.Generic;
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
        public Dictionary<Dictionary<State, char>, State> transitionMap;

        public AFD() {
        }
        public AFD(State startState, int noStates, string alphabet, Dictionary<Dictionary<State, char>, State> tMap)
        {
            this.alphabet = alphabet;
            this.noStates = noStates;
            this.transitionMap = tMap;
        }
        
        public AFD read(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
                    
                    string[] finalStates = lines[4].Split(' ');
                    Dictionary<Dictionary<State, char>, State> transitionTable = new Dictionary<
                        Dictionary<State, char>, State>();

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
                    State startState =  new State(Int32.Parse(lines[2]), 
                        finalStates.Contains(lines[2]));

                    AFD afd = new AFD(startState, noStates, alphabet, transitionTable);
                    // access map elements
                    // foreach (KeyValuePair<Dictionary<State,char>,State> keyValuePair in transitionTable)
                    // {
                    //     foreach (KeyValuePair<State,char> pair in keyValuePair.Key)
                    //     {
                    //         Console.WriteLine("{0} -> {1} -> {2}", pair.Key.num, pair.Value, keyValuePair.Value.num);
                    //     }
                    // }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return this;
        }
    }
}