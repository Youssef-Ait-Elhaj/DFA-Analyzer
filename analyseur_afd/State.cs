namespace analyseur_afd
{
    public class State
    {
        public int num { get; set; }
        public bool final { get; set; }


        public State(int num, bool final)
        {
            this.num = num;
            this.final = final;
        }
    }
}