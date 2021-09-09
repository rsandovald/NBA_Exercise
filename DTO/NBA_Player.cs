using System;


namespace NBA_Entities
{
    public class NBA_Player
    {
        string _first_name;
        int _h_in;
        float _h_meters;
        string _last_name;

        public NBA_Player(string first_name, int h_in)
        {
            _first_name = first_name;
            _h_in = h_in; 
        }

        public string first_name { get => _first_name; set => _first_name = value; }
        public int h_in { get => _h_in; set => _h_in = value; }
        public float h_meters { get => _h_meters; set => _h_meters = value; }
        public string last_name { get => _last_name; set => _last_name = value; }
    }
}
