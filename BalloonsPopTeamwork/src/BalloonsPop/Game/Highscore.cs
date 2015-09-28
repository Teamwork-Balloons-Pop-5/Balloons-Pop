namespace BalloonsPop.Game
{
    using System;

    public class Highscore : IComparable<Highscore>
    {
        private int value;
        private string name;

        public Highscore(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int CompareTo(Highscore other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
